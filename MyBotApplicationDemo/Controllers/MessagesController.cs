using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.FormFlow;
using System.Text;
using Autofac;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace MyBotApplicationDemo
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // calculate something for us to return
                int length = (message.Text ?? string.Empty).Length;

                // return our reply to the user
                //  return message.CreateReplyMessage($"You sent {length} characters");
                // return message.CreateReplyMessage($"you said "+ message.Text);
                //return await Conversation.SendAsync(message, () => new EchoDialog());
                return await Conversation.SendAsync(message, MakeRootDialog);
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }
        ////internal static IDialog<SandwichOrder> MakeRootDialog()
        ////{
        ////    //FIRST ONE IS THE SANDWICH ORDER FORM 
        ////    return Chain.From(() => FormDialog.FromForm(SandwichOrder.BuildForm));

        ////}
        internal static IDialog<SimpleMovieBooking> MakeRootDialog()
        {
            //Second is the Movie order form 
            return Chain.From(() => FormDialog.FromForm(SimpleMovieBooking.BuildForm));
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
                return message.CreateReplyMessage("Hello and Welcome to demo for the BOT framework from Microsoft!!!!!! ");
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }


        //static async Task Interactive<T>(IDialog<T> form) where T : class
        //{
        //    // NOTE: I use the DejaVuSansMono fonts as described here: http://stackoverflow.com/questions/21751827/displaying-arabic-characters-in-c-sharp-console-application
        //    // But you don't have to reboot.
        //    // If you don't want the multi-lingual support just comment this out
        //    Console.OutputEncoding = Encoding.GetEncoding(65001);
        //    var message = new Activity()
        //    {
        //        From = new ChannelAccount { Id = "ConsoleUser" },
        //        Conversation = new ConversationAccount { Id = Guid.NewGuid().ToString() },
        //        Recipient = new ChannelAccount { Id = "FormTest" },
        //        ChannelId = "Console",
        //        ServiceUrl = "http://localhost:9000/",
        //        Text = ""
        //    };
        //    var builder = new ContainerBuilder();
        //    builder.RegisterModule(new DialogModule_MakeRoot());
        //    builder.RegisterType<InMemoryDataStore>()
        //        .As<IBotDataStore<BotData>>()
        //        .AsSelf()
        //        .SingleInstance();
        //    builder
        //        .Register(c => new BotIdResolver("testBot"))
        //        .As<IBotIdResolver>()
        //        .SingleInstance();
        //    builder
        //        .Register(c => new BotToUserTextWriter(new BotToUserQueue(message, new Queue<IMessageActivity>()), Console.Out))
        //        .As<IBotToUser>()
        //        .InstancePerLifetimeScope();
        //    using (var container = builder.Build())
        //    using (var scope = DialogModule.BeginLifetimeScope(container, message))
        //    {
        //        Func<IDialog<object>> MakeRoot = () => form;
        //        DialogModule_MakeRoot.Register(scope, MakeRoot);
        //        var task = scope.Resolve<IPostToBot>();
        //        await scope.Resolve<IBotData>().LoadAsync(default(CancellationToken));
        //        var stack = scope.Resolve<IDialogStack>();
        //        stack.Call(MakeRoot(), null);
        //        await stack.PollAsync(CancellationToken.None);
        //        while (true)
        //        {
        //            message.Text = await Console.In.ReadLineAsync();
        //            message.Locale = Locale;
        //            await task.PostAsync(message, CancellationToken.None);
        //        }
        //    }
        //}
        //echo example 
        //adding a claas to using the bot bulder dialogs 
        //[Serializable]
        //public class EchoDialog : IDialog<object>
        //{
        //    public async Task StartAsync(IDialogContext context)
        //    {
        //        context.Wait(MessageReceivedAsync);
        //    }
        //    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<Message> argument)
        //    {
        //        var message = await argument;
        //        await context.PostAsync("You said: " + message.Text);
        //        context.Wait(MessageReceivedAsync);
        //    }

        //echo state example 
        [Serializable]
        public class EchoDialog : IDialog<object>
        {
            protected int count = 1;
            public async Task StartAsync(IDialogContext context)
            {
                context.Wait(MessageReceivedAsync);
            }
            public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<Message> argument)
            {
                var message = await argument;
                if (message.Text == "reset")
                {
                    PromptDialog.Confirm(
                        context,
                        AfterResetAsync,
                        "Are you sure you want to reset the count?",
                        "Didn't get that!",
                        promptStyle: PromptStyle.None);
                }
                else
                {
                    await context.PostAsync(string.Format("{0}: You said {1}", this.count++, message.Text));
                    context.Wait(MessageReceivedAsync);
                }
            }
            public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
            {
                var confirm = await argument;
                if (confirm)
                {
                    this.count = 1;
                    await context.PostAsync("Reset count.");
                }
                else
                {
                    await context.PostAsync("Did not reset count.");
                }
                context.Wait(MessageReceivedAsync);
            }
        }
    }
}