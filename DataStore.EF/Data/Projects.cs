using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.EF
{
    class Projects
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public List<Tickets> Tickets { get; set; }
    }
}
