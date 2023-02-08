using AdoNetWinformsApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdoNetWinformsApp
{
    public class CountryServices
    {
        WarehouseContext _context;

        public CountryServices(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<List<string>> GetCountrieNamesAsync()
        {
            return await _context.Countries
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<string>> GetCountrieCapitalsAsync()
        {
            return await _context.Countries
                .Select(x => x.Capital)
                .ToListAsync();
        }

        public async Task<List<string>> GetEuropianCountrieNamesAsync()
        {
            return await _context.Countries
                .Where(x => x.PartOfWorld == Constant.PartOfWorld.Europa)
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<string>> GetCountrieNamesWithAreaFilteringAsync(decimal area)
        {
            return await _context.Countries
                .Where(x => x.Area > area)
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Country>> GetCountriesWithLetterAsync(params char[] letters)
        {
            return await _context.Countries
                .Where(x => letters.All(l => x.Name.Contains(l)))
                .ToListAsync();
        }

        public async Task<List<Country>> GetCountriesStartsWithLetterAAsync(char letter)
        {
            return await _context.Countries
                .Where(x => x.Name.StartsWith(letter))
                .ToListAsync();
        }

        public async Task<List<string>> GetCountrieNamesWithAreaFilteringAsync(decimal minArea, decimal maxArea)
        {
            return await _context.Countries
                .Where(x => x.Area >= minArea && x.Area <= maxArea)
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<string>> GetCountrieNamesWithPopulationFilteringAsync(int population)
        {
            return await _context.Countries
                .Where(x => x.Population > population)
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Country>> GetTopAreaCountriesAsync(int top)
        {
            return await _context.Countries
                .OrderByDescending(x => x.Area)
                .Take(top)
                .ToListAsync();
        }

        public async Task<List<Country>> GetTopPopulationCountriesAsync(int top)
        {
            return await _context.Countries
                .OrderByDescending(x => x.Population)
                .Take(top)
                .ToListAsync();
        }

        public async Task<Country?> TopAreaCountryAsync()
        {
            return await _context.Countries
                .OrderBy(x => x.Area)
                .FirstOrDefaultAsync();
        }

        public async Task<Country?> TopPopulationCountryAsync()
        {
            return await _context.Countries
                .OrderBy(x => x.Population)
                .FirstOrDefaultAsync();
        }

        public async Task<Country?> TopMinAreaAfricaCountryAsync()
        {
            return await _context.Countries
                .Where(x => x.PartOfWorld == Constant.PartOfWorld.Africa)
                .OrderByDescending(x => x.Area)
                .LastOrDefaultAsync();
        }

        public async Task<decimal> GetAfricaAvgArea()
        {
            return await _context.Countries
                .Where(x => x.PartOfWorld == Constant.PartOfWorld.Africa)
                .AverageAsync(x => x.Area);
        }
    }
}
