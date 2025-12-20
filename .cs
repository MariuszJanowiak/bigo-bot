using System;

namespace Tests;

public static class Helpers{
    static bool HasBit(ulong bb, Square sq) => (bb & Bitboard.Mask(sq)) != 0;

}
