using Telegram.Bot;
using Telegram.Bot.Types;

public partial class UpdateHandler
{
    private Task HandleEditMessageUpdateAsync(ITelegramBotClient botClient, Message editedMessage, CancellationToken cancellationToken)
    {
        var username = editedMessage.From?.Username ?? editedMessage.From.FirstName;
        logger.LogInformation("Received message from {username}: {text}", username, editedMessage.Text);
        return Task.CompletedTask;
    }
}