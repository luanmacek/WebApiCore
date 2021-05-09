using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.EF
{
    class Tickets
    {
        public int? TicketId { get; set; }
        public int? ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
