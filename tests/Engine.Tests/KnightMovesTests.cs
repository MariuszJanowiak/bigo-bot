using Domain.ValueObjects;
using Engine.Bitboards;
using Engine.Tests.TestHelpers;

namespace Engine.Tests
{
    [Fact]
    public void Knight_OnE4_Should_Have_8_Possible_Moves_On_Empty_Board()
    {
        // arrange
        var board = new PieceBitboards();
        var e4 = BitboardTestHelper.DefineSquare('e', 4);
        board.AddWhiteKnight(e4);
        // act
        var moves = KnightMoves.WhiteKnightMove(board).ToList();
        // assert
        var expectedDestinations = new List<Square>
        {
            BitboardTestHelper.DefineSquare('d', 6),
            BitboardTestHelper.DefineSquare('f', 6),
            BitboardTestHelper.DefineSquare('c', 5),
            BitboardTestHelper.DefineSquare('g', 5),
            BitboardTestHelper.DefineSquare('c', 3),
            BitboardTestHelper.DefineSquare('g', 3),
            BitboardTestHelper.DefineSquare('d', 2),
            BitboardTestHelper.DefineSquare('f', 2),
        };
        foreach (var destination in expectedDestinations)
        {
            Assert.Contains(moves, m => m.From == e4 && m.To == destination);
        }
        Assert.Equal(8, moves.Count);
    }
}
