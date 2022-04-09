using CreationalPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Notifications
{
    public class FacebookNotification : INotification
    {
        public string GetNotification()
        {
            return "Facebook Notification";
        }
    }
}
