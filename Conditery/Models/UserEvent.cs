using System.ComponentModel.DataAnnotations.Schema;

namespace Conditery.Models
{
    public class UserEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
    public enum EventType
    {
        HandleStart = 1,
        HandleCreateOrder,
        HandleOrderType,
        HandleOrderDetails,
        HandleOrderCity,
        HandleOrderPriceRange,
        HandleOrderDate,
        HandleOrderAttachments,
        HandleOrderReady,
    }
}