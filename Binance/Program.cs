using Binance.CurrencyClient;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public class Program
{
    public static void Main()
    {
        //var bot = new TelegramBot();
        //Console.ReadKey();

        Console.WriteLine(CurrencyClient.GetPrices("BTC", "USD").Result);
    }
}
class TelegramBot 
{
    TelegramBotClient botClient = new TelegramBotClient("5450834704:AAGP3QPyaxPDeNed_F0FnmuYMR5RjftarpU");
    public TelegramBot() 
    {
        using var cts = new CancellationTokenSource();

        // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new UpdateType[] { UpdateType.Message } // receive only messages
        };
        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = botClient.GetMeAsync().Result;

        Console.WriteLine($"Start listening for @{me.Username}");
    }
    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Check null
        if (update == null || update.Message == null)
            return;
        // Only process text messages
        if (update.Message.Text is not { } messageText)
            return;

        var chatId = update.Message.Chat.Id;

        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

        // Echo received message text
        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "You said:\n" + messageText,
            cancellationToken: cancellationToken);
    }

    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }

}
