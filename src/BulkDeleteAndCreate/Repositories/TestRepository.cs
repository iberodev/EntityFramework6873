using BulkDeleteCreate.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;

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
        }
    }
}
