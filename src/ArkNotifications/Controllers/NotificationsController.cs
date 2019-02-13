using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArkNotifications.Models;

namespace ArkNotifications.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        // GET: api/notifications
        [HttpGet]
        public IEnumerable<NotificationModel> Get()
        {
            DbConnection db = new DbConnection();

            var result = (from r in db.Notifications
                          orderby r.Received descending
                          select r).Take(50);
            return result;
        }

        // GET api/notifications/5
        [HttpGet("{id}")]
        public IEnumerable<NotificationModel> Get(Guid id)
        {
            DbConnection db = new DbConnection();

            var result = from r in db.Notifications
                         where r.Id == id
                         select r;
            return result;
        }


        // POST api/notifications
#pragma warning disable SG0016 // Controller method is vulnerable to CSRF
        [HttpPost]
        public void Post(string key, string steamid, string notetitle, string message)
        {
            DbConnection db = new DbConnection();

            if (key != null)
            {
                var record = (from r in db.ApiKeys
                              where r.ApiKey == key
                              select r).Take(1);

                if (record.Count() >= 1)
                {
                    db.Notifications.Add(new NotificationModel { ApiKeyUsed = key, SteamId = steamid, NoteTitle = notetitle, Message = message, Received = DateTime.Now });
                    db.SaveChangesAsync();

                    Discord.SendNotification(notetitle, steamid);
                }
            }
        }
#pragma warning restore SG0016 // Controller method is vulnerable to CSRF
    }
}
