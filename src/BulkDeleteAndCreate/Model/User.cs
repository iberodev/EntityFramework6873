using System;
using System.Collections.Generic;

namespace BulkDeleteCreate.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<GroupMember> GroupMembers { get; set; }
    }
}
