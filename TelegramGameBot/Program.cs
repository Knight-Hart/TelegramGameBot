using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
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
                    InlineKeyboardButton b = new InlineKeyboardButton();
                    b.Text = "Отправиться в лес";
                    b.CallbackData = "/to_the_forest";
                    var keys = new InlineKeyboardMarkup(b);
                    await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://dragon-quest.org/images/thumb/7/77/KingLorikArt.png/200px-KingLorikArt.png", "Храбрый воин, наследник великого рыцаря Эрдрика, на наши земли пришло зло в виде ужасного Драгонлорда! Отправляйся в его замок, который находится в лесу на севере и уничтож Драгонлорда!");
                    await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "-", replyMarkup: keys);
                    break;
                case "/to_the_forest":
                    {
                        List<InlineKeyboardButton> btns = new List<InlineKeyboardButton>();
                        btns.Add(new InlineKeyboardButton() { CallbackData = "/counter", Text = "Контратаковать" });
                        btns.Add(new InlineKeyboardButton() { CallbackData = "/evade", Text = "Увернуться" });
                        await botClient.SendAnimationAsync(e.CallbackQuery.Message.Chat.Id, "https://thumbs.gfycat.com/TeemingBabyishAnnelid-small.gif");
                        await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "По пути лес на вас набросился один из подданных Драгонлорда! Слайм нападает и прыгает на вас, пытаясь повалить на пол!");
                        var b1 = new InlineKeyboardMarkup(btns);
                        await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "-", replyMarkup: b1);
                        break;
                    }
                case "/counter":
                    {
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://cdn-images-1.medium.com/max/1200/1*jGZe7mqtuC-_sjwlfS--Cw.png", "Вы попытасть ударить слайма, но его слизь расплавила лезвие меча. Вам ничего не остается, кроме как вернуться домой и ждать смерти от рук Драгонлорда.");
                        break;
                    }
                case "/evade":
                    {
                        InlineKeyboardButton b2 = new InlineKeyboardButton();
                        b2.Text = "Войти";
                        b2.CallbackData = "/enter";
                        var bb2 = new InlineKeyboardMarkup(b2);
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "http://4.bp.blogspot.com/-Xo4ZSepT4gQ/UiXpDU1xgKI/AAAAAAAAAUA/PCjsskLnwuc/s1600/spooky+castle.jpg", "Вы увернулсь, от прыжка слайма. За вами было дерево, в которое слайм врезался и бошльше был не в состоянии сражаться. Пройдя по лесу вы наткнулись на замок Драгонлорда. У вас пробежали мурашки по коже от одного только вида этого сооружения.");
                        await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "-", replyMarkup: bb2);
                        break; ;
                    }
                case "/enter":
                    {
                        await botClient.SendAudioAsync(e.CallbackQuery.Message.Chat.Id, "https://www.woodus.com/den/gallery/graphics/dq3snes/mp3/10%20Dragon%20Quest%203%20-%20Battle%20Theme.mp3");
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://i3.wp.com/usercontent1.hubstatic.com/4580568_f520.jpg", "Перед вами стоит Драгонлорд. Вы понимаете, что это последнияя битва. Драгонлорд говорит: Ну что, человек! Так уж и быть, дам первый ход тебе!");
                        List<InlineKeyboardButton> btns3 = new List<InlineKeyboardButton>();
                        btns3.Add(new InlineKeyboardButton() { CallbackData = "/cast", Text = "Метнуть фаербол" });
                        btns3.Add(new InlineKeyboardButton() { CallbackData = "/attack", Text = "Ударить мечем" });
                        var b3 = new InlineKeyboardMarkup(btns3);
                        await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "-", replyMarkup: b3);
                        break;
                    }
                case "/cast":
                    {
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://i3.wp.com/usercontent1.hubstatic.com/4580568_f520.jpg", "Пока вы кастовали фаербол, Драогонлорд одним взмахом руки снес люстру над вами. Люстра упала прямо на вас, устроив вам небольшую большую травму мозга");
                        break;
                    }
                case "/attack":
                    {
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "http://www.macdonaldarms.com/armoury/images/SOP3.jpg", "Вы начали наносить Драгонлорду удар за ударом, но ваши удары были малоэффективны. ВНЕЗАПНО вы услышали голос Эрдрика: Храбрый воин, обычный меч не сможет одолеть зло. Я дам твоему мечу силу, с которой ты сразишь Драгонлорда одним ударом!");
                        InlineKeyboardButton b4 = new InlineKeyboardButton();
                        b4.Text = "Навалять Драгонлорду";
                        b4.CallbackData = "/navalyat";
                        var bb4 = new InlineKeyboardMarkup(b4);
                        await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "-", replyMarkup: bb4);
                        break;
                    }
                case "/navalyat":
                    {
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRXmyQj9dswTp9Y6oCJof8_ZzD2sTpy5YOkUq1d8ygP5rjBkNAJ", "Вы победили зло и спасли мир. Легенда о вас будет передаваться еще много лет");
                        break;
                    }
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

        private static async Task deleteLastMsg(Chat chatId, int msgId)
        {
            try
            {
                await botClient.DeleteMessageAsync(chatId, msgId);
            }
            catch (ApiRequestException e)
            {
                Console.WriteLine("удалил не то");
            }
            catch (Exception e)
            {
                Console.WriteLine("удалил  то");
            }
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