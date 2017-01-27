using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Specialized;
using SteamGame;
using System.Security.Cryptography;
using SynchrotronNet;
using System.Diagnostics;
using System.Threading;

namespace Civ6Mod
{
    public interface IKeyed { string Key { get; } }

    // Hash table that preserves insertion order
    public class KeyedList<T> : Collection<T> where T : IKeyed
    {
        protected Dictionary<string, T> Table = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);

        public KeyedList() : this(new List<T>()) { }
        public KeyedList(List<T> lst) : base(lst) { }

        public Dictionary<string, T> GetTable() { return Table; }

        public void Sort(Comparison<T> comparison) { ((List<T>)Items).Sort(comparison); }

        protected override void ClearItems() { base.ClearItems(); Table.Clear(); }

        protected override void InsertItem(int index, T item) { if (!ContainsKey(item.Key)) { base.InsertItem(index, item); Table[item.Key] = item; } }

        protected override void RemoveItem(int index) { Table.Remove((this[index] as IKeyed).Key); base.RemoveItem(index); }

        protected override void SetItem(int index, T item)
        {
            if (index < Count && this[index] != null) Table.Remove((this[index] as IKeyed).Key); Table[item.Key] = item;

            base.SetItem(index, item);
        }

        public int IndexOfKey(string strKey)
        {
            if (ContainsKey(strKey))
                for (int i = 0; i < Count; i++)
                    if (this[i].Key.Equals(strKey, StringComparison.OrdinalIgnoreCase))
                        return i;
            return -1;
        }

        public T this[string index]
        {
            get
            {
                return (ContainsKey(index)) ? Table[index] : default(T);
            }
            set
            {
                if (ContainsKey(index))
                {
                    int i = IndexOfKey(index);
                    if (i > -1)
                        SetItem(i, value);
                }
                else
                    Add(value);
            }
        }

        public bool TryGetItem(string strKey, out T objValue)
        {
            if (ContainsKey(strKey))
            {
                objValue = Table[strKey];
                return true;
            }
            else
            {
                objValue = default(T);
                return false;
            }
        }

        public bool ContainsKey(string strKey) { return (Table.ContainsKey(strKey)); }

        public new T Add(T item)
        {
            if (ContainsKey(item.Key))
                this[item.Key] = item;
            else
                base.Add(item);

            return item;
        }
    }

    public class KeyedStringList : Collection<KeyValuePair<string, string>>
    {
        protected Dictionary<string, string> Table = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public KeyedStringList() : this(new List<KeyValuePair<string, string>>()) { }
        public KeyedStringList(List<KeyValuePair<string, string>> lst) : base(lst) { }

        public Dictionary<string, string> GetTable() { return Table; }

        protected override void ClearItems() { base.ClearItems(); Table.Clear(); }

        protected override void InsertItem(int index, KeyValuePair<string, string> item) { if (!ContainsKey(item.Key)) { base.InsertItem(index, item); Table[item.Key] = item.Value; } }

        protected override void RemoveItem(int index) { Table.Remove(this[index].Key); base.RemoveItem(index); }

        protected override void SetItem(int index, KeyValuePair<string, string> item)
        {
            if (index < Count) Table.Remove(this[index].Key); Table[item.Key] = item.Value;

            base.SetItem(index, item);
        }

        public int IndexOfKey(string strKey)
        {
            if (ContainsKey(strKey))
                for (int i = 0; i < Count; i++)
                    if (this[i].Key.Equals(strKey, StringComparison.OrdinalIgnoreCase))
                        return i;
            return -1;
        }

        public string this[string index]
        {
            get
            {
                return (ContainsKey(index)) ? Table[index] : "";
            }
            set
            {
                if (ContainsKey(index))
                {
                    int i = IndexOfKey(index);
                    if (i > -1)
                        SetItem(i, new KeyValuePair<string, string>(index, value));
                }
                else
                    Add(index, value);
            }
        }

        public bool TryGetItem(string strKey, out string strValue)
        {
            if (ContainsKey(strKey))
            {
                strValue = Table[strKey];
                return true;
            }
            else
            {
                strValue = "";
                return false;
            }
        }

        public bool ContainsKey(string strKey) { return (Table.ContainsKey(strKey)); }

        public void Add(string strKey, string strValue)
        {
            if (ContainsKey(strKey))
                this[strKey] = strValue;
            else
                Add(new KeyValuePair<string, string>(strKey, strValue));
        }

        public void Remove(string strKey)
        {
            int i = IndexOfKey(strKey);
            if (i > -1)
                RemoveAt(i);
        }
    }

    public class HashedStringList : Collection<string>
    {
        protected HashSet<string> Table = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        
        public HashedStringList() : this(new List<string>()) { }
        public HashedStringList(List<string> lst) : base(lst) { }

        public HashSet<string> GetTable() { return Table; }

        protected override void ClearItems() { base.ClearItems(); Table.Clear(); }

        protected override void InsertItem(int index, string item) { if (!ContainsKey(item)) { base.InsertItem(index, item); Table.Add(item); } }

        protected override void RemoveItem(int index) { Table.Remove(this[index]); base.RemoveItem(index); }

        protected override void SetItem(int index, string item)
        {
            if (index < Count) Table.Remove(this[index]); Table.Add(item);

            base.SetItem(index, item);
        }

        public bool ContainsKey(string strKey) { return (Table.Contains(strKey)); }

        public new void Add(string strKey)
        {
            if (!ContainsKey(strKey))
                base.Add(strKey);
        }

        public void UnionWith(HashedStringList u)
        {
            foreach (string strAdd in u)
                Add(strAdd);
        }
    }

    public static class ModFileUtils
    {
        public const char LinuxSeparator = '/';
        public static readonly char OSSeparator = Path.DirectorySeparatorChar;
        public static bool HasAltSeparator = LinuxSeparator != OSSeparator;

        private static char AltSeparater(char cMainSeparater) { return (cMainSeparater == LinuxSeparator) ? OSSeparator : LinuxSeparator; }

        public static bool IsSeparator(char cChar) { return (cChar == LinuxSeparator || cChar == OSSeparator); }

        public static List<string> FindFiles(string strPath, SearchOption eSearchOption, params string[] astrExtensions)
        {
            if (!Directory.Exists(strPath))
                return new List<string>();
            else if (astrExtensions.Length == 0)
                return Directory.EnumerateFiles(strPath, "*.*", eSearchOption).ToList();
            else if (astrExtensions.Length == 1)
                return Directory.EnumerateFiles(strPath, astrExtensions[0], eSearchOption).ToList();
            else
                return Directory.EnumerateFiles(strPath, "*.*", eSearchOption)
                    .Where(file => astrExtensions.Any(file.ToLower().EndsWith)).ToList();
        }

        public static string StandardizePath(string strPath, char cPathSeparator = LinuxSeparator)
        {
            return (!HasAltSeparator) ? strPath : (cPathSeparator == '/') ? strPath.Replace('\\', '/') : (cPathSeparator == '\\') ? strPath.Replace('/', '\\') : strPath.Replace('\\', cPathSeparator).Replace('/', cPathSeparator);
        }

        public static List<string> StandardizePaths(List<string> lstPaths, char cPathSeparator = LinuxSeparator)
        {
            if (!HasAltSeparator)
                return lstPaths;
            else
            {
                List<string> strRet = new List<string>();
                foreach (string strPath in lstPaths)
                    strRet.Add(StandardizePath(strPath, cPathSeparator));
                return strRet;
            }
        }

        public static string ExcludeTrailingSeparator(string strPath)
        {
            int i;
            for (i = strPath.Length; i > 0 && IsSeparator(strPath[i - 1]); i--) ;
            return (i < strPath.Length) ? strPath.Substring(0, i) : strPath;
        }

        public static string ExcludeLeadingSeparator(string strPath)
        {
            int i;
            for (i = 0; i < strPath.Length && IsSeparator(strPath[i]); i++) ;
            return (i == 0) ? strPath : (i == strPath.Length) ? "" : strPath.Substring(i);
        }

        public static string IncludeTrailingSeparator(string strPath, char cPathSeparator = LinuxSeparator)
        {
            int i = strPath.Length;
            return (i == 0 || strPath[i] == cPathSeparator) ? strPath : ExcludeTrailingSeparator(strPath) + cPathSeparator;
        }

        public static string IncludeLeadingSeparator(string strPath, char cPathSeparator = LinuxSeparator)
        {
            return (strPath.Length == 0 || strPath[0] == cPathSeparator) ? strPath : cPathSeparator + ExcludeLeadingSeparator(strPath);
        }

        public static string GetRelativePath(string strBase, string strFull, char cPathSeparator = LinuxSeparator)
        {
            strBase = ExcludeLeadingSeparator(ExcludeTrailingSeparator(StandardizePath(strBase, cPathSeparator)));
            strFull = ExcludeLeadingSeparator(ExcludeTrailingSeparator(StandardizePath(strFull, cPathSeparator)));

            int i = strBase.Length;
            if (strFull.StartsWith(strBase, StringComparison.OrdinalIgnoreCase))
            {
                if (strFull.Length == i)
                    return "";
                else if (IsSeparator(strFull[i]))
                    return strFull.Substring(i + 1);
            }
            return strFull;
        }

        public static string CombineLinux(params string[] astrPaths)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string strPath in astrPaths)
            {
                if (sb.Length > 0)
                    sb.Append(IncludeLeadingSeparator(ExcludeTrailingSeparator(strPath)));
                else
                    sb.Append(ExcludeTrailingSeparator(strPath));
            }

            return sb.ToString();
        }

        public static string GetMD5Checksum(string strFileName)
        {
            if (!File.Exists(strFileName))
                return "";

            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(File.ReadAllBytes(strFileName));
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("x2"));

                return sb.ToString();
            }
        }

        public static void CopyFileAndForceDirectories(string strSource, string strDest)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(strDest));
            File.Copy(strSource, strDest, true);
        }

        public static DateTime GetModifiedDT(string strFileName)
        {
            if (File.Exists(strFileName))
                return File.GetLastWriteTime(strFileName);
            else
                return default(DateTime);
        }

        public static DateTime FiraxisDTToDT(long dt)
        {
            return DateTime.FromFileTime(dt);
        }

        public static long DTToFiraxisDT(DateTime dt)
        {
            return dt.ToFileTime();
        }

        public static void SplitParmsFromExe(string strCmd, out string strFile, out string strParms)
        {
            int i = 0;
            strCmd = strCmd.Trim();
            strFile = strCmd;
            strParms = "";
            if (strCmd.Length > 0)
            {
                if (strCmd[0] == '"')
                    i = strCmd.IndexOf('"', 1);

                if (i >= 0)
                    i = strCmd.IndexOf(' ', i);

                if (i >= 0)
                {
                    strFile = strCmd.Substring(0, i);
                    strParms = strCmd.Substring(i + 1).Trim();
                }
            }
        }

        public static void DeleteDirectory(string strTarget)
        {          
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Directory.Delete(strTarget, true);
                }
                catch (DirectoryNotFoundException)
                {
                    return;
                }
                catch (IOException)
                {
                    if (i < 9)
                    {
                        Thread.Sleep(50);
                        continue;
                    }
                    else
                        throw;
                }
                return;
            }
        }

        public static void CopyDirectory(string strSource, string strDest)
        {
            strSource = ExcludeLeadingSeparator(strSource);
            int iSourceLength = strSource.Length + 1;

            foreach (string strPath in Directory.GetDirectories(strSource, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(Path.Combine(strDest, strPath.Substring(iSourceLength)));
            }

            foreach (string strFile in Directory.GetFiles(strSource, "*", SearchOption.AllDirectories))
                File.Copy(strFile, Path.Combine(strDest, strFile.Substring(iSourceLength)), true);
        }

        public static void CopyDirectory(string strSourceParent, string strDestParent, string strDirectory)
        {
            string strSource = Path.Combine(strSourceParent, strDirectory);
            if (Directory.Exists(strSource))
            {
                string strDest = Path.Combine(strDestParent, strDirectory);
                Directory.CreateDirectory(strDest);
                CopyDirectory(strSource, strDest);
            }
        }
    }

    public static class XmlExtensions
    {
        public static XmlElement GetFirstChildElement(this XmlNode n, string strName = null, StringComparison Comparison = StringComparison.Ordinal, bool fForce = false)
        {
            foreach (XmlNode n2 in n.ChildNodes)
                if ((string.IsNullOrEmpty(strName) || n2.Name.Equals(strName, Comparison)) && n2.NodeType == XmlNodeType.Element)
                    return n2 as XmlElement;

            if (fForce)
                return n.AppendNewElement(strName);
            else
                return null;
        }

        public static string GetFormattedText(this XmlDocument doc, bool fNewLineOnAttributes = false)
        {
            StringBuilder sb = new StringBuilder();
            var xmlSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    ",
                NewLineHandling = NewLineHandling.Replace,
                NewLineChars = Environment.NewLine,
                NewLineOnAttributes = fNewLineOnAttributes,
                Encoding = Encoding.UTF8
            };

            var dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            if (doc.FirstChild != null && doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                doc.ReplaceChild(dec, doc.FirstChild);
            else
                doc.InsertBefore(dec, doc.DocumentElement);
            
            using (XmlWriter tx = XmlWriter.Create(sb, xmlSettings))
            {
                doc.WriteTo(tx);
            }

            return sb.ToString();
        }

        public static XmlElement AppendNewElement(this XmlDocument d, string strName, string strText = null, params string[] astrAttributes)
        {
            XmlElement e = d.CreateElement(strName);
            d.AppendChild(e);

            if (!string.IsNullOrWhiteSpace(strText))
                e.InnerText = strText;

            for (int i = 0; i + 1 < astrAttributes.Length; i += 2)
            {
                e.SetAttribute(astrAttributes[i], astrAttributes[i + 1]);
            }

            return e;
        }

        public static XmlElement AppendNewElement(this XmlNode n, string strName, string strText = null, params string[] astrAttributes)
        {
            XmlElement e = n.OwnerDocument.CreateElement(strName);
            n.AppendChild(e);

            if (!string.IsNullOrWhiteSpace(strText))
                e.InnerText = strText;

            for (int i = 0; i + 1 < astrAttributes.Length; i += 2)
            {
                e.SetAttribute(astrAttributes[i], astrAttributes[i + 1]);
            }

            return e;
        }

        public static string GetAttributeString(this XmlElement e, string strKey, string strDefault = "")
        {
            if (e.HasAttribute(strKey))
                return e.GetAttribute(strKey);
            else
                return strDefault;
        }

        public static int GetAttributeInt(this XmlElement e, string strKey, int iDefault = 0, int? iMin = null, int? iMax = null )
        {
            int iRet;
            if (int.TryParse(e.GetAttributeString(strKey, iDefault.ToString()), out iRet) && (!iMax.HasValue || iMax.Value >= iRet) && (!iMin.HasValue || iMin.Value <= iRet))
                return iRet;
            else
                return iDefault;
        }

        public static void SetAttributeInt(this XmlElement e, string strKey, int iValue)
        {
            e.SetAttribute(strKey, iValue.ToString());
        }

        public static bool GetAttributeBool(this XmlElement e, string strKey, bool fDefault = false)
        {
            return e.GetAttributeInt(strKey, (fDefault) ? 1 : 0) != 0;
        }

        public static void SetAttributeBool(this XmlElement e, string strKey, bool fValue)
        {
            e.SetAttribute(strKey, (fValue) ? "1" : "0" );
        }

        public static string GetText(this XmlNode n)
        {
            StringBuilder sb = new StringBuilder();

            foreach(XmlNode n2 in n.ChildNodes)
            {
                if (n2.NodeType == XmlNodeType.Text || n2.NodeType == XmlNodeType.CDATA)
                {
                    string strText = n2.Value.Trim(' ', '\r', '\n', '\t');
                    sb.Append(strText);
                }
            }

            return sb.ToString();
        }
    }

    public enum ModFileType : int
    {
        None,
        Unknown,
        ModInfo,
        Xml,
        Lua,
        Dep,
        ArtDef,
        Sql,
        Civ6Map,
        Dds,
        Count
    }

    [Flags]
    public enum ModFileTypeFlags : ulong
    {
        Unknown = 1 << ModFileType.Unknown,
        ModInfo = 1 << ModFileType.ModInfo,
        Xml = 1 << ModFileType.Xml,
        Lua = 1 << ModFileType.Lua,
        Dep = 1 << ModFileType.Dep,
        ArtDef = 1 << ModFileType.ArtDef,
        Sql = 1 << ModFileType.Sql,
        Civ6Map = 1 << ModFileType.Civ6Map,
        Dds = 1 << ModFileType.Dds,
        All = ulong.MaxValue
    }

    public static class ModFileTypeExt
    {
        public static readonly string[] Names = new string[]
        {
            "",
            "Unknown",
            "ModInfo",
            "Xml",
            "Lua",
            "Dep",
            "ArtDef",
            "Sql",
            "Civ6Map",
            "Icons",
            "Dds",
        };

        public static string GetName(this ModFileType e)
        {
            if (e > default(ModFileType) && e < ModFileType.Count)
                return Names[(uint)e];
            else
                return "";
        }

        public static ModFileTypeFlags ToFlag(this ModFileType e)
        {
            return (ModFileTypeFlags)(1UL << (int)e);
        }

        public static ModFileType GetEnum(string strFileName)
        {
            strFileName = Path.GetExtension(strFileName);
            if (strFileName.StartsWith("."))
                strFileName = strFileName.Substring(1);
            for (int i = 1; i < Names.Length; i++)
                if (Names[i].Equals(strFileName, StringComparison.OrdinalIgnoreCase))
                    return (ModFileType)(i);
            return ModFileType.Unknown;
        }
    }

    public class ModFile : IKeyed
    {
        public enum KeyType
        {
            ByRelFileName,
            ByFileName,
            ByFullFilename
        }

        public static ModFileType GetFileType(string strFileName)
        {
            return ModFileTypeExt.GetEnum(strFileName);
        }

        public static string GetFileTypeExtension(ModFileType eType)
        {
            return "." + eType.GetName().ToLowerInvariant();
        }

        public static string SetFileType(string strFileName, ModFileType eNewType)
        {
            return Path.ChangeExtension(strFileName, GetFileTypeExtension(eNewType));
        }

        public Mod ParentMod;

        protected string m_strFileTypeAndRelPath;
        protected string m_strFileName;
        protected string m_strRelPath;
        protected ModFileType m_eFileType;
        protected string m_strChecksum;

        public string Key { get { return (keyType == KeyType.ByFileName) ? FileName : (keyType == KeyType.ByFullFilename) ? FileNameAndFullPath : FileNameAndRelPath; } }

        public DateTime Modified;
        public bool Implied;
        public string Checksum { get { if (string.IsNullOrEmpty(m_strChecksum)) m_strChecksum = ModFileUtils.GetMD5Checksum(FileNameAndFullPath); return m_strChecksum; } }

        public string FileName { get { return m_strFileName; } }
        public string RelPath { get { return m_strRelPath; } }
        public ModFileType FileType { get { return m_eFileType; } }

        public KeyType keyType = ModFile.KeyType.ByRelFileName;

        public string FileNameAndRelPath
        {
            get
            {
                return m_strFileTypeAndRelPath;
            }
            set
            {
                m_strFileTypeAndRelPath = value;
                m_strRelPath = Path.GetDirectoryName(value);
                m_strFileName = Path.GetFileName(value);
                m_eFileType = GetFileType(value);
            }
        }

        public string FileNameAndFullPath { get { return ModFileUtils.CombineLinux((ParentMod != null) ? ParentMod.FullPath : ModPaths.AssetPath, FileNameAndRelPath); } }

        public ModFile(Mod oParent, string strFileNameAndRelPath, bool fImplied = false, DateTime dtModified = default(DateTime))
        {
            ParentMod = oParent;
            FileNameAndRelPath = strFileNameAndRelPath;
            Implied = fImplied;
            Modified = dtModified;
        }

        public ModFile Clone(KeyType? eKeyType = null)
        {
            ModFile f = (ModFile)MemberwiseClone();
            if (eKeyType.HasValue)
                f.keyType = eKeyType.Value;
            return f;
        }
    }

    public class ModFileList : KeyedList<ModFile>
    {
        public Mod ParentMod;

        public ModFile AddNew(string strFileNameAndRelPath, bool fImplied = false)
        {
            ModFile mfRet = null;
            if (!ContainsKey(strFileNameAndRelPath))
            {
                mfRet = new ModFile(ParentMod, strFileNameAndRelPath, fImplied);
                Add(mfRet);
            }
            else
                mfRet = this[strFileNameAndRelPath];
            return mfRet;
        }

        public void Add(List<string> lstFiles)
        {
            foreach (string strFile in lstFiles)
                AddNew(strFile);
        }

        public void Add(ModFileList lstFiles)
        {
            foreach (ModFile mf in lstFiles)
                if (!ContainsKey(mf.Key))
                    Add(mf.Clone());
        }
    }

    public enum ModElementType : int
    {
        None = 0,
        ImportFiles,
        GameplayScripts,
        LocalizedText,
        UserInterface,
        ModArt,
        UpdateARX,
        UpdateAudio,
        UpdateDatabase,
        Icons,
        WorldBuilder,
        Map,
        Custom,

        Count
    }

    [Flags]
    public enum ModElementTypeFlags : ulong
    {
        None = 0,
        ImportFiles = 1 << ModElementType.ImportFiles,
        GameplayScripts = 1 << ModElementType.GameplayScripts,
        LocalizedText = 1 << ModElementType.LocalizedText,
        UserInterface = 1 << ModElementType.UserInterface,
        ModArt = 1 << ModElementType.ModArt,
        UpdateARX = 1 << ModElementType.UpdateARX,
        UpdateAudio = 1 << ModElementType.UpdateAudio,
        UpdateDatabase = 1 << ModElementType.UpdateDatabase,
        Icons = 1 << ModElementType.Icons,
        WorldBuilder = 1 << ModElementType.WorldBuilder,
        Map = 1 << ModElementType.Map,
        Custom = 1 << ModElementType.Custom,
        All = ulong.MaxValue,
    }

    public static class ModElementTypeExt
    {
        public static readonly string[] Names = new string[]
        {
            "",
            "ImportFiles",
            "GameplayScripts",
            "LocalizedText",
            "UserInterface",
            "ModArt",
            "UpdateARX",
            "UpdateAudio",
            "UpdateDatabase",
            "Icons",
            "WorldBuilder",
            "Map",
            "Custom",
        };

        public static string GetName(this ModElementType e)
        {
            if (e > ModElementType.None && e < ModElementType.Count)
                return Names[(int)e];
            else
                return "";
        }

        public static ModElementTypeFlags ToFlag(this ModElementType e)
        {
            return (ModElementTypeFlags)(1UL << (int)e);
        }

        public static ModElementType GetEnum(string strName)
        {
            for (int i = 0; i < Names.Length; i++)
                if (Names[i].Equals(strName, StringComparison.OrdinalIgnoreCase))
                    return (ModElementType)(i);
            return default(ModElementType);
        }

        public static ModRootTypeFlags GetAllowedContainers(this ModElementType e)
        {
            switch (e)
            {
                case ModElementType.Custom:
                case ModElementType.Map:
                    return ModRootTypeFlags.Settings;
                case ModElementType.UpdateDatabase:
                    return ModRootTypeFlags.Components;
                default:
                    return ModRootTypeFlags.Settings | ModRootTypeFlags.Components;
            }
        }

        public static ModPropertyTypeFlags GetRequiredProperties(this ModElementType e)
        {
            switch (e)
            {
                case ModElementType.UserInterface:
                    return ModPropertyTypeFlags.Context;
                case ModElementType.Map:
                    return ModPropertyTypeFlags.Name;
                default:
                    return ModPropertyTypeFlags.None;
            }
        }

        public static ModPropertyTypeFlags GetAllowedProperties(this ModElementType e)
        {
            ModPropertyTypeFlags eAllowed = ModPropertyTypeFlags.LoadOrder | e.GetRequiredProperties();
            if (e.GetAllowedContainers().HasFlag(ModRootTypeFlags.Components))
                eAllowed |= ModPropertyTypeFlags.RuleSet;

            switch (e)
            {
                case ModElementType.Map:
                    eAllowed |= ModPropertyTypeFlags.Group | ModPropertyTypeFlags.Description;
                    break;
            }

            return eAllowed;
        }

        public static ModFileTypeFlags GetAllowedFileTypes(this ModElementType e)
        {
            switch (e)
            {
                case ModElementType.Custom:
                    return ModFileTypeFlags.Xml | ModFileTypeFlags.Sql;
                case ModElementType.GameplayScripts:
                    return ModFileTypeFlags.Lua;
                case ModElementType.Icons:
                    return ModFileTypeFlags.Xml | ModFileTypeFlags.Sql;
                case ModElementType.ImportFiles:
                    return ModFileTypeFlags.All;
                case ModElementType.LocalizedText:
                    return ModFileTypeFlags.Xml | ModFileTypeFlags.Sql;
                case ModElementType.Map:
                    return ModFileTypeFlags.Civ6Map;
                case ModElementType.ModArt:
                    return ModFileTypeFlags.Dep;
                case ModElementType.UpdateARX:
                    return ModFileTypeFlags.All;
                case ModElementType.UpdateAudio:
                    return ModFileTypeFlags.All;
                case ModElementType.UpdateDatabase:
                    return ModFileTypeFlags.Xml | ModFileTypeFlags.Sql;
                case ModElementType.UserInterface:
                    return ModFileTypeFlags.Xml;
                case ModElementType.WorldBuilder:
                    return ModFileTypeFlags.All;
                default:
                    return ModFileTypeFlags.All;
            }
        }
    }

    public class ModElementFile
    {
        public string FileName;
        public List<string> ImplicitFiles = new List<string>();

        public ModElementFile(string strFileName)
        {
            FileName = strFileName;
        }
    }

    public abstract class ModElement
    {
        public Mod ParentMod;
        public string Id = "";
        public readonly string ElementName;
        public readonly ModElementType ElementType;
        public ModProperties Properties;
        public List<ModElementFile> Files = new List<ModElementFile>();

        public int LoadOrder
        {
            get
            {
                int i;
                if (!int.TryParse(Properties[ModPropertyType.LoadOrder], out i))
                    i = 0;

                return i;
            }
            set
            {
                Properties[ModPropertyType.LoadOrder] = value.ToString();
            }
        }

        public virtual string GetDescription()
        {
            if (Id.Length > 0)
                return ElementName + "::" + Id;
            else
                return ElementName;
        }

        public virtual bool IsEmpty()
        {
            return Files.Count == 0;
        }

        private class ModOrderedFile
        {
            public string FileName;
            public int Priority;
            public int FileOrder;

            public ModOrderedFile(string strFileName, int iPriority = 0, int iFileOrder = 0)
            {
                FileName = strFileName;
                Priority = iPriority;
                FileOrder = iFileOrder;
            }
        }

        public virtual void AddImpliedFiles(ModElementFile f)
        {

        }

        public ModElementFile AddFile(string strFileName)
        {
            if (ElementType.GetAllowedFileTypes().HasFlag(ModFile.GetFileType(strFileName).ToFlag()))
            {
                var f = new ModElementFile(strFileName);
                Files.Add(f);
                AddImpliedFiles(f);
                return f;
            }
            else
                return null;
        }

        public virtual void LoadFromNode(XmlElement xmlElement)
        {
            var lstFiles = new List<ModOrderedFile>();

            Id = xmlElement.GetAttribute("id");

            foreach (XmlNode n in xmlElement.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element)
                {
                    switch (n.Name)
                    {
                        case "Properties":
                            Properties = new ModProperties(ParentMod, ElementType.GetAllowedProperties(), ElementType.GetRequiredProperties(), n as XmlElement);
                            break;
                        case "Items":
                            foreach (XmlNode n2 in n.ChildNodes)
                            {
                                if (n2.NodeType == XmlNodeType.Element && n2.Name.Equals("File", StringComparison.OrdinalIgnoreCase))
                                {
                                    var f = new ModOrderedFile(n2.GetText());

                                    if (ParentMod.LegacyFileOrder.ContainsKey(f.FileName))
                                        f.FileOrder = ParentMod.LegacyFileOrder[f.FileName];

                                    int.TryParse((n2 as XmlElement).GetAttribute("Priority"), out f.Priority);

                                    if (File.Exists(Path.Combine(ParentMod.FullPath, f.FileName)))
                                        lstFiles.Add(f);
                                }
                            }
                            break;
                    }
                }
            }

            lstFiles.Sort((m1, m2) => { int i = m2.Priority.CompareTo(m1.Priority); if (i == 0) i = m1.FileOrder.CompareTo(m2.FileOrder); return i; });

            foreach (ModOrderedFile m in lstFiles)
                AddFile(m.FileName);
        }

        public virtual XmlElement SaveUnderNode(XmlElement xmlElement)
        {
            XmlElement e = xmlElement.AppendNewElement(ElementName);

            if (!string.IsNullOrEmpty(Id))
                e.SetAttribute("id", Id);

            if (!Properties.IsEmpty())
                Properties.SaveUnderNode(e);

            XmlElement eFiles = e.AppendNewElement("Items");

            for (int i = 0; i < Files.Count; i++)
                eFiles.AppendNewElement("File", Files[i].FileName, "Priority", ((i + 1) * -10).ToString());

            return e;
        }

        protected ModElement(Mod oParentMod, ModElementType eType)
        {
            ParentMod = oParentMod;
            ElementType = eType;
            ElementName = eType.GetName();
            Properties = new ModProperties(oParentMod);
        }

        public void Clean(bool fCheckFiles = false)
        {
            Properties.Clean();
            for (int i = Files.Count - 1; i >= 0; i--)
                if (!ElementType.GetAllowedFileTypes().HasFlag(ModFile.GetFileType(Files[i].FileName).ToFlag()))
                    Files.RemoveAt(i);
        }

        public static ModElement CreateByType(ModElementType e, Mod oParentMod)
        {
            switch(e)
            {
                case ModElementType.Custom: return new ModCustom(oParentMod);
                case ModElementType.GameplayScripts: return new ModGameplayScripts(oParentMod);
                case ModElementType.Icons: return new ModIcons(oParentMod);
                case ModElementType.ImportFiles: return new ModImportFiles(oParentMod);
                case ModElementType.LocalizedText: return new ModLocalizedText(oParentMod);
                case ModElementType.Map: return new ModMap(oParentMod);
                case ModElementType.ModArt: return new ModArt(oParentMod);
                case ModElementType.UpdateARX: return new ModUpdateARX(oParentMod);
                case ModElementType.UpdateAudio: return new ModUpdateAudio(oParentMod);
                case ModElementType.UpdateDatabase: return new ModUpdateDatabase(oParentMod);
                case ModElementType.UserInterface: return new ModUserInterface(oParentMod);
                case ModElementType.WorldBuilder: return new ModWorldBuilder(oParentMod);
                default: return null;
            }
        }
    }

    public sealed class ModCustom : ModElement
    {
        public ModCustom(Mod oParentMod) : base(oParentMod, ModElementType.Custom) { }
        public ModCustom(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModGameplayScripts : ModElement
    {
        public ModGameplayScripts(Mod oParentMod) : base(oParentMod, ModElementType.GameplayScripts) { }
        public ModGameplayScripts(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModIcons : ModElement
    {
        public ModIcons(Mod oParentMod) : base(oParentMod, ModElementType.Icons) { }
        public ModIcons(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModImportFiles : ModElement
    {
        public ModImportFiles(Mod oParentMod) : base(oParentMod, ModElementType.ImportFiles) { }
        public ModImportFiles(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModLocalizedText : ModElement
    {
        public ModLocalizedText(Mod oParentMod) : base(oParentMod, ModElementType.LocalizedText) { }
        public ModLocalizedText(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModMap : ModElement
    {
        public ModMap(Mod oParentMod) : base(oParentMod, ModElementType.Map) { }
        public ModMap(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModArt : ModElement
    {
        public ModArt(Mod oParentMod) : base(oParentMod, ModElementType.ModArt) { }
        public ModArt(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
        public override void AddImpliedFiles(ModElementFile f)
        {
            List<string> lstFiles = ModFileUtils.FindFiles(Path.Combine(ParentMod.FullPath, "ArtDefs"), SearchOption.TopDirectoryOnly, "*.artdef");

            foreach (string strFileName in lstFiles)
                f.ImplicitFiles.Add(ModFileUtils.GetRelativePath(ParentMod.FullPath, strFileName));
        }
    }

    public sealed class ModUpdateARX : ModElement
    {
        public ModUpdateARX(Mod oParentMod) : base(oParentMod, ModElementType.UpdateARX) { }
        public ModUpdateARX(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModUpdateAudio : ModElement
    {
        public ModUpdateAudio(Mod oParentMod) : base(oParentMod, ModElementType.UpdateAudio) { }
        public ModUpdateAudio(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModUpdateDatabase : ModElement
    {
        public ModUpdateDatabase(Mod oParentMod) : base(oParentMod, ModElementType.UpdateDatabase) { }
        public ModUpdateDatabase(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModUserInterface : ModElement
    {
        public ModUserInterface(Mod oParentMod) : base(oParentMod, ModElementType.UserInterface) { }
        public ModUserInterface(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
        public override void AddImpliedFiles(ModElementFile f)
        {
            f.ImplicitFiles.Clear();
            if (ModFile.GetFileType(f.FileName) == ModFileType.Xml)
                f.ImplicitFiles.Add(ModFile.SetFileType(f.FileName, ModFileType.Lua));
        }
    }

    public sealed class ModWorldBuilder : ModElement
    {
        public ModWorldBuilder(Mod oParentMod) : base(oParentMod, ModElementType.WorldBuilder) { }
        public ModWorldBuilder(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public enum ModRootType : int
    {
        None = 0,
        Properties,
        Components,
        Settings,
        Files,
        LocalizedText,
        Dependencies,
        References,
        Blocks,
        User,
        Count
    }

    public enum ModRootTypeFlags : ulong
    {
        None = 0,
        Properties = 1UL << ModRootType.Properties,
        Components = 1UL << ModRootType.Components,
        Settings = 1UL << ModRootType.Settings,
        Files = 1UL << ModRootType.Files,
        LocalizedText = 1UL << ModRootType.LocalizedText,
        Dependencies = 1UL << ModRootType.Dependencies,
        References = 1UL << ModRootType.References,
        Blocks = 1UL << ModRootType.Blocks,
        User = 1UL << ModRootType.User,
        All = ulong.MaxValue
    }

    public static class ModRootTypeExt
    {
        public const string Properties = "Properties";
        public const string Components = "Components";
        public const string Settings = "Settings";
        public const string Files = "Files";
        public const string LocalizedText = "LocalizedText";
        public const string Dependencies = "Dependencies";
        public const string References = "References";
        public const string Blocks = "Blocks";
        public const string User = "User";

        public static readonly string[] Names = new string[]
        {
            "",
            Properties,
            Components,
            Settings,
            Files,
            LocalizedText,
            Dependencies,
            References,
            Blocks,
            User
        };

        public static string GetName(this ModRootType e)
        {
            if (e > ModRootType.None && e < ModRootType.Count)
                return Names[(int)e];
            else
                return "";
        }

        public static ModRootType GetEnum(string strName)
        {
            for (int i = 0; i < Names.Length; i++)
                if (Names[i].Equals(strName, StringComparison.OrdinalIgnoreCase))
                    return (ModRootType)(i);
            return default(ModRootType);
        }

        public static ModRootTypeFlags ToFlag(this ModRootType e)
        {
            return (ModRootTypeFlags)(1UL << (int)e);
        }
    }

    public abstract class ModRoot
    {
        public Mod ParentMod;
        public readonly string ContainerName;
        public readonly ModRootType ContainerType;

        public abstract bool IsEmpty();

        protected ModRoot(Mod oParentMod, ModRootType eContainerType)
        {
            ParentMod = oParentMod;
            ContainerType = eContainerType;
            ContainerName = eContainerType.GetName();
        }
        public abstract void LoadFromNode(XmlElement xmlElement);

        public virtual XmlElement SaveUnderNode(XmlElement xmlElement)
        {
            return xmlElement.AppendNewElement(ContainerName);
        }
    }

    public class ModRelation : IKeyed
    {
        public string Id;
        public string Title;
        public string Key { get { return Id; } }

        public ModRelation() { }
        public ModRelation(string strId, string strTitle)
        {
            Id = strId;
            Title = strTitle;
        }
        public ModRelation(XmlElement e)
        {
            Id = e.GetAttribute("id");
            Title = e.GetAttribute("title");
        }

        public XmlNode SaveUnderNode(XmlElement xmlElement)
        {
            return xmlElement.AppendNewElement("Mod", null, "id", Id, "title", Title);
        }
    }

    public abstract class ModRelations : ModRoot
    {
        public KeyedList<ModRelation> Items = new KeyedList<ModRelation>();

        protected ModRelations(Mod oParentMod, ModRootType eContainerType) : base(oParentMod, eContainerType) {  }

        public override bool IsEmpty() { return Items.Count == 0; }

        public override void LoadFromNode(XmlElement xmlElement)
        {
            foreach (XmlNode e in xmlElement.ChildNodes)
                if (e.NodeType == XmlNodeType.Element && e.Name.Equals("Mod", StringComparison.OrdinalIgnoreCase))
                    Items.Add(new ModRelation(e as XmlElement));
        }

        public override XmlElement SaveUnderNode(XmlElement xmlElement)
        {
            XmlElement e = base.SaveUnderNode(xmlElement);

            foreach (ModRelation m in Items)
                m.SaveUnderNode(e);

            return e;
        }
    }

    public sealed class ModDependencies : ModRelations
    {
        public ModDependencies(Mod oParentMod) : base(oParentMod, ModRootType.Dependencies) { }
        public ModDependencies(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModReferences : ModRelations
    {
        public ModReferences(Mod oParentMod) : base(oParentMod, ModRootType.References) { }
        public ModReferences(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }

    public sealed class ModBlocks : ModRelations
    {
        public ModBlocks(Mod oParentMod) : base(oParentMod, ModRootType.Blocks) { }
        public ModBlocks(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }
    }


    public sealed class LocalizedString : IKeyed
    {
        public string Literal;
        public const string DefaultLanguage = "en_US";
        public KeyedStringList Translations = new KeyedStringList();
        public string Key { get { return Literal; } }

        public string Value { get { if (Translations.Count > 0) return this[DefaultLanguage]; else return Literal; } set { if (Translations.Count > 0) this[DefaultLanguage] = value; else Literal = value; } }

        public string this[string strLanguage]
        {
            get { return (!string.IsNullOrEmpty(strLanguage)) && (Translations.ContainsKey(strLanguage)) ? Translations[strLanguage] : (Translations.ContainsKey(DefaultLanguage)) ? Translations[DefaultLanguage] : Literal; }
            set { Translations[(!string.IsNullOrEmpty(strLanguage)) ? strLanguage : DefaultLanguage] = value; }
        }

        public bool IsEmpty() { return string.IsNullOrEmpty(Value); }

        public LocalizedString(string strLiteral, string strValue = null, string strLanguage = DefaultLanguage)
        {
            Literal = strLiteral;
            if (!string.IsNullOrEmpty(strValue))
                Translations.Add(strLanguage, strValue);
        }
    }

    public sealed class ModInfoLocalizedStrings : ModRoot
    {
        public KeyedList<LocalizedString> Items = new KeyedList<LocalizedString>();

        public override bool IsEmpty() { return Items.Count == 0; }
        
        public string this[string strLiteral, string strLanguage = LocalizedString.DefaultLanguage]
        {
            get { return (Items.ContainsKey(strLiteral)) ? Items[strLiteral][strLanguage] : strLiteral; }
            set { if (!Items.ContainsKey(strLiteral)) Items.Add(new LocalizedString(strLiteral, value, strLanguage)); else Items[strLiteral][strLanguage] = value; }
        }

        public ModInfoLocalizedStrings(Mod oParentMod) : base(oParentMod, ModRootType.LocalizedText) { }

        public ModInfoLocalizedStrings(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }

        public override void LoadFromNode(XmlElement xmlElement)
        {
            foreach (XmlNode e in xmlElement.ChildNodes)
            {
                if (e.NodeType == XmlNodeType.Element)
                {
                    string strLiteral = (e as XmlElement).GetAttribute("id");
                    foreach (XmlNode e2 in e.ChildNodes)
                    {
                        if (e.NodeType == XmlNodeType.Element)
                        {
                            string strLanguage = e2.Name;
                            string strText = e2.GetText();
                            this[strLiteral, strLanguage] = strText;
                        }
                    }
                }
            }
        }

        public override XmlElement SaveUnderNode(XmlElement xmlElement)
        {
            XmlElement e = base.SaveUnderNode(xmlElement);

            foreach(LocalizedString ls in Items)
            {
                XmlElement eLit = e.AppendNewElement("Text", null, "id", ls.Literal);
                foreach (KeyValuePair<string, string> kv in ls.Translations)
                    eLit.AppendNewElement(kv.Key, kv.Value);
            }

            return e;
        }
    }

    public enum ModPropertyType : int
    {
        None = 0,
        Name,
        Teaser,
        Description,
        Authors,
        SpecialThanks,
        RuleSet,
        Context,
        Group,
        LoadOrder,
        EnabledByDefault,
        ShowInBrowser,
        Unknown,
        Count
    }

    [Flags]
    public enum ModPropertyTypeFlags : ulong
    {
        None = 0,
        Name = 1 << ModPropertyType.Name,
        Teaser = 1 << ModPropertyType.Teaser,
        Description = 1 << ModPropertyType.Description,
        Authors = 1 << ModPropertyType.Authors,
        SpecialThanks = 1 << ModPropertyType.SpecialThanks,
        RuleSet = 1 << ModPropertyType.RuleSet,
        Context = 1 << ModPropertyType.Context,
        Group = 1 << ModPropertyType.Group,
        LoadOrder = 1 << ModPropertyType.LoadOrder,
        EnabledByDefault = 1 << ModPropertyType.EnabledByDefault,
        ShowInBrowser = 1 << ModPropertyType.ShowInBrowser,
        Unknown = 1 << ModPropertyType.Unknown,
        All = ulong.MaxValue,
    }

    public static class ModPropertyTypeExt
    {
        public static readonly string[] Names = new string[]
        {
            "",
            "Name",
            "Teaser",
            "Description",
            "Authors",
            "SpecialThanks",
            "Ruleset",
            "Context",
            "Group",
            "LoadOrder",
            "EnabledByDefault",
            "ShowInBrowser",
            "Unknown",
        };

        public static string GetName(this ModPropertyType e)
        {
            if (e > ModPropertyType.None && e < ModPropertyType.Count)
                return Names[(int)e];
            else
                return "";
        }

        public static ModPropertyTypeFlags ToFlag(this ModPropertyType e)
        {
            return (ModPropertyTypeFlags)(1UL << (int)e);
        }

        public static ModPropertyType GetEnum(string strName)
        {
            for (int i = 0; i < Names.Length; i++)
                if (Names[i].Equals(strName, StringComparison.OrdinalIgnoreCase))
                    return (ModPropertyType)(i);
            return default(ModPropertyType);
        }

        public const string DefaultRuleset = "RULESET_STANDARD";
    }

    public sealed class ModProperties : ModRoot
    {
        public KeyedStringList Items = new KeyedStringList();
        public ModPropertyTypeFlags AllowedTypes = ModPropertyTypeFlags.All;
        public ModPropertyTypeFlags RequiredTypes = ModPropertyTypeFlags.None;

        public override bool IsEmpty() { return Items.Count == 0; }
        
        public string this[string strProperty]
        {
            get { return (Items.ContainsKey(strProperty)) ? Items[strProperty] : ""; }
            set { Items[strProperty] = value; }
        }

        public string this[ModPropertyType eType]
        {
            get { return this[eType.GetName()]; }
            set { Items[eType.GetName()] = value; }
        }

        public bool ContainsKey(string strProperty) { return Items.ContainsKey(strProperty); }
        public bool ContainsKey(ModPropertyType eType) { return Items.ContainsKey(eType.GetName()); }

        public string GetLocalized(string strProperty, string strLanguage = LocalizedString.DefaultLanguage)
        {
            return (Items.ContainsKey(strProperty)) ? ParentMod.LocalizedStrings[Items[strProperty], strLanguage] : "";
        }

        public void SetLocalized(string strProperty, string strValue, string strLanguage = LocalizedString.DefaultLanguage)
        {
            if (Items.ContainsKey(strProperty))
                ParentMod.LocalizedStrings[Items[strProperty], strLanguage] = strValue;
        }

        public string GetLocalized(ModPropertyType eType, string strLanguage = LocalizedString.DefaultLanguage)
        {
            return GetLocalized(eType.GetName(), strLanguage);
        }

        public void SetLocalized(ModPropertyType eType, string strValue, string strLanguage = LocalizedString.DefaultLanguage)
        {
            SetLocalized(eType.GetName(), strValue, strLanguage);
        }

        public ModProperties(Mod oParentMod, ModPropertyTypeFlags efPermitted = ModPropertyTypeFlags.All, ModPropertyTypeFlags efRequired = ModPropertyTypeFlags.None, XmlElement xmlElement = null) : base(oParentMod, ModRootType.Properties)
        {
            AllowedTypes = efPermitted;
            RequiredTypes = efRequired;
            if (xmlElement != null)
                LoadFromNode(xmlElement);
        }

 
        public override void LoadFromNode(XmlElement xmlElement)
        {
            foreach (XmlNode e in xmlElement.ChildNodes)
                if (e.NodeType == XmlNodeType.Element)
                    Items.Add(e.Name, e.GetText());
        }

        public override XmlElement SaveUnderNode(XmlElement xmlElement)
        {
            XmlElement e = base.SaveUnderNode(xmlElement);

            foreach (KeyValuePair<string, string> kv in Items)
                e.AppendNewElement(kv.Key, kv.Value);

            return e;
        }

        public void Clean()
        {
            for (int i = Items.Count - 1; i >= 0; i--)
                if (!AllowedTypes.HasFlag(ModPropertyTypeExt.GetEnum(Items[i].Key).ToFlag()))
                    Items.RemoveAt(i);
        }

        public void CopyFrom(ModProperties p)
        {
            foreach (KeyValuePair<string, string> kv in p.Items)
                Items.Add(kv.Key, kv.Value);

            AllowedTypes = p.AllowedTypes;
            RequiredTypes = p.RequiredTypes;
        }
    }

    public abstract class ModContainer : ModRoot
    {
        public List<ModElement> Elements = new List<ModElement>();

        protected ModContainer(Mod oParentMod, ModRootType eType) : base(oParentMod, eType) { }

        public override bool IsEmpty()
        {
            foreach (ModElement e in Elements)
                if (!e.IsEmpty())
                    return false;
            return true;
        }

        public override void LoadFromNode(XmlElement xmlElement)
        {
            foreach (XmlNode n in xmlElement.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (n as XmlElement);
                    switch (ModElementTypeExt.GetEnum(e.Name))
                    {
                        case ModElementType.Custom:
                            Elements.Add(new ModCustom(ParentMod, e));
                            break;
                        case ModElementType.GameplayScripts:
                            Elements.Add(new ModGameplayScripts(ParentMod, e));
                            break;
                        case ModElementType.Icons:
                            Elements.Add(new ModIcons(ParentMod, e));
                            break;
                        case ModElementType.ImportFiles:
                            Elements.Add(new ModImportFiles(ParentMod, e));
                            break;
                        case ModElementType.LocalizedText:
                            Elements.Add(new ModLocalizedText(ParentMod, e));
                            break;
                        case ModElementType.Map:
                            Elements.Add(new ModMap(ParentMod, e));
                            break;
                        case ModElementType.ModArt:
                            Elements.Add(new ModArt(ParentMod, e));
                            break;
                        case ModElementType.UpdateARX:
                            Elements.Add(new ModUpdateARX(ParentMod, e));
                            break;
                        case ModElementType.UpdateAudio:
                            Elements.Add(new ModUpdateAudio(ParentMod, e));
                            break;
                        case ModElementType.UpdateDatabase:
                            Elements.Add(new ModUpdateDatabase(ParentMod, e));
                            break;
                        case ModElementType.UserInterface:
                            Elements.Add(new ModUserInterface(ParentMod, e));
                            break;
                        case ModElementType.WorldBuilder:
                            Elements.Add(new ModWorldBuilder(ParentMod, e));
                            break;
                    }
                }
            }
        }

        public override XmlElement SaveUnderNode(XmlElement xmlElement)
        {
            XmlElement e = base.SaveUnderNode(xmlElement);
            {
                foreach( ModElement m in Elements )
                {
                    if (!m.IsEmpty())
                    {
                        m.SaveUnderNode(e);
                    }
                }
            }

            return e;
        }

        public virtual void Clean()
        {
            foreach (ModElement e in Elements)
                e.Clean();
            
            for (int i = Elements.Count - 1; i >= 0; i--)
                if (Elements[i].IsEmpty())
                    Elements.RemoveAt(i);
        }

    }

    public sealed class ModComponents : ModContainer
    {
        public ModComponents(Mod oParentMod) : base(oParentMod, ModRootType.Components) { }

        public ModComponents(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }

        public bool HasRulesets()
        {
            foreach (ModElement e in Elements)
                if (!e.IsEmpty() && e.Properties.ContainsKey(ModPropertyType.RuleSet) && !ModPropertyTypeExt.DefaultRuleset.Equals(e.Properties[ModPropertyType.RuleSet], StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public override void Clean()
        {
            if (!HasRulesets())
                foreach (ModElement e in Elements)
                    e.Properties.AllowedTypes &= ~ModPropertyTypeFlags.RuleSet;

            base.Clean();
        }

    }

    public sealed class ModSettings : ModContainer
    {
        public ModSettings(Mod oParentMod) : base(oParentMod, ModRootType.Settings) { }

        public ModSettings(Mod oParentMod, XmlElement xmlElement) : this(oParentMod) { LoadFromNode(xmlElement); }

        public override void Clean()
        {
            foreach (ModElement e in Elements)
                e.Properties.AllowedTypes &= ~ModPropertyTypeFlags.RuleSet;

            base.Clean();
        }
    }

    public class ModChildRef
    {
        public string Id;
        public string Title;
        public string Version;
        public string Checksum;
        public Mod mod;
        public int SortOrder;

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Version))
                return string.Format("{0} (v{1})", Title, Version);
            else
                return Title;
        }

        public ModChildRef() { }
        public ModChildRef(Mod m)
        {
            Id = m.Id;
            Title = m.Title;
            Version = m.Version;
            mod = m;
        }
        public ModChildRef(string strId, string strTitle, string strVersion, string strChecksum)
        {
            Id = strId;
            Title = strTitle;
            Version = strVersion;
            Checksum = strChecksum;
        }
    }

    public class ModMergeFileSource
    {
        public string ModId;
        public string FileNameAndRelPath;
        public string Checksum;

        public ModMergeFileSource(string strModId, string strFileNameAndRelPath, string strChecksum)
        {
            ModId = strModId;
            FileNameAndRelPath = strFileNameAndRelPath;
            Checksum = strChecksum;
        }
    }

    public class ModMergedFileRef
    {
        public string FileNameAndRelPath;
        public List<ModMergeFileSource> Sources = new List<ModMergeFileSource>();

        public ModMergedFileRef(string strFileNameAndRelPath)
        {
            FileNameAndRelPath = strFileNameAndRelPath;
        }
    }

    public class ModSet
    {
        public const int ModSetVersion = 1;

        Mod ParentMod;

        public List<ModChildRef> ChildModRefs;
        public List<ModMergedFileRef> MergedFiles;
        public int Version = ModSetVersion;

        public void LoadFromNode(XmlElement xmlElement)
        {
            if (!int.TryParse(xmlElement.GetAttribute("version"), out Version))
                Version = ModSetVersion;

            XmlElement eMods = xmlElement.GetFirstChildElement("Mods");
            if (eMods != null)
            {
                foreach (XmlNode n in eMods.ChildNodes)
                {
                    if (n.NodeType == XmlNodeType.Element && n.Name.Equals("Mod"))
                    {
                        XmlElement e = (n as XmlElement);
                        ChildModRefs.Add(new ModChildRef(e.GetAttribute("id"), e.GetAttribute("title"), e.GetAttribute("version"), e.GetAttribute("md5")));
                    }
                }
                XmlElement eMerged = xmlElement.GetFirstChildElement("Merged");
                if (eMerged != null)
                {
                    foreach (XmlNode n in eMerged.ChildNodes)
                    {
                        if (n.NodeType == XmlNodeType.Element && n.Name.Equals("File"))
                        {
                            var f = new ModMergedFileRef((n as XmlElement).GetAttribute("name"));
                            MergedFiles.Add(f);
                            foreach (XmlNode n2 in n.ChildNodes)
                            {
                                XmlElement e = (n2 as XmlElement);
                                f.Sources.Add(new ModMergeFileSource(e.GetAttribute("id"), e.GetAttribute("name"), e.GetAttribute("md5")));
                            }
                        }
                    }
                }
            }
        }

        public void SaveUnderNode(XmlElement xmlElement)
        {
            XmlElement e = xmlElement.AppendNewElement("ModSet", null, "version", Version.ToString());
            XmlElement eMods = e.AppendNewElement("Mods");
            foreach (var mr in ChildModRefs)
                eMods.AppendNewElement("Mod", null, "id", mr.Id, "title", mr.Title, "version", mr.Version, "md5", mr.Checksum);
            XmlElement eMerged = e.AppendNewElement("Merged");
            foreach (var f in MergedFiles)
            {
                XmlElement eFile = eMerged.AppendNewElement("File", null, "name", f.FileNameAndRelPath);
                foreach (var s in f.Sources)
                    eFile.AppendNewElement("Source", null, "id", s.ModId, "name", s.FileNameAndRelPath, "md5", s.Checksum);
            }
        }

        public ModSet(Mod oParentMod)
        {
            ParentMod = oParentMod;
            ChildModRefs = new List<ModChildRef>();
            MergedFiles = new List<ModMergedFileRef>();
        }
    }

    public partial class Mod
    {
        public delegate void DelMod(Mod m);
        public delegate void DelModIdChanging(Mod m, string strNewId);
        public delegate void DelModShowError(string strMessage, string strTitle = "Error");
        public delegate void DelModProgressMessage(string strProgressMessage);

        public DelMod OnModDelete = null;
        public DelModIdChanging OnModIdChanging = null;
        public DelMod OnModIdChanged = null;
        public static DelModShowError OnModShowError = null;
        public static DelModProgressMessage OnModProgressMessage = null;

        public string[] Lines;

        public string ModsPath;
        public string RelPath;
        public string FileName;

        protected DateTime? m_dtModifiedDT = null;
        protected string m_strChecksum;
       
        private string m_strId = "";
        private string m_strFileStub = null;
        private string m_strComponentId = null;
        public string Version;

        public ModInfoLocalizedStrings LocalizedStrings;
        public ModProperties Properties;
        public ModDependencies Dependencies;
        public ModReferences References;
        public ModBlocks Blocks;
        public ModComponents Components;
        public ModSettings Settings;
        public ModContainer[] Containers;

        public Dictionary<string, int> LegacyFileOrder;

        public ModFileList Files;
        public Dictionary<string, ModFile> ImportFiles;
        public Dictionary<string, ModFile> ArtDefFiles;
        public Dictionary<string, ModFile> DepFiles;
        public HashSet<string> ImportFileSet;

        private DateTime? m_dtSqlModifiedDT = null;
        private bool m_fSqlEnabled;
        private bool m_fSqlVisible;

        public static ModMergeOptions MergeOptions = new ModMergeOptions();

        public ModSet ModSet;
        public bool ModSetBuilt = false;

        public Mod()
        {
            Reset();
        }

        public Mod(string strModsPath, string strModRelPath, string strFileName, bool fNew = false) : this()
        {
            ModsPath = strModsPath;
            RelPath = strModRelPath;
            FileName = strFileName;
            if (!fNew)
                Load();
        }

        public void Reset(bool fForRebuild = false)
        {
            string strTitle = (Properties != null) ? Title : null;
            bool fEnabled = (Properties != null) ? Enabled : false;

            LocalizedStrings = new ModInfoLocalizedStrings(this);
            Properties = new ModProperties(this);
            Dependencies = new ModDependencies(this);
            References = new ModReferences(this);
            Blocks = new ModBlocks(this);
            Components = new ModComponents(this);
            Settings = new ModSettings(this);
            Containers = new ModContainer[] { Settings, Components };
            LegacyFileOrder = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            ImportFiles = new Dictionary<string, ModFile>(StringComparer.OrdinalIgnoreCase);
            ArtDefFiles = new Dictionary<string, ModFile>(StringComparer.OrdinalIgnoreCase);
            DepFiles = new Dictionary<string, ModFile>(StringComparer.OrdinalIgnoreCase);
            Files = new ModFileList();
            Files.ParentMod = this;
            m_strChecksum = "";
            m_dtModifiedDT = null;
            m_dtSqlModifiedDT = null;
            m_fSqlEnabled = false;
            m_fSqlVisible = false;

            if (!fForRebuild)
            {
                ModSet = new ModSet(this);

                m_strFileStub = null;
                m_strComponentId = null;
                Version = "";
            }
            else
            {
                Title = strTitle;
                Enabled = fEnabled;
            }
        }

        static partial void GetCompiledWithSql(ref bool f);
        partial void SqlReadValues();
        partial void SqlDelete();

        public DateTime ModifiedDT { get { if (!m_dtModifiedDT.HasValue) m_dtModifiedDT = File.GetLastWriteTime(FullPathAndFileName); return m_dtModifiedDT.Value; } }
        public string Checksum { get { if (string.IsNullOrEmpty(m_strChecksum)) m_strChecksum = ModFileUtils.GetMD5Checksum(FullPathAndFileName); return m_strChecksum; } }

        public string FullPath { get { return Path.Combine(ModsPath, RelPath); } }
        public string FullPathAndFileName { get { return Path.Combine(FullPath, FileName); } }

        public static bool IsValidNameChar(char c)
        {
            return 0 > "<\"".IndexOf(c);
        }

        public static bool IsValidFileNameChar(char c)
        {
            return char.IsLetterOrDigit(c) || -1 < " _-".IndexOf(c);
        }

        public static string NameToFileName(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append(c);
                else if (c == '_')
                {
                    if (sb.Length == 0 || sb[sb.Length - 1] != '_')
                        sb.Append(c);
                }
                else if (sb.Length > 0 && 0 <= " -".IndexOf(c) && 0 > " -_".IndexOf(sb[sb.Length - 1]))
                    sb.Append(c);
            }

            return sb.ToString();
        }

        public static bool CompiledWithSql
        {
            get
            {
                bool f = false;
                GetCompiledWithSql(ref f);
                return f;
            }
        }

        public bool IsOutOfDate { get { return (!m_dtSqlModifiedDT.HasValue || ModifiedDT != m_dtSqlModifiedDT.Value); } }

        public bool IsModSet { get { return ModSet.ChildModRefs.Count > 0; } }

        public bool Enabled
        {
            get
            {
                if (IsOutOfDate)
                {
                    int i;
                    if (!Properties.ContainsKey(ModPropertyType.EnabledByDefault) ||
                        !int.TryParse(Properties[ModPropertyType.EnabledByDefault], out i))
                    {
                        i = 1;
                    }
                    return i != 0;
                }
                else
                    return m_fSqlEnabled;
            }
            set
            {
                if (IsOutOfDate)
                    Properties[ModPropertyType.EnabledByDefault] = (value) ? "1" : "0";
                else
                    m_fSqlEnabled = value;
            }
        }

        public bool Visible
        {
            get
            {
                if (IsOutOfDate)
                    return !Properties[ModPropertyType.ShowInBrowser].Equals("AlwaysHidden", StringComparison.OrdinalIgnoreCase);
                else
                    return m_fSqlVisible;
            }
            set
            {
                if (IsOutOfDate)
                {
                    if (value)
                        Properties.Items.Remove(ModPropertyType.ShowInBrowser.GetName());
                    else
                        Properties[ModPropertyType.ShowInBrowser] = "AlwaysHidden";
                }
                else
                    m_fSqlVisible = value;
            }
        }

        partial void SqlWriteEnabledAndVisible();

        public bool WriteEnabledAndVisible()
        {
            try
            {
                if (!IsOutOfDate)
                    SqlWriteEnabledAndVisible();
                else
                {
                    String strText = File.ReadAllText(FullPathAndFileName);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(strText);
                    var xmlRoot = xmlDoc.DocumentElement;
                    if (xmlRoot != null)
                    {
                        XmlElement xmlProperties = xmlRoot.GetFirstChildElement("Properties", StringComparison.OrdinalIgnoreCase, true);
                        XmlElement e = xmlProperties.GetFirstChildElement(ModPropertyType.ShowInBrowser.GetName(), StringComparison.OrdinalIgnoreCase);
                        if (e != null)
                            xmlProperties.RemoveChild(e);
                        if (!Visible)
                        {
                            xmlProperties.AppendNewElement(ModPropertyType.ShowInBrowser.GetName(), "AlwaysHidden");
                        }
                        e = xmlProperties.GetFirstChildElement(ModPropertyType.EnabledByDefault.GetName(), StringComparison.OrdinalIgnoreCase);
                        if (e != null)
                            xmlProperties.RemoveChild(e);
                        xmlProperties.AppendNewElement(ModPropertyType.EnabledByDefault.GetName(), (Enabled) ? "1" : "0");

                        string strXml = xmlDoc.GetFormattedText();

                        File.WriteAllText(FullPathAndFileName, strXml);
                    }
                }
            }
            catch (Exception e)
            {
                OnModShowError?.Invoke("Error updating visible/enabled properties: " + e.Message);
                return false;
            }
            return true;
        }

        private static readonly Dictionary<string, string> FiraxisHardcodedTitles = new Dictionary<string, string>()
        {
            { "LOC_AZTEC_MONTEZUMA_MOD_TITLE", "<DLC> Aztec Civilization Pack" },
            { "LOC_POLAND_JADWIGA_MOD_TITLE", "<DLC> Poland Civilization Pack" },
            { "LOC_MOD_VIKINGSLANDMARKS_TITLE", "<DLC> Vikings Content" },
            { "LOC_MOD_POLAND_SCENARIO_TITLE", "<Scenario> Jadwiga's Legacy" },
            { "LOC_MOD_VIKINGS_SCENARIO_TITLE", "<Scenario> Vikings, Traders, and Raiders!" }
        };

        public string Title
        {
            get
            {
                string strTitle = Properties?.GetLocalized(ModPropertyType.Name);

                if (!string.IsNullOrEmpty(strTitle))
                {
                    if (FiraxisHardcodedTitles.ContainsKey(strTitle))
                        strTitle = FiraxisHardcodedTitles[strTitle];
                }
                else
                    strTitle = FileStub;

                return strTitle;
            }
            set
            {
                Properties[ModPropertyType.Name] = value;
            }
        }

        public string Id
        {
            get
            {
                return (!string.IsNullOrEmpty(m_strId)) ? m_strId : Title;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(m_strId) && !m_strId.Equals(value))
                {
                    OnModIdChanging?.Invoke(this, value);
                    SqlDelete();
                    m_strId = value;
                    if (File.Exists(FullPathAndFileName))
                    {
                        var xmlDoc = new XmlDocument();
                        xmlDoc.Load(FullPathAndFileName);
                        xmlDoc.DocumentElement.SetAttribute("id", value);
                        string strXml = xmlDoc.GetFormattedText();
                        File.WriteAllText(FullPathAndFileName, strXml);
                    }
                    OnModIdChanged?.Invoke(this);
                }
                else
                    m_strId = value;
            }
        }

        public string FileStub { get { if (string.IsNullOrEmpty(m_strFileStub)) m_strFileStub = Path.GetFileNameWithoutExtension(FileName); return m_strFileStub; } }

        public string ComponentId
        {
            get
            {
                if (string.IsNullOrEmpty(m_strComponentId))
                {
                    string s = FileStub;
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in s.ToCharArray())
                        if (c == ' ')
                            sb.Append('_');
                        else if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                            sb.Append(c);

                    char c1 = (sb.Length > 0) ? sb[0] : '\0';
                    if (!((c1 >= 'a' && c1 <= 'z') || (c1 >= 'A' && c1 <= 'Z')))
                        sb.Insert(0, 'A');
                    m_strComponentId = sb.ToString();
                }
                return m_strComponentId;
            }
        }

        public void Delete()
        {
            try
            {
                try
                {
                    SqlDelete();
                }
                catch (Exception ex)
                {
                    OnModShowError?.Invoke("Error deleting mod from DB: " + ex.Message);
                }

                if (File.Exists(FullPathAndFileName))
                {
                    File.Delete(FullPathAndFileName);
                    if (ModFileUtils.FindFiles(FullPath, SearchOption.AllDirectories, "*.modinfo").Count == 0)
                    {
                        ModFileUtils.DeleteDirectory(FullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                OnModShowError?.Invoke("Error deleting mod: " + ex.Message);
            }

            OnModDelete?.Invoke(this);
        }

        public void Load()
        {
            m_strChecksum = null;
            m_dtModifiedDT = null;

            string strXml = File.ReadAllText(FullPathAndFileName);

            Reset();

            Xml = strXml;

            try
            {
                SqlReadValues();
            }
            catch
            {
                m_dtSqlModifiedDT = null;
            }
        }

        public string Xml
        {
            get
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (string.IsNullOrEmpty(m_strId))
                    m_strId = Guid.NewGuid().ToString();

                XmlElement eRoot = xmlDoc.AppendNewElement("Mod", null, "id", m_strId);

                if (!string.IsNullOrEmpty(Version))
                    eRoot.SetAttribute("version", Version);

                if (!Properties.IsEmpty())
                    Properties.SaveUnderNode(eRoot);

                if (!Dependencies.IsEmpty())
                    Dependencies.SaveUnderNode(eRoot);

                if (!References.IsEmpty())
                    References.SaveUnderNode(eRoot);

                if (!Blocks.IsEmpty())
                    Blocks.SaveUnderNode(eRoot);

                if (!Settings.IsEmpty())
                    Settings.SaveUnderNode(eRoot);

                if (!Components.IsEmpty())
                    Components.SaveUnderNode(eRoot);

                if (Files.Count > 0)
                {
                    XmlElement eFiles = eRoot.AppendNewElement("Files");

                    foreach (ModFile f in Files)
                        if (!f.Implied)
                            eFiles.AppendNewElement("File", f.FileNameAndRelPath);
                }

                if (!LocalizedStrings.IsEmpty())
                    LocalizedStrings.SaveUnderNode(eRoot);

                if (IsModSet)
                {
                    XmlElement eUser = eRoot.AppendNewElement("User");
                    ModSet.SaveUnderNode(eUser);
                }

                return xmlDoc.GetFormattedText();
            }
            set
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(value);

                m_strId = xmlDoc.DocumentElement.GetAttribute("id");
                Version = xmlDoc.DocumentElement.GetAttribute("version");

                foreach (XmlNode n in xmlDoc.DocumentElement.GetElementsByTagName("Files"))
                    foreach (XmlNode n2 in n.ChildNodes)                   
                        if (n2.NodeType == XmlNodeType.Element && n2.Name.Equals("File", StringComparison.OrdinalIgnoreCase) && !LegacyFileOrder.ContainsKey(n2.GetText()))
                            LegacyFileOrder.Add(n2.GetText(), LegacyFileOrder.Count);

                foreach (XmlNode n in xmlDoc.DocumentElement.ChildNodes)
                {
                    if (n.NodeType == XmlNodeType.Element)
                    {
                        XmlElement e = (n as XmlElement);
                        switch (ModRootTypeExt.GetEnum(e.Name))
                        {
                            case ModRootType.Components:
                                Components.LoadFromNode(e);
                                break;
                            case ModRootType.Settings:
                                Settings.LoadFromNode(e);
                                break;
                            case ModRootType.Dependencies:
                                Dependencies = new ModDependencies(this, e);
                                break;
                            case ModRootType.References:
                                References = new ModReferences(this, e);
                                break;
                            case ModRootType.Blocks:
                                Blocks = new ModBlocks(this, e);
                                break;
                            case ModRootType.Properties:
                                Properties = new ModProperties(this, ModPropertyTypeFlags.All, ModPropertyTypeFlags.Name | ModPropertyTypeFlags.Teaser, e);
                                break;
                            case ModRootType.LocalizedText:
                                LocalizedStrings = new ModInfoLocalizedStrings(this, e);
                                break;
                            case ModRootType.User:
                                XmlElement eModSet = e.GetFirstChildElement("ModSet");
                                if (eModSet != null)
                                    ModSet.LoadFromNode(eModSet);
                                break;
                        }
                    }
                }

                LegacyFileOrder.Clear();

                UpdateModFiles();
            }
        }

        public void Save(string strFullPathAndFileName = null)
        {
            string strXml = Xml;

            if (string.IsNullOrEmpty(strFullPathAndFileName))
                strFullPathAndFileName = FullPathAndFileName;

            File.WriteAllText(strFullPathAndFileName, strXml);

            m_strChecksum = null;
            m_dtModifiedDT = null;
        }

        public void Clean()
        {
            Properties.Clean();
            Components.Clean();
            Settings.Clean();
        }

        public void UpdateModFiles()
        {
            Files.Clear();
            ImportFiles.Clear();
            ArtDefFiles.Clear();
            DepFiles.Clear();

            foreach (ModContainer c in Containers)
            {
                foreach (ModElement e in c.Elements)
                {
                    foreach (ModElementFile f in e.Files)
                    {
                        ModFile mf = Files.AddNew(f.FileName);
                        foreach (string strImplied in f.ImplicitFiles)
                        {
                            ModFile mf2 = Files.AddNew(strImplied, true);
                            if (e.ElementType == ModElementType.ModArt && ModFile.GetFileType(strImplied) == ModFileType.ArtDef)
                                ArtDefFiles[mf2.FileName] = mf2;
                        }

                        if (e.ElementType == ModElementType.ImportFiles)
                            ImportFiles[mf.FileName] = mf;
                    }
                }
            }

            ImportFileSet = new HashSet<string>(ImportFiles.Keys, StringComparer.OrdinalIgnoreCase);
        }

        public class ModChildElementRef
        {
            public ModChildRef Parent;
            public ModElement Element;
            public int Index;
            public bool IsSetting;
            public long SortOrder; // LoadOrder << 32 | ModOrder << 16 | OrderInMod

            public ModChildElementRef(ModChildRef p, ModElement e, int iIndex, bool fIsSetting)
            {
                Parent = p;
                Element = e;
                Index = iIndex;
                IsSetting = fIsSetting;

                SortOrder = e.LoadOrder * 0x100000000L + p.SortOrder * 0x10000L + iIndex;
            }
        }

        public class ModMergedFile : IKeyed
        {
            public ModFile modFile;
            public string Key { get { return modFile.FileNameAndRelPath; } }
            public KeyedList<ModFile> Sources = new KeyedList<ModFile>();
            public bool AddedToSettings;
            public bool AddedToComponents;
        }

        public class ModMergedFileList : KeyedList<ModMergedFile>
        {
            Mod ParentMod;
            public void AddNew(ModFile mf)
            {
                string strFileNameAndRelPath;

                switch (mf.FileType)
                {
                    case ModFileType.ArtDef:
                        strFileNameAndRelPath = ModFileUtils.CombineLinux("ArtDefs", mf.FileName);
                        break;
                    case ModFileType.Dep:
                        strFileNameAndRelPath = ModFile.SetFileType(ParentMod.FileName, ModFileType.Dep);
                        break;
                    default:
                        strFileNameAndRelPath = ModFileUtils.CombineLinux("Merged", mf.FileName);
                        break;
                }

                if (!ContainsKey(strFileNameAndRelPath))
                {
                    var mrg = new ModMergedFile();
                    mrg.modFile = new ModFile(ParentMod, strFileNameAndRelPath, mf.Implied);
                    mrg.Sources.Add(mf.Clone(ModFile.KeyType.ByFullFilename));
                    Add(mrg);
                }
                else
                    this[strFileNameAndRelPath].Sources.Add(mf.Clone(ModFile.KeyType.ByFullFilename));
            }

            public ModMergedFileList(Mod oParent) : base()
            {
                ParentMod = oParent;
            }
        }

        public static bool MergeFiles(string strOFileName, string strAFileName, string strBFileName, string strOutFileName)
        {
            bool fConflicts = MergeOptions.Shell3Way == ModMergeOptions.ShellWhen.AlwaysShell;

            if (!fConflicts)
            {

                string[] astrO = File.ReadAllLines(strOFileName);
                string[] astrA = File.ReadAllLines(strAFileName);
                string[] astrB = File.ReadAllLines(strBFileName);

                List<Diff.IMergeResultBlock> merged = Diff.diff3_merge(astrA, astrO, astrB, true);
                List<string> lstOut = new List<string>();


                foreach (Diff.IMergeResultBlock block in merged)
                {
                    if (block is Diff.MergeOKResultBlock)
                    {
                        lstOut.AddRange((block as Diff.MergeOKResultBlock).ContentLines);
                        Diff.MergeOKResultBlock ok = (block as Diff.MergeOKResultBlock);
                    }
                    else if (block is Diff.MergeConflictResultBlock)
                    {
                        Diff.MergeConflictResultBlock conflicts = (block as Diff.MergeConflictResultBlock);
                        fConflicts = true;
                        break;
                    }
                }

                if (!fConflicts)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(strOutFileName));
                    File.WriteAllLines(strOutFileName, lstOut.ToArray());
                }
            }

            if (fConflicts && MergeOptions.Shell3Way != ModMergeOptions.ShellWhen.NeverShell)
            {
                string strCmd = ModFileUtils.StandardizePath(MergeOptions.ShellCmd3Way, Path.DirectorySeparatorChar);
                strCmd = strCmd.Replace("%OUT", '"' + strOutFileName + '"');
                strCmd = strCmd.Replace("%O", '"' + strOFileName + '"');
                strCmd = strCmd.Replace("%A", '"' + strAFileName + '"');
                strCmd = strCmd.Replace("%B", '"' + strBFileName + '"');

                string strFile;
                string strParms;

                ModFileUtils.SplitParmsFromExe(strCmd, out strFile, out strParms);

                using (Process p = Process.Start(strFile, strParms))
                {
                    p.WaitForExit();
                    fConflicts = p.ExitCode != 0 || !File.Exists(strOutFileName);
                }
            }

            return !fConflicts;
        }

        public static bool MergeFiles(string strAFileName, string strBFileName, string strOutFileName)
        {
            bool fConflicts = false;

            string[] astrA = File.ReadAllLines(strAFileName);
            string[] astrB = File.ReadAllLines(strBFileName);

            List<string> lstOut = Diff.diff_merge_keepall(astrA, astrB);

            if (!fConflicts)
                File.WriteAllLines(strOutFileName, lstOut.ToArray());

            return !fConflicts;
        }

        private string MergeCopyFile(Mod m, string strFileNameAndRelPath, bool fImplied)
        {
            string strNew = ModFileUtils.CombineLinux(m.FileStub, strFileNameAndRelPath);
            string strOldFull = m.Files[strFileNameAndRelPath].FileNameAndFullPath;

            ModFileType t = ModFile.GetFileType(strFileNameAndRelPath);
            if (t == ModFileType.Dep)
                strNew = Path.ChangeExtension(FileName, ".dep");
            else if (t == ModFileType.ArtDef)
                strNew = ModFileUtils.CombineLinux("ArtDefs", Path.GetFileName(strFileNameAndRelPath));

            ModFile mf = Files.AddNew(strNew, fImplied);

            string strNewFull = mf.FileNameAndFullPath;

            ModFileUtils.CopyFileAndForceDirectories(strOldFull, strNewFull);

            return strNew;
        }


        public void BuildModSet(ModHandler mm)
        {
            ModSetBuilt = false;

            string strSavedModsPath = ModsPath;
            string strFullPath = FullPath;
            ModsPath = ModPaths.BackupModsPath;
            string strFullBackupPath = FullPath;
            ModsPath = ModPaths.TempModsPath;
            string strFullTempPath = FullPath;
           
            try
            {
                Reset(true);

                var klstMergedImportFiles = new ModMergedFileList(this);
                var klstMergedDepFiles = new ModMergedFileList(this);
                var klstMergedArtDefFiles = new ModMergedFileList(this);

                for (int i = ModSet.ChildModRefs.Count - 1; i >= 0; i--)
                    if (mm.Mods.ContainsKey(ModSet.ChildModRefs[i].Id))
                    {
                        ModSet.ChildModRefs[i].mod = mm.Mods[ModSet.ChildModRefs[i].Id];
                        ModSet.ChildModRefs[i].Checksum = ModSet.ChildModRefs[i].mod.Checksum;
                    }
                    else
                        ModSet.ChildModRefs.RemoveAt(i);

                // Move dependencies and references behind their referant.
                int j = 0;
                while (j < ModSet.ChildModRefs.Count - 1)
                {
                    bool fFound = false;
                    var m1 = ModSet.ChildModRefs[j];
                    for (int k = ModSet.ChildModRefs.Count - 1; k > j; k--)
                    {
                        var m2 = ModSet.ChildModRefs[k];
                        if (m1.mod.Dependencies.Items.ContainsKey(m2.Id) || m1.mod.References.Items.ContainsKey(m2.Id))
                        {
                            fFound = true;
                            ModSet.ChildModRefs.RemoveAt(j);
                            ModSet.ChildModRefs.Insert(k, m1);
                            break;
                        }
                    }
                    if (!fFound)
                        j++;
                }

                for (int i = 0; i < ModSet.ChildModRefs.Count; i++)
                    ModSet.ChildModRefs[i].SortOrder = i;

                var lstElements = new List<ModChildElementRef>();

                foreach (ModChildRef r in ModSet.ChildModRefs)
                {
                    j = 0;
                    foreach (ModElement e in r.mod.Settings.Elements)
                    {
                        var re = new ModChildElementRef(r, e, j, true);
                        lstElements.Add(re);
                        j++;
                    }
                    foreach (ModElement e in r.mod.Components.Elements)
                    {
                        var re = new ModChildElementRef(r, e, j, false);
                        lstElements.Add(re);
                        j++;
                    }
                }

                lstElements.Sort((re1, re2) => re1.SortOrder.CompareTo(re2.SortOrder));

                bool fMergingArtDef = false;
                bool fArtDefInSettings = false;
                bool fArtDefInComponents = false;
                Mod mLastArdDefMod = null;

                //build list of files to merge
                foreach (ModChildElementRef re in lstElements)
                {
                    switch (re.Element.ElementType)
                    {
                        case ModElementType.ImportFiles:
                            foreach (ModElementFile ef in re.Element.Files)
                                klstMergedImportFiles.AddNew(re.Parent.mod.Files[ef.FileName]);
                            break;
                        case ModElementType.ModArt:
                            if (re.Element.Files.Count > 0)
                            {
                                if (!fMergingArtDef)
                                {
                                    if (mLastArdDefMod == null)
                                        mLastArdDefMod = re.Element.ParentMod;
                                    else if (mLastArdDefMod != re.Element.ParentMod)
                                        fMergingArtDef = true;
                                }
                                fArtDefInSettings |= re.IsSetting;
                                fArtDefInComponents |= !re.IsSetting;
                            }
                            foreach (ModElementFile ef in re.Element.Files)
                            {
                                klstMergedDepFiles.AddNew(re.Parent.mod.Files[ef.FileName]);
                                foreach (string strFileName in ef.ImplicitFiles)
                                    klstMergedArtDefFiles.AddNew(re.Parent.mod.Files[strFileName]);
                            }
                            break;
                    }
                }

                // for imports, only need files with more than 1 source
                for (int i = klstMergedImportFiles.Count - 1; i >= 0; i--)
                    if (klstMergedImportFiles[i].Sources.Count < 2)
                        klstMergedImportFiles.RemoveAt(i);

                // Do the merging
                foreach (ModMergedFile mrg in klstMergedImportFiles)
                {
                    OnModProgressMessage?.Invoke("Merging " + mrg.modFile.FileName);
                    var mr = new ModMergedFileRef(mrg.modFile.FileNameAndRelPath);
                    ModSet.MergedFiles.Add(mr);
                    ModFile mfBase = ModPaths.AssetFiles[mrg.modFile.FileName];
                    if (mfBase != null)
                        mr.Sources.Add(new ModMergeFileSource("base", mfBase.FileNameAndRelPath, mfBase.Checksum));
                    foreach (var ms in mrg.Sources)
                        mr.Sources.Add(new ModMergeFileSource(ms.ParentMod.Id, ms.FileNameAndRelPath, ms.Checksum));

                    if (mfBase != null)
                    {
                        MergeFiles(mfBase.FileNameAndFullPath, mrg.Sources[0].FileNameAndFullPath, mrg.Sources[1].FileNameAndFullPath, mrg.modFile.FileNameAndFullPath);
                        for (int i = 2; i < mrg.Sources.Count; i++)
                            MergeFiles(mfBase.FileNameAndFullPath, mrg.modFile.FileNameAndFullPath, mrg.Sources[1].FileNameAndFullPath, mrg.modFile.FileNameAndFullPath);
                    }
                    else
                    {
                        MergeFiles(mrg.Sources[0].FileNameAndFullPath, mrg.Sources[1].FileNameAndFullPath, mrg.modFile.FileNameAndFullPath);
                        for (int i = 2; i < mrg.Sources.Count; i++)
                            MergeFiles(mrg.modFile.FileNameAndFullPath, mrg.Sources[1].FileNameAndFullPath, mrg.modFile.FileNameAndFullPath);
                    }
                }

                // Merge ArtDef
                if (fMergingArtDef)
                {
                    if (klstMergedDepFiles.Count == 0 || klstMergedDepFiles[0].Sources.Count < 2)
                        fMergingArtDef = false;
                    else
                    {
                        ModDep dep = new ModDep();
                        dep.Name = FileStub;
                        dep.Id = Id;
                        var mr = new ModMergedFileRef(klstMergedDepFiles[0].modFile.FileNameAndRelPath);
                        ModSet.MergedFiles.Add(mr);
                        foreach (ModFile f in klstMergedDepFiles[0].Sources)
                        {
                            mr.Sources.Add(new ModMergeFileSource(f.ParentMod.Id, f.FileNameAndRelPath, f.Checksum));
                            ModDep dep2 = new ModDep();
                            if (dep2.Load(f.FileNameAndFullPath))
                                dep.MergeFrom(dep2);
                        }

                        dep.Save(klstMergedDepFiles[0].modFile.FileNameAndFullPath);

                        ModElementFile efNew = new ModElementFile(klstMergedDepFiles[0].modFile.FileNameAndRelPath);

                        foreach (var art in klstMergedArtDefFiles)
                        {
                            efNew.ImplicitFiles.Add(art.modFile.FileNameAndRelPath);
                            if (art.Sources.Count == 1)
                                ModFileUtils.CopyFileAndForceDirectories(art.Sources[0].FileNameAndFullPath, art.modFile.FileNameAndFullPath);
                            else
                            {
                                ModArtDef ad = null;
                                mr = new ModMergedFileRef(art.modFile.FileNameAndRelPath);

                                foreach (ModFile f in art.Sources)
                                {
                                    mr.Sources.Add(new ModMergeFileSource(f.ParentMod.Id, f.FileNameAndRelPath, f.Checksum));
                                    ModArtDef ad2 = new ModArtDef();
                                    if (ad2.Load(f.FileNameAndFullPath))
                                    {
                                        if (ad == null)
                                            ad = ad2;
                                        else
                                            ad.MergeFrom(ad2);
                                    }
                                }

                                if (ad != null)
                                {
                                    ad.Save(art.modFile.FileNameAndFullPath);
                                    ModSet.MergedFiles.Add(mr);
                                }
                            }
                        }

                        if (fArtDefInSettings)
                        {
                            var e = new ModArt(this);
                            e.Id = string.Format("{0}_{1}_{2}", ComponentId, e.ElementName, "Settings");
                            e.Files.Add(efNew);
                            Settings.Elements.Add(e);
                        }
                        if (fArtDefInComponents)
                        {
                            var e = new ModArt(this);
                            e.Id = string.Format("{0}_{1}_{2}", ComponentId, e.ElementName, "Components");
                            e.Files.Add(efNew);
                            Components.Elements.Add(e);
                        }
                    }
                }

                //Copy platform stuff
                foreach (var cr in ModSet.ChildModRefs)
                    ModFileUtils.CopyDirectory(cr.mod.FullPath, FullPath, "platforms");

                //Build components and copy files
                j = 0;
                foreach (ModChildElementRef re in lstElements)
                {
                    ModElement e = ModElement.CreateByType(re.Element.ElementType, this);
                    e.Properties.CopyFrom(re.Element.Properties);
                    e.Id = string.Format("{0}_{1}_{2}", re.Element.ParentMod.ComponentId, e.ElementName, j);
                    j++;
                    //Add files and copy them
                    foreach (ModElementFile ef in re.Element.Files)
                    {
                        bool fAdd = true;

                        if (re.Element.ElementType == ModElementType.ImportFiles)
                        {
                            foreach (ModMergedFile mrg in klstMergedImportFiles)
                            {
                                if (mrg.Sources.ContainsKey(re.Element.ParentMod.Files[ef.FileName].FileNameAndFullPath))
                                {
                                    if ((re.IsSetting) ? !mrg.AddedToSettings : !mrg.AddedToComponents)
                                    {
                                        e.Files.Add(new ModElementFile(mrg.modFile.FileNameAndRelPath));
                                        if (re.IsSetting)
                                            mrg.AddedToSettings = true;
                                        else
                                            mrg.AddedToComponents = true;
                                    }
                                    fAdd = false;
                                    break;
                                }
                            }
                        }

                        if (re.Element.ElementType == ModElementType.ModArt && fMergingArtDef)
                            fAdd = false;

                        if (fAdd)
                        {
                            string strNew = MergeCopyFile(re.Element.ParentMod, ef.FileName, false);
                            ModElementFile efNew = new ModElementFile(strNew);
                            foreach (string strFileName in ef.ImplicitFiles)
                            {
                                strNew = MergeCopyFile(re.Element.ParentMod, strFileName, true);
                                efNew.ImplicitFiles.Add(strNew);
                            }
                            e.Files.Add(efNew);
                        }
                    }
                    if (re.IsSetting)
                        Settings.Elements.Add(e);
                    else
                        Components.Elements.Add(e);
                }

                Clean();
                UpdateModFiles();

                StringBuilder sb = new StringBuilder();
                sb.Append("Merge of ");
                bool fFirst = true;
                foreach (ModChildRef r in ModSet.ChildModRefs)
                {
                    if (fFirst)
                        fFirst = false;
                    else
                        sb.Append("; ");
                    sb.Append(r.Title);
                }
                Properties[ModPropertyType.Teaser] = sb.ToString();

                // Add mod relations
                foreach (ModChildRef r in ModSet.ChildModRefs)
                {
                    Blocks.Items.Add(new ModRelation(r.Id, r.Title));

                    foreach (ModRelation mr in r.mod.Dependencies.Items)
                    {
                        bool fFound = false;
                        foreach (ModChildRef r2 in ModSet.ChildModRefs)
                        {
                            if (mr.Id.Equals(r2.Id, StringComparison.OrdinalIgnoreCase))
                            {
                                fFound = true;
                                break;
                            }
                        }
                        fFound = fFound || Dependencies.Items.ContainsKey(mr.Id);
                        if (!fFound)
                        {
                            Dependencies.Items.Add(new ModRelation(mr.Id, mr.Title));
                        }
                    }

                    foreach (ModRelation mr in r.mod.References.Items)
                    {
                        bool fFound = false;
                        foreach (ModChildRef r2 in ModSet.ChildModRefs)
                        {
                            if (mr.Id.Equals(r2.Id, StringComparison.OrdinalIgnoreCase))
                            {
                                fFound = true;
                                break;
                            }
                        }
                        fFound = fFound || References.Items.ContainsKey(mr.Id);
                        if (!fFound)
                        {
                            References.Items.Add(new ModRelation(mr.Id, mr.Title));
                        }
                    }

                    foreach (ModRelation mr in r.mod.Blocks.Items)
                    {
                        bool fFound = false;
                        fFound = fFound || Blocks.Items.ContainsKey(mr.Id);
                        if (!fFound)
                        {
                            Blocks.Items.Add(new ModRelation(mr.Id, mr.Title));
                        }
                    }
                }

                Version = "1";

                Save();

                if (!Directory.Exists(ModPaths.BackupModsPath))
                    Directory.CreateDirectory(ModPaths.BackupModsPath);

                if (Directory.Exists(strFullBackupPath))
                    ModFileUtils.DeleteDirectory(strFullBackupPath);

                if (Directory.Exists(strFullPath))
                    Directory.Move(strFullPath, strFullBackupPath);

                Directory.Move(strFullTempPath, strFullPath);
                ModsPath = strSavedModsPath;

                ModSetBuilt = true;
            }
            catch (Exception ex)
            {
                try
                {
                    ModFileUtils.DeleteDirectory(strFullTempPath);
                }
                catch
                {

                }
                ModsPath = strSavedModsPath;
                try
                {
                    if (File.Exists(FullPathAndFileName))
                    {
                        Load();
                    }
                    else
                    {
                        Reset();
                    }
                }
                catch
                {

                }

                OnModShowError?.Invoke(ex.Message);
            }
        }
    }

    public class ModDep
    {
        public abstract class ModDepBase : IKeyed
        {
            public string Name;
            public string Key { get { return Name; } }
            public abstract string NameElement { get; }

            public HashedStringList ArtDefDependencyPaths = new HashedStringList();
            public HashedStringList LibraryDependencies = new HashedStringList();
            public HashedStringList PackageDependencies = new HashedStringList();
            public bool? LoadsLibraries = null;

            public void MergeFrom(ModDepBase m)
            {
                ArtDefDependencyPaths.UnionWith(m.ArtDefDependencyPaths);
                LibraryDependencies.UnionWith(m.LibraryDependencies);
                PackageDependencies.UnionWith(m.PackageDependencies);

                if (LoadsLibraries.HasValue || m.LoadsLibraries.HasValue)
                    LoadsLibraries = LoadsLibraries.GetValueOrDefault() || m.LoadsLibraries.GetValueOrDefault();
            }
    
            public bool LoadFromNode(XmlNode n)
            {
                XmlNode xmlName = n[NameElement];
                if (xmlName != null && xmlName.NodeType == XmlNodeType.Element)
                    Name = (xmlName as XmlElement).GetAttribute("text");
                if (string.IsNullOrWhiteSpace(Name))
                    return false;

                foreach (XmlNode n2 in n.ChildNodes)
                {
                    if (n2.NodeType == XmlNodeType.Element)
                    {
                        HashedStringList lstTarget = null;
                        switch(n2.Name)
                        {
                            case "ArtDefDependencyPaths":
                                lstTarget = ArtDefDependencyPaths;
                                break;
                            case "LibraryDependencies":
                                lstTarget = LibraryDependencies;
                                break;
                            case "PackageDependencies":
                                lstTarget = PackageDependencies;
                                break;
                            case "LoadsLibraries":
                                bool f;
                                if (bool.TryParse(n2.GetText(), out f))
                                    LoadsLibraries = f;
                                break;
                        }
                        if (lstTarget != null)
                        {
                            foreach (XmlNode n3 in n2.ChildNodes)
                            {
                                if (n3.Name.Equals("Element") && n3.NodeType == XmlNodeType.Element)
                                {
                                    string s = (n3 as XmlElement).GetAttribute("text");
                                    if (!string.IsNullOrWhiteSpace(s))
                                        lstTarget.Add(s);
                                }
                            }
                        }
                    }
                }

                return LoadsLibraries.HasValue || ArtDefDependencyPaths.Count > 0 || LibraryDependencies.Count > 0 || PackageDependencies.Count > 0;
            }

            public void SaveUnderNode(XmlNode n)
            {
                XmlElement xmlBase = n.AppendNewElement("Element");

                XmlElement e = xmlBase.AppendNewElement(NameElement, null, "text", Name);

                if (ArtDefDependencyPaths.Count > 0)
                {
                    XmlElement eGroup = xmlBase.AppendNewElement("ArtDefDependencyPaths");
                    foreach (string s in ArtDefDependencyPaths)
                        eGroup.AppendNewElement("Element", null, "text", s);
                }

                if (LibraryDependencies.Count > 0)
                {
                    XmlElement eGroup = xmlBase.AppendNewElement("LibraryDependencies");
                    foreach (string s in LibraryDependencies)
                        eGroup.AppendNewElement("Element", null, "text", s);
                }

                if (PackageDependencies.Count > 0)
                {
                    XmlElement eGroup = xmlBase.AppendNewElement("PackageDependencies");
                    foreach (string s in PackageDependencies)
                        eGroup.AppendNewElement("Element", null, "text", s);
                }

                if (LoadsLibraries.HasValue)
                {
                    XmlElement eLoads = xmlBase.AppendNewElement("LoadsLibraries", (LoadsLibraries.Value) ? "true" : "false");
                }
            }
        }

        public class ModDepSystemDependency : ModDepBase
        {
            public override string NameElement { get { return "ConsumerName"; } }
        }

        public class ModDepArtDefDependency : ModDepBase
        {
            public override string NameElement { get { return "ArtDefPath"; } }
        }

        public class ModDepLibraryDependency : ModDepBase
        {
            public override string NameElement { get { return "LibraryName"; } }
        }

        public class ModDepRequiredGameArtId : IKeyed
        {
            public string Name;
            public string Id;
            public string Key { get { return Id; } }
        }

        public string Name;
        public string Id;

        public KeyedList<ModDepSystemDependency> SystemDependencies = new KeyedList<ModDepSystemDependency>();
        public KeyedList<ModDepArtDefDependency> ArtDefDependencies = new KeyedList<ModDepArtDefDependency>();
        public KeyedList<ModDepLibraryDependency> LibraryDependencies = new KeyedList<ModDepLibraryDependency>();
        public KeyedList<ModDepRequiredGameArtId> RequiredGameArtIds = new KeyedList<ModDepRequiredGameArtId>();
        public HashSet<string> hsMergedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public void Clean()
        {
            for (int i = RequiredGameArtIds.Count - 1; i >= 0; i--)
                if (hsMergedIds.Contains(RequiredGameArtIds[i].Id))
                    RequiredGameArtIds.RemoveAt(i);
        }

        public void MergeFrom(ModDep m)
        {
            hsMergedIds.Add(m.Id);

            foreach (var r in m.RequiredGameArtIds)
                if (!RequiredGameArtIds.ContainsKey(r.Key))
                    RequiredGameArtIds.Add(r);

            foreach (var d in m.SystemDependencies)
            {
                if (SystemDependencies.ContainsKey(d.Key))
                    SystemDependencies[d.Key].MergeFrom(d);
                else
                    SystemDependencies.Add(d);
            }

            foreach (var d in m.ArtDefDependencies)
            {
                if (ArtDefDependencies.ContainsKey(d.Key))
                    ArtDefDependencies[d.Key].MergeFrom(d);
                else
                    ArtDefDependencies.Add(d);
            }

            foreach (var d in m.LibraryDependencies)
            {
                if (LibraryDependencies.ContainsKey(d.Key))
                    LibraryDependencies[d.Key].MergeFrom(d);
                else
                    LibraryDependencies.Add(d);
            }
        }

        public string Xml
        {
            get
            {
                Clean();

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement e, e2;

                XmlElement eRoot = xmlDoc.AppendNewElement("AssetObjects_coloncolon_GameDependencyData");

                e = eRoot.AppendNewElement("ID");
                e.AppendNewElement("name", null, "text", Name);
                e.AppendNewElement("id", null, "text", Id);

                if (RequiredGameArtIds.Count > 0)
                {
                    e2 = eRoot.AppendNewElement("RequiredGameArtIDs");
                    foreach(ModDepRequiredGameArtId r in RequiredGameArtIds)
                    {
                        e = e2.AppendNewElement("Element");
                        e.AppendNewElement("name", null, "text", r.Name);
                        e.AppendNewElement("id", null, "text", r.Id);
                    }
                }

                if (SystemDependencies.Count > 0)
                {
                    e = eRoot.AppendNewElement("SystemDependencies");

                    foreach (ModDepBase m in SystemDependencies)
                        m.SaveUnderNode(e);
                }

                if (ArtDefDependencies.Count > 0)
                {
                    e = eRoot.AppendNewElement("ArtDefDependencies");

                    foreach (ModDepBase m in ArtDefDependencies)
                        m.SaveUnderNode(e);
                }

                if (LibraryDependencies.Count > 0)
                {
                    e = eRoot.AppendNewElement("LibraryDependencies");

                    foreach (ModDepBase m in LibraryDependencies)
                        m.SaveUnderNode(e);
                }
                
                string strXml = xmlDoc.GetFormattedText().Replace("_coloncolon_", "::");

                return strXml;
            }
            set
            {
                XmlDocument xmlDoc = new XmlDocument();

                value = value.Replace("::", "_coloncolon_");

                // Poland and Viking DLC .dep files end with a null
                value = value.Replace('\0', ' ');

                xmlDoc.LoadXml(value);

                XmlNode xmlRoot = xmlDoc.DocumentElement;
                if (xmlRoot == null)
                    return;

                foreach (XmlNode n in xmlRoot.ChildNodes)
                {
                    foreach( XmlNode n2 in n)
                    {
                        if (n.NodeType == XmlNodeType.Element && n2.NodeType == XmlNodeType.Element)
                        {
                            switch (n.Name)
                            {
                                case "ID":
                                    if (n2.Name.Equals("name"))
                                        Name = (n2 as XmlElement).GetAttribute("text");
                                    if (n2.Name.Equals("id"))
                                        Id = (n2 as XmlElement).GetAttribute("text");
                                    break;
                                case "RequiredGameArtIDs":
                                    var r = new ModDepRequiredGameArtId();
                                    foreach (XmlNode n3 in n2.ChildNodes)
                                    {
                                        if (n3.Name.Equals("name"))
                                            r.Name = (n3 as XmlElement).GetAttribute("text");
                                        if (n3.Name.Equals("id"))
                                            r.Id = (n3 as XmlElement).GetAttribute("text");
                                        break;
                                    }
                                    if (!string.IsNullOrWhiteSpace(r.Id))
                                        RequiredGameArtIds.Add(r);
                                    break;
                                case "SystemDependencies":
                                    if (n2.Name.Equals("Element"))
                                    {
                                        var d = new ModDepSystemDependency();
                                        if (d.LoadFromNode(n2))
                                            SystemDependencies.Add(d);
                                    }
                                    break;
                                case "ArtDefDependencies":
                                    if (n2.Name.Equals("Element"))
                                    {
                                        var d = new ModDepArtDefDependency();
                                        if (d.LoadFromNode(n2))
                                            ArtDefDependencies.Add(d);
                                    }
                                    break;
                                case "LibraryDependencies":
                                    if (n2.Name.Equals("Element"))
                                    {
                                        var d = new ModDepLibraryDependency();
                                        if (d.LoadFromNode(n2))
                                            LibraryDependencies.Add(d);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public bool Load(string strFileName)
        {
            try
            {
                if (File.Exists(strFileName))
                {
                    string strText = File.ReadAllText(strFileName);
                    Xml = strText;
                    return true;
                }
            }
            catch
            {

            }

            return false;
        }

        public void Save(string strFileName)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(strFileName));
            File.WriteAllText(strFileName, Xml);
        }

    }


    public class ModArtDefNode : IKeyed
    {
        public string Name;
        public string Key { get { return Name; } }
        public XmlElement Node;
        public KeyedList<ModArtDefNode> Children = new KeyedList<ModArtDefNode>();
        public ModArtDefNode(string strName, XmlElement e)
        {
            Name = strName;
            Node = e;
        }
    }

    public class ModArtDef
    {
        public XmlDocument Doc = new XmlDocument();
        public XmlElement RootCollections = null;
        public KeyedList<ModArtDefNode> Collections = new KeyedList<ModArtDefNode>();

        public void Update()
        {
            Collections.Clear();
            RootCollections = null;
            
            XmlNode xmlRoot = Doc.DocumentElement;
            if (xmlRoot == null)
                return;

            XmlNode n = xmlRoot["m_RootCollections"];
            if (n == null || n.NodeType != XmlNodeType.Element)
                return;

            RootCollections = (n as XmlElement);

            foreach( XmlNode xmlCollection in RootCollections.ChildNodes )
            {
                if (xmlCollection.NodeType == XmlNodeType.Element && xmlCollection.Name.Equals("Element"))
                {
                    XmlNode xmlCollectionName = xmlCollection["m_CollectionName"];

                    string strName = null;

                    if (xmlCollectionName != null && xmlCollectionName.NodeType == XmlNodeType.Element)
                        strName = (xmlCollectionName as XmlElement).GetAttribute("text");

                    if (!string.IsNullOrWhiteSpace(strName))
                    {
                        ModArtDefNode col = new ModArtDefNode(strName, xmlCollection as XmlElement);
                        Collections.Add(col);

                        foreach (XmlNode xmlItem in xmlCollection.ChildNodes)
                        {
                            if (xmlItem.NodeType == XmlNodeType.Element && xmlItem.Name.Equals("Element"))
                            {
                                XmlNode xmlItemName = xmlItem["m_Name"];

                                string strItemName = null;

                                if (xmlItemName != null && xmlItemName.NodeType == XmlNodeType.Element)
                                    strItemName = (xmlItemName as XmlElement).GetAttribute("text");

                                if (!string.IsNullOrWhiteSpace(strItemName))
                                    col.Children.Add(new ModArtDefNode(strItemName, xmlItem as XmlElement));
                            }
                        }
                    }
                }
            }
        }

        public void MergeFrom(ModArtDef a)
        {
            foreach(ModArtDefNode col2 in a.Collections)
            {
                ModArtDefNode col1;
                if (Collections.TryGetItem(col2.Key, out col1))
                {
                    foreach( ModArtDefNode item2 in col2.Children)
                    {
                        ModArtDefNode item1;
                        if (col1.Children.TryGetItem(item2.Key, out item1))
                        {
                            XmlNode n = Doc.ImportNode(item2.Node, true);
                            col1.Node.ReplaceChild(n, item1.Node);
                            item1.Node = n as XmlElement;
                        }
                        else
                            col1.Node.AppendChild(Doc.ImportNode(item2.Node, true));
                    }
                }
                else
                {
                    RootCollections.AppendChild(Doc.ImportNode(col2.Node, true));
                }
            }

            Update();
        }

        public string Xml
        {
            get
            {
                string strXml = Doc.GetFormattedText().Replace("_coloncolon_", "::");

                return strXml;
            }
            set
            {
                value = value.Replace("::", "_coloncolon_");
                Doc.LoadXml(value);
                Update();
            }
        }

        public bool Load(string strFileName)
        {
            try
            {
                if (File.Exists(strFileName))
                {
                    string strText = File.ReadAllText(strFileName);
                    Xml = strText;
                    return RootCollections != null;
                }
            }
            catch
            {

            }

            return false;
        }

        public void Save(string strFileName)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(strFileName));
            File.WriteAllText(strFileName, Xml);
        }
    }

    public class ModMergeOptions
    {
        public enum ShellWhen : int
        {
            NeverShell,
            AlwaysShell,
            ShellOnFail,
            Max2Way = AlwaysShell,
            Max3Way = ShellOnFail
        }
        public ShellWhen Shell2Way;
        public ShellWhen Shell3Way = ShellWhen.ShellOnFail;

        public string ShellCmd2Way = @"KDiff3\kdiff3.exe %A %B -o %OUT";
        public string ShellCmd3Way = @"KDiff3\kdiff3.exe %O %A %B -o %OUT";
    }

    public static class ModPaths
    {
        public static string AppPath;
        public static string DocPath;
        public static string ModsPath { get { return (string.IsNullOrEmpty(DocPath)) ? "" : Path.Combine(DocPath, "Mods"); } }
        public static string AssetPath { get { return (string.IsNullOrEmpty(AppPath)) ? "" : Path.Combine(AppPath, "Base"); } }
        public static string DLCPath { get { return (string.IsNullOrEmpty(AppPath)) ? "" : Path.Combine(AppPath, "DLC"); } }
        public static string ModsDB { get { return (string.IsNullOrEmpty(DocPath)) ? "" : Path.Combine(DocPath, "Mods.sqlite"); } }
        public static string TempModsPath { get { return Path.Combine(DocPath, @"Temp\Mods"); } }
        public static string BackupModsPath { get { return Path.Combine(DocPath, @"Backup\Mods"); } }
        public static Dictionary<string, ModFile> AssetFiles;

        public static bool TrySetAppPath(string strAppPath)
        {
            if (Directory.Exists(strAppPath) && Directory.Exists(Path.Combine(strAppPath, @"Base\Assets")))
            {
                AppPath = strAppPath;
                LoadAssetFiles();
                return true;
            }
            else
                return false;
        }

        public static void LoadAssetFiles()
        {
            if (AssetFiles == null && !string.IsNullOrEmpty(AppPath) && Directory.Exists(AppPath))
            {
                AssetFiles = new Dictionary<string, ModFile>(StringComparer.OrdinalIgnoreCase);
                var lstFiles = ModFileUtils.FindFiles(AssetPath, SearchOption.AllDirectories,
                    ModFile.GetFileTypeExtension(ModFileType.Lua),
                    ModFile.GetFileTypeExtension(ModFileType.Xml),
                    ModFile.GetFileTypeExtension(ModFileType.Sql));

                foreach (string strFileName in lstFiles)
                    AssetFiles[Path.GetFileName(strFileName)] = new ModFile(null, ModFileUtils.GetRelativePath(AssetPath, strFileName));
            }
        }

        public static bool AssignPaths()
        {
            if (string.IsNullOrEmpty(AppPath) || !Directory.Exists(AppPath))
            {
                AppPath = FindGame.FindByName("Sid Meier's Civilization VI");
                if (string.IsNullOrEmpty(AppPath))
                    AppPath = FindGame.FindByAppId("289070");
            }

            if (string.IsNullOrEmpty(DocPath) || !Directory.Exists(DocPath))
            {
                DocPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"My Games\Sid Meier's Civilization VI");
                if (!Directory.Exists(DocPath))
                    DocPath = "";
            }

            if (!string.IsNullOrEmpty(DocPath) && !Directory.Exists(ModsPath))
                Directory.CreateDirectory(ModsPath);

            LoadAssetFiles();

            return !(string.IsNullOrEmpty(AppPath) || string.IsNullOrEmpty(DocPath));
        }
    }

    public partial class ModHandler
    {
        public SortedDictionary<string, Mod> Mods = new SortedDictionary<string, Mod>(StringComparer.OrdinalIgnoreCase);

        public delegate void DelModIdConflict(Mod m1, Mod m2, ref bool fHandled);

        public DelModIdConflict OnModIdConflict = null;
        public Mod.DelMod OnModAdded = null;
        public Mod.DelMod OnModDeleted = null;
        public Mod.DelModIdChanging OnModIdChanging = null;
        public Mod.DelMod OnModIdChanged = null;


        protected void DoModDelete(Mod m)
        {
            if (Mods.ContainsKey(m.Id))
                Mods.Remove(m.Id);
            OnModDeleted?.Invoke(m);
        }

        protected void DoModIdChanging(Mod m, string strNewId)
        {
            if (Mods.ContainsKey(strNewId))
                throw new Exception("Mod with Id " + strNewId + "already exists.");
            OnModIdChanging?.Invoke(m, strNewId);
            if (Mods.ContainsKey(m.Id))
                Mods.Remove(m.Id);
        }

        protected void DoModIdChanged(Mod m)
        {
            AddMod(m);
            OnModIdChanged?.Invoke(m);
        }

        public bool TryAddMod(Mod m)
        {
            if (Mods.ContainsKey(m.Id))
            {
                bool fHandled = false;
                OnModIdConflict?.Invoke(Mods[m.Id], m, ref fHandled);
                return fHandled;
            }
            else
            {
                Mods.Add(m.Id, m);
                m.OnModDelete -= DoModDelete;
                m.OnModDelete += DoModDelete;
                m.OnModIdChanging -= DoModIdChanging;
                m.OnModIdChanging += DoModIdChanging;
                m.OnModIdChanged -= DoModIdChanged;
                m.OnModIdChanged += DoModIdChanged;
                OnModAdded?.Invoke(m);
                return true;
            }
        }

        public void AddMod(Mod m)
        {
            if (!TryAddMod(m))
                throw new Exception("Multiple mods with the same Id " + m.Id);
        }

        public void RemoveMod(Mod m)
        {
            if (Mods.ContainsKey(m.Id))
            {
                m.OnModDelete -= DoModDelete;
                m.OnModIdChanging -= DoModIdChanging;
                m.OnModIdChanged -= DoModIdChanged;
                DoModDelete(m);
            }
        }

        public void LoadMods()
        {
            Mods.Clear();

            var lstFiles = ModFileUtils.FindFiles(ModPaths.ModsPath, SearchOption.AllDirectories, "*.modinfo");

            foreach (string s in lstFiles)
            {
                try
                {
                    Mod m = new Mod(ModPaths.ModsPath, ModFileUtils.GetRelativePath(ModPaths.ModsPath, Path.GetDirectoryName(s)), Path.GetFileName(s));
                    AddMod(m);
                }
                catch (Exception ex)
                {
                    Mod.OnModShowError?.Invoke("Error loading mod " + ModFileUtils.StandardizePath(s) + Environment.NewLine + ex.Message, "Error Loading Mod");
                }
            }

            lstFiles = ModFileUtils.FindFiles(ModPaths.DLCPath, SearchOption.AllDirectories, "*.modinfo");

            foreach (string s in lstFiles)
            {
                try
                { 
                    Mod m = new Mod(ModPaths.DLCPath, ModFileUtils.GetRelativePath(ModPaths.DLCPath, Path.GetDirectoryName(s)), Path.GetFileName(s));
                    AddMod(m);
                }
                catch (Exception ex)
                {
                    Mod.OnModShowError?.Invoke("Error loading mod " + ModFileUtils.StandardizePath(s) + Environment.NewLine + ex.Message, "Error Loading Mod");
                }
            }
        }

        public bool CheckBlockingModsEnabled(Mod m, out List<Mod> lst)
        {
            lst = new List<Mod>();

            foreach(ModRelation mr in m.Blocks.Items)
            {
                if (Mods.ContainsKey(mr.Id) && Mods[mr.Id].Enabled && lst.IndexOf(Mods[mr.Id]) < 0)
                    lst.Add(Mods[mr.Id]);
            }

            foreach (KeyValuePair<string, Mod> kv in Mods)
            {
                if (kv.Value != m && kv.Value.Enabled && kv.Value.Blocks.Items.ContainsKey(m.Id) && lst.IndexOf(kv.Value) < 0)
                    lst.Add(kv.Value);
            }

            lst.Sort((Mod m1, Mod m2) => m1.Title.ToLowerInvariant().CompareTo(m2.Title.ToLowerInvariant()));

            return lst.Count > 0;
        }
    }
}
