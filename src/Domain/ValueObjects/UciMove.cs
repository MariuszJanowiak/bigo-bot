namespace Domain.ValueObjects;

public sealed record UciMove
{
    public Square From { get; }
    public Square To { get; }
    public PromotionPiece? Promotion { get; }

    private UciMove(Square from, Square to, PromotionPiece? promotion = null)
    {
        From = from;
        To = to;
        Promotion = promotion;
    }

    public static bool TryFrom(string? uci, out UciMove? move)
    {
        move = null;
        PromotionPiece? promotion = null;

        if (string.IsNullOrEmpty(uci) || uci.Length is not (4 or 5))
            return false;

        if (!Square.TryFrom(uci[0], (uci[1] - '0'), out var from))
            return false;
        if (!Square.TryFrom(uci[2], (uci[3] - '0'), out var to))
            return false;

        if (uci.Length == 5)
        {
            promotion = char.ToLowerInvariant(uci[4]) switch
            {
                'q' => PromotionPiece.Queen,
                'r' => PromotionPiece.Rook,
                'b' => PromotionPiece.Bishop,
                'n' => PromotionPiece.Knight,
                _ => null
            };

            if (promotion == null)
            {
                return false;
            }
        }

        move = new UciMove(from, to, promotion);
        return true;
    }
}