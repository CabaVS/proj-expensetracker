using CabaVS.ExpenseTracker.Persistence.Write.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CabaVS.ExpenseTracker.Persistence.Write.EntitiesConfiguration;

internal sealed class UserEfConfiguration : IEntityTypeConfiguration<UserEfEntity>
{
    public void Configure(EntityTypeBuilder<UserEfEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
    }
}
