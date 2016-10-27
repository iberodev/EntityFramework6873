using System;
using System.Collections;
using System.Collections.Generic;

namespace BulkDeleteCreate
{
    public static class AppSettings
    {
        public static Guid UserId = new Guid("91d85c01-d4be-4764-b2e6-b96dee264b09");
        public static Guid YesId = new Guid("8263f1f5-ea1c-4f96-bafe-ef759daf1ee1");
        public static Guid TheWhoId = new Guid("8263f1f5-ea1c-4f96-bafe-ef759daf1ee2");
        public static Guid MetallicaId = new Guid("8263f1f5-ea1c-4f96-bafe-ef759daf1ee3");
        public static Guid PinkFloydId = new Guid("8263f1f5-ea1c-4f96-bafe-ef759daf1ee4");
        public static IEnumerable<Guid> GetTheWhoMetallicaAndPinkFloydList()
        {
            return new List<Guid>
            {
                TheWhoId, MetallicaId, PinkFloydId
            };
        }
    }
}
