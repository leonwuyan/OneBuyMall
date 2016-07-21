namespace OneBuyMall.DAL
{
    public partial class db_onebuymall
    {
        public enum e_tb_admin
        {
            id,
            name,
            pass,
            permission,
        }
        public enum e_tb_admin_permission
        {
            id,
            permission,
            control,
            action,
        }
        public enum e_tb_config
        {
            id,
            sitename,
            keywords,
            desc,
        }
        public enum e_tb_customer
        {
            id,
            name,
            nickname,
            password,
            lv,
            regip,
            regtime,
            lastlogintime,
            isenabled,
        }
        public enum e_tb_customer_addrs
        {
            id,
            customerid,
            country,
            province,
            city,
            address,
            isdefault,
        }
        public enum e_tb_customer_bank
        {
            customerid,
            money,
            point,
            coin,
        }
        public enum e_tb_customer_store
        {
            id,
            customerid,
            goodsid,
            price,
            storetime,
        }
        public enum e_tb_goods
        {
            id,
            name,
            desc,
            intro,
            price,
            images,
        }
        public enum e_tb_goods_group
        {
            id,
            name,
        }
        public enum e_tb_issue
        {
            id,
            goodsid,
            maxcount,
            lastnum,
        }
        public enum e_tb_log_consume
        {
            id,
            issue,
            nums,
            customerid,
            notetime,
        }
        public enum e_tb_log_login
        {
            id,
            notetime,
            customerid,
            ip,
            addr,
            os,
            browser,
        }
        public enum e_tb_log_recharge
        {
            id,
            orderid,
            customerid,
            money,
            chancel,
            ispay,
            issuccess,
        }
        public enum e_v_customer_base
        {
            id,
            name,
            nickname,
            lv,
            money,
            point,
            coin,
        }
    }
}
