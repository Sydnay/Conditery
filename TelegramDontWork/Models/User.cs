using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public int UserEventId { get; set; }
        public UserEvent UserEvent { get; set; }
        public List<Order> Orders { get; set; }
    }
}
