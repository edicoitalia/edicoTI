/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2025 Alberto Zanella - EdicoItalia.it
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

		public static bool resetSettings()
		{
			bool retval = false;
			string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			dataDir = Path.Combine(dataDir, "Apps", "2.0", "Data");
			if (!Directory.Exists(dataDir)) return false;
			string[] configFiles = Directory.GetFiles(dataDir, "user.config", SearchOption.AllDirectories);
			foreach (var file in configFiles)
			{
				retval = retval || deleteUserConfig(file);
			}
			return retval;
		}

		private static bool deleteUserConfig(string xmlFile)
		{
			XDocument doc = XDocument.Load(xmlFile);
			XElement elem = doc.Element("configuration");
			if (elem == null) return false;
			elem = elem.Element("userSettings");
			if (elem == null) return false;
			elem = elem.Element("Edico.Properties.Settings");
			if (elem == null) return false;
			File.Delete(xmlFile);
			return true;
		}

		public static void crawlAndChange(string openFile)
		{
			string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			dataDir = Path.Combine(dataDir, "Apps", "2.0", "Data");
			if (!Directory.Exists(dataDir)) return;
			string[] keyboardFiles = Directory.GetFiles(dataDir, "ShortCutKeys.xml", SearchOption.AllDirectories);
			string[] configFiles = Directory.GetFiles(dataDir, "user.config", SearchOption.AllDirectories);
			foreach(var file in configFiles)
			{
				changeUserConfig(file);
				if(openFile != null)
				{
					setFileToOpen(file, openFile);
				}
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

		private static void setFileToOpen(string config, string openFilePath)
		{
			XDocument doc = XDocument.Load(config);
			XElement elem = doc.Element("configuration");
			if (elem == null) return;
			elem = elem.Element("userSettings");
			if (elem == null) return;
			elem = elem.Element("Edico.Properties.Settings");
			if (elem == null) return;
			string filesOpenXMLPath = elem.Elements().Where(e =>
				(e.Attribute("name").Value == "xmlData_path")).First().Value;
			if (filesOpenXMLPath == null) return;
			filesOpenXMLPath = Path.Combine(filesOpenXMLPath, "Model", "XMLs", "filesOpen.xml");
			if (!File.Exists(filesOpenXMLPath)) return;
			doc = XDocument.Load(filesOpenXMLPath);
			elem = doc.Element("Files");
			bool isPresent = false;
			int maxPos = 0;
			foreach(var xFile in elem.Elements())
			{
				try
				{
					string xPosition = xFile.Attribute("Position").Value;
					if (xPosition != null)
					{
						int iPosition = Convert.ToInt32(xPosition);
						if (iPosition >= maxPos) maxPos = iPosition + 1;
					}
					string xCurrent = xFile.Attribute("Current").Value;
					if ((xCurrent != null) && (xCurrent == "1"))
					{
						xFile.Attribute("Current").Value = "0";
					}
					string xPath = xFile.Attribute("Path").Value;
					if ((xPath != null) && (xPath.ToLower() == openFilePath.ToLower()))
					{
						xFile.Attribute("Current").Value = "1";
						isPresent = true;
					}
				} catch(Exception e) { } //skip file
			}
			if (!isPresent)
			{
				XElement newFile = new XElement("File");
				newFile.SetAttributeValue("Path", openFilePath);
				newFile.SetAttributeValue("Position", maxPos);
				newFile.SetAttributeValue("Current", "1");
				elem.Add(newFile);
			}
			doc.Save(filesOpenXMLPath);
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
