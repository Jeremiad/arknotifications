using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkNotifications.Models
{
    public class NotificationModel
    {
        public Guid Id { get; set; }
        public string ApiKeyUsed { get; set; }
        public string SteamId { get; set; }
        public string NoteTitle { get; set; }
        public string Message { get; set; }
        public DateTime? Received { get; set; }
    }
}
