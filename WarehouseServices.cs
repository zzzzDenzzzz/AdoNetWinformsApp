﻿using AdoNetWinformsApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetWinformsApp
{
    public class WarehouseServices
    {
        WarehouseContext _context;

        public WarehouseServices(WarehouseContext context)
        {
            _context = context;
        }

        // отображение всей информации о товаре
        public async Task<List<Good>> GetGoodsAsync()
        {
            return await _context.Goods.ToListAsync();
        }

        // отображение всех типов товаров
        public async Task<List<string>> GetGoodTypeNameAsync()
        {
            return await _context.GoodTypes
                .Select(x => x.Name)
                .ToListAsync();
        }

        // отображение всех поставщиков
        public async Task<List<string>> GetSupplierNamesAsync()
        {
            return await _context.Suppliers
                .Select(x => x.Name)
                .ToListAsync();
        }

        // показать товар с максимальным количеством
        public async Task<Good> GetGoodMaxAmountAsync()
        {
            if (_context.Deliveries.Any())
            {
                var max = await _context.Deliveries
                .GroupBy(p => p.GoodsId)
                .Select(p => new { GoodsId = p.Key, AmountMax = p.Max(p => p.Amount) })
                .OrderByDescending(p => p.AmountMax)
                .FirstAsync();

                var goods = await _context.Goods
                    .FindAsync(max.GoodsId);

                if (goods != null)
                {
                    return goods;
                }
                throw new Exception("Поставщик не найден");
            }
            throw new Exception("Нет товара");
        }

        // показать товар с минимальным количеством
        public async Task<Good?> GetGoodMinAmountAsync()
        {
            if (_context.Deliveries.Any())
            {
                var min = await _context.Deliveries
                .GroupBy(p => p.GoodsId)
                .Select(p => new { GoodsId = p.Key, AmountMin = p.Min(p => p.Amount) })
                .OrderBy(p => p.AmountMin)
                .FirstAsync();

                var goods = await _context.Goods
                    .FindAsync(min.GoodsId);

                if (goods != null)
                {
                    return goods;
                }
                throw new Exception("Поставщик не найден");
            }
            throw new Exception("Нет товара");
        }

        // показать товар с минимальной себестоимостью
        public async Task<Good?> GetGoodMinCost()
        {
            return await _context.Goods
                .OrderBy(g => g.Cost)
                .FirstOrDefaultAsync();
        }

        // показать товар с максимальной себестоимостью
        public async Task<Good?> GetGoodMaxCost()
        {
            return await _context.Goods
                .OrderByDescending(g => g.Cost)
                .FirstOrDefaultAsync();
        }

        // показать товары заданной категории
        public async Task<List<Good>> GetGoodsTypeAsync(string typeName)
        {
            var result = _context.GoodTypes
                .Where(t => t.Name == typeName).ToList();
            select Goods.Name, GoodsTypes.Name
            //from Goods
            //inner join GoodsTypes
            //on GoodsTypes.Id = Goods.GoodsTypeId
            //group by Goods.Name, GoodsTypes.Name
            //having GoodsTypes.Name = 'спортивный инвентарь'
        }
    }
}
