using BulkDeleteCreate.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkDeleteCreate.SqlServer.Mapping
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);

            entityBuilder.Property(u => u.Id)
                .IsRequired(true);

            entityBuilder.HasMany(u => u.GroupMembers);

            entityBuilder.Property(u => u.Name)
                .IsRequired(true)
                .HasMaxLength(200);
        }
    }
}
