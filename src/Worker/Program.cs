using Worker;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<BotWorker>();
    })
    .Build();

await host.RunAsync();



// TEST FOR BITBOARDS

//using Domain.ValueObjects;
//using Engine.Bitboards;

//var board = new PieceBitboards();

//Square.TryFrom('a', 2, out var a2);
//Square.TryFrom('b', 2, out var b2);
//Square.TryFrom('e', 2, out var e2);
//Square.TryFrom('d', 7, out var d7);

//board.AddWhitePawn(a2!);
//board.AddWhitePawn(b2!);
//board.AddWhitePawn(e2!);
//board.AddBlackPawn(d7!);

//Console.WriteLine(board.AsciiCoordinates(e2));