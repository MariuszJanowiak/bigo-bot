using Domain.ValueObjects;

namespace Engine.Bitboards;

public sealed class PieceBitboards
{
    // White
    public ulong WhitePawns { get; private set; }
    public ulong WhiteKnights { get; private set; }
    public ulong WhiteBishops { get; private set; }
    public ulong WhiteRooks { get; private set; }
    public ulong WhiteQueens { get; private set; }
    public ulong WhiteKing { get; private set; }

    // Black
    public ulong BlackPawns { get; private set; }
    public ulong BlackKnights { get; private set; }
    public ulong BlackBishops { get; private set; }
    public ulong BlackRooks { get; private set; }
    public ulong BlackQueens { get; private set; }
    public ulong BlackKing { get; private set; }

    public ulong WhitePieces =>
        WhitePawns | WhiteKnights | WhiteBishops | WhiteRooks | WhiteQueens | WhiteKing;

    public ulong BlackPieces =>
        BlackPawns | BlackKnights | BlackBishops | BlackRooks | BlackQueens | BlackKing;

    public ulong Occupied => WhitePieces | BlackPieces;

    // PAWNS
    public void AddWhitePawn(Square square) => WhitePawns |= Bitboard.Mask(square);
    public void AddBlackPawn(Square square) => BlackPawns |= Bitboard.Mask(square);
    public void RemoveWhitePawn(Square square) => WhitePawns &= ~Bitboard.Mask(square);
    public void RemoveBlackPawn(Square square) => BlackPawns &= ~Bitboard.Mask(square);

    // KNIGHTS
    public void AddWhiteKnight(Square square) => WhiteKnights |= Bitboard.Mask(square);
    public void AddBlackKnight(Square square) => BlackKnights |= Bitboard.Mask(square);
    public void RemoveWhiteKnight(Square square) => WhiteKnights &= ~Bitboard.Mask(square);
    public void RemoveBlackKnight(Square square) => BlackKnights &= ~Bitboard.Mask(square);

    // BISHOPS
    public void AddWhiteBishop(Square square) => WhiteBishops |= Bitboard.Mask(square);
    public void AddBlackBishop(Square square) => BlackBishops |= Bitboard.Mask(square);
    public void RemoveWhiteBishop(Square square) => WhiteBishops &= ~Bitboard.Mask(square);
    public void RemoveBlackBishop(Square square) => BlackBishops &= ~Bitboard.Mask(square);

    // ROOKS
    public void AddWhiteRook(Square square) => WhiteRooks |= Bitboard.Mask(square);
    public void AddBlackRook(Square square) => BlackRooks |= Bitboard.Mask(square);
    public void RemoveWhiteRook(Square square) => WhiteRooks &= ~Bitboard.Mask(square);
    public void RemoveBlackRook(Square square) => BlackRooks &= ~Bitboard.Mask(square);

    // QUEEN
    public void AddWhiteQueen(Square square) => WhiteQueens |= Bitboard.Mask(square);
    public void AddBlackQueen(Square square) => BlackQueens |= Bitboard.Mask(square);
    public void RemoveWhiteQueen(Square square) => WhiteQueens &= ~Bitboard.Mask(square);
    public void RemoveBlackQueen(Square square) => BlackQueens &= ~Bitboard.Mask(square);

    // KING
    public void AddWhiteKing(Square square) => WhiteKing |= Bitboard.Mask(square);
    public void AddBlackKing(Square square) => BlackKing |= Bitboard.Mask(square);
    public void RemoveWhiteKing(Square square) => WhiteKing &= ~Bitboard.Mask(square);
    public void RemoveBlackKing(Square square) => BlackKing &= ~Bitboard.Mask(square);

    public bool IsOccupied(Square square)
    {
        ulong mask = Bitboard.Mask(square);
        return (Occupied & mask) != 0;
    }
}
