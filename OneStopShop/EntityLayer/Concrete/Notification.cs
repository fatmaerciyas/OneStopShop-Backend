using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public bool NotificationStatus { get; set; }
        //User
       // public ICollection<UserNotification> UserNotifications { get; set; }
    }
}
