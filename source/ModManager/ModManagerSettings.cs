using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Civ6Mod;
using System.Collections;
using System.Xml;

namespace ModManager
{
    public static class ModSetOptions
    {
        public static ModMergeOptions Merge { get { return Mod.MergeOptions; } set { Mod.MergeOptions = value; } }
        public static bool HideChildren = false;

        public static void Reset()
        {
            Merge = new ModMergeOptions();
            HideChildren = false;
        }

        public static void Save() { ModManagerSettings.Save(); }
        public static void Load() { ModManagerSettings.Load(); }

        public static void SaveUnderNode(XmlNode n)
        {
            XmlElement e = n.AppendNewElement("ModSet");
            e.SetAttributeBool("HideChildren", HideChildren);
            e.SetAttributeInt("Shell2Way", (int)Merge.Shell2Way);
            e.SetAttributeInt("Shell3Way", (int)Merge.Shell3Way);
            e.SetAttribute("Shell2WayCmdLine", Merge.ShellCmd2Way);
            e.SetAttribute("Shell3WayCmdLine", Merge.ShellCmd3Way);

        }

        public static void LoadUnderNode(XmlNode n)
        {
            XmlElement e = n.GetFirstChildElement("ModSet");
            if (e != null)
            {
                HideChildren = e.GetAttributeBool("HideChildren", HideChildren);
                Merge.Shell2Way = (ModMergeOptions.ShellWhen)e.GetAttributeInt("Shell2Way", (int)Merge.Shell2Way, (int)ModMergeOptions.ShellWhen.Max2Way);
                Merge.Shell3Way = (ModMergeOptions.ShellWhen)e.GetAttributeInt("Shell3Way", (int)Merge.Shell2Way, (int)ModMergeOptions.ShellWhen.Max3Way);
                Merge.ShellCmd2Way = e.GetAttributeString("Shell2WayCmdLine", Merge.ShellCmd2Way);
                Merge.ShellCmd3Way = e.GetAttributeString("Shell3WayCmdLine", Merge.ShellCmd3Way);
            }
        }
    }

    public static class ModManagerSettings
    {
        public static string Civ6Path = "";

        public static string FileName
        {
            get
            {
                string strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"My Games\Sid Meier's Civilization VI");
                Directory.CreateDirectory(strFileName);
                return Path.Combine(strFileName, "ModManagerSettings.xml");
            }
        }

        public static void Load()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    string strText = File.ReadAllText(FileName);
                    XmlDocument Doc = new XmlDocument();
                    Doc.LoadXml(strText);

                    if (Doc.DocumentElement != null)
                    {
                        Civ6Path = Doc.DocumentElement.GetAttributeString("Civ6Path");

                        ModSetOptions.LoadUnderNode(Doc.DocumentElement);
                    }
                }
            }
            catch
            {
            }
        }

        public static void Save()
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                XmlElement eRoot = Doc.AppendNewElement("ModManagerSettings", null , "Version", "1", "Civ6Path", Civ6Path);
                ModSetOptions.SaveUnderNode(eRoot);
                string strXml = Doc.GetFormattedText(true);
                File.WriteAllText(FileName, strXml);
            }
            catch
            { 
            }
        }

        static ModManagerSettings()
        {
            Load();
        }
    }
}
