using Engine.Bitboards;
using Engine.Moves.Pieces;
using Engine.Tests.TestHelpers;

namespace Engine.Tests;

public sealed class PawnMovesTests
{
    [Fact]
    public void WhitePawn_OnD2_Should_Have_PushMove_ToD3_When_D3_IsEmpty()
    {
        // arrange
        var board = new PieceBitboards();
        var d2 = BitboardTestHelper.DefineSquare('d', 2);
        var d3 = BitboardTestHelper.DefineSquare('d', 3);

        board.AddWhitePawn(d2);

        // act
        var moves = PawnMoves.WhitePawnMove(board).ToList();

        // assert
        Assert.Contains(moves, m => m.From == d2 && m.To == d3);
    }

    [Fact]
    public void WhitePawn_OnD2_Should_NotHave_PushMove_When_D3_IsOccupied()
    {
        // arrange
        var board = new PieceBitboards();
        var d2 = BitboardTestHelper.DefineSquare('d', 2);
        var d3 = BitboardTestHelper.DefineSquare('d', 3);

        board.AddWhitePawn(d2);
        board.AddBlackPawn(d3); // blokada

        // act
        var moves = PawnMoves.WhitePawnMove(board).ToList();

        // assert
        Assert.DoesNotContain(moves, m => m.From == d2 && m.To == d3);
    }

    [Fact]
    public void BlackPawn_OnD7_Should_Have_PushMove_ToD6_When_D6_IsEmpty()
    {
        // arrange
        var board = new PieceBitboards();
        var d7 = BitboardTestHelper.DefineSquare('d', 7);
        var d6 = BitboardTestHelper.DefineSquare('d', 6);

        board.AddBlackPawn(d7);

        // act
        var moves = PawnMoves.BlackPawnMove(board).ToList();

        // assert
        Assert.Contains(moves, m => m.From == d7 && m.To == d6);
    }

    [Fact]
    public void BlackPawn_OnD7_Should_NotHave_PushMove_When_D6_IsOccupied()
    {
        // arrange
        var board = new PieceBitboards();
        var d7 = BitboardTestHelper.DefineSquare('d', 7);
        var d6 = BitboardTestHelper.DefineSquare('d', 6);

        board.AddBlackPawn(d7);
        board.AddWhitePawn(d6); // blokada

        // act
        var moves = PawnMoves.BlackPawnMove(board).ToList();

        // assert
        Assert.DoesNotContain(moves, m => m.From == d7 && m.To == d6);
    }
}
