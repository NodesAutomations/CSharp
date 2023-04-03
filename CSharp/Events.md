### Sample Code to Understand Creting and Subscribing to new events
```csharp

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            var video = new Video
            {
                Title = "Video 1"
            };

            var videoEncoder = new VideoEncoder();

            var mailService = new MailService();
            videoEncoder.VideoEncoded += mailService.OnVideoEncode;

            videoEncoder.Encode(video);

            Console.WriteLine("Press Any key to continue");
            Console.ReadLine();
        }
    }

    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEncoder
    {
        //1.Define Delegate
        //Naming of Delegage = NameOfDelgate + postfix(EventHandler)
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        //2.Define an event based on that delegate
        public event VideoEncodedEventHandler VideoEncoded;

        //3.Raise the event
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty);
            }
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            OnVideoEncoded();
        }
    }

    public class MailService
    {
        public void OnVideoEncode(object source, EventArgs e)
        {
            Console.WriteLine("Sending Mail...");
        }
    }
}
```
