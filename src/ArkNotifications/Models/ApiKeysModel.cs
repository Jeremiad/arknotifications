using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkNotifications.Models
{
    public class ApiKeysModel
    {
        public int Id { get; set; }
        public string ApiKey { get; set; }
        public bool IsValid { get; set; }
        public DateTime? Added { get; set; }
    }
}
