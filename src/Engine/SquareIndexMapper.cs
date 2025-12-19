using Domain.ValueObjects;


namespace Engine;

public static class SquareIndexMapper
{
    public static int Map(Square square)
    {
        ArgumentNullException.ThrowIfNull(square);

        int fileIndex = square.File - 'a';
        int rankIndex = square.Rank - 1;

        return (rankIndex * 8) + fileIndex;
    }

    public static bool TryMap(int index, out Square? square)
    {
        if (index is < 0 or > 63)
        {
            square = null;
            return false;
        }
        int rank = (index / 8) + 1;
        char file = (char)('a' + (index % 8));
        return Square.TryFrom(file, rank, out square);
    }
}