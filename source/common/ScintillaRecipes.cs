using System.Drawing;

namespace ScintillaNET
{
    public static class ScintillaRecipes
    {
        public static void ApplyLuaStyle(this Scintilla sci)
        {
            sci.StyleResetDefault();
            sci.Styles[Style.Default].ForeColor = Color.Black;
            sci.Styles[Style.Default].Font = "Courier New";
            sci.StyleClearAll();

            // Show line numbers
            sci.Margins[0].Width = 45;
            sci.Margins[2].Width = 0;

            sci.Lexer = Lexer.Lua;

            sci.Styles[Style.Lua.Comment].ForeColor = Color.DarkGreen;
            sci.Styles[Style.Lua.CommentLine].ForeColor = Color.DarkGreen;
            sci.Styles[Style.Lua.CommentDoc].ForeColor = Color.DarkGreen;
            sci.Styles[Style.Lua.Number].ForeColor = Color.Fuchsia;
            sci.Styles[Style.Lua.Word].ForeColor = Color.Blue;
            sci.Styles[Style.Lua.String].ForeColor = Color.Fuchsia;
            sci.Styles[Style.Lua.Character].ForeColor = Color.Fuchsia;
            sci.Styles[Style.Lua.LiteralString].ForeColor = Color.Fuchsia;
            sci.Styles[Style.Lua.Preprocessor].ForeColor = Color.Navy;
            sci.Styles[Style.Lua.StringEol].ForeColor = Color.Teal;
            sci.Styles[Style.Lua.Word2].ForeColor = Color.DarkMagenta;
            sci.Styles[Style.Lua.Word3].ForeColor = Color.DarkRed;
            sci.Styles[Style.Lua.Word4].ForeColor = Color.SaddleBrown;

            sci.SetKeywords(0, @"and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
            sci.SetKeywords(1, @"assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV number");
            sci.SetKeywords(2, @"string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.count table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            sci.SetKeywords(3, @"coroutine.isyieldable coroutine.running io.popen package.config package.searchers package.searchpath coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload");
            sci.SetKeywords(4, @"debug.getfenv debug.getmetatable debug.getregistry debug.setfenv debug.setmetatable");
        }

        public static void ApplyXmlStyle(this Scintilla sci)
        {
            sci.StyleResetDefault();
            sci.Styles[Style.Default].ForeColor = Color.Black;
            sci.Styles[Style.Default].Font = "Courier New";
            sci.StyleClearAll();

            // Set the XML Lexer
            sci.Lexer = Lexer.Xml;

            // Show line numbers
            sci.Margins[0].Width = 45;

            // Enable folding
            sci.SetProperty("fold", "1");
            sci.SetProperty("fold.compact", "1");
            sci.SetProperty("fold.html", "1");

            // Use Margin 2 for fold markers
            sci.Margins[2].Type = MarginType.Symbol;
            sci.Margins[2].Mask = Marker.MaskFolders;
            sci.Margins[2].Sensitive = true;
            sci.Margins[2].Width = 12;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                sci.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                sci.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            sci.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            sci.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            sci.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            sci.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            sci.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            sci.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            sci.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            sci.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            sci.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            sci.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Set the Styles
            sci.Styles[Style.Xml.Attribute].ForeColor = Color.SaddleBrown;
            sci.Styles[Style.Xml.Entity].ForeColor = Color.SaddleBrown;
            sci.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            sci.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            sci.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            sci.Styles[Style.Xml.DoubleString].ForeColor = Color.Fuchsia;
            sci.Styles[Style.Xml.SingleString].ForeColor = Color.Fuchsia;
        }

        public static void ApplySqlStyle(this Scintilla sci)
        {
            sci.StyleResetDefault();
            sci.Styles[Style.Default].ForeColor = Color.Black;
            sci.Styles[Style.Default].Font = "Courier New";
            sci.StyleClearAll();

            // Set the SQL Lexer
            sci.Lexer = Lexer.Sql;

            // Show line numbers
            sci.Margins[0].Width = 45;
            sci.Margins[2].Width = 0;

            // Set the Styles
            sci.Styles[Style.Sql.Comment].ForeColor = Color.Green;
            sci.Styles[Style.Sql.CommentLine].ForeColor = Color.Green;
            sci.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.Green;
            sci.Styles[Style.Sql.Number].ForeColor = Color.Maroon;
            sci.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            sci.Styles[Style.Sql.Word2].ForeColor = Color.Fuchsia;
            sci.Styles[Style.Sql.User1].ForeColor = Color.Gray;
            sci.Styles[Style.Sql.User2].ForeColor = Color.FromArgb(255, 00, 128, 192);    //Medium Blue-Green
            sci.Styles[Style.Sql.String].ForeColor = Color.Red;
            sci.Styles[Style.Sql.Character].ForeColor = Color.Red;
            sci.Styles[Style.Sql.Operator].ForeColor = Color.Black;

            // Set keyword lists
            // Word = 0
            sci.SetKeywords(0, @"add alter as authorization backup begin bigint binary bit break browse bulk by cascade case catch check checkpoint close clustered column commit compute constraint containstable continue create current cursor cursor database date datetime datetime2 datetimeoffset dbcc deallocate decimal declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor float for foreign freetext freetexttable from full function goto grant group having hierarchyid holdlock identity identity_insert identitycol if image index insert int intersect into key kill lineno load merge money national nchar nocheck nocount nolock nonclustered ntext numeric nvarchar of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext real reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select set setuser shutdown smalldatetime smallint smallmoney sql_variant statistics table table tablesample text textsize then time timestamp tinyint to top tran transaction trigger truncate try union unique uniqueidentifier update updatetext use user values varbinary varchar varying view waitfor when where while with writetext xml ");
            // Word2 = 1
            sci.SetKeywords(1, @"ascii cast char charindex ceiling coalesce collate contains convert current_date current_time current_timestamp current_user floor isnull max min nullif object_id session_user substring system_user tsequal ");
            // User1 = 4
            sci.SetKeywords(4, @"all and any between cross exists in inner is join left like not null or outer pivot right some unpivot ( ) * ");
            // User2 = 5
            sci.SetKeywords(5, @"sys objects sysobjects ");
        }
    }
}
