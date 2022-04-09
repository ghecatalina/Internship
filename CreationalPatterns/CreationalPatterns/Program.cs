using CreationalPatterns;
using CreationalPatterns.Interfaces;

NotificationFactory factory = new NotificationFactory();
var factory1 = factory.CreateFactory("facebook").CreateNotification();
Console.WriteLine(factory1.GetNotification());
var factory2 = factory.CreateFactory("instagram").CreateNotification();
Console.WriteLine(factory2.GetNotification());
var factory3 = factory.CreateFactory("tumblr").CreateNotification();
Console.WriteLine(factory3.GetNotification());
