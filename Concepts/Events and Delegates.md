# Events

### What?

- Mechanism for Communication between objects, Which Means if Something happen to one Object it can notify other object about that

### Why?

- Used in Building Loosely Coupled Application
- Helps with Easily Extend Functionality

### Terms

Publiser : Sender of Event

Subscriber : receiver of the event 

<aside>
💡 Here one Publisher can have Multiple Subscriber, and Subscriber can have multiple publisher. This will Help us create lots of Loosely Coupled Application.

</aside>

To do this we need agreement between Publisher and Subscriber which is done using delegates.

# Delegates

### What?

- It's Agreement between publisher and subscriber
- Determine signature of event handler method in subscriber

## Delegate Example

- Simple Example 1
    
    ```csharp
    internal class Program
        {
            private static void Main(string[] args)
            {
                Video video = new Video { Title = "Video 1" };
                VideoEncoder videoEncoder = new VideoEncoder();//Publisher
                var mailService = new MailService();
                var msgService = new MessageService();
                videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
                videoEncoder.VideoEncoded += msgService.OnVideoEncoded;
                videoEncoder.Encode(video);
    
            }
        }
        public class MailService
        {
            public void OnVideoEncoded(object Source,EventArgs e)
            {
                Console.WriteLine("Sending Mail");
            }
        }
    
        public class MessageService
        {
            public void OnVideoEncoded(object source,EventArgs e)
            {
                Console.WriteLine("Sending Message");
            }
        }
    
        public class VideoEncoder
        {
            //1:Define Delegate
            //2.Define an Event based on that
            //3.Raise an Event
            public delegate void VideoEncodedEventHandler(object source, EventArgs args);//1
            public event VideoEncodedEventHandler VideoEncoded;//2
            public void Encode(Video video)
            {
                Console.WriteLine("Encoding Video");
                Thread.Sleep(3000);
                OnVideoEncoded();
            }
            protected virtual void OnVideoEncoded()
            {
                if (VideoEncoded!=null)
                {
                    VideoEncoded(this, EventArgs.Empty);//3
                }
            }
        }
        public class Video
        {
            public string Title { get; set; }
        }
    ```
    
- Sample Example 2
    
    ```csharp
    internal class Program
        {
            private static void Main(string[] args)
            {
                Video video = new Video { Title = "Video 1" };
                VideoEncoder videoEncoder = new VideoEncoder();//Publisher
                var mailService = new MailService();
                var msgService = new MessageService();
                videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
                videoEncoder.VideoEncoded += msgService.OnVideoEncoded;
                videoEncoder.Encode(video);
            }
        }
    
        public class MailService
        {
            public void OnVideoEncoded(object Source, VideoEventArg e)
            {
                Console.WriteLine($"Sending Mail-{e.VideoTitle}");
            }
        }
    
        public class MessageService
        {
            public void OnVideoEncoded(object source, VideoEventArg e)
            {
                Console.WriteLine($"Sending Message-{e.VideoTitle}");
            }
        }
    
        public class VideoEventArg : EventArgs
        {
            public string VideoTitle { get; set; }
        }
    
        public class VideoEncoder
        {
            //1:Define Delegate
            //2.Define an Event based on that
            //3.Raise an Event
            public delegate void VideoEncodedEventHandler(object source, VideoEventArg args);//1
    
            public event VideoEncodedEventHandler VideoEncoded;//2
    
            public void Encode(Video video)
            {
                Console.WriteLine("Encoding Video");
                Thread.Sleep(3000);
                OnVideoEncoded(video);
            }
    
            protected virtual void OnVideoEncoded(Video video)
            {
                if (VideoEncoded != null)
                {
                    VideoEncoded(this, new VideoEventArg() { VideoTitle = video.Title });//3
                }
            }
        }
    
        public class Video
        {
            public string Title { get; set; }
        }
    ```
    

## Event Example

### Steps to Add Event Handler

1. Declaration for Event Handler (Reference Library)
2. Invoke / Raise Event (Reference Library)
3. Subscribe to Event (Main Project)
4. Implementation Code (Main Project)

### Event Example

- Example 1
    
    ```csharp
    //ClassLibrary
    using System;
    using System.Windows.Forms;
    
    namespace ClassLib
    {
        public partial class ClassLibraryForm : Form
        {
            //Step 1 : Event Declaration
            public event EventHandler<string> TestEvent;
    
            public ClassLibraryForm()
            {
                InitializeComponent();
            }
    
            private void btnClickMe_Click(object sender, EventArgs e)
            {
                lblMain.Text = "Hello World";
            }
    
            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
                //Step 2 : Invoke Event
                TestEvent?.Invoke(this, "Form Closed");
            }
        }
    }
    
    //Main Project
    using ClassLib;
    using System;
    using System.Windows.Forms;
    
    namespace CSharpWindowsFormsApp
    {
        internal static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            private static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var Form = new ClassLibraryForm();
                //Step 3 : Subscribe to Event
                Form.TestEvent += Form_TestEvent;
                Form.ShowDialog();
            }
    
            //Step 4 : Implimentation Code when Event is raised
            private static void Form_TestEvent(object sender, string e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
    ```
    
- Example 2
    
    ```csharp
    internal class Program
        {
            private static void Main(string[] args)
            {
                Video video = new Video { Title = "Video 1" };
                VideoEncoder videoEncoder = new VideoEncoder();//Publisher
                var mailService = new MailService();
                var msgService = new MessageService();
                videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
                videoEncoder.VideoEncoded += msgService.OnVideoEncoded;
                videoEncoder.Encode(video);
            }
        }
    
        public class MailService
        {
            public void OnVideoEncoded(object Source, VideoEventArg e)
            {
                Console.WriteLine($"Sending Mail-{e.VideoTitle}");
            }
        }
    
        public class MessageService
        {
            public void OnVideoEncoded(object source, VideoEventArg e)
            {
                Console.WriteLine($"Sending Message-{e.VideoTitle}");
            }
        }
    
        public class VideoEventArg : EventArgs
        {
            public string VideoTitle { get; set; }
        }
    
        public class VideoEncoder
        {
            //Event Handler
            public event EventHandler<VideoEventArg> VideoEncoded;//2
    
            public void Encode(Video video)
            {
                Console.WriteLine("Encoding Video");
                Thread.Sleep(3000);
                OnVideoEncoded(video);
            }
    
            protected virtual void OnVideoEncoded(Video video)
            {
                if (VideoEncoded != null)
                {
                    VideoEncoded(this, new VideoEventArg() { VideoTitle = video.Title });//3
                }
            }
        }
    
        public class Video
        {
            public string Title { get; set; }
        }
    ```
