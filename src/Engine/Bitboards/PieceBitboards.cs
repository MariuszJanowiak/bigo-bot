using System.Text;
using Domain.ValueObjects;

namespace Engine.Bitboards;

public sealed class PieceBitboards
{
    public ulong WhitePawns { get; private set; }
    public ulong BlackPawns { get; private set; }

    public void AddWhitePawn(Square square) => WhitePawns |= Bitboard.Mask(square);
    public void AddBlackPawn(Square square) => BlackPawns |= Bitboard.Mask(square);

    public void RemoveWhitePawn(Square square) => WhitePawns &= ~Bitboard.Mask(square);
    public void RemoveBlackPawn(Square square) => BlackPawns &= ~Bitboard.Mask(square);

    public bool IsOccupied(Square square)
    {
        ulong mask = Bitboard.Mask(square);
        return (WhitePawns & mask) != 0 || (BlackPawns & mask) != 0;
    }

    public IEnumerable<string> Ascii(Square? highlight = null)
    {
        for (int rank = 8; rank > 0; rank--)
        {
            var line = new StringBuilder(8 * 3);

            for (char file = 'a'; file <= 'h'; file++)
            {
                if (!Square.TryFrom(file, rank, out var square) || square is null)
                    throw new InvalidOperationException();

                ulong mask = Bitboard.Mask(square);
                bool isHighlight = highlight is not null && square == highlight;

                line.Append(isHighlight ? '[' : ' ');

                if ((WhitePawns & mask) != 0) line.Append('P');
                else if ((BlackPawns & mask) != 0) line.Append('p');
                else line.Append('.');

                line.Append(isHighlight ? ']' : ' ');
            }

            yield return line.ToString();
        }
    }

    public string AsciiCoordinates(Square? highlight = null)
    {
        var sb = new StringBuilder();

        int rank = 8;
        foreach (var line in Ascii(highlight))
        {
            sb.Append(rank);
            sb.Append(" |");
            sb.Append(line);
            sb.AppendLine("|");
            rank--;
        }

        sb.Append("    ");
        sb.AppendLine("a  b  c  d  e  f  g  h");

        return sb.ToString();
    }
}