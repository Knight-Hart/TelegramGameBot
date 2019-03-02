using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramGameBot
{
    class Program
    {
        static TelegramBotClient botClient;
        static void Main(string[] args)
        {
            try
            {
                botClient = new TelegramBotClient("659459848:AAGt08uNp_ubBdb8ABzrGsVC5Ia4t1DwPo4");
                var bot = botClient.GetMeAsync().Result;
                botClient.OnMessage += getMessage;
                botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static async void getMessage(object sender, MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "/begin":
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://vignette.wikia.nocookie.net/fictionalcrossover/images/8/80/Dragon_Quest_logo.png/");
                    break;
                default:
                    break;
            }
        }
    }
}