using CreationalPatterns.Interfaces;
using CreationalPatterns.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Factories
{
    public class FacebookNotificationFactory : INotificationFactory
    {
        public INotification CreateNotification()
        {
            return new FacebookNotification();
        }
    }
}
