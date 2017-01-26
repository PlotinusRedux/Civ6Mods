using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Microsoft.Win32;


namespace SteamGame
{
    public class FindGame
    {
        public static string FindByName(string strName)
        {
            List<string> lstAppPaths = GetAppPaths();

            foreach (string strAppPath in lstAppPaths)
            {
                foreach (string strFileName in Directory.EnumerateFiles(strAppPath, "*.acf"))
                { 
                    string[] astrFile = File.ReadAllLines(strFileName);
                    foreach (string strLine in astrFile)
                    {
                        if (-1 < strLine.IndexOf("\"name\"", StringComparison.OrdinalIgnoreCase) )
                        {
                            if (strName.Equals(GetAcfValue(strLine), StringComparison.OrdinalIgnoreCase))
                            {
                                foreach (string strLine2 in astrFile)
                                {
                                    if (-1 < strLine2.IndexOf("\"installdir\"", StringComparison.OrdinalIgnoreCase))
                                    {
                                        string strPath = GetAcfValue(strLine2);
                                        if (strPath.Length > 0)
                                        {
                                            strPath = Path.Combine(strAppPath, "common", strPath);
                                            if (Directory.Exists(strPath))
                                            {
                                                return strPath;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }

            return "";
        }

        public static string FindByAppId(string strAppId)
        {
            List<string> lstAppPaths = GetAppPaths();

            foreach (string strAppPath in lstAppPaths)
            {
                string strFileName = Path.Combine(strAppPath, string.Format("appmanifest_{0}.acf", strAppId));

                if (File.Exists(strFileName))
                {
                    string[] astrFile = File.ReadAllLines(strFileName);
                    foreach (string strLine in astrFile)
                    {
                        if (-1 < strLine.IndexOf("\"installdir\"", StringComparison.OrdinalIgnoreCase))
                        {
                            string strPath = GetAcfValue(strLine);
                            if (!string.IsNullOrEmpty(strPath) )
                            {
                                strPath = Path.Combine(strAppPath, "common", strPath);
                                if (Directory.Exists(strPath))
                                {
                                    return strPath;
                                }
                            }
                        }
                    }
                }
            }

            return "";
        }


        private static void AddPath(HashSet<string> hsPaths, string strPath)
        {
            if (!string.IsNullOrEmpty(strPath) && !hsPaths.Contains(strPath) && Directory.Exists(strPath))
                hsPaths.Add(strPath);
        }

        private static string GetAcfValue(string strLine)
        {
            string strValue = "";

            int i = strLine.LastIndexOf('"');
            if (i > 0)
            {
                int j = strLine.LastIndexOf('"', i - 1);
                if (i - j > 1)
                {
                    strValue = strLine.Substring(j + 1, i - j - 1);
                    strValue = strValue.Replace(@"\\", @"\");
                }
            }

            return strValue;
        }

        private static List<string> GetAppPaths()
        {
            List<string> lstPaths = new List<string>();

            try
            {
                using (RegistryKey rkSteam = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam"))
                {
                    if (rkSteam != null)
                    {
                        String strSteamPath = (rkSteam.GetValue("SteamPath", "") as string).Replace('/', '\\');

                        if (!string.IsNullOrEmpty(strSteamPath))
                        {
                            HashSet<string> hsPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                            AddPath(hsPaths, Path.Combine(strSteamPath, "steamapps"));

                            string strCfgFile = Path.Combine(strSteamPath, @"config\config.vdf");
                            if (File.Exists(strCfgFile))
                            {
                                string[] astrFile = File.ReadAllLines(strCfgFile);
                                foreach (string strLine in astrFile)
                                {
                                    if ( -1 < strLine.IndexOf("\"BaseInstallFolder", StringComparison.OrdinalIgnoreCase) )
                                    {
                                        AddPath(hsPaths, Path.Combine( GetAcfValue(strLine), "steamapps"));
                                    }
                                }
                            }

                            lstPaths.AddRange(hsPaths);
                        }
                    }
                }
            }
            catch
            {
                //just return empty list
            }

            return lstPaths;
        }
    }

}
 