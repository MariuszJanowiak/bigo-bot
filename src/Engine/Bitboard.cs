using Domain.ValueObjects;

namespace Engine
{
    public static class Bitboard
    {
        public static ulong Mask(Square square)
        {
            return 1UL << SquareIndexMapper.Map(square);
        }
    }
}
