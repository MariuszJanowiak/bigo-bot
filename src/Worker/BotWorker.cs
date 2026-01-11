using Domain.ValueObjects;
using Engine.Bitboards;
using Engine.Decision;
using Engine.Moves;

namespace Worker;

public sealed class BotWorker : BackgroundService
{
    private readonly ILogger<BotWorker> _logger;

    public BotWorker(ILogger<BotWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var board = new PieceBitboards();

        Square.TryFrom('a', 2, out var a2);
        Square.TryFrom('b', 2, out var b2);
        Square.TryFrom('e', 2, out var e2);
        Square.TryFrom('d', 7, out var d7);

        board.AddWhitePawn(a2!);
        board.AddWhitePawn(b2!);
        board.AddWhitePawn(e2!);
        board.AddBlackPawn(d7!);

        _logger.LogInformation("\n{board}", board.AsciiCoordinates(e2));

        bool whiteToMove = true;

        var moves = MoveGenerator.Generate(board, whiteToMove);

        foreach (var uci in moves)
        {
            _logger.LogInformation("UCI: {uci}", $"{uci.From.File}{uci.From.Rank}{uci.To.File}{uci.To.Rank}");
        }

        var selector = new FirstMoveSelector();
        var chosen = selector.Select(moves);

        _logger.LogInformation(
            "CHOSEN MOVE: {uci}",
            $"{chosen.From.File}{chosen.From.Rank}{chosen.To.File}{chosen.To.Rank}"
        );

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}