using MySql.Data.MySqlClient;
using OneBuyMall.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenerator
{
    class Program
    {
        private static string _connStr = "server=localhost;user id=root;password=root;persist security info=True;database=information_schema;charset=utf8";
        private static string dbname = "onebuymall";
        private static string Namespace = "OneBuyMall.DAL";
        static void Main(string[] args)
        {
            DBHelper._connStr = _connStr;
            var tables = DBHelper.ExecuteDataTable(new MySqlCommand("use " + dbname + ";show tables;"));
            CreateModels(tables);
            CreateEnums(tables);
            CreateFuns(tables);
        }
        static string dbtypeto(string _type)
        {
            switch (_type)
            {
                default: return null;
                case "int": return "int";
                case "text":
                case "char":
                case "varchar": return "string";
                case "datetime": return "DateTime";
                case "bit": return "bool";
            }
        }
        private static void CreateModels(DataTable tables)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("namespace " + Namespace);
            sb.AppendLine("{");
            sb.AppendLine("public partial class db_" + dbname);
            sb.AppendLine("{");
            foreach (DataRow table in tables.Rows)
            {
                var tablename = table[0].ToString();
                sb.AppendLine("public partial class " + tablename);
                sb.AppendLine("{");
                var cols = DBHelper.ExecuteDataTable(new MySqlCommand("select `table_name`,`column_name`,`data_type`,`column_key`,`extra` from `columns` where table_schema='" + dbname + "' and table_name='" + tablename + "';")).ToList<DBTableModel>();
                foreach (var col in cols)
                {
                    var _type = dbtypeto(col.data_type);
                    sb.AppendLine("public " + _type + " " + col.column_name + "{ set; get; }");
                }
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            sb.AppendLine("}");
            System.IO.File.WriteAllText(dbname + "_models.cs", sb.ToString());
        }
        private static void CreateEnums(DataTable tables)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace " + Namespace);
            sb.AppendLine("{");
            sb.AppendLine("public partial class db_" + dbname);
            sb.AppendLine("{");
            foreach (DataRow table in tables.Rows)
            {
                var tablename = table[0].ToString();
                sb.AppendLine("public enum e_" + tablename);
                sb.AppendLine("{");
                var cols = DBHelper.ExecuteDataTable(new MySqlCommand("select `table_name`,`column_name`,`data_type`,`column_key`,`extra` from `columns` where table_schema='" + dbname + "' and table_name='" + tablename + "';")).ToList<DBTableModel>();
                foreach (var col in cols)
                {
                    sb.AppendLine(col.column_name + ",");
                }
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            sb.AppendLine("}");
            System.IO.File.WriteAllText(dbname + "_enums.cs", sb.ToString());
        }
        private static void CreateFuns(DataTable tables)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using MySql.Data.MySqlClient;");
            sb.AppendLine("namespace " + Namespace);
            sb.AppendLine("{");
            sb.AppendLine("public partial class db_" + dbname);
            sb.AppendLine("{");
            foreach (DataRow table in tables.Rows)
            {
                var tablename = table[0].ToString();
                sb.AppendLine("public partial class " + tablename);
                sb.AppendLine("{");
                var cols = DBHelper.ExecuteDataTable(new MySqlCommand("select `table_name`,`column_name`,`data_type`,`column_key`,`extra` from `columns` where table_schema='" + dbname + "' and table_name='" + tablename + "';")).ToList<DBTableModel>();
                var keys = cols.FindAll(c => c.column_key == "PRI");

                #region Select
                sb.AppendLine("public static List<" + tablename + "> Select(" + tablename + " model = null, e_" + tablename + "[] cols = null, e_" + tablename + "[] keys = null, e_" + tablename + "[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)");
                sb.AppendLine("{");
                sb.AppendLine("MySqlCommand cmd = new MySqlCommand();");
                sb.AppendLine("var command = \"select {0} from " + tablename + "{1}{2}{3};\";");
                sb.AppendLine("var selectcols = \"\";");
                sb.AppendLine("var selectwhere = \"\";");
                sb.AppendLine("var selectsort = \"\";");
                sb.AppendLine("var selectlimit = \"\";");
                sb.AppendLine("#region selectcols筛选");
                sb.AppendLine("if (cols != null && cols.Length > 0)");
                sb.AppendLine("{");
                foreach (var col in cols)
                {
                    sb.AppendLine("if (cols.Contains(e_" + tablename + "." + col.column_name + "))");
                    sb.AppendLine("{");
                    sb.AppendLine("selectcols += \"`" + col.column_name + "`,\";");
                    sb.AppendLine("}");
                }
                sb.AppendLine("selectcols = selectcols.Substring(0, selectcols.LastIndexOf(','));");
                sb.AppendLine("}");
                sb.AppendLine("else");
                sb.AppendLine("{");
                sb.AppendLine("selectcols = \"*\";");
                sb.AppendLine("}");
                sb.AppendLine("#endregion");
                sb.AppendLine("#region selectkeys 筛选");
                sb.AppendLine("if (keys != null && keys.Length > 0 && model != null)");
                sb.AppendLine("{");
                sb.AppendLine("selectwhere = \" where \";");

                foreach (var col in cols)
                {
                    sb.AppendLine("if (keys.Contains(e_" + tablename + "." + col.column_name + "))");
                    sb.AppendLine("{");
                    sb.AppendLine("selectwhere += \"`" + col.column_name + "`=@" + col.column_name + " and\";");
                    sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + col.column_name + "\", model." + col.column_name + ");");
                    sb.AppendLine("}");
                }
                sb.AppendLine("selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(\" and\"));");
                sb.AppendLine("}");
                sb.AppendLine("#endregion");
                sb.AppendLine("#region sortkeys筛选");
                sb.AppendLine("if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)");
                sb.AppendLine("{");
                sb.AppendLine("selectsort = \" order by \";");
                foreach (var col in cols)
                {
                    sb.AppendLine("if (sortkeys.Contains(e_" + tablename + "." + col.column_name + "))");
                    sb.AppendLine("{");
                    sb.AppendLine("selectsort += \"`" + col.column_name + "`,\";");
                    sb.AppendLine("}");
                }
                sb.AppendLine("selectsort = selectsort.Substring(0, selectsort.LastIndexOf(','));");
                sb.AppendLine("switch (sort)");
                sb.AppendLine("{");
                sb.AppendLine("case Sort.ASC: selectsort += \" ASC\"; break;");
                sb.AppendLine("case Sort.DESC: selectsort += \" DESC\"; break;");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("#endregion");
                sb.AppendLine("#region limt");
                sb.AppendLine("if (limit > 0)");
                sb.AppendLine("{");
                sb.AppendLine("selectlimit = \" limit \" + start + \",\" + limit;");
                sb.AppendLine("}");
                sb.AppendLine("#endregion");
                sb.AppendLine("command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);");
                sb.AppendLine("cmd.CommandText = command;");
                sb.AppendLine("var data = DBHelper.ExecuteDataTable(cmd);");
                sb.AppendLine("return data.ToList<" + tablename + ">();");
                sb.AppendLine("}");
                #endregion
                if (tablename.StartsWith("tb_"))
                {
                    #region Insert
                    sb.AppendLine("public static int Insert(" + tablename + " model, e_" + tablename + "[] cols = null)");
                    sb.AppendLine("{");
                    sb.AppendLine("if (model == null)");
                    sb.AppendLine("return -1;");
                    sb.AppendLine("MySqlCommand cmd = new MySqlCommand();");
                    sb.AppendLine("var command = \"insert into " + tablename + " ({0}) values ({1})\";");
                    sb.AppendLine("var inertcols = \"\";");
                    sb.AppendLine("var inertvalues = \"\";");
                    sb.AppendLine("if (cols != null && cols.Length > 0)");
                    sb.AppendLine("{");
                    foreach (var col in cols)
                    {
                        if (col.extra != "auto_increment")
                        {
                            sb.AppendLine("if (cols.Contains(e_" + tablename + "." + col.column_name + "))");
                            sb.AppendLine("{");
                            sb.AppendLine("inertcols += \"`" + col.column_name + "`,\";");
                            sb.AppendLine("inertvalues += \"" + col.column_name + ",\";");
                            sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + col.column_name + "\", model." + col.column_name + ");");
                            sb.AppendLine("}");
                        }
                    }
                    sb.AppendLine("inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));");
                    sb.AppendLine("inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));");
                    sb.AppendLine("}");
                    sb.AppendLine("else");
                    sb.AppendLine("{");
                    foreach (var col in cols)
                    {
                        if (col.extra != "auto_increment")
                        {
                            sb.AppendLine("inertcols += \"`" + col.column_name + "`,\";");
                            sb.AppendLine("inertvalues += \"" + col.column_name + ",\";");
                            sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + col.column_name + "\", model." + col.column_name + ");");
                        }
                    }
                    sb.AppendLine("}");
                    sb.AppendLine("command = string.Format(command, inertcols, inertvalues);");
                    sb.AppendLine("cmd.CommandText = command;");
                    sb.AppendLine("return DBHelper.ExecuteNonQuery(cmd);");
                    sb.AppendLine("}");
                    #endregion
                    #region Update
                    sb.AppendLine("public static int Update(" + tablename + " model, e_" + tablename + "[] cols = null)");
                    sb.AppendLine("{");
                    sb.AppendLine("MySqlCommand cmd = new MySqlCommand();");
                    sb.AppendLine("var command = \"update " + tablename + " set {0} {1}\";");
                    sb.AppendLine("var updatecols = \"\";");
                    sb.AppendLine("var updatekeys = \"\";");
                    sb.AppendLine("if (cols != null && cols.Length > 0)");
                    sb.AppendLine("{");
                    foreach (var col in cols)
                    {
                        if (col.column_key != "PRI")
                        {
                            sb.AppendLine("if (cols.Contains(e_" + tablename + "." + col.column_name + "))");
                            sb.AppendLine("{");
                            sb.AppendLine("updatecols += \"`" + col.column_name + "`=@" + col.column_name + ",\";");
                            sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + col.column_name + "\", model." + col.column_name + ");");
                            sb.AppendLine("}");
                        }
                    }
                    sb.AppendLine("updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));");
                    sb.AppendLine("}");
                    sb.AppendLine("else");
                    sb.AppendLine("{");
                    foreach (var col in cols)
                    {
                        if (col.column_key != "PRI")
                        {
                            sb.AppendLine("updatecols += \"`" + col.column_name + "`=@" + col.column_name + ",\";");
                            sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + col.column_name + "\", model." + col.column_name + ");");
                        }
                    }
                    sb.AppendLine("updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));");
                    sb.AppendLine("}");
                    if (keys.Count > 0)
                    {
                        sb.AppendLine("updatekeys += \" where \";");
                        foreach (var key in keys)
                        {
                            sb.AppendLine("updatekeys += \" `" + key.column_name + "`=@" + key.column_name + " and\";");
                            sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + key.column_name + "\", model." + key.column_name + ");");
                        }
                        sb.AppendLine("updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(\" and\"));");
                    }
                    //sb.AppendLine("var updatekeys = " where `id`=@id";
                    //sb.AppendLine("cmd.Parameters.AddWithValue("@id", model.id);
                    sb.AppendLine("command = string.Format(command, updatecols, updatekeys);");
                    sb.AppendLine("cmd.CommandText = command;");
                    sb.AppendLine("return DBHelper.ExecuteNonQuery(cmd);");
                    sb.AppendLine("}");
                    #endregion
                    #region Delete
                    sb.AppendLine("public static int Delete(" + tablename + " model)");
                    sb.AppendLine("{");
                    sb.AppendLine("MySqlCommand cmd = new MySqlCommand();");
                    sb.AppendLine("var command = \"delete from " + tablename + "{0}\";");
                    sb.AppendLine("var deletekeys = \"\";");
                    if (keys.Count > 0)
                    {
                        sb.AppendLine("deletekeys += \" where \";");
                        foreach (var key in keys)
                        {
                            sb.AppendLine("deletekeys += \" `" + key.column_name + "`=@" + key.column_name + " and\";");
                            sb.AppendLine("cmd.Parameters.AddWithValue(\"@" + key.column_name + "\", model." + key.column_name + ");");
                        }
                        sb.AppendLine("deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(\" and\"));");
                    }
                    sb.AppendLine("command = string.Format(command, deletekeys);");
                    sb.AppendLine("cmd.CommandText = command;");
                    sb.AppendLine("return DBHelper.ExecuteNonQuery(cmd);");
                    sb.AppendLine("}");
                    #endregion
                }
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            sb.AppendLine("}");
            System.IO.File.WriteAllText(dbname + "_funs.cs", sb.ToString());
        }
    }
}
