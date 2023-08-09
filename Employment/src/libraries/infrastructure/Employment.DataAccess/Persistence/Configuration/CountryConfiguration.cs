

using Employment.Model.Entities;
using Employment.Sheared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.DataAccess.Persistence.Configurationp;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		builder.ToTable("Countries");
		builder.HasKey(x => x.Id);
       

    }
}
