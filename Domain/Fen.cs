
public sealed record Fen
{
    public string Value { get; }

    private Fen(string value)
    {
        Value = value;
    }

    // Controlled Creation
    public static bool TryFrom(string? fenValue, out Fen? fen)
    {
        if (string.IsNullOrWhiteSpace(fenValue)) { fen = null; return false; }

        string[] tokens = fenValue.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length != 6)
        {
            fen = null;
            return false;
        }
        fen = new Fen(fenValue);
        return true;
    }
}