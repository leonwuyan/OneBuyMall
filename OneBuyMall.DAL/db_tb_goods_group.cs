using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace OneBuyMall.DAL
{
    public static class db_tb_goods_group
    {
        public class tb_goods_group
        {
            public int id { set; get; }
            public string name { set; get; }
        }
        public enum e_tb_goods_group
        {
            id,
            name
        }
        public static List<tb_goods_group> Select(tb_goods_group model = null, e_tb_goods_group[] cols = null, e_tb_goods_group[] keys = null, e_tb_goods_group[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
        {
            MySqlCommand cmd = new MySqlCommand();
            var command = "select {0} from tb_goods_group{1}{2}{3};";
            var selectcols = "";
            var selectwhere = "";
            var selectsort = "";
            var selectlimit = "";
            #region selectcols筛选
            if (cols != null && cols.Length > 0)
            {
                if (cols.Contains(e_tb_goods_group.id))
                {
                    selectcols += "`id`,";
                }
                if (cols.Contains(e_tb_goods_group.name))
                {
                    selectcols += "`name`,";
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
                if (keys.Contains(e_tb_goods_group.id))
                {
                    selectwhere += "`id`=@id and";
                    cmd.Parameters.AddWithValue("@id", model.id);
                }
                if (keys.Contains(e_tb_goods_group.name))
                {
                    selectwhere += "`name`=@name and";
                    cmd.Parameters.AddWithValue("@name", model.name);
                }
                selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
            }
            #endregion
            #region sortkeys筛选
            if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
            {
                selectsort = " order by ";
                if (sortkeys.Contains(e_tb_goods_group.id))
                {
                    selectsort += "`id`,";
                }
                if (sortkeys.Contains(e_tb_goods_group.name))
                {
                    selectsort += "`name`,";
                }
                selectsort = selectsort.Substring(0, selectsort.LastIndexOf(','));
                switch(sort)
                {
                    case Sort.ASC: selectsort += " ASC"; break;
                    case Sort.DESC: selectsort += " DESC"; break;
                }
            }
            #endregion
            #region limt
            if (limit > 0)
            {
                selectlimit = " limit " + start + "," + limit;
            }
            #endregion
            command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);

            cmd.CommandText = command;

            var data = DBHelper.ExecuteDataTable(cmd);
            return data.ToList<tb_goods_group>();
        }
        public static int Insert(tb_goods_group model, e_tb_goods_group[] cols = null)
        {
            if (model == null)
                return -1;
            MySqlCommand cmd = new MySqlCommand();
            var command = "insert into tb_goods_group ({0}) values ({1})";
            var inertcols = "";
            var inertvalues = "";
            if (cols != null && cols.Length > 0)
            {
                if (cols.Contains(e_tb_goods_group.name))
                {
                    inertcols += "`name`,";
                    inertvalues += "@name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                }
                inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
            }
            else
            {
                inertcols = "`name`";
                inertvalues = "@name";
                cmd.Parameters.AddWithValue("@name", model.name);
            }
            command = string.Format(command, inertcols, inertvalues);

            cmd.CommandText = command;

            return DBHelper.ExecuteNonQuery(cmd);
        }
        public static int Update(tb_goods_group model, e_tb_goods_group[] cols = null)
        {
            MySqlCommand cmd = new MySqlCommand();
            var command = "update tb_goods_group set {0} {1}";
            var updatecols = "";
            if (cols != null && cols.Length > 0)
            {
                if (cols.Contains(e_tb_goods_group.name))
                {
                    updatecols += "`name`=@name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                }
                updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
            }
            else
            {
                updatecols = "`name`=@name";
                cmd.Parameters.AddWithValue("@name", model.name);
            }
            var updatekeys = " where `id`=@id";
            cmd.Parameters.AddWithValue("@id", model.id);
            command = string.Format(command, updatecols, updatekeys);

            cmd.CommandText = command;

            return DBHelper.ExecuteNonQuery(cmd);
        }
        public static int Delete(tb_goods_group model)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "delete from tb_goods_group where `id`=@id";
            cmd.Parameters.AddWithValue("@id", model.id);
            return DBHelper.ExecuteNonQuery(cmd);
        }

    }
}
