using Domain.ValueObjects;

namespace Engine.Moves;

public static class UciMoveMapper
{
    public static UciMove ToUciMove(Square from, Square to, PromotionPiece? promotion = null)
    {
        string uci = BuildUci(from, to, promotion);

        if (!UciMove.TryFrom(uci, out var move) || move is null)
            throw new InvalidOperationException($"Failed to map to UCI move: '{uci}'.");

        return move;
    }

    private static string BuildUci(Square from, Square to, PromotionPiece? promotion)
    {
        Span<char> buffer = stackalloc char[promotion is null ? 4 : 5];

        buffer[0] = from.File;
        buffer[1] = (char)('0' + from.Rank);
        buffer[2] = to.File;
        buffer[3] = (char)('0' + to.Rank);

        if (promotion is not null)
        {
            buffer[4] = promotion.Value switch
            {
                PromotionPiece.Queen => 'q',
                PromotionPiece.Rook => 'r',
                PromotionPiece.Bishop => 'b',
                PromotionPiece.Knight => 'n',
                _ => throw new InvalidOperationException($"Unsupported promotion: {promotion}")
            };
        }

        return buffer.ToString();
    }
}