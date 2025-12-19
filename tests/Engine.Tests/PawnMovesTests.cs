using Domain.ValueObjects;
using Engine.Bitboards;
using Engine.Moves;
using Xunit;

namespace Engine.Tests;

public sealed class PawnMovesTests
{
    [Fact]
    public void WhitePawns_Should_Move_One_Step_Forward()
    {
        // arrange
        var board = new PieceBitboards();

        Square.TryFrom('a', 2, out var a2);
        Square.TryFrom('b', 2, out var b2);
        Square.TryFrom('e', 2, out var e2);

        board.AddWhitePawn(a2!);
        board.AddWhitePawn(b2!);
        board.AddWhitePawn(e2!);

        // act
        var moves = PawnMoves.WhitePawnMove(board).ToList();

        // assert
        Assert.Contains(moves, m => m.From.Equals(a2) && m.To.Rank == 3);
        Assert.Contains(moves, m => m.From.Equals(b2) && m.To.Rank == 3);
        Assert.Contains(moves, m => m.From.Equals(e2) && m.To.Rank == 3);
        Assert.Equal(3, moves.Count);
    }

    [Fact]
    public void BlackPawn_Should_Move_One_Step_Forward()
    {
        // arrange
        var board = new PieceBitboards();

        Square.TryFrom('d', 7, out var d7);
        board.AddBlackPawn(d7!);

        // act
        var moves = PawnMoves.BlackPawnPushMoves(board).ToList();

        // assert
        Assert.Single(moves);
        Assert.Equal(7, moves[0].From.Rank);
        Assert.Equal(6, moves[0].To.Rank);
    }

    [Fact]
    public void Ascii_Should_Render_Board_With_Coordinates()
    {
        // arrange
        var board = new PieceBitboards();

        Square.TryFrom('a', 2, out var a2);
        Square.TryFrom('d', 7, out var d7);

        board.AddWhitePawn(a2!);
        board.AddBlackPawn(d7!);

        // act
        var ascii = board.AsciiCoordinates();

        // assert
        Assert.Contains("a  b  c  d  e  f  g  h", ascii);
        Assert.Contains("2 | P", ascii);
        Assert.Contains("7 | . . . p", ascii);
    }
}