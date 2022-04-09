using CreationalPatterns.Factories;
using CreationalPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public class NotificationFactory 
    {
        public INotificationFactory CreateFactory(string platform)
        {
            if (string.IsNullOrEmpty(platform))
                throw new ArgumentNullException(platform);
            switch (platform.ToLower())
            {
                case "facebook":
                    return new FacebookNotificationFactory();
                    break;
                case "tumblr":
                    return new TumblrNotificationFactory();
                    break;
                case "instagram":
                    return new InstagramNotificationFactory();
                    break;
                default:
                    throw new ArgumentException(platform);
                    break;
            }
            
        }
    }
}
