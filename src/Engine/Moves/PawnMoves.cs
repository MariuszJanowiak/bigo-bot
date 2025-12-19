using Domain.ValueObjects;
using Engine.Bitboards;

namespace Engine.Moves;

public static class PawnMoves
{
    public static ulong WhitePawnTargets(PieceBitboards board)
    {
        ulong occupied = board.WhitePawns | board.BlackPawns;
        return (board.WhitePawns << 8) & ~occupied;
    }

    public static ulong BlackPawnTargets(PieceBitboards board)
    {
        ulong occupied = board.WhitePawns | board.BlackPawns;
        return (board.BlackPawns >> 8) & ~occupied;
    }

    public static IEnumerable<(Square From, Square To)> WhitePawnMove(PieceBitboards board)
    {
        ulong targets = WhitePawnTargets(board);

        for (int toIndex = 0; toIndex < 64; toIndex++)
        {
            ulong toMask = 1UL << toIndex;
            if ((targets & toMask) == 0) continue;

            int fromIndex = toIndex - 8;

            if (!SquareIndexMapper.TryMap(fromIndex, out var from) || from is null) continue;
            if (!SquareIndexMapper.TryMap(toIndex, out var to) || to is null) continue;

            yield return (from, to);
        }
    }

    public static IEnumerable<(Square From, Square To)> BlackPawnPushMoves(PieceBitboards board)
    {
        ulong targets = BlackPawnTargets(board);

        for (int toIndex = 0; toIndex < 64; toIndex++)
        {
            ulong toMask = 1UL << toIndex;
            if ((targets & toMask) == 0) continue;

            int fromIndex = toIndex + 8;

            if (!SquareIndexMapper.TryMap(fromIndex, out var from) || from is null)
                continue;

            if (!SquareIndexMapper.TryMap(toIndex, out var to) || to is null)
                continue;

            yield return (from, to);
        }
    }
}