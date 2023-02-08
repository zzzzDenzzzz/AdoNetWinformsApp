using AdoNetWinformsApp.Constant;
using AdoNetWinformsApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdoNetWinformsApp.EntityMappings
{
    internal class CountryEntityMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(DatabaseDefault.StringValueMaxLength);
            builder.Property(x => x.Capital).HasMaxLength(DatabaseDefault.StringValueMaxLength);
        }
    }
}
