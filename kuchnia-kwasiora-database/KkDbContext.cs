using Microsoft.EntityFrameworkCore;
using System;

namespace kuchnia_kwasiora_database
{
    public class KkDbContext : DbContext
    {
        public KkDbContext(DbContextOptions<KkDbContext> options) : base (options)
        {
        }
    }
}
