using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Civ6Mod
{
    public partial class Mod
    {
        private static SQLiteConnection m_DB = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        public static SQLiteConnection DB
        {
            get
            {
                if (m_DB == null)
                {
                    try
                    {
                        m_DB = new SQLiteConnection(ModPaths.ModsDB);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Could not connect to mod DB: " + e.Message, e);
                    }
                }
                return m_DB;
            }
        }

        static partial void GetCompiledWithSql(ref bool f)
        {
            f = true;
        }

        partial void SqlWriteEnabledAndVisible()
        {
            DB.Execute("UPDATE Mods SET Enabled = ? WHERE ModId = ?", (Enabled) ? 1 : 0, Id);
            DB.Execute("DELETE FROM ModProperties WHERE Name = 'ShowInBrowser' AND ModRowId IN (SELECT ModRowId FROM Mods WHERE ModId = ?)", Id);
            if (!Visible)
                DB.Execute("INSERT INTO ModProperties (ModRowId, Name, Value) SELECT ModRowId, 'ShowInBrowser', 'AlwaysHidden' FROM Mods WHERE ModId = ?", Id);
        }

        private class SQLModInfo
        {
            public int ModRowId { get; set; }
            public string ModId { get; set; }
            public int Enabled { get; set; }
            public string Path { get; set; }
            public long LastWriteTime { get; set; }
            public int Invisible { get; set; }
        }

        partial void SqlReadValues()
        {
            List<SQLModInfo> lst = DB.Query<SQLModInfo>(
                    "SELECT m.ModRowId, ModId, Enabled, Path, LastWriteTime, " +
                        "(SELECT COUNT(*) FROM ModProperties p WHERE p.ModRowId = m.ModRowId AND Name = 'ShowInBrowser' AND Value = 'AlwaysHidden') AS Invisible " +
                    "FROM Mods m " +
                    "INNER JOIN ScannedFiles f on m.ScannedFileRowId = f.ScannedFileRowID " +
                    "WHERE ModId = ?", Id);

            if (lst.Count > 0)
            {
                SQLModInfo info = lst[0];

                m_dtSqlModifiedDT = ModFileUtils.FiraxisDTToDT(info.LastWriteTime);
                m_fSqlEnabled = info.Enabled != 0;
                m_fSqlVisible = info.Invisible == 0;
            }
            else
                m_dtSqlModifiedDT = null;
        }

        partial void SqlDelete()
        {
            DB.Execute("DELETE FROM Mods WHERE ModId = ?", Id);
        }

    }
}
