using System;
using System.Collections.Generic;
using System.Text;

namespace OOPS_Day4.SOLID
{
    class MiniProject_Program
    {
        public static void Main()
        {
            User user1 = new User(101,"Aayush Panchasara","aayushpanchasara@gmail.com");
            Video video1 = new Video(1, "Complete C# in one shot", "complete-C#", user1.UserId, user1.Email);

            IVideoEncoder encoder = new MP4Encoder();
            IVideoStorage storage = new AWSCloudStorage();
            INotificationService notificationService = new EmailService();

            VideoProcessor vp = new VideoProcessor(encoder, storage, notificationService);
            vp.Process(video1);
        }
    }
}
