using ExamCode.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamCode.DAL.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder
                .HasMany(x => x.Members)
                .WithOne(x => x.Plan)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();


            builder
                .Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .IsRequired();
        }
    }
}
