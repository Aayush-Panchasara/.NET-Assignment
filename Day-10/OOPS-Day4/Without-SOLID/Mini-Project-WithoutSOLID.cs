using System;
using System.Collections.Generic;
using System.Text;

namespace OOPS_Day4.WithoutSOLID
{
    public class Video
    {

        public string Title;
        public string FileName;
        public Video(string title, string filename) { 
            Title = title;
            FileName = filename;
        }
    } 

    public class VideoProcessing
    {
        public bool isProcessingDone = false;

        public void StartVideoProcessing(Video video)
        {
            Console.WriteLine($"Video Processing started for {video.Title} ");
            Thread.Sleep( 1000 );
            EncodeVideoToMP4(video);
            StoreVideoOnCloud(video);

            onVideoProcessing(video);
        }
        public void EncodeVideoToMP4(Video video) 
        {
            Console.WriteLine($"Video Encoding Started for {video.Title}");
            Thread.Sleep(2000);
            Console.WriteLine($"Video Encoding is Done");
        }

        public void StoreVideoOnCloud(Video video)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Video uploaded on cloud: {video.Title}");
        }

        public void onVideoProcessing(Video video)
        {
            isProcessingDone = true;
            NotifyUser(video);
            Console.WriteLine("Video Processing is Done");
        }

        public void NotifyUser(Video video) {

            Thread.Sleep(3000);
            Console.WriteLine($"Video Processed and Uploaded Succesfully");
        }

    }

    internal class Mini_Project
    {
        public static void Main()
        {
            Video video = new Video("Complete C# (From basic to advance) in One shot ","C#-Tutorials");

            VideoProcessing videoOne = new VideoProcessing();
            videoOne.StartVideoProcessing(video);




        }
    }
}
