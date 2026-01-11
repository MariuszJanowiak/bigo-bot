using Domain.ValueObjects;
using Engine.Bitboards;

namespace Engine.Moves;

public static class MoveGenerator
{
    public static IReadOnlyList<UciMove> Generate(PieceBitboards board, bool whiteToMove)
    {
        ArgumentNullException.ThrowIfNull(board);

        return whiteToMove
            ? PawnMoves.WhitePawnMoveUci(board).ToList()
            : PawnMoves.BlackPawnMoveUci(board).ToList();
    }
}