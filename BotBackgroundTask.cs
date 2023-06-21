using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

public class BotBackgroundTask : BackgroundService
{
    private readonly ILogger<BotBackgroundTask> logger;
    private readonly ITelegramBotClient telegramBotClient;
    private readonly IUpdateHandler updateHandler;

    public BotBackgroundTask(
        ILogger<BotBackgroundTask> logger,
        ITelegramBotClient telegramBotClient,
        IUpdateHandler updateHandler)
    {
        this.logger = logger;
        this.telegramBotClient = telegramBotClient;
        this.updateHandler = updateHandler;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
         var me = await telegramBotClient.GetMeAsync(stoppingToken);
        logger.LogInformation("Bot {username} started at {time}", me.Username, DateTime.UtcNow);

        telegramBotClient.StartReceiving(
            updateHandler : updateHandler,
            receiverOptions : new ReceiverOptions
            {
                AllowedUpdates = new []
                {
                  UpdateType.Message,
                  UpdateType.EditedMessage
                },
            },
            cancellationToken : stoppingToken
        );
    }
}