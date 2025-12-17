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
}