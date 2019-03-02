using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
                botClient.OnCallbackQuery += BotClient_OnCallbackQueryAsync;
                botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static async void BotClient_OnCallbackQueryAsync(object sender, CallbackQueryEventArgs e)
        {
            switch (e.CallbackQuery.Data)
            {
                case "/kingspeech":
                    await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://dragon-quest.org/images/thumb/7/77/KingLorikArt.png/200px-KingLorikArt.png", "Храбрый воин, наследник великого рыцаря Эрдрика, на наши земли пришло зло в виде ужасного Драгонлорда! Отправляйся в его замок, который находится в лесу на севере и уничтож Драгонлорда!");
                    break;
            }
        }

        private static async Task getGamePage(Chat userChat)
        {
            InlineKeyboardButton b = new InlineKeyboardButton();
            b.Text = "Начать";
            b.CallbackData = "/kingspeech";

            var keys = new InlineKeyboardMarkup(b);
            await botClient.SendTextMessageAsync(userChat.Id, "-", replyMarkup: keys);
        }

        private static async void getMessage(object sender, MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "/begin":
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://vignette.wikia.nocookie.net/fictionalcrossover/images/8/80/Dragon_Quest_logo.png/");
                    await getGamePage(e.Message.Chat);
                    break;
                default:
                    break;
            }
        }
    }
}