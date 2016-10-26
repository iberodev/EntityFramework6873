using BulkDeleteCreate.Model;
using System.Collections.Generic;
using System.Linq;

namespace BulkDeleteCreate.SqlServer
{
    public  class SampleContextSeeder
    {
        private readonly SampleContext _context;

        public SampleContextSeeder(SampleContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Users.Any())
            {
                var groups = new List<Group>
                {
                    new Group
                    {
                        Id = AppSettings.YesId,
                        Name = "Yes"
                    },
                    new Group
                    {
                        Id = AppSettings.TheWhoId,
                        Name = "The Who"
                    },
                    new Group
                    {
                        Id = AppSettings.MetallicaId,
                        Name = "Metallica"
                    },
                    new Group
                    {
                        Id = AppSettings.PinkFloydId,
                        Name = "Pink Floyd"
                    }
                };
                _context.Groups.AddRange(groups);

                var user = new User
                {
                    Id = AppSettings.UserId,
                    Name = "Joe Bloggs",
                    GroupMembers = new List<GroupMember>
                    {
                        new GroupMember
                        {
                            Group = groups.ElementAt(0)
                        },
                        new GroupMember
                        {
                            Group = groups.ElementAt(1)
                        }
                    }
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
    }
}
