using System;
using System.Collections.Generic;
using System.Text;

namespace OOPS_Day4.SOLID
{
    class VideoProcessor
    {
        private IVideoEncoder encoder;
        private IVideoStorage storage;
        private INotificationService notificationService;

        public VideoProcessor(IVideoEncoder encoder, IVideoStorage storage, INotificationService notificationService)
        {
            this.encoder = encoder;
            this.storage = storage;
            this.notificationService = notificationService;
        }

        public void Process(Video video)
        {
            Console.WriteLine($"Video with videoId: {video.VideoId} are under processing...");
            Thread.Sleep(2000);
            encoder.Encode(video);

            storage.Store(video);

            notificationService.Send(video.OwnerEmail, "Video Processing and uploading is completed successfully");

            Console.WriteLine($"Processing of VideoId: {video.VideoId} is Completed.");
        }
    }
}
