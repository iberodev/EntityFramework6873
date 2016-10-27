using BulkDeleteCreate.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using BulkDeleteCreate.Model;
using System.Collections.Generic;

namespace BulkDeleteCreate.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly SampleContext _context;

        public TestRepository(SampleContext context)
        {
            _context = context;
        }

        public async Task UpdateGroupMembershipsAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.GroupMembers).ThenInclude(gm => gm.Group)
                .Where(u => u.Id == userId)
                .SingleOrDefaultAsync();

            _context.GroupMembers.RemoveRange(user.GroupMembers);
            user.GroupMembers.Clear();
            var groupMembersToAdd = GetGroupMembershipsToAdd();
            user.GroupMembers.AddRange(groupMembersToAdd);
            //this will fail when saving changes in DB.
            //Notice that if the groupMembership to add are not for any of the current groups it will succeed.
            await _context.SaveChangesAsync(); 
        }

        private IEnumerable<GroupMember> GetGroupMembershipsToAdd()
        {
            var groupIdsToAdd = AppSettings.GetTheWhoMetallicaAndPinkFloydList();
            var groupMemberships = groupIdsToAdd.Select(id => new GroupMember
            {
                GroupId = id
            });
            return groupMemberships;
        }
    }
}
