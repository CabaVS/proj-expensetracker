using CabaVS.ExpenseTracker.Domain.ValueObjects;
using CabaVS.ExpenseTracker.Persistence.Write.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CabaVS.ExpenseTracker.Persistence.Write.EntitiesConfiguration;

internal sealed class WorkspaceEfConfiguration : IEntityTypeConfiguration<WorkspaceEfEntity>
{
    public void Configure(EntityTypeBuilder<WorkspaceEfEntity> builder)
    {
        builder.ToTable("Workspaces");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasMaxLength(WorkspaceName.MaxLength)
            .IsRequired();
    }
}
