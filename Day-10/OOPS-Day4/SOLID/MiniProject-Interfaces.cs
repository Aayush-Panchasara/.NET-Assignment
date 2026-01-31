using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace OOPS_Day4.SOLID
{
    interface IVideoEncoder
    {
        void Encode(Video video);

    }

    interface IVideoStorage
    {
        void Store(Video video);
    }

    interface IDatabaseService
    {
        void uploadVideo(string videoLink);
    }

    interface INotificationService
    {
        void Send(string OwnerEmail, string message);
    }
   
}
