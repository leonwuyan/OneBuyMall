using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall.DAL
{
    public static class db_tb_config
    {
        public class tb_config
        {
            public int id { set; get; }
            public string sitename { set; get; }
            public string keywords { set; get; }
            public string desc { set; get; }
        }
        public enum e_tb_config
        {
            id,
            sitename,
            keywords,
            desc
        }
        public static List<tb_config> Select(tb_config model = null, e_tb_config[] cols = null, e_tb_config[] keys = null, e_tb_config[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
        {
            MySqlCommand cmd = new MySqlCommand();
            var command = "select {0} from tb_config{1}{2}{3};";
            var selectcols = "";
            var selectwhere = "";
            var selectsort = "";
            var selectlimit = "";
            #region selectcols筛选
            if (cols != null && cols.Length > 0)
            {
                if (cols.Contains(e_tb_config.id))
                {
                    selectcols += "`id`,";
                }
                if (cols.Contains(e_tb_config.sitename))
                {
                    selectcols += "`sitename`,";
                }
                if (cols.Contains(e_tb_config.keywords))
                {
                    selectcols += "`keywords`,";
                }
                if (cols.Contains(e_tb_config.desc))
                {
                    selectcols += "`desc`,";
                }
                selectcols = selectcols.Substring(0, selectcols.LastIndexOf(','));
            }
            else
            {
                selectcols = "*";
            }
            #endregion
            #region selectkeys 筛选
            if (keys != null && keys.Length > 0 && model != null)
            {
                selectwhere = " where ";
                if (keys.Contains(e_tb_config.id))
                {
                    selectwhere += "`id`=@id and";
                    cmd.Parameters.AddWithValue("@id", model.id);
                }
                if (keys.Contains(e_tb_config.sitename))
                {
                    selectwhere += "`sitename`=@sitename and";
                    cmd.Parameters.AddWithValue("@sitename", model.sitename);
                }
                if (keys.Contains(e_tb_config.keywords))
                {
                    selectwhere += "`keywords`=@keywords and";
                    cmd.Parameters.AddWithValue("@keywords", model.keywords);
                }
                if (keys.Contains(e_tb_config.desc))
                {
                    selectwhere += "`desc`=@desc and";
                    cmd.Parameters.AddWithValue("@desc", model.desc);
                }
                selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
            }
            #endregion
            #region sortkeys筛选

            if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
            {
                selectsort = " order by ";
                if (sortkeys.Contains(e_tb_config.id))
                {
                    selectsort += "`id`,";
                }
                if (sortkeys.Contains(e_tb_config.sitename))
                {
                    selectsort += "`sitename`,";
                }
                if (sortkeys.Contains(e_tb_config.keywords))
                {
                    selectsort += "`keywords`,";
                }
                if (sortkeys.Contains(e_tb_config.desc))
                {
                    selectsort += "`desc`,";
                }
                selectsort = selectsort.Substring(0, selectsort.LastIndexOf(','));
                switch (sort)
                {
                    case Sort.ASC: selectsort += " ASC"; break;
                    case Sort.DESC: selectsort += " DESC"; break;
                }
            }
            #endregion
            #region limt
            if(limit > 0)
            {
                selectlimit = " limit " + start + "," + limit;
            }
            #endregion
            command = string.Format(command, selectcols, selectwhere,selectsort, selectlimit);

            cmd.CommandText = command;

            var data = DBHelper.ExecuteDataTable(cmd);
            return data.ToList<tb_config>();
        }
        public static int Insert(tb_config model, e_tb_config[] cols = null)
        {
            if (model == null)
                return -1;
            MySqlCommand cmd = new MySqlCommand();
            var command = "insert into tb_config ({0}) values ({1})";
            var inertcols = "";
            var inertvalues = "";
            if (cols != null && cols.Length > 0)
            {
                if (cols.Contains(e_tb_config.sitename))
                {
                    inertcols += "`sitename`,";
                    inertvalues += "@sitename,";
                    cmd.Parameters.AddWithValue("@sitename", model.sitename);
                }
                if (cols.Contains(e_tb_config.keywords))
                {
                    inertcols += "`keywords`,";
                    inertvalues += "@keywords,";
                    cmd.Parameters.AddWithValue("@keywords", model.keywords);
                }
                if (cols.Contains(e_tb_config.desc))
                {
                    inertcols += "`desc`,";
                    inertvalues += "@desc,";
                    cmd.Parameters.AddWithValue("@desc", model.desc);
                }
                inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
            }
            else
            {
                inertcols = "`sitename`,`keywords`,`desc`";
                inertvalues = "@sitename,@keywords,@desc";
                cmd.Parameters.AddWithValue("@sitename", model.sitename);
                cmd.Parameters.AddWithValue("@keywords", model.keywords);
                cmd.Parameters.AddWithValue("@desc", model.desc);
            }
            command = string.Format(command, inertcols, inertvalues);

            cmd.CommandText = command;

            return DBHelper.ExecuteNonQuery(cmd);
        }
        public static int Update(tb_config model, e_tb_config[] cols = null)
        {
            MySqlCommand cmd = new MySqlCommand();
            var command = "update tb_config set {0} {1}";
            var updatecols = "";
            if (cols != null && cols.Length > 0)
            {
                if (cols.Contains(e_tb_config.sitename))
                {
                    updatecols += "`sitename`=@sitename,";
                    cmd.Parameters.AddWithValue("@sitename", model.sitename);
                }
                if (cols.Contains(e_tb_config.keywords))
                {
                    updatecols += "`keywords`=@keywords,";
                    cmd.Parameters.AddWithValue("@keywords", model.keywords);
                }
                if (cols.Contains(e_tb_config.desc))
                {
                    updatecols += "`desc`=@desc,";
                    cmd.Parameters.AddWithValue("@desc", model.desc);
                }
                updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
            }
            else
            {
                updatecols = "`sitename`=@sitename,`keywords`=@keywords,`desc`=@desc";
                cmd.Parameters.AddWithValue("@sitename", model.sitename);
                cmd.Parameters.AddWithValue("@keywords", model.keywords);
                cmd.Parameters.AddWithValue("@desc", model.desc);
            }
            var updatekeys = " where `id`=@id";
            cmd.Parameters.AddWithValue("@id", model.id);
            command = string.Format(command, updatecols, updatekeys);

            cmd.CommandText = command;

            return DBHelper.ExecuteNonQuery(cmd);
        }
        public static int Delete(tb_config model)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "delete from tb_config where `id`=@id";
            cmd.Parameters.AddWithValue("@id", model.id);
            return DBHelper.ExecuteNonQuery(cmd);
        }
    }
}