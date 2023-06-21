using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

public partial class UpdateHandler : IUpdateHandler
{
    private Task HandleMessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        var username = message.From?.Username ?? message.From.FirstName;
        logger.LogInformation("Received message from {username}: {text}", username, message.Text);
        return Task.CompletedTask;
    }
}