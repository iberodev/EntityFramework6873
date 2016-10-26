using BulkDeleteCreate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkDeleteCreate.SqlServer.Mapping
{
    public class GroupMap
    {
        public GroupMap(EntityTypeBuilder<Group> entityBuilder)
        {
            entityBuilder.HasKey(g => g.Id);

            entityBuilder.Property(g => g.Id)
                .IsRequired(true);

            entityBuilder.HasMany(g => g.GroupMembers);

            entityBuilder.Property(g => g.Name)
                .IsRequired(true)
                .HasMaxLength(200);
        }
    }
}
