public sealed record Square
{
    public char File { get;  }

    public int Rank { get; }

    private Square(char file, int rank)
    {
        File = file;
        Rank = rank;
    }

    // Controlled Creation

    public static bool TryFrom(char file, int rank, out Square? square)
    {
        file = char.ToLowerInvariant(file);

        if (rank is < 1 or > 8 || file < 'a' || file > 'h')
        {
            square = null;
            return false;
        }
        square = new Square(file, rank);
        return true;
    }
}