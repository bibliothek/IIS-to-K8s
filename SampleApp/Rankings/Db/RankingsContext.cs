using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rankings.Models;

namespace Rankings.Db
{
    public class RankingsContext : DbContext
    {
        public RankingsContext (DbContextOptions<RankingsContext> options)
            : base(options)
        {
        }

        public DbSet<Rankings.Models.RankedItem> RankedItem { get; set; }
    }
}
