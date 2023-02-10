using AdoNetWinformsApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdoNetWinformsApp.Services
{
    public class WarehouseService
    {
        readonly WarehouseContext _context;

        public WarehouseService()
        {
            _context = new WarehouseContext();
        }

        public async Task<List<Good>> GetGoods()
        {
            return await _context.Goods.ToListAsync();
        }

        public async Task<List<GoodType>> GetGoodsType()
        {
            return await _context.GoodTypes.ToListAsync();
        }

        public async Task AddGoodType(string goodTypeName)
        {
            var goodType = new GoodType { Name = goodTypeName };
            await _context.GoodTypes.AddAsync(goodType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGoodType(int id)
        {
            var googType = await _context.GoodTypes.FindAsync(id);
            if (googType != null)
            {
                if (googType.Goods != null && googType.Goods.Any())
                {
                    throw new Exception("В системе существуют товары с таким типом. Удаление не возможно");
                }

                _context.GoodTypes.Remove(googType);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Такого типа товара не существует");
            }
        }
    }
}