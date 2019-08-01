using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OASample.Data.Entity;

namespace OASample.Repo.Mapping
{
    //setup fluent api
    public class UserMapping : IEntityMapping<User>
    {
        //setup fluent API here
        public void ConfigureModel(EntityTypeBuilder<User> entityBuilder)
        {
            //setup primary key
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.UserName).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired();
            entityBuilder.Property(x => x.Password).IsRequired();
            entityBuilder.Property(x => x.IsActive).HasDefaultValue(true);
            entityBuilder.Property(x => x.IsRemoved).HasDefaultValue(false);
            entityBuilder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            entityBuilder.Property(x => x.ModifiedDate).HasDefaultValueSql("getdate()");

            //setup user profile foreign key
            entityBuilder.HasOne(x => x.UserProfile).WithOne(x => x.User).HasForeignKey<UserProfile>(f => f.Id);
        }
    }
}
