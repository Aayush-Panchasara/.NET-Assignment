using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OOPS_Day4.SOLID
{
     public class User
    {
        public int UserId;
        public string Name;
        public string Email;
        List<Video> videos;
        public User(int userid, string name, string email) {
            UserId = userid;
            Name= name;
            Email= email;
            videos= new List<Video>();
        }

        public void addVideo(Video video)
        {
            videos.Add(video);
            Console.WriteLine("");
        }
    }

    public class Video
    {
        public int VideoId;
        public string Title;
        public string FileName;
        public string CloudURL;
        public int OwnerId;
        public string OwnerEmail;

        public Video(int videoid, string title, string fileName, int ownerid, string ownerEmail)
        {
            VideoId = videoid;
            Title = title;
            FileName = fileName;
            OwnerId = ownerid;
            OwnerEmail = ownerEmail;
        }
    }

    public class MP4Encoder : IVideoEncoder
    {
        public void Encode(Video video)
        {
            Console.WriteLine($"Process of encoding VideoId: {video.VideoId} to MP4 is started...");
            Thread.Sleep(2000);
            Console.WriteLine($"Encoding of Videoid: {video.VideoId} to MP4 is completed successfully.");
        }

    }

    public class MKVEncoder : IVideoEncoder
    {
        public void Encode(Video video)
        {
            Console.WriteLine($"Process of encoding VideoId: {video.VideoId} to MKV is started...");
            Thread.Sleep(2000);
            Console.WriteLine($"Encoding of Videoid: {video.VideoId} to MKV is completed successfully.");
        }
    }


    public class AWSCloudStorage : IVideoStorage
    {
        public void Store(Video video)
        {
            Console.WriteLine($"Saving VideoId: {video.VideoId} to AWS cloud...");
            Thread.Sleep(2000);
            string videoCloudUrl = $"https://s3.amazonaws.com/{video.VideoId}";
            video.CloudURL = videoCloudUrl;
            Console.WriteLine($"VideoId: {video.VideoId} Saved successfully on AWS");
        }
    }

    public class GoogleCloudStorage : IVideoStorage
    {
        public void Store(Video video)
        {
            Console.WriteLine($"Saving VideoId: {video.VideoId} to Google cloud...");
            Thread.Sleep(2000);
            string videoCloudUrl = $"https://storage.cloud.google.com/{video.VideoId}";
            video.CloudURL = videoCloudUrl;
            Console.WriteLine($"VideoId: {video.VideoId} Saved successfully on Google cloud");
        }
    }

    public class EmailService : INotificationService
    {
        public void Send(string email, string message)
        {
            Console.WriteLine($"Sending email to {email} Message: {message}.");
            Thread.Sleep(2000);
            Console.WriteLine($"Email send successfully");
        }
    }

}
