using AdoNetWinformsApp.Entities;
using System.Data;

namespace AdoNetWinformsApp.Services
{
    public class TableCreatorService
    {
        public static DataTable CreateGoodsTable(List<Good> goods)
        {
            DataTable table = new();
            table.Clear();
            table.Columns.Add("Id");
            table.Columns.Add("Название");
            table.Columns.Add("Себестоимость");
            table.Columns.Add("Тип товара");

            foreach (var good in goods)
            {
                DataRow row = table.NewRow();
                row[0] = good.Id;
                row[1] = good.Name;
                row[2] = good.Cost;
                row[3] = good.GoodType.Name;
                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateGoodsTypeTable(List<GoodType> goodsType)
        {
            DataTable table = new();
            table.Clear();
            table.Columns.Add("Id");
            table.Columns.Add("Название");

            foreach (var good in goodsType)
            {
                DataRow row = table.NewRow();
                row[0] = good.Id;
                row[1] = good.Name;
                table.Rows.Add(row);
            }

            return table;
        }

        public static void ShowTable(DataGridView grid, DataTable table)
        {
            grid.DataSource = null;
            grid.DataSource = table;
            grid.Columns[0].Visible = false;
        }
    }
}
