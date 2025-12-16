public sealed record GameId
{
    public string Id { get; }

    private GameId(string id)
    {
        Id = id;
    }

    // Controlled Creation

    public static bool TryFrom(string? value, out GameId? gameId)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            gameId = null;
            return false;
        }

        gameId = new GameId(value);
        return true;
    }
}