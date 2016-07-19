using OneBuyMall.DAL;
using OneBuyMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall
{
    public partial class Core
    {
        public List<GoodsGroup> GetGoodsGroups()
        {
            var result = new List<GoodsGroup>();
            var data = db_tb_goods_group.Select();
            foreach(var item in data)
            {
                var goodsgroup = new GoodsGroup {
                    ID = item.id,
                    Name = item.name
                };
                result.Add(goodsgroup);
            }
            return result;
        }
        public GoodsGroup GetGoodsGroup(int ID)
        {
            var result = db_tb_goods_group.Select(
                new db_tb_goods_group.tb_goods_group { id = ID },
                null,
                new db_tb_goods_group.e_tb_goods_group[]{ db_tb_goods_group.e_tb_goods_group.id }
                ).FirstOrDefault();
            if (result != null)
            {
                return new GoodsGroup
                {
                    ID = result.id,
                    Name = result.name
                };
            }
            return null;
        }
        public HRESULT AddGoodsGroup(string Name)
        {
            db_tb_goods_group.tb_goods_group model = new db_tb_goods_group.tb_goods_group { 
                name = Name
            };
            if (db_tb_goods_group.Insert(model) == 1)
            {
                return HRESULT.Success;
            }
            return HRESULT.Fail;
        }
        public HRESULT EditGoodsGroup(int ID, string Name)
        {
            db_tb_goods_group.tb_goods_group model = new db_tb_goods_group.tb_goods_group
            {
                id = ID,
                name = Name
            };
            if (db_tb_goods_group.Update(model) == 1)
            {
                return HRESULT.Success;
            }
            return HRESULT.Fail;
        }
        public HRESULT DelGoodsGroup(int ID)
        {
            db_tb_goods_group.tb_goods_group model = new db_tb_goods_group.tb_goods_group
            {
                id = ID
            };
            if (db_tb_goods_group.Delete(model) == 1)
            {
                return HRESULT.Success;
            }
            return HRESULT.Fail;
        }
    }
}
