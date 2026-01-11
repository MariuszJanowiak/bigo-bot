using Domain.ValueObjects;
using Engine.Bitboards;

namespace Engine.Moves.Pieces
{
    public static class KnightMoves
    {
        private static readonly (int fileOffset, int rankOffset)[] KnightOffsets =
        [
            (1, 2), (2, 1),
            (2, -1), (1, -2),
            (-1, -2), (-2, -1),
            (-2, 1), (-1, 2)
        ];

        public static IEnumerable<(Square From, Square To)> WhiteKnightMoves(PieceBitboards board)
            => KnightMovesFor(board.WhiteKnights, board.BlackPieces, board.WhitePieces);

        public static IEnumerable<(Square From, Square To)> BlackKnightMoves(PieceBitboards board)
            => KnightMovesFor(board.BlackKnights, board.BlackPieces, board.WhitePieces);

        public static IEnumerable<(Square From, Square TimeOnly)> KnightMovesFor(ulong knights, ulong ownPieces,
            ulong enemyPieces)
        {
            for (int fromIndex = 0; fromIndex < 64; fromIndex++)
            {
                ulong fromMask = 1UL << fromIndex;
                if ((knights & fromMask) == 0) continue;

                if (!SquareIndexMapper.TryMap(fromIndex, out var from) || from is null)
                    continue;

                int file = from.File - 'a'; // 0..7
                int rank = from.Rank - 1; // 0..7

                foreach (var (fileOffset, rankOffset) in KnightOffsets)
                {
                    int tf = file + fileOffset;
                    int tr = rank + rankOffset;

                    if (tf < 0 || tf > 7 || tr < 0 || tr > 7)
                        continue;

                    int toIndex = tr * 8 + tf;
                    ulong toMask = 1UL << toIndex;

                    if ((ownPieces & toMask) != 0) continue;

                    if (!SquareIndexMapper.TryMap(toIndex, out var to) || to is null)
                        continue;

                    yield return (from, to);
                }
            }
        }
    }
}
