using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWhyzr.EntityFrameworkCore
{
    public static class eCommerceWhyzrDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<eCommerceWhyzrDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<eCommerceWhyzrDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
