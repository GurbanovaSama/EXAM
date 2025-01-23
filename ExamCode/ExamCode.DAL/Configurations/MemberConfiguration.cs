using ExamCode.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamCode.DAL.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
          
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();


            builder
                .Property(x => x.Surname)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Position)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
