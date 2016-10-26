using System;
using System.Threading.Tasks;

namespace BulkDeleteCreate.Repositories
{
    public interface ITestRepository
    {
        Task UpdateGroupMembershipsAsync(Guid userId);
    }
}
