using System;

namespace BulkDeleteCreate.Model
{
    public class GroupMember
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
