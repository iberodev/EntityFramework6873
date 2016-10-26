using BulkDeleteCreate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkDeleteCreate.SqlServer.Mapping
{
    public class GroupMemberMap
    {
        public GroupMemberMap(EntityTypeBuilder<GroupMember> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.HasAlternateKey(t => new { t.UserId, t.GroupId });

            entityBuilder.Property(t => t.UserId);

            entityBuilder.Property(t => t.GroupId);

            entityBuilder.HasOne(t => t.User)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasOne(t => t.Group)
                .WithMany(group => group.GroupMembers)
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
