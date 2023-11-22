using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.NotificatonDTOs
{
    public class UpdateNotificationDTO
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public bool NotificationStatus { get; set; }
    }
}
