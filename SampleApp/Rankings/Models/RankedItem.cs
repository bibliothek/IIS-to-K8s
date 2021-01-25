using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rankings.Models
{
    public class RankedItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int EloNumber { get; set; }
    }
}
