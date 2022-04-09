using CreationalPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Notifications
{
    public class InstagramNotification : INotification
    {
        public string GetNotification()
        {
            return "Instagram Notification";
        }
    }
}
