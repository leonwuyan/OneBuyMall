using System;
namespace OneBuyMall.DAL
{
public partial class db_onebuymall
{
public partial class tb_admin
{
public int id{ set; get; }
public string name{ set; get; }
public string pass{ set; get; }
public int permission{ set; get; }
}
public partial class tb_admin_permission
{
public int id{ set; get; }
public string name{ set; get; }
public int permission{ set; get; }
public string control{ set; get; }
public string action{ set; get; }
public bool isenabled{ set; get; }
}
public partial class tb_config
{
public int id{ set; get; }
public string sitename{ set; get; }
public string keywords{ set; get; }
public string desc{ set; get; }
}
public partial class tb_customer
{
public int id{ set; get; }
public string name{ set; get; }
public string nickname{ set; get; }
public string password{ set; get; }
public int lv{ set; get; }
public string regip{ set; get; }
public DateTime regtime{ set; get; }
public DateTime lastlogintime{ set; get; }
public bool isenabled{ set; get; }
}
public partial class tb_customer_addrs
{
public int id{ set; get; }
public int customerid{ set; get; }
public string country{ set; get; }
public string province{ set; get; }
public string city{ set; get; }
public string address{ set; get; }
public bool isdefault{ set; get; }
}
public partial class tb_customer_bank
{
public int customerid{ set; get; }
public int money{ set; get; }
public int point{ set; get; }
public int coin{ set; get; }
}
public partial class tb_customer_store
{
public int id{ set; get; }
public int customerid{ set; get; }
public int goodsid{ set; get; }
public int price{ set; get; }
public DateTime storetime{ set; get; }
}
public partial class tb_goods
{
public int id{ set; get; }
public string name{ set; get; }
public string desc{ set; get; }
public string intro{ set; get; }
public int price{ set; get; }
public string images{ set; get; }
}
public partial class tb_goods_group
{
public int id{ set; get; }
public string name{ set; get; }
}
public partial class tb_issue
{
public int id{ set; get; }
public int goodsid{ set; get; }
public int maxcount{ set; get; }
public string lastnum{ set; get; }
}
public partial class tb_log_consume
{
public int id{ set; get; }
public int issue{ set; get; }
public string nums{ set; get; }
public int customerid{ set; get; }
public DateTime notetime{ set; get; }
}
public partial class tb_log_login
{
public int id{ set; get; }
public DateTime notetime{ set; get; }
public int customerid{ set; get; }
public string ip{ set; get; }
public string addr{ set; get; }
public string os{ set; get; }
public string browser{ set; get; }
}
public partial class tb_log_recharge
{
public int id{ set; get; }
public string orderid{ set; get; }
public int customerid{ set; get; }
public int money{ set; get; }
public int chancel{ set; get; }
public bool ispay{ set; get; }
public bool issuccess{ set; get; }
}
public partial class v_customer_base
{
public int id{ set; get; }
public string name{ set; get; }
public string nickname{ set; get; }
public int lv{ set; get; }
public int money{ set; get; }
public int point{ set; get; }
public int coin{ set; get; }
}
}
}
