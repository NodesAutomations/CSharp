### References
- https://github.com/NodesAutomations/CSharp/issues/65

### Overview
- It's mechanism for communication between objects
- Used in building loosly coupled applications
- Help extending application
- There's normally two part of this mechanism. one is publish and second is subscriber. 
- One publish have multiple subscribers. publish also unaware of number of subscribers.

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
### Events which also pass some info to it's subscribers
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

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        //1.Define Delegate
        //Naming of Delegage = NameOfDelgate + postfix(EventHandler)
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        //2.Define an event based on that delegate
        public event VideoEncodedEventHandler VideoEncoded;

        //3.Raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video=video});
            }
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }
    }

    public class MailService
    {
        public void OnVideoEncode(object source, VideoEventArgs e)
        {
            Console.WriteLine("Sending Mail..." + e.Video.Title);
        }
    }
}
```
### Use Inbuilt Delegated instead of creating own
```csharp
    public class VideoEncoder
    {

        //2.Define an event based on that delegate
        //we can use EventHandler if we don't need to pass any data
        public event EventHandler<VideoEventArgs> VideoEncoded;

        //3.Raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video=video});
            }
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }
    }
```
