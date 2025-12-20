using Domain.ValueObjects;
using Engine.Bitboards;
using Engine.Moves;

namespace Worker;

public sealed class BotWorker : BackgroundService
{

    private ILogger<BotWorker> _logger { get; }

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

        // From - To
        foreach (var m in PawnMoves.WhitePawnMove(board))
        {
            _logger.LogInformation("MOVE: {from}{fromRank}->{to}{toRank}",
                m.From.File, m.From.Rank, m.To.File, m.To.Rank);
        }

        // UCI
        foreach (var uci in PawnMoves.WhitePawnMoveUci(board))
        {
            _logger.LogInformation("UCI: {uci}", $"{uci.From.File}{uci.From.Rank}{uci.To.File}{uci.To.Rank}");
        }

        // Keep the service running
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

}
