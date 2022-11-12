using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; } = "Some description";
        public string Location { get; set; } = "Some location";
        public string Price { get; set; } = "Some Price";
        public string Attachment { get; set; } = "Some photo";
        public DateTime ExecutionDate { get; set; } = DateTime.MinValue;
        public DateTime UpdateTime { get; set; } = DateTime.MinValue;

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
