using AdoNetWinformsApp.Entities;
using AdoNetWinformsApp.Forms.GoodType;
using AdoNetWinformsApp.Services;
using FastMember;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AdoNetWinformsApp
{
    public partial class MainForm : Form
    {
        Dictionary<int, Action> LoadTabsMethod;

        readonly WarehouseService _warehouseService;

        public MainForm()
        {
            InitializeComponent();
            _warehouseService = new();
            LoadTabsMethod = new()
            {
                { 0, () => LoadGoods() },
                { 1, () => LoadGoodsType() }
            };
        }

        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTabsMethod[mainTab.SelectedIndex]();
        }

        async void LoadGoods()
        {
            TableCreatorService.ShowTable(
                gridGoods,
                TableCreatorService.CreateGoodsTable(await _warehouseService.GetGoods()));
        }

        async void LoadGoodsType()
        {
            TableCreatorService.ShowTable(
                gridGoodsType,
                TableCreatorService.CreateGoodsTypeTable(await _warehouseService.GetGoodsType()));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTabsMethod[0]();
        }

        private async void BtnAddGoodType_Click(object sender, EventArgs e)
        {
            var form = new AddGoodType();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await _warehouseService.AddGoodType(form.GoodTypeName);
                LoadGoodsType();
            }
        }

        private async void btnDeleteGoodType_Click(object sender, EventArgs e)
        {
            if (gridGoodsType.SelectedRows.Count > 0)
            {
                var goodTypeId = int.Parse(gridGoodsType.SelectedRows[0].Cells[0].Value.ToString()!);
                try
                {
                    await _warehouseService.DeleteGoodType(goodTypeId);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadGoodsType();
                }
            }
            else
            {
                MessageBox.Show("Выберите тип товара для удаления!");
            }
        }
    }
}