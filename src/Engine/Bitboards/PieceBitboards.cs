using Domain.ValueObjects;

namespace Engine.Bitboards
{
    public class PieceBitboards
    {
        public ulong WhitePawns { get; private set; }
        public ulong BlackPawns { get; private set; }

        public void AddWhitePawn(Square square)
        {
            WhitePawns |= Bitboard.Mask(square);
        }

        public void AddBlackPawn(Square square)
        {
            BlackPawns |= Bitboard.Mask(square);
        }

        public void RemoveWhitePawn(Square square)
        {
            WhitePawns &= ~Bitboard.Mask(square);
        }

        public void RemoveBlackPawn(Square square)
        {
            BlackPawns &= ~Bitboard.Mask(square);
        }

        public bool IsOccupied(Square square)
        {
            ulong mask = Bitboard.Mask(square);
            return (WhitePawns & mask) is not 0 || (BlackPawns & mask) is not 0;
        }
    }
}