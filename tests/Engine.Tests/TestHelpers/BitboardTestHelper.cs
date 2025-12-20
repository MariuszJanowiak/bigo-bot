using Domain.ValueObjects;
using Engine.Bitboards;

namespace Engine.Tests.TestHelpers;

public static class BitboardTestHelper
{
    public static bool HasBit(ulong bitboard, Square square)
        => (bitboard & Bitboard.Mask(square)) != 0;

    public static Square DefineSquare(char file, int rank)
    {
        if (!Square.TryFrom(file, rank, out var sq) || sq is null)
            throw new InvalidOperationException($"Invalid square: {file}{rank}");

        return sq;
    }
}