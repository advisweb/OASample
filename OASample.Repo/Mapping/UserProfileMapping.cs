using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OASample.Data.Entity;

namespace OASample.Repo.Mapping
{
    public class UserProfileMapping : IEntityMapping<UserProfile>
    {
        public void ConfigureModel(EntityTypeBuilder<UserProfile> model)
        {
            //setup primary key
            model.HasKey(x => x.Id);
            model.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            model.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            model.Property(x => x.Address).HasMaxLength(500).IsRequired();

            //setup 1 to 1 relationship
            model.HasOne(x => x.User).WithOne(x => x.UserProfile).HasForeignKey<User>();
        }
    }
}
