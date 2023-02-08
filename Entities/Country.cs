using AdoNetWinformsApp.Constant;

namespace AdoNetWinformsApp.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Population { get; set; }

        public string Capital { get; set; } = string.Empty;

        public decimal Area { get; set; }

        public PartOfWorld PartOfWorld { get; set; }
    }
}
