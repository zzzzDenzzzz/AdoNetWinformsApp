using AdoNetWinformsApp.Entities;
using FastMember;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AdoNetWinformsApp
{
    public partial class MainForm : Form
    {
        private const string GetGoodsWithInfoQuery = @"
            SELECT G.Id, G.[Name] AS N'Наименование', GT.[Name] AS N'Тип товара', G.Cost AS N'Себестоимость'
            FROM Goods AS G
            JOIN GoodsTypes AS GT
            ON G.GoodsTypeId = GT.Id";

        private WarehouseContext? _context;
        public MainForm()
        {
            InitializeComponent();
            _context = new WarehouseContext();
            _context.Database.Migrate();
        }

        private async void btnShowGoods_Click(object sender, EventArgs e)
        {
            var goods = await _context.Goods.ToListAsync();
            var table = new DataTable();
            using var reader = ObjectReader.Create(goods, "Id", "Name", "Cost", "GoodsTypeId");
            table.Load(reader);
            mainGrid.DataSource = null;
            mainGrid.DataSource = table;
        }

        async Task<Supplier?> MaxGoodsSuppllier()
        {
            if (_context.Deliveries.Any())
            {
                var max = await _context.Deliveries
                .GroupBy(p => p.SupplierId)
                .Select(p => new { SupplierId = p.Key, AmountSum = p.Sum(p => p.Amount) })
                .OrderByDescending(p => p.AmountSum)
                .FirstAsync();

                var supplier = await _context.Suppliers
                    .FindAsync(max.SupplierId);

                if (supplier != null)
                {
                    return supplier;
                }
                throw new Exception("Поставщик не найден");
            }
            throw new Exception("Нет поставок");
        }

        async Task<List<Delivery>> DeliverysWithDaysOnWarehouse(int days)
        {
            var now = DateTime.Now;
            var timeNeeded = now.AddDays(-days);

            return await _context.Deliveries
                .Where(p => p.DeliveryTime <= timeNeeded)
                .OrderByDescending(p => p.DeliveryTime)
                .ToListAsync();
        }

        async Task<List<Good>> GoodsWithDaysOnWarehouse(int days)
        {
            var now = DateTime.Now;
            var timeNeeded = now.AddDays(-days);

            var goods = await _context.Deliveries
                .Where(p => p.DeliveryTime <= timeNeeded)
                .Select(p => p.Good)
                .DistinctBy(p => p.Id)
                .ToListAsync();

            var names = goods
                .Select(p => p.Name)
                .ToList();

            return goods;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
            _context = null;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await _context.SaveChangesAsync();
        }

        private async void btnGoodsTypes_Click(object sender, EventArgs e)
        {
            var goodTypes = await _context.GoodTypes.ToListAsync();
            var table = new DataTable();
            using var reader = ObjectReader.Create(goodTypes, "Id", "Name");
            table.Load(reader);
            mainGrid.DataSource = null;
            mainGrid.DataSource = table;
        }
    }
}