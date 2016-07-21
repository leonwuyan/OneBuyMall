using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace OneBuyMall.DAL
{
    public partial class db_onebuymall
    {
        public partial class tb_admin
        {
            public static List<tb_admin> Select(tb_admin model = null, e_tb_admin[] cols = null, e_tb_admin[] keys = null, e_tb_admin[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_admin{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_admin.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_admin.name))
                    {
                        selectcols += "`name`,";
                    }
                    if (cols.Contains(e_tb_admin.pass))
                    {
                        selectcols += "`pass`,";
                    }
                    if (cols.Contains(e_tb_admin.permission))
                    {
                        selectcols += "`permission`,";
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
                    if (keys.Contains(e_tb_admin.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_admin.name))
                    {
                        selectwhere += "`name`=@name and";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (keys.Contains(e_tb_admin.pass))
                    {
                        selectwhere += "`pass`=@pass and";
                        cmd.Parameters.AddWithValue("@pass", model.pass);
                    }
                    if (keys.Contains(e_tb_admin.permission))
                    {
                        selectwhere += "`permission`=@permission and";
                        cmd.Parameters.AddWithValue("@permission", model.permission);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_admin.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_admin.name))
                    {
                        selectsort += "`name`,";
                    }
                    if (sortkeys.Contains(e_tb_admin.pass))
                    {
                        selectsort += "`pass`,";
                    }
                    if (sortkeys.Contains(e_tb_admin.permission))
                    {
                        selectsort += "`permission`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_admin>();
            }
            public static int Insert(tb_admin model, e_tb_admin[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_admin ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_admin.name))
                    {
                        inertcols += "`name`,";
                        inertvalues += "name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (cols.Contains(e_tb_admin.pass))
                    {
                        inertcols += "`pass`,";
                        inertvalues += "pass,";
                        cmd.Parameters.AddWithValue("@pass", model.pass);
                    }
                    if (cols.Contains(e_tb_admin.permission))
                    {
                        inertcols += "`permission`,";
                        inertvalues += "permission,";
                        cmd.Parameters.AddWithValue("@permission", model.permission);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`name`,";
                    inertvalues += "name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    inertcols += "`pass`,";
                    inertvalues += "pass,";
                    cmd.Parameters.AddWithValue("@pass", model.pass);
                    inertcols += "`permission`,";
                    inertvalues += "permission,";
                    cmd.Parameters.AddWithValue("@permission", model.permission);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_admin model, e_tb_admin[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_admin set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_admin.name))
                    {
                        updatecols += "`name`=@name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (cols.Contains(e_tb_admin.pass))
                    {
                        updatecols += "`pass`=@pass,";
                        cmd.Parameters.AddWithValue("@pass", model.pass);
                    }
                    if (cols.Contains(e_tb_admin.permission))
                    {
                        updatecols += "`permission`=@permission,";
                        cmd.Parameters.AddWithValue("@permission", model.permission);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`name`=@name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    updatecols += "`pass`=@pass,";
                    cmd.Parameters.AddWithValue("@pass", model.pass);
                    updatecols += "`permission`=@permission,";
                    cmd.Parameters.AddWithValue("@permission", model.permission);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_admin model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_admin{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_admin_permission
        {
            public static List<tb_admin_permission> Select(tb_admin_permission model = null, e_tb_admin_permission[] cols = null, e_tb_admin_permission[] keys = null, e_tb_admin_permission[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_admin_permission{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_admin_permission.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_admin_permission.permission))
                    {
                        selectcols += "`permission`,";
                    }
                    if (cols.Contains(e_tb_admin_permission.control))
                    {
                        selectcols += "`control`,";
                    }
                    if (cols.Contains(e_tb_admin_permission.action))
                    {
                        selectcols += "`action`,";
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
                    if (keys.Contains(e_tb_admin_permission.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_admin_permission.permission))
                    {
                        selectwhere += "`permission`=@permission and";
                        cmd.Parameters.AddWithValue("@permission", model.permission);
                    }
                    if (keys.Contains(e_tb_admin_permission.control))
                    {
                        selectwhere += "`control`=@control and";
                        cmd.Parameters.AddWithValue("@control", model.control);
                    }
                    if (keys.Contains(e_tb_admin_permission.action))
                    {
                        selectwhere += "`action`=@action and";
                        cmd.Parameters.AddWithValue("@action", model.action);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_admin_permission.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_admin_permission.permission))
                    {
                        selectsort += "`permission`,";
                    }
                    if (sortkeys.Contains(e_tb_admin_permission.control))
                    {
                        selectsort += "`control`,";
                    }
                    if (sortkeys.Contains(e_tb_admin_permission.action))
                    {
                        selectsort += "`action`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_admin_permission>();
            }
            public static int Insert(tb_admin_permission model, e_tb_admin_permission[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_admin_permission ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_admin_permission.permission))
                    {
                        inertcols += "`permission`,";
                        inertvalues += "permission,";
                        cmd.Parameters.AddWithValue("@permission", model.permission);
                    }
                    if (cols.Contains(e_tb_admin_permission.control))
                    {
                        inertcols += "`control`,";
                        inertvalues += "control,";
                        cmd.Parameters.AddWithValue("@control", model.control);
                    }
                    if (cols.Contains(e_tb_admin_permission.action))
                    {
                        inertcols += "`action`,";
                        inertvalues += "action,";
                        cmd.Parameters.AddWithValue("@action", model.action);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`permission`,";
                    inertvalues += "permission,";
                    cmd.Parameters.AddWithValue("@permission", model.permission);
                    inertcols += "`control`,";
                    inertvalues += "control,";
                    cmd.Parameters.AddWithValue("@control", model.control);
                    inertcols += "`action`,";
                    inertvalues += "action,";
                    cmd.Parameters.AddWithValue("@action", model.action);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_admin_permission model, e_tb_admin_permission[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_admin_permission set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_admin_permission.permission))
                    {
                        updatecols += "`permission`=@permission,";
                        cmd.Parameters.AddWithValue("@permission", model.permission);
                    }
                    if (cols.Contains(e_tb_admin_permission.control))
                    {
                        updatecols += "`control`=@control,";
                        cmd.Parameters.AddWithValue("@control", model.control);
                    }
                    if (cols.Contains(e_tb_admin_permission.action))
                    {
                        updatecols += "`action`=@action,";
                        cmd.Parameters.AddWithValue("@action", model.action);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`permission`=@permission,";
                    cmd.Parameters.AddWithValue("@permission", model.permission);
                    updatecols += "`control`=@control,";
                    cmd.Parameters.AddWithValue("@control", model.control);
                    updatecols += "`action`=@action,";
                    cmd.Parameters.AddWithValue("@action", model.action);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_admin_permission model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_admin_permission{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_config
        {
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
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
                    if (cols.Contains(e_tb_config.id))
                    {
                        inertcols += "`id`,";
                        inertvalues += "id,";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (cols.Contains(e_tb_config.sitename))
                    {
                        inertcols += "`sitename`,";
                        inertvalues += "sitename,";
                        cmd.Parameters.AddWithValue("@sitename", model.sitename);
                    }
                    if (cols.Contains(e_tb_config.keywords))
                    {
                        inertcols += "`keywords`,";
                        inertvalues += "keywords,";
                        cmd.Parameters.AddWithValue("@keywords", model.keywords);
                    }
                    if (cols.Contains(e_tb_config.desc))
                    {
                        inertcols += "`desc`,";
                        inertvalues += "desc,";
                        cmd.Parameters.AddWithValue("@desc", model.desc);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`id`,";
                    inertvalues += "id,";
                    cmd.Parameters.AddWithValue("@id", model.id);
                    inertcols += "`sitename`,";
                    inertvalues += "sitename,";
                    cmd.Parameters.AddWithValue("@sitename", model.sitename);
                    inertcols += "`keywords`,";
                    inertvalues += "keywords,";
                    cmd.Parameters.AddWithValue("@keywords", model.keywords);
                    inertcols += "`desc`,";
                    inertvalues += "desc,";
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
                var updatekeys = "";
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
                    updatecols += "`sitename`=@sitename,";
                    cmd.Parameters.AddWithValue("@sitename", model.sitename);
                    updatecols += "`keywords`=@keywords,";
                    cmd.Parameters.AddWithValue("@keywords", model.keywords);
                    updatecols += "`desc`=@desc,";
                    cmd.Parameters.AddWithValue("@desc", model.desc);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_config model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_config{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_customer
        {
            public static List<tb_customer> Select(tb_customer model = null, e_tb_customer[] cols = null, e_tb_customer[] keys = null, e_tb_customer[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_customer{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_customer.name))
                    {
                        selectcols += "`name`,";
                    }
                    if (cols.Contains(e_tb_customer.nickname))
                    {
                        selectcols += "`nickname`,";
                    }
                    if (cols.Contains(e_tb_customer.password))
                    {
                        selectcols += "`password`,";
                    }
                    if (cols.Contains(e_tb_customer.lv))
                    {
                        selectcols += "`lv`,";
                    }
                    if (cols.Contains(e_tb_customer.regip))
                    {
                        selectcols += "`regip`,";
                    }
                    if (cols.Contains(e_tb_customer.regtime))
                    {
                        selectcols += "`regtime`,";
                    }
                    if (cols.Contains(e_tb_customer.lastlogintime))
                    {
                        selectcols += "`lastlogintime`,";
                    }
                    if (cols.Contains(e_tb_customer.isenabled))
                    {
                        selectcols += "`isenabled`,";
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
                    if (keys.Contains(e_tb_customer.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_customer.name))
                    {
                        selectwhere += "`name`=@name and";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (keys.Contains(e_tb_customer.nickname))
                    {
                        selectwhere += "`nickname`=@nickname and";
                        cmd.Parameters.AddWithValue("@nickname", model.nickname);
                    }
                    if (keys.Contains(e_tb_customer.password))
                    {
                        selectwhere += "`password`=@password and";
                        cmd.Parameters.AddWithValue("@password", model.password);
                    }
                    if (keys.Contains(e_tb_customer.lv))
                    {
                        selectwhere += "`lv`=@lv and";
                        cmd.Parameters.AddWithValue("@lv", model.lv);
                    }
                    if (keys.Contains(e_tb_customer.regip))
                    {
                        selectwhere += "`regip`=@regip and";
                        cmd.Parameters.AddWithValue("@regip", model.regip);
                    }
                    if (keys.Contains(e_tb_customer.regtime))
                    {
                        selectwhere += "`regtime`=@regtime and";
                        cmd.Parameters.AddWithValue("@regtime", model.regtime);
                    }
                    if (keys.Contains(e_tb_customer.lastlogintime))
                    {
                        selectwhere += "`lastlogintime`=@lastlogintime and";
                        cmd.Parameters.AddWithValue("@lastlogintime", model.lastlogintime);
                    }
                    if (keys.Contains(e_tb_customer.isenabled))
                    {
                        selectwhere += "`isenabled`=@isenabled and";
                        cmd.Parameters.AddWithValue("@isenabled", model.isenabled);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_customer.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.name))
                    {
                        selectsort += "`name`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.nickname))
                    {
                        selectsort += "`nickname`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.password))
                    {
                        selectsort += "`password`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.lv))
                    {
                        selectsort += "`lv`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.regip))
                    {
                        selectsort += "`regip`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.regtime))
                    {
                        selectsort += "`regtime`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.lastlogintime))
                    {
                        selectsort += "`lastlogintime`,";
                    }
                    if (sortkeys.Contains(e_tb_customer.isenabled))
                    {
                        selectsort += "`isenabled`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_customer>();
            }
            public static int Insert(tb_customer model, e_tb_customer[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_customer ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer.id))
                    {
                        inertcols += "`id`,";
                        inertvalues += "id,";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (cols.Contains(e_tb_customer.name))
                    {
                        inertcols += "`name`,";
                        inertvalues += "name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (cols.Contains(e_tb_customer.nickname))
                    {
                        inertcols += "`nickname`,";
                        inertvalues += "nickname,";
                        cmd.Parameters.AddWithValue("@nickname", model.nickname);
                    }
                    if (cols.Contains(e_tb_customer.password))
                    {
                        inertcols += "`password`,";
                        inertvalues += "password,";
                        cmd.Parameters.AddWithValue("@password", model.password);
                    }
                    if (cols.Contains(e_tb_customer.lv))
                    {
                        inertcols += "`lv`,";
                        inertvalues += "lv,";
                        cmd.Parameters.AddWithValue("@lv", model.lv);
                    }
                    if (cols.Contains(e_tb_customer.regip))
                    {
                        inertcols += "`regip`,";
                        inertvalues += "regip,";
                        cmd.Parameters.AddWithValue("@regip", model.regip);
                    }
                    if (cols.Contains(e_tb_customer.regtime))
                    {
                        inertcols += "`regtime`,";
                        inertvalues += "regtime,";
                        cmd.Parameters.AddWithValue("@regtime", model.regtime);
                    }
                    if (cols.Contains(e_tb_customer.lastlogintime))
                    {
                        inertcols += "`lastlogintime`,";
                        inertvalues += "lastlogintime,";
                        cmd.Parameters.AddWithValue("@lastlogintime", model.lastlogintime);
                    }
                    if (cols.Contains(e_tb_customer.isenabled))
                    {
                        inertcols += "`isenabled`,";
                        inertvalues += "isenabled,";
                        cmd.Parameters.AddWithValue("@isenabled", model.isenabled);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`id`,";
                    inertvalues += "id,";
                    cmd.Parameters.AddWithValue("@id", model.id);
                    inertcols += "`name`,";
                    inertvalues += "name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    inertcols += "`nickname`,";
                    inertvalues += "nickname,";
                    cmd.Parameters.AddWithValue("@nickname", model.nickname);
                    inertcols += "`password`,";
                    inertvalues += "password,";
                    cmd.Parameters.AddWithValue("@password", model.password);
                    inertcols += "`lv`,";
                    inertvalues += "lv,";
                    cmd.Parameters.AddWithValue("@lv", model.lv);
                    inertcols += "`regip`,";
                    inertvalues += "regip,";
                    cmd.Parameters.AddWithValue("@regip", model.regip);
                    inertcols += "`regtime`,";
                    inertvalues += "regtime,";
                    cmd.Parameters.AddWithValue("@regtime", model.regtime);
                    inertcols += "`lastlogintime`,";
                    inertvalues += "lastlogintime,";
                    cmd.Parameters.AddWithValue("@lastlogintime", model.lastlogintime);
                    inertcols += "`isenabled`,";
                    inertvalues += "isenabled,";
                    cmd.Parameters.AddWithValue("@isenabled", model.isenabled);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_customer model, e_tb_customer[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_customer set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer.name))
                    {
                        updatecols += "`name`=@name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (cols.Contains(e_tb_customer.nickname))
                    {
                        updatecols += "`nickname`=@nickname,";
                        cmd.Parameters.AddWithValue("@nickname", model.nickname);
                    }
                    if (cols.Contains(e_tb_customer.password))
                    {
                        updatecols += "`password`=@password,";
                        cmd.Parameters.AddWithValue("@password", model.password);
                    }
                    if (cols.Contains(e_tb_customer.lv))
                    {
                        updatecols += "`lv`=@lv,";
                        cmd.Parameters.AddWithValue("@lv", model.lv);
                    }
                    if (cols.Contains(e_tb_customer.regip))
                    {
                        updatecols += "`regip`=@regip,";
                        cmd.Parameters.AddWithValue("@regip", model.regip);
                    }
                    if (cols.Contains(e_tb_customer.regtime))
                    {
                        updatecols += "`regtime`=@regtime,";
                        cmd.Parameters.AddWithValue("@regtime", model.regtime);
                    }
                    if (cols.Contains(e_tb_customer.lastlogintime))
                    {
                        updatecols += "`lastlogintime`=@lastlogintime,";
                        cmd.Parameters.AddWithValue("@lastlogintime", model.lastlogintime);
                    }
                    if (cols.Contains(e_tb_customer.isenabled))
                    {
                        updatecols += "`isenabled`=@isenabled,";
                        cmd.Parameters.AddWithValue("@isenabled", model.isenabled);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`name`=@name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    updatecols += "`nickname`=@nickname,";
                    cmd.Parameters.AddWithValue("@nickname", model.nickname);
                    updatecols += "`password`=@password,";
                    cmd.Parameters.AddWithValue("@password", model.password);
                    updatecols += "`lv`=@lv,";
                    cmd.Parameters.AddWithValue("@lv", model.lv);
                    updatecols += "`regip`=@regip,";
                    cmd.Parameters.AddWithValue("@regip", model.regip);
                    updatecols += "`regtime`=@regtime,";
                    cmd.Parameters.AddWithValue("@regtime", model.regtime);
                    updatecols += "`lastlogintime`=@lastlogintime,";
                    cmd.Parameters.AddWithValue("@lastlogintime", model.lastlogintime);
                    updatecols += "`isenabled`=@isenabled,";
                    cmd.Parameters.AddWithValue("@isenabled", model.isenabled);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_customer model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_customer{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_customer_addrs
        {
            public static List<tb_customer_addrs> Select(tb_customer_addrs model = null, e_tb_customer_addrs[] cols = null, e_tb_customer_addrs[] keys = null, e_tb_customer_addrs[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_customer_addrs{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_addrs.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_customer_addrs.customerid))
                    {
                        selectcols += "`customerid`,";
                    }
                    if (cols.Contains(e_tb_customer_addrs.country))
                    {
                        selectcols += "`country`,";
                    }
                    if (cols.Contains(e_tb_customer_addrs.province))
                    {
                        selectcols += "`province`,";
                    }
                    if (cols.Contains(e_tb_customer_addrs.city))
                    {
                        selectcols += "`city`,";
                    }
                    if (cols.Contains(e_tb_customer_addrs.address))
                    {
                        selectcols += "`address`,";
                    }
                    if (cols.Contains(e_tb_customer_addrs.isdefault))
                    {
                        selectcols += "`isdefault`,";
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
                    if (keys.Contains(e_tb_customer_addrs.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_customer_addrs.customerid))
                    {
                        selectwhere += "`customerid`=@customerid and";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (keys.Contains(e_tb_customer_addrs.country))
                    {
                        selectwhere += "`country`=@country and";
                        cmd.Parameters.AddWithValue("@country", model.country);
                    }
                    if (keys.Contains(e_tb_customer_addrs.province))
                    {
                        selectwhere += "`province`=@province and";
                        cmd.Parameters.AddWithValue("@province", model.province);
                    }
                    if (keys.Contains(e_tb_customer_addrs.city))
                    {
                        selectwhere += "`city`=@city and";
                        cmd.Parameters.AddWithValue("@city", model.city);
                    }
                    if (keys.Contains(e_tb_customer_addrs.address))
                    {
                        selectwhere += "`address`=@address and";
                        cmd.Parameters.AddWithValue("@address", model.address);
                    }
                    if (keys.Contains(e_tb_customer_addrs.isdefault))
                    {
                        selectwhere += "`isdefault`=@isdefault and";
                        cmd.Parameters.AddWithValue("@isdefault", model.isdefault);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_customer_addrs.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_addrs.customerid))
                    {
                        selectsort += "`customerid`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_addrs.country))
                    {
                        selectsort += "`country`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_addrs.province))
                    {
                        selectsort += "`province`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_addrs.city))
                    {
                        selectsort += "`city`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_addrs.address))
                    {
                        selectsort += "`address`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_addrs.isdefault))
                    {
                        selectsort += "`isdefault`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_customer_addrs>();
            }
            public static int Insert(tb_customer_addrs model, e_tb_customer_addrs[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_customer_addrs ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_addrs.customerid))
                    {
                        inertcols += "`customerid`,";
                        inertvalues += "customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_customer_addrs.country))
                    {
                        inertcols += "`country`,";
                        inertvalues += "country,";
                        cmd.Parameters.AddWithValue("@country", model.country);
                    }
                    if (cols.Contains(e_tb_customer_addrs.province))
                    {
                        inertcols += "`province`,";
                        inertvalues += "province,";
                        cmd.Parameters.AddWithValue("@province", model.province);
                    }
                    if (cols.Contains(e_tb_customer_addrs.city))
                    {
                        inertcols += "`city`,";
                        inertvalues += "city,";
                        cmd.Parameters.AddWithValue("@city", model.city);
                    }
                    if (cols.Contains(e_tb_customer_addrs.address))
                    {
                        inertcols += "`address`,";
                        inertvalues += "address,";
                        cmd.Parameters.AddWithValue("@address", model.address);
                    }
                    if (cols.Contains(e_tb_customer_addrs.isdefault))
                    {
                        inertcols += "`isdefault`,";
                        inertvalues += "isdefault,";
                        cmd.Parameters.AddWithValue("@isdefault", model.isdefault);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`customerid`,";
                    inertvalues += "customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    inertcols += "`country`,";
                    inertvalues += "country,";
                    cmd.Parameters.AddWithValue("@country", model.country);
                    inertcols += "`province`,";
                    inertvalues += "province,";
                    cmd.Parameters.AddWithValue("@province", model.province);
                    inertcols += "`city`,";
                    inertvalues += "city,";
                    cmd.Parameters.AddWithValue("@city", model.city);
                    inertcols += "`address`,";
                    inertvalues += "address,";
                    cmd.Parameters.AddWithValue("@address", model.address);
                    inertcols += "`isdefault`,";
                    inertvalues += "isdefault,";
                    cmd.Parameters.AddWithValue("@isdefault", model.isdefault);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_customer_addrs model, e_tb_customer_addrs[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_customer_addrs set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_addrs.customerid))
                    {
                        updatecols += "`customerid`=@customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_customer_addrs.country))
                    {
                        updatecols += "`country`=@country,";
                        cmd.Parameters.AddWithValue("@country", model.country);
                    }
                    if (cols.Contains(e_tb_customer_addrs.province))
                    {
                        updatecols += "`province`=@province,";
                        cmd.Parameters.AddWithValue("@province", model.province);
                    }
                    if (cols.Contains(e_tb_customer_addrs.city))
                    {
                        updatecols += "`city`=@city,";
                        cmd.Parameters.AddWithValue("@city", model.city);
                    }
                    if (cols.Contains(e_tb_customer_addrs.address))
                    {
                        updatecols += "`address`=@address,";
                        cmd.Parameters.AddWithValue("@address", model.address);
                    }
                    if (cols.Contains(e_tb_customer_addrs.isdefault))
                    {
                        updatecols += "`isdefault`=@isdefault,";
                        cmd.Parameters.AddWithValue("@isdefault", model.isdefault);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`customerid`=@customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    updatecols += "`country`=@country,";
                    cmd.Parameters.AddWithValue("@country", model.country);
                    updatecols += "`province`=@province,";
                    cmd.Parameters.AddWithValue("@province", model.province);
                    updatecols += "`city`=@city,";
                    cmd.Parameters.AddWithValue("@city", model.city);
                    updatecols += "`address`=@address,";
                    cmd.Parameters.AddWithValue("@address", model.address);
                    updatecols += "`isdefault`=@isdefault,";
                    cmd.Parameters.AddWithValue("@isdefault", model.isdefault);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_customer_addrs model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_customer_addrs{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_customer_bank
        {
            public static List<tb_customer_bank> Select(tb_customer_bank model = null, e_tb_customer_bank[] cols = null, e_tb_customer_bank[] keys = null, e_tb_customer_bank[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_customer_bank{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_bank.customerid))
                    {
                        selectcols += "`customerid`,";
                    }
                    if (cols.Contains(e_tb_customer_bank.money))
                    {
                        selectcols += "`money`,";
                    }
                    if (cols.Contains(e_tb_customer_bank.point))
                    {
                        selectcols += "`point`,";
                    }
                    if (cols.Contains(e_tb_customer_bank.coin))
                    {
                        selectcols += "`coin`,";
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
                    if (keys.Contains(e_tb_customer_bank.customerid))
                    {
                        selectwhere += "`customerid`=@customerid and";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (keys.Contains(e_tb_customer_bank.money))
                    {
                        selectwhere += "`money`=@money and";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (keys.Contains(e_tb_customer_bank.point))
                    {
                        selectwhere += "`point`=@point and";
                        cmd.Parameters.AddWithValue("@point", model.point);
                    }
                    if (keys.Contains(e_tb_customer_bank.coin))
                    {
                        selectwhere += "`coin`=@coin and";
                        cmd.Parameters.AddWithValue("@coin", model.coin);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_customer_bank.customerid))
                    {
                        selectsort += "`customerid`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_bank.money))
                    {
                        selectsort += "`money`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_bank.point))
                    {
                        selectsort += "`point`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_bank.coin))
                    {
                        selectsort += "`coin`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_customer_bank>();
            }
            public static int Insert(tb_customer_bank model, e_tb_customer_bank[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_customer_bank ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_bank.customerid))
                    {
                        inertcols += "`customerid`,";
                        inertvalues += "customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_customer_bank.money))
                    {
                        inertcols += "`money`,";
                        inertvalues += "money,";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (cols.Contains(e_tb_customer_bank.point))
                    {
                        inertcols += "`point`,";
                        inertvalues += "point,";
                        cmd.Parameters.AddWithValue("@point", model.point);
                    }
                    if (cols.Contains(e_tb_customer_bank.coin))
                    {
                        inertcols += "`coin`,";
                        inertvalues += "coin,";
                        cmd.Parameters.AddWithValue("@coin", model.coin);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`customerid`,";
                    inertvalues += "customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    inertcols += "`money`,";
                    inertvalues += "money,";
                    cmd.Parameters.AddWithValue("@money", model.money);
                    inertcols += "`point`,";
                    inertvalues += "point,";
                    cmd.Parameters.AddWithValue("@point", model.point);
                    inertcols += "`coin`,";
                    inertvalues += "coin,";
                    cmd.Parameters.AddWithValue("@coin", model.coin);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_customer_bank model, e_tb_customer_bank[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_customer_bank set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_bank.money))
                    {
                        updatecols += "`money`=@money,";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (cols.Contains(e_tb_customer_bank.point))
                    {
                        updatecols += "`point`=@point,";
                        cmd.Parameters.AddWithValue("@point", model.point);
                    }
                    if (cols.Contains(e_tb_customer_bank.coin))
                    {
                        updatecols += "`coin`=@coin,";
                        cmd.Parameters.AddWithValue("@coin", model.coin);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`money`=@money,";
                    cmd.Parameters.AddWithValue("@money", model.money);
                    updatecols += "`point`=@point,";
                    cmd.Parameters.AddWithValue("@point", model.point);
                    updatecols += "`coin`=@coin,";
                    cmd.Parameters.AddWithValue("@coin", model.coin);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `customerid`=@customerid and";
                cmd.Parameters.AddWithValue("@customerid", model.customerid);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_customer_bank model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_customer_bank{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `customerid`=@customerid and";
                cmd.Parameters.AddWithValue("@customerid", model.customerid);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_customer_store
        {
            public static List<tb_customer_store> Select(tb_customer_store model = null, e_tb_customer_store[] cols = null, e_tb_customer_store[] keys = null, e_tb_customer_store[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_customer_store{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_store.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_customer_store.customerid))
                    {
                        selectcols += "`customerid`,";
                    }
                    if (cols.Contains(e_tb_customer_store.goodsid))
                    {
                        selectcols += "`goodsid`,";
                    }
                    if (cols.Contains(e_tb_customer_store.price))
                    {
                        selectcols += "`price`,";
                    }
                    if (cols.Contains(e_tb_customer_store.storetime))
                    {
                        selectcols += "`storetime`,";
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
                    if (keys.Contains(e_tb_customer_store.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_customer_store.customerid))
                    {
                        selectwhere += "`customerid`=@customerid and";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (keys.Contains(e_tb_customer_store.goodsid))
                    {
                        selectwhere += "`goodsid`=@goodsid and";
                        cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    }
                    if (keys.Contains(e_tb_customer_store.price))
                    {
                        selectwhere += "`price`=@price and";
                        cmd.Parameters.AddWithValue("@price", model.price);
                    }
                    if (keys.Contains(e_tb_customer_store.storetime))
                    {
                        selectwhere += "`storetime`=@storetime and";
                        cmd.Parameters.AddWithValue("@storetime", model.storetime);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_customer_store.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_store.customerid))
                    {
                        selectsort += "`customerid`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_store.goodsid))
                    {
                        selectsort += "`goodsid`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_store.price))
                    {
                        selectsort += "`price`,";
                    }
                    if (sortkeys.Contains(e_tb_customer_store.storetime))
                    {
                        selectsort += "`storetime`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_customer_store>();
            }
            public static int Insert(tb_customer_store model, e_tb_customer_store[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_customer_store ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_store.id))
                    {
                        inertcols += "`id`,";
                        inertvalues += "id,";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (cols.Contains(e_tb_customer_store.customerid))
                    {
                        inertcols += "`customerid`,";
                        inertvalues += "customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_customer_store.goodsid))
                    {
                        inertcols += "`goodsid`,";
                        inertvalues += "goodsid,";
                        cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    }
                    if (cols.Contains(e_tb_customer_store.price))
                    {
                        inertcols += "`price`,";
                        inertvalues += "price,";
                        cmd.Parameters.AddWithValue("@price", model.price);
                    }
                    if (cols.Contains(e_tb_customer_store.storetime))
                    {
                        inertcols += "`storetime`,";
                        inertvalues += "storetime,";
                        cmd.Parameters.AddWithValue("@storetime", model.storetime);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`id`,";
                    inertvalues += "id,";
                    cmd.Parameters.AddWithValue("@id", model.id);
                    inertcols += "`customerid`,";
                    inertvalues += "customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    inertcols += "`goodsid`,";
                    inertvalues += "goodsid,";
                    cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    inertcols += "`price`,";
                    inertvalues += "price,";
                    cmd.Parameters.AddWithValue("@price", model.price);
                    inertcols += "`storetime`,";
                    inertvalues += "storetime,";
                    cmd.Parameters.AddWithValue("@storetime", model.storetime);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_customer_store model, e_tb_customer_store[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_customer_store set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_customer_store.customerid))
                    {
                        updatecols += "`customerid`=@customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_customer_store.goodsid))
                    {
                        updatecols += "`goodsid`=@goodsid,";
                        cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    }
                    if (cols.Contains(e_tb_customer_store.price))
                    {
                        updatecols += "`price`=@price,";
                        cmd.Parameters.AddWithValue("@price", model.price);
                    }
                    if (cols.Contains(e_tb_customer_store.storetime))
                    {
                        updatecols += "`storetime`=@storetime,";
                        cmd.Parameters.AddWithValue("@storetime", model.storetime);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`customerid`=@customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    updatecols += "`goodsid`=@goodsid,";
                    cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    updatecols += "`price`=@price,";
                    cmd.Parameters.AddWithValue("@price", model.price);
                    updatecols += "`storetime`=@storetime,";
                    cmd.Parameters.AddWithValue("@storetime", model.storetime);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_customer_store model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_customer_store{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_goods
        {
            public static List<tb_goods> Select(tb_goods model = null, e_tb_goods[] cols = null, e_tb_goods[] keys = null, e_tb_goods[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_goods{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_goods.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_goods.name))
                    {
                        selectcols += "`name`,";
                    }
                    if (cols.Contains(e_tb_goods.desc))
                    {
                        selectcols += "`desc`,";
                    }
                    if (cols.Contains(e_tb_goods.intro))
                    {
                        selectcols += "`intro`,";
                    }
                    if (cols.Contains(e_tb_goods.price))
                    {
                        selectcols += "`price`,";
                    }
                    if (cols.Contains(e_tb_goods.images))
                    {
                        selectcols += "`images`,";
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
                    if (keys.Contains(e_tb_goods.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_goods.name))
                    {
                        selectwhere += "`name`=@name and";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (keys.Contains(e_tb_goods.desc))
                    {
                        selectwhere += "`desc`=@desc and";
                        cmd.Parameters.AddWithValue("@desc", model.desc);
                    }
                    if (keys.Contains(e_tb_goods.intro))
                    {
                        selectwhere += "`intro`=@intro and";
                        cmd.Parameters.AddWithValue("@intro", model.intro);
                    }
                    if (keys.Contains(e_tb_goods.price))
                    {
                        selectwhere += "`price`=@price and";
                        cmd.Parameters.AddWithValue("@price", model.price);
                    }
                    if (keys.Contains(e_tb_goods.images))
                    {
                        selectwhere += "`images`=@images and";
                        cmd.Parameters.AddWithValue("@images", model.images);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_goods.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_goods.name))
                    {
                        selectsort += "`name`,";
                    }
                    if (sortkeys.Contains(e_tb_goods.desc))
                    {
                        selectsort += "`desc`,";
                    }
                    if (sortkeys.Contains(e_tb_goods.intro))
                    {
                        selectsort += "`intro`,";
                    }
                    if (sortkeys.Contains(e_tb_goods.price))
                    {
                        selectsort += "`price`,";
                    }
                    if (sortkeys.Contains(e_tb_goods.images))
                    {
                        selectsort += "`images`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_goods>();
            }
            public static int Insert(tb_goods model, e_tb_goods[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_goods ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_goods.name))
                    {
                        inertcols += "`name`,";
                        inertvalues += "name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (cols.Contains(e_tb_goods.desc))
                    {
                        inertcols += "`desc`,";
                        inertvalues += "desc,";
                        cmd.Parameters.AddWithValue("@desc", model.desc);
                    }
                    if (cols.Contains(e_tb_goods.intro))
                    {
                        inertcols += "`intro`,";
                        inertvalues += "intro,";
                        cmd.Parameters.AddWithValue("@intro", model.intro);
                    }
                    if (cols.Contains(e_tb_goods.price))
                    {
                        inertcols += "`price`,";
                        inertvalues += "price,";
                        cmd.Parameters.AddWithValue("@price", model.price);
                    }
                    if (cols.Contains(e_tb_goods.images))
                    {
                        inertcols += "`images`,";
                        inertvalues += "images,";
                        cmd.Parameters.AddWithValue("@images", model.images);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`name`,";
                    inertvalues += "name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    inertcols += "`desc`,";
                    inertvalues += "desc,";
                    cmd.Parameters.AddWithValue("@desc", model.desc);
                    inertcols += "`intro`,";
                    inertvalues += "intro,";
                    cmd.Parameters.AddWithValue("@intro", model.intro);
                    inertcols += "`price`,";
                    inertvalues += "price,";
                    cmd.Parameters.AddWithValue("@price", model.price);
                    inertcols += "`images`,";
                    inertvalues += "images,";
                    cmd.Parameters.AddWithValue("@images", model.images);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_goods model, e_tb_goods[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_goods set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_goods.name))
                    {
                        updatecols += "`name`=@name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (cols.Contains(e_tb_goods.desc))
                    {
                        updatecols += "`desc`=@desc,";
                        cmd.Parameters.AddWithValue("@desc", model.desc);
                    }
                    if (cols.Contains(e_tb_goods.intro))
                    {
                        updatecols += "`intro`=@intro,";
                        cmd.Parameters.AddWithValue("@intro", model.intro);
                    }
                    if (cols.Contains(e_tb_goods.price))
                    {
                        updatecols += "`price`=@price,";
                        cmd.Parameters.AddWithValue("@price", model.price);
                    }
                    if (cols.Contains(e_tb_goods.images))
                    {
                        updatecols += "`images`=@images,";
                        cmd.Parameters.AddWithValue("@images", model.images);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`name`=@name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    updatecols += "`desc`=@desc,";
                    cmd.Parameters.AddWithValue("@desc", model.desc);
                    updatecols += "`intro`=@intro,";
                    cmd.Parameters.AddWithValue("@intro", model.intro);
                    updatecols += "`price`=@price,";
                    cmd.Parameters.AddWithValue("@price", model.price);
                    updatecols += "`images`=@images,";
                    cmd.Parameters.AddWithValue("@images", model.images);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_goods model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_goods{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_goods_group
        {
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
                    switch (sort)
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
                        inertvalues += "name,";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`name`,";
                    inertvalues += "name,";
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
                var updatekeys = "";
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
                    updatecols += "`name`=@name,";
                    cmd.Parameters.AddWithValue("@name", model.name);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_goods_group model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_goods_group{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_issue
        {
            public static List<tb_issue> Select(tb_issue model = null, e_tb_issue[] cols = null, e_tb_issue[] keys = null, e_tb_issue[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_issue{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_issue.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_issue.goodsid))
                    {
                        selectcols += "`goodsid`,";
                    }
                    if (cols.Contains(e_tb_issue.maxcount))
                    {
                        selectcols += "`maxcount`,";
                    }
                    if (cols.Contains(e_tb_issue.lastnum))
                    {
                        selectcols += "`lastnum`,";
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
                    if (keys.Contains(e_tb_issue.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_issue.goodsid))
                    {
                        selectwhere += "`goodsid`=@goodsid and";
                        cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    }
                    if (keys.Contains(e_tb_issue.maxcount))
                    {
                        selectwhere += "`maxcount`=@maxcount and";
                        cmd.Parameters.AddWithValue("@maxcount", model.maxcount);
                    }
                    if (keys.Contains(e_tb_issue.lastnum))
                    {
                        selectwhere += "`lastnum`=@lastnum and";
                        cmd.Parameters.AddWithValue("@lastnum", model.lastnum);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_issue.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_issue.goodsid))
                    {
                        selectsort += "`goodsid`,";
                    }
                    if (sortkeys.Contains(e_tb_issue.maxcount))
                    {
                        selectsort += "`maxcount`,";
                    }
                    if (sortkeys.Contains(e_tb_issue.lastnum))
                    {
                        selectsort += "`lastnum`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_issue>();
            }
            public static int Insert(tb_issue model, e_tb_issue[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_issue ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_issue.goodsid))
                    {
                        inertcols += "`goodsid`,";
                        inertvalues += "goodsid,";
                        cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    }
                    if (cols.Contains(e_tb_issue.maxcount))
                    {
                        inertcols += "`maxcount`,";
                        inertvalues += "maxcount,";
                        cmd.Parameters.AddWithValue("@maxcount", model.maxcount);
                    }
                    if (cols.Contains(e_tb_issue.lastnum))
                    {
                        inertcols += "`lastnum`,";
                        inertvalues += "lastnum,";
                        cmd.Parameters.AddWithValue("@lastnum", model.lastnum);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`goodsid`,";
                    inertvalues += "goodsid,";
                    cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    inertcols += "`maxcount`,";
                    inertvalues += "maxcount,";
                    cmd.Parameters.AddWithValue("@maxcount", model.maxcount);
                    inertcols += "`lastnum`,";
                    inertvalues += "lastnum,";
                    cmd.Parameters.AddWithValue("@lastnum", model.lastnum);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_issue model, e_tb_issue[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_issue set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_issue.goodsid))
                    {
                        updatecols += "`goodsid`=@goodsid,";
                        cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    }
                    if (cols.Contains(e_tb_issue.maxcount))
                    {
                        updatecols += "`maxcount`=@maxcount,";
                        cmd.Parameters.AddWithValue("@maxcount", model.maxcount);
                    }
                    if (cols.Contains(e_tb_issue.lastnum))
                    {
                        updatecols += "`lastnum`=@lastnum,";
                        cmd.Parameters.AddWithValue("@lastnum", model.lastnum);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`goodsid`=@goodsid,";
                    cmd.Parameters.AddWithValue("@goodsid", model.goodsid);
                    updatecols += "`maxcount`=@maxcount,";
                    cmd.Parameters.AddWithValue("@maxcount", model.maxcount);
                    updatecols += "`lastnum`=@lastnum,";
                    cmd.Parameters.AddWithValue("@lastnum", model.lastnum);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_issue model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_issue{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_log_consume
        {
            public static List<tb_log_consume> Select(tb_log_consume model = null, e_tb_log_consume[] cols = null, e_tb_log_consume[] keys = null, e_tb_log_consume[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_log_consume{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_consume.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_log_consume.issue))
                    {
                        selectcols += "`issue`,";
                    }
                    if (cols.Contains(e_tb_log_consume.nums))
                    {
                        selectcols += "`nums`,";
                    }
                    if (cols.Contains(e_tb_log_consume.customerid))
                    {
                        selectcols += "`customerid`,";
                    }
                    if (cols.Contains(e_tb_log_consume.notetime))
                    {
                        selectcols += "`notetime`,";
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
                    if (keys.Contains(e_tb_log_consume.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_log_consume.issue))
                    {
                        selectwhere += "`issue`=@issue and";
                        cmd.Parameters.AddWithValue("@issue", model.issue);
                    }
                    if (keys.Contains(e_tb_log_consume.nums))
                    {
                        selectwhere += "`nums`=@nums and";
                        cmd.Parameters.AddWithValue("@nums", model.nums);
                    }
                    if (keys.Contains(e_tb_log_consume.customerid))
                    {
                        selectwhere += "`customerid`=@customerid and";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (keys.Contains(e_tb_log_consume.notetime))
                    {
                        selectwhere += "`notetime`=@notetime and";
                        cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_log_consume.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_log_consume.issue))
                    {
                        selectsort += "`issue`,";
                    }
                    if (sortkeys.Contains(e_tb_log_consume.nums))
                    {
                        selectsort += "`nums`,";
                    }
                    if (sortkeys.Contains(e_tb_log_consume.customerid))
                    {
                        selectsort += "`customerid`,";
                    }
                    if (sortkeys.Contains(e_tb_log_consume.notetime))
                    {
                        selectsort += "`notetime`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_log_consume>();
            }
            public static int Insert(tb_log_consume model, e_tb_log_consume[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_log_consume ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_consume.issue))
                    {
                        inertcols += "`issue`,";
                        inertvalues += "issue,";
                        cmd.Parameters.AddWithValue("@issue", model.issue);
                    }
                    if (cols.Contains(e_tb_log_consume.nums))
                    {
                        inertcols += "`nums`,";
                        inertvalues += "nums,";
                        cmd.Parameters.AddWithValue("@nums", model.nums);
                    }
                    if (cols.Contains(e_tb_log_consume.customerid))
                    {
                        inertcols += "`customerid`,";
                        inertvalues += "customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_log_consume.notetime))
                    {
                        inertcols += "`notetime`,";
                        inertvalues += "notetime,";
                        cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`issue`,";
                    inertvalues += "issue,";
                    cmd.Parameters.AddWithValue("@issue", model.issue);
                    inertcols += "`nums`,";
                    inertvalues += "nums,";
                    cmd.Parameters.AddWithValue("@nums", model.nums);
                    inertcols += "`customerid`,";
                    inertvalues += "customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    inertcols += "`notetime`,";
                    inertvalues += "notetime,";
                    cmd.Parameters.AddWithValue("@notetime", model.notetime);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_log_consume model, e_tb_log_consume[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_log_consume set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_consume.issue))
                    {
                        updatecols += "`issue`=@issue,";
                        cmd.Parameters.AddWithValue("@issue", model.issue);
                    }
                    if (cols.Contains(e_tb_log_consume.nums))
                    {
                        updatecols += "`nums`=@nums,";
                        cmd.Parameters.AddWithValue("@nums", model.nums);
                    }
                    if (cols.Contains(e_tb_log_consume.customerid))
                    {
                        updatecols += "`customerid`=@customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_log_consume.notetime))
                    {
                        updatecols += "`notetime`=@notetime,";
                        cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`issue`=@issue,";
                    cmd.Parameters.AddWithValue("@issue", model.issue);
                    updatecols += "`nums`=@nums,";
                    cmd.Parameters.AddWithValue("@nums", model.nums);
                    updatecols += "`customerid`=@customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    updatecols += "`notetime`=@notetime,";
                    cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_log_consume model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_log_consume{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_log_login
        {
            public static List<tb_log_login> Select(tb_log_login model = null, e_tb_log_login[] cols = null, e_tb_log_login[] keys = null, e_tb_log_login[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_log_login{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_login.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_log_login.notetime))
                    {
                        selectcols += "`notetime`,";
                    }
                    if (cols.Contains(e_tb_log_login.customerid))
                    {
                        selectcols += "`customerid`,";
                    }
                    if (cols.Contains(e_tb_log_login.ip))
                    {
                        selectcols += "`ip`,";
                    }
                    if (cols.Contains(e_tb_log_login.addr))
                    {
                        selectcols += "`addr`,";
                    }
                    if (cols.Contains(e_tb_log_login.os))
                    {
                        selectcols += "`os`,";
                    }
                    if (cols.Contains(e_tb_log_login.browser))
                    {
                        selectcols += "`browser`,";
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
                    if (keys.Contains(e_tb_log_login.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_log_login.notetime))
                    {
                        selectwhere += "`notetime`=@notetime and";
                        cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    }
                    if (keys.Contains(e_tb_log_login.customerid))
                    {
                        selectwhere += "`customerid`=@customerid and";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (keys.Contains(e_tb_log_login.ip))
                    {
                        selectwhere += "`ip`=@ip and";
                        cmd.Parameters.AddWithValue("@ip", model.ip);
                    }
                    if (keys.Contains(e_tb_log_login.addr))
                    {
                        selectwhere += "`addr`=@addr and";
                        cmd.Parameters.AddWithValue("@addr", model.addr);
                    }
                    if (keys.Contains(e_tb_log_login.os))
                    {
                        selectwhere += "`os`=@os and";
                        cmd.Parameters.AddWithValue("@os", model.os);
                    }
                    if (keys.Contains(e_tb_log_login.browser))
                    {
                        selectwhere += "`browser`=@browser and";
                        cmd.Parameters.AddWithValue("@browser", model.browser);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_log_login.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_log_login.notetime))
                    {
                        selectsort += "`notetime`,";
                    }
                    if (sortkeys.Contains(e_tb_log_login.customerid))
                    {
                        selectsort += "`customerid`,";
                    }
                    if (sortkeys.Contains(e_tb_log_login.ip))
                    {
                        selectsort += "`ip`,";
                    }
                    if (sortkeys.Contains(e_tb_log_login.addr))
                    {
                        selectsort += "`addr`,";
                    }
                    if (sortkeys.Contains(e_tb_log_login.os))
                    {
                        selectsort += "`os`,";
                    }
                    if (sortkeys.Contains(e_tb_log_login.browser))
                    {
                        selectsort += "`browser`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_log_login>();
            }
            public static int Insert(tb_log_login model, e_tb_log_login[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_log_login ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_login.id))
                    {
                        inertcols += "`id`,";
                        inertvalues += "id,";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (cols.Contains(e_tb_log_login.notetime))
                    {
                        inertcols += "`notetime`,";
                        inertvalues += "notetime,";
                        cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    }
                    if (cols.Contains(e_tb_log_login.customerid))
                    {
                        inertcols += "`customerid`,";
                        inertvalues += "customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_log_login.ip))
                    {
                        inertcols += "`ip`,";
                        inertvalues += "ip,";
                        cmd.Parameters.AddWithValue("@ip", model.ip);
                    }
                    if (cols.Contains(e_tb_log_login.addr))
                    {
                        inertcols += "`addr`,";
                        inertvalues += "addr,";
                        cmd.Parameters.AddWithValue("@addr", model.addr);
                    }
                    if (cols.Contains(e_tb_log_login.os))
                    {
                        inertcols += "`os`,";
                        inertvalues += "os,";
                        cmd.Parameters.AddWithValue("@os", model.os);
                    }
                    if (cols.Contains(e_tb_log_login.browser))
                    {
                        inertcols += "`browser`,";
                        inertvalues += "browser,";
                        cmd.Parameters.AddWithValue("@browser", model.browser);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`id`,";
                    inertvalues += "id,";
                    cmd.Parameters.AddWithValue("@id", model.id);
                    inertcols += "`notetime`,";
                    inertvalues += "notetime,";
                    cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    inertcols += "`customerid`,";
                    inertvalues += "customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    inertcols += "`ip`,";
                    inertvalues += "ip,";
                    cmd.Parameters.AddWithValue("@ip", model.ip);
                    inertcols += "`addr`,";
                    inertvalues += "addr,";
                    cmd.Parameters.AddWithValue("@addr", model.addr);
                    inertcols += "`os`,";
                    inertvalues += "os,";
                    cmd.Parameters.AddWithValue("@os", model.os);
                    inertcols += "`browser`,";
                    inertvalues += "browser,";
                    cmd.Parameters.AddWithValue("@browser", model.browser);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_log_login model, e_tb_log_login[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_log_login set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_login.notetime))
                    {
                        updatecols += "`notetime`=@notetime,";
                        cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    }
                    if (cols.Contains(e_tb_log_login.customerid))
                    {
                        updatecols += "`customerid`=@customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_log_login.ip))
                    {
                        updatecols += "`ip`=@ip,";
                        cmd.Parameters.AddWithValue("@ip", model.ip);
                    }
                    if (cols.Contains(e_tb_log_login.addr))
                    {
                        updatecols += "`addr`=@addr,";
                        cmd.Parameters.AddWithValue("@addr", model.addr);
                    }
                    if (cols.Contains(e_tb_log_login.os))
                    {
                        updatecols += "`os`=@os,";
                        cmd.Parameters.AddWithValue("@os", model.os);
                    }
                    if (cols.Contains(e_tb_log_login.browser))
                    {
                        updatecols += "`browser`=@browser,";
                        cmd.Parameters.AddWithValue("@browser", model.browser);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`notetime`=@notetime,";
                    cmd.Parameters.AddWithValue("@notetime", model.notetime);
                    updatecols += "`customerid`=@customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    updatecols += "`ip`=@ip,";
                    cmd.Parameters.AddWithValue("@ip", model.ip);
                    updatecols += "`addr`=@addr,";
                    cmd.Parameters.AddWithValue("@addr", model.addr);
                    updatecols += "`os`=@os,";
                    cmd.Parameters.AddWithValue("@os", model.os);
                    updatecols += "`browser`=@browser,";
                    cmd.Parameters.AddWithValue("@browser", model.browser);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_log_login model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_log_login{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class tb_log_recharge
        {
            public static List<tb_log_recharge> Select(tb_log_recharge model = null, e_tb_log_recharge[] cols = null, e_tb_log_recharge[] keys = null, e_tb_log_recharge[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from tb_log_recharge{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_recharge.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_tb_log_recharge.orderid))
                    {
                        selectcols += "`orderid`,";
                    }
                    if (cols.Contains(e_tb_log_recharge.customerid))
                    {
                        selectcols += "`customerid`,";
                    }
                    if (cols.Contains(e_tb_log_recharge.money))
                    {
                        selectcols += "`money`,";
                    }
                    if (cols.Contains(e_tb_log_recharge.chancel))
                    {
                        selectcols += "`chancel`,";
                    }
                    if (cols.Contains(e_tb_log_recharge.ispay))
                    {
                        selectcols += "`ispay`,";
                    }
                    if (cols.Contains(e_tb_log_recharge.issuccess))
                    {
                        selectcols += "`issuccess`,";
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
                    if (keys.Contains(e_tb_log_recharge.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_tb_log_recharge.orderid))
                    {
                        selectwhere += "`orderid`=@orderid and";
                        cmd.Parameters.AddWithValue("@orderid", model.orderid);
                    }
                    if (keys.Contains(e_tb_log_recharge.customerid))
                    {
                        selectwhere += "`customerid`=@customerid and";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (keys.Contains(e_tb_log_recharge.money))
                    {
                        selectwhere += "`money`=@money and";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (keys.Contains(e_tb_log_recharge.chancel))
                    {
                        selectwhere += "`chancel`=@chancel and";
                        cmd.Parameters.AddWithValue("@chancel", model.chancel);
                    }
                    if (keys.Contains(e_tb_log_recharge.ispay))
                    {
                        selectwhere += "`ispay`=@ispay and";
                        cmd.Parameters.AddWithValue("@ispay", model.ispay);
                    }
                    if (keys.Contains(e_tb_log_recharge.issuccess))
                    {
                        selectwhere += "`issuccess`=@issuccess and";
                        cmd.Parameters.AddWithValue("@issuccess", model.issuccess);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_tb_log_recharge.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_tb_log_recharge.orderid))
                    {
                        selectsort += "`orderid`,";
                    }
                    if (sortkeys.Contains(e_tb_log_recharge.customerid))
                    {
                        selectsort += "`customerid`,";
                    }
                    if (sortkeys.Contains(e_tb_log_recharge.money))
                    {
                        selectsort += "`money`,";
                    }
                    if (sortkeys.Contains(e_tb_log_recharge.chancel))
                    {
                        selectsort += "`chancel`,";
                    }
                    if (sortkeys.Contains(e_tb_log_recharge.ispay))
                    {
                        selectsort += "`ispay`,";
                    }
                    if (sortkeys.Contains(e_tb_log_recharge.issuccess))
                    {
                        selectsort += "`issuccess`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<tb_log_recharge>();
            }
            public static int Insert(tb_log_recharge model, e_tb_log_recharge[] cols = null)
            {
                if (model == null)
                    return -1;
                MySqlCommand cmd = new MySqlCommand();
                var command = "insert into tb_log_recharge ({0}) values ({1})";
                var inertcols = "";
                var inertvalues = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_recharge.orderid))
                    {
                        inertcols += "`orderid`,";
                        inertvalues += "orderid,";
                        cmd.Parameters.AddWithValue("@orderid", model.orderid);
                    }
                    if (cols.Contains(e_tb_log_recharge.customerid))
                    {
                        inertcols += "`customerid`,";
                        inertvalues += "customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_log_recharge.money))
                    {
                        inertcols += "`money`,";
                        inertvalues += "money,";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (cols.Contains(e_tb_log_recharge.chancel))
                    {
                        inertcols += "`chancel`,";
                        inertvalues += "chancel,";
                        cmd.Parameters.AddWithValue("@chancel", model.chancel);
                    }
                    if (cols.Contains(e_tb_log_recharge.ispay))
                    {
                        inertcols += "`ispay`,";
                        inertvalues += "ispay,";
                        cmd.Parameters.AddWithValue("@ispay", model.ispay);
                    }
                    if (cols.Contains(e_tb_log_recharge.issuccess))
                    {
                        inertcols += "`issuccess`,";
                        inertvalues += "issuccess,";
                        cmd.Parameters.AddWithValue("@issuccess", model.issuccess);
                    }
                    inertcols = inertcols.Substring(0, inertcols.LastIndexOf(','));
                    inertvalues = inertvalues.Substring(0, inertvalues.LastIndexOf(','));
                }
                else
                {
                    inertcols += "`orderid`,";
                    inertvalues += "orderid,";
                    cmd.Parameters.AddWithValue("@orderid", model.orderid);
                    inertcols += "`customerid`,";
                    inertvalues += "customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    inertcols += "`money`,";
                    inertvalues += "money,";
                    cmd.Parameters.AddWithValue("@money", model.money);
                    inertcols += "`chancel`,";
                    inertvalues += "chancel,";
                    cmd.Parameters.AddWithValue("@chancel", model.chancel);
                    inertcols += "`ispay`,";
                    inertvalues += "ispay,";
                    cmd.Parameters.AddWithValue("@ispay", model.ispay);
                    inertcols += "`issuccess`,";
                    inertvalues += "issuccess,";
                    cmd.Parameters.AddWithValue("@issuccess", model.issuccess);
                }
                command = string.Format(command, inertcols, inertvalues);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Update(tb_log_recharge model, e_tb_log_recharge[] cols = null)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "update tb_log_recharge set {0} {1}";
                var updatecols = "";
                var updatekeys = "";
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_tb_log_recharge.orderid))
                    {
                        updatecols += "`orderid`=@orderid,";
                        cmd.Parameters.AddWithValue("@orderid", model.orderid);
                    }
                    if (cols.Contains(e_tb_log_recharge.customerid))
                    {
                        updatecols += "`customerid`=@customerid,";
                        cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    }
                    if (cols.Contains(e_tb_log_recharge.money))
                    {
                        updatecols += "`money`=@money,";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (cols.Contains(e_tb_log_recharge.chancel))
                    {
                        updatecols += "`chancel`=@chancel,";
                        cmd.Parameters.AddWithValue("@chancel", model.chancel);
                    }
                    if (cols.Contains(e_tb_log_recharge.ispay))
                    {
                        updatecols += "`ispay`=@ispay,";
                        cmd.Parameters.AddWithValue("@ispay", model.ispay);
                    }
                    if (cols.Contains(e_tb_log_recharge.issuccess))
                    {
                        updatecols += "`issuccess`=@issuccess,";
                        cmd.Parameters.AddWithValue("@issuccess", model.issuccess);
                    }
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                else
                {
                    updatecols += "`orderid`=@orderid,";
                    cmd.Parameters.AddWithValue("@orderid", model.orderid);
                    updatecols += "`customerid`=@customerid,";
                    cmd.Parameters.AddWithValue("@customerid", model.customerid);
                    updatecols += "`money`=@money,";
                    cmd.Parameters.AddWithValue("@money", model.money);
                    updatecols += "`chancel`=@chancel,";
                    cmd.Parameters.AddWithValue("@chancel", model.chancel);
                    updatecols += "`ispay`=@ispay,";
                    cmd.Parameters.AddWithValue("@ispay", model.ispay);
                    updatecols += "`issuccess`=@issuccess,";
                    cmd.Parameters.AddWithValue("@issuccess", model.issuccess);
                    updatecols = updatecols.Substring(0, updatecols.LastIndexOf(','));
                }
                updatekeys += " where ";
                updatekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                updatekeys = updatekeys.Substring(0, updatekeys.LastIndexOf(" and"));
                command = string.Format(command, updatecols, updatekeys);
                cmd.CommandText = command;
                return DBHelper.ExecuteNonQuery(cmd);
            }
            public static int Delete(tb_log_recharge model)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "delete from tb_log_recharge{0}";
                var deletekeys = "";
                deletekeys += " where ";
                deletekeys += " `id`=@id and";
                cmd.Parameters.AddWithValue("@id", model.id);
                deletekeys = deletekeys.Substring(0, deletekeys.LastIndexOf(" and"));
                command = string.Format(command, deletekeys);
                return DBHelper.ExecuteNonQuery(cmd);
            }
        }
        public partial class v_customer_base
        {
            public static List<v_customer_base> Select(v_customer_base model = null, e_v_customer_base[] cols = null, e_v_customer_base[] keys = null, e_v_customer_base[] sortkeys = null, Sort sort = Sort.NONE, int start = 0, int limit = 0)
            {
                MySqlCommand cmd = new MySqlCommand();
                var command = "select {0} from v_customer_base{1}{2}{3};";
                var selectcols = "";
                var selectwhere = "";
                var selectsort = "";
                var selectlimit = "";
                #region selectcols筛选
                if (cols != null && cols.Length > 0)
                {
                    if (cols.Contains(e_v_customer_base.id))
                    {
                        selectcols += "`id`,";
                    }
                    if (cols.Contains(e_v_customer_base.name))
                    {
                        selectcols += "`name`,";
                    }
                    if (cols.Contains(e_v_customer_base.nickname))
                    {
                        selectcols += "`nickname`,";
                    }
                    if (cols.Contains(e_v_customer_base.lv))
                    {
                        selectcols += "`lv`,";
                    }
                    if (cols.Contains(e_v_customer_base.money))
                    {
                        selectcols += "`money`,";
                    }
                    if (cols.Contains(e_v_customer_base.point))
                    {
                        selectcols += "`point`,";
                    }
                    if (cols.Contains(e_v_customer_base.coin))
                    {
                        selectcols += "`coin`,";
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
                    if (keys.Contains(e_v_customer_base.id))
                    {
                        selectwhere += "`id`=@id and";
                        cmd.Parameters.AddWithValue("@id", model.id);
                    }
                    if (keys.Contains(e_v_customer_base.name))
                    {
                        selectwhere += "`name`=@name and";
                        cmd.Parameters.AddWithValue("@name", model.name);
                    }
                    if (keys.Contains(e_v_customer_base.nickname))
                    {
                        selectwhere += "`nickname`=@nickname and";
                        cmd.Parameters.AddWithValue("@nickname", model.nickname);
                    }
                    if (keys.Contains(e_v_customer_base.lv))
                    {
                        selectwhere += "`lv`=@lv and";
                        cmd.Parameters.AddWithValue("@lv", model.lv);
                    }
                    if (keys.Contains(e_v_customer_base.money))
                    {
                        selectwhere += "`money`=@money and";
                        cmd.Parameters.AddWithValue("@money", model.money);
                    }
                    if (keys.Contains(e_v_customer_base.point))
                    {
                        selectwhere += "`point`=@point and";
                        cmd.Parameters.AddWithValue("@point", model.point);
                    }
                    if (keys.Contains(e_v_customer_base.coin))
                    {
                        selectwhere += "`coin`=@coin and";
                        cmd.Parameters.AddWithValue("@coin", model.coin);
                    }
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                    selectwhere = selectwhere.Substring(0, selectwhere.LastIndexOf(" and"));
                }
                #endregion
                #region sortkeys筛选
                if (sortkeys != null && sortkeys.Length > 0 && sort != Sort.NONE)
                {
                    selectsort = " order by ";
                    if (sortkeys.Contains(e_v_customer_base.id))
                    {
                        selectsort += "`id`,";
                    }
                    if (sortkeys.Contains(e_v_customer_base.name))
                    {
                        selectsort += "`name`,";
                    }
                    if (sortkeys.Contains(e_v_customer_base.nickname))
                    {
                        selectsort += "`nickname`,";
                    }
                    if (sortkeys.Contains(e_v_customer_base.lv))
                    {
                        selectsort += "`lv`,";
                    }
                    if (sortkeys.Contains(e_v_customer_base.money))
                    {
                        selectsort += "`money`,";
                    }
                    if (sortkeys.Contains(e_v_customer_base.point))
                    {
                        selectsort += "`point`,";
                    }
                    if (sortkeys.Contains(e_v_customer_base.coin))
                    {
                        selectsort += "`coin`,";
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
                if (limit > 0)
                {
                    selectlimit = " limit " + start + "," + limit;
                }
                #endregion
                command = string.Format(command, selectcols, selectwhere, selectsort, selectlimit);
                cmd.CommandText = command;
                var data = DBHelper.ExecuteDataTable(cmd);
                return data.ToList<v_customer_base>();
            }
        }
    }
}
