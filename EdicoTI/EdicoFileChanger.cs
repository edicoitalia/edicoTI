/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace EdicoTI
{
	internal class EdicoFileChanger
	{

		public static void crawlAndChange()
		{
			string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			dataDir = Path.Combine(dataDir, "Apps", "2.0", "Data");
			string[] keyboardFiles = Directory.GetFiles(dataDir, "ShortCutKeys.xml", SearchOption.AllDirectories);
			string[] configFiles = Directory.GetFiles(dataDir, "user.config", SearchOption.AllDirectories);
			foreach(var file in configFiles)
			{
				changeUserConfig(file);
			}
			foreach (var file in keyboardFiles)
			{
				changeShortcutXML(file);
			}
		}

		private static void changeUserConfig(string xmlFile)
		{
			XDocument doc = XDocument.Load(xmlFile);
			XElement elem = doc.Element("configuration");
			if(elem == null) return;
			elem = elem.Element("userSettings");
			if (elem == null) return;
			elem = elem.Element("Edico.Properties.Settings");
			if (elem == null) return;
			bool isPresent = elem.Elements().Where(e =>
				(e.Attribute("name").Value == "viewBraille")).Any();
			if (isPresent) return;
			XElement setting = new XElement("setting");
			setting.SetAttributeValue("name", "viewBraille");
			setting.SetAttributeValue("serializeAs", "String");
			XElement value = new XElement("value");
			value.SetValue("False");
			setting.Add(value);
			elem.Add(setting);
			doc.Save(xmlFile);
		}

		private static void changeShortcutXML(string xmlFile)
		{
			XDocument doc = XDocument.Load(xmlFile);
			addKeyIfNotExists(doc, "458938", "\u0153", "Ctrl+Alt+Shift+Oem1");
			addKeyIfNotExists(doc, "458939", "\u00F5", "Ctrl+Alt+Shift+Oemplus");
			addKeyIfNotExists(doc, "65757", "\u005E", "Shift+Oem6");
			addKeyIfNotExists(doc, "196829", "\u00A7", "Ctrl+Shift+Oem6");
			doc.Save(xmlFile);
		}
		private static void addKeyIfNotExists(XDocument doc, string id, string hex, string text)
		{
			var elem = doc.Element("Keys");
			bool isPresent = elem.Elements().Where(e =>
				(e.Attribute("id").Value == id) &&
				(e.Attribute("hex").Value == hex) &&
				(e.Attribute("text").Value == text)).Any();
			if (isPresent) return;
			var conflicts = elem.Elements().Where(e =>
				(e.Attribute("hex").Value == hex) ||
				(e.Attribute("text").Value == text)).ToList();
			foreach(var c in conflicts)
			{
				c.Remove();
			}
			XElement key = new XElement("Key");
			key.SetAttributeValue("id", id);
			key.SetAttributeValue("hex",hex);
			key.SetAttributeValue("text", text);
			elem.Add(key);
		}
	}
}
