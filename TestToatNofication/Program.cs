using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using System.Data;
using Windows.Data.Xml.Dom;

namespace TestToatNofication
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //ToastContent toastContent = new ToastContentBuilder().AddToastActivationInfo("action=viewConversation&conversationId=5", ToastActivationType.Protocol).AddText("Hello world!").GetToastContent();

            // And create the toast notification
            //var toast = new ToastNotification(toastContent.GetXml());

            // And then show it
            //ToastNotificationManagerCompat.CreateToastNotifier().Show(toast);

            CreateAndShowPrompt("Hello test");

            Console.ReadLine(); 
        }

        public static void CreateAndShowPrompt(string message)
        {
            ToastContent toastContent = new ToastContent()
            {
                Launch = "bodyTapped",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = message
                            }
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons = { new ToastButton("Yes", "Yes"), new ToastButton("No", "No") }
                },
                Header = new ToastHeader("header", "App", "header"),
                Duration = ToastDuration.Long

            };

            toastContent.AdditionalProperties.Add("lkjsdlfkjsdf", "sdlfjlskjsldfkjsdifjlkjsdlfkj");

            var doc = new XmlDocument();
           
            doc.LoadXml(toastContent.GetContent());
            
            var promptNotification = new ToastNotification(doc);
            promptNotification.Activated += PromptNotificationOnActivated;
            promptNotification.Tag = "sdlkjsdflkjsflkjsdlfkjsldkjf";
            ToastNotificationManagerCompat.CreateToastNotifier().Show(promptNotification);
        }

        static void PromptNotificationOnActivated(ToastNotification sender, object args)
        {
            ToastActivatedEventArgs strArgs = args as ToastActivatedEventArgs;

            Console.WriteLine(sender.Tag);
            switch (strArgs.Arguments)
            {
                case "Yes":
                    Console.WriteLine("Yes");
                    Console.ReadLine();//stuff
                    break;
                case "No":
                    Console.WriteLine("No");
                    Console.ReadLine();//stuff
                    break;
                case "bodyTapped":
                    Console.WriteLine("bodytrapped");
                    Console.ReadLine();//stuff
                    break;
            }

        }


    }
}
