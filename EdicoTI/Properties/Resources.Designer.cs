﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdicoTI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EdicoTI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UTILITY DI EDICO
        ///Da questa finestra di dialogo sarà possibile lanciare alcune funzioni di servizio di EDICO. Occorre prestare particolare attenzione poiché le impostazioni che si effettuano da questa finestra di dialogo non possono essere annullate.
        ///Selezionare un&apos;opzione fra i pulsanti seguenti. E&apos; possibile spostarsi fra i pulsanti premendo Tab e selezionare un pulsante premendo Invio.
        ///
        ///Edico Targato Italia è un software con licenza GNU General Public License. Per tutti i dettagli consultare il sorgen [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string dlgUtility {
            get {
                return ResourceManager.GetString("dlgUtility", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Per il corretto funzionamento di JAWS con EDICO è necessario copiare alcuni file nella cartella di di installazione di JAWS. Per fare questo sono necessari i permessi di amministratore. Si desidera procedere?
        ///- Scegliendo Sì verranno richiesti i privilegi di amministratore e si procederà alla copia dei file
        ///- Scegliendo No verrà avviato EDICO senza copiare i file. L&apos;uso con JAWS potrebbe risultare problematico..
        /// </summary>
        internal static string jfwAdminNeeded {
            get {
                return ResourceManager.GetString("jfwAdminNeeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Installazione dei file necessari a JAWS completata.
        ///Lanciare nuovamente EDICO per completare l&apos;operazione..
        /// </summary>
        internal static string jfwCompleted {
            get {
                return ResourceManager.GetString("jfwCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attenzione: si sta eseguendo una versione di JAWS che non è più supportata. Aggiornare a uno screen reader più recente per usare al meglio EDICO con il supporto in italiano..
        /// </summary>
        internal static string jfwOld {
            get {
                return ResourceManager.GetString("jfwOld", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Si desidera ricevere un avviso relativo alla configurazione di JAWS anche al prossimo avvio di EDICO?.
        /// </summary>
        internal static string jfwSkip {
            get {
                return ResourceManager.GetString("jfwSkip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;/Modes&gt;.
        /// </summary>
        internal static string jfwXMLFrom {
            get {
                return ResourceManager.GetString("jfwXMLFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to     &lt;Mode   Id=&quot;999&quot;
        ///                Language=&quot;ita&quot;
        ///                DisplayName=&quot;Italian EDICO&quot;
        ///                Table=&quot;edico-ita.utb&quot;
        ///                Symbols=&quot;&quot; 
        ///                AllowInput=&quot;1&quot; /&gt;
        ///    &lt;/Modes&gt;.
        /// </summary>
        internal static string jfwXMLTo {
            get {
                return ResourceManager.GetString("jfwXMLTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Installare l&apos;addon per NVDA ora?.
        /// </summary>
        internal static string nvdaInternet {
            get {
                return ResourceManager.GetString("nvdaInternet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non è possibile collegarsi al server per installare l&apos;addon in modo automatico. Procedere manualmente a scaricare e installare l&apos;addon di NVDA per EDICO..
        /// </summary>
        internal static string nvdaNoInternet {
            get {
                return ResourceManager.GetString("nvdaNoInternet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Si desidera ricevere un avviso relativo all&apos;addon di NVDA anche al prossimo avvio di EDICO?.
        /// </summary>
        internal static string nvdaSkip {
            get {
                return ResourceManager.GetString("nvdaSkip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E&apos; stato rilevato che si sta usando lo screen reader NVDA. Per ottenere un pieno supporto a EDICO si consiglia di installare una versione aggiornata dell&apos;addon di NVDA prima di eseguire EDICO.
        ///.
        /// </summary>
        internal static string nvdaSuggestion {
            get {
                return ResourceManager.GetString("nvdaSuggestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Si desidera verificare la disponibilità di nuovi aggiornamenti di EDICO Targato Italia le prossime volte che il programma viene avviato? 
        ///Se si risponde No, EDICO Targato Italia non verificherà più su internet la presenza di aggiornamenti.
        /// </summary>
        internal static string updateReminder {
            get {
                return ResourceManager.GetString("updateReminder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to È disponibile su internet una versione aggiornata di EDICO Targato Italia. Le nuove versioni offrono un supporto ancora migliore al software EDICO e se ne consiglia l’installazione. 
        ///Si desidera scaricare e installare il nuovo Edico Targato Italia?.
        /// </summary>
        internal static string updateText {
            get {
                return ResourceManager.GetString("updateText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Benvenuti in EDICO Targato Italia!
        ///
        ///Lo scopo di questo progetto è di offrire un modo semplice e veloce per installare e configurare al meglio il software EDICO nel vostro computer. 
        ///
        ///EDICO è un editor scientifico adatto a persone non vedenti e ipovedenti utilizzabile con il braille, la sintesi vocale e l&apos;ingrandimento dei caratteri. EDICO è stato ideato e realizzato da ONCE-Spagna.
        ///
        ///Il progetto è stato realizzato nello spirito del software libero in modo gratuito e slegato da enti, associazioni o azie [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string welcomeText {
            get {
                return ResourceManager.GetString("welcomeText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Benvenuti.
        /// </summary>
        internal static string welcomeTitle {
            get {
                return ResourceManager.GetString("welcomeTitle", resourceCulture);
            }
        }
    }
}
