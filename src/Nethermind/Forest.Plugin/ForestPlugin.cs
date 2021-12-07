using Nethermind.Api;
using Nethermind.Api.Extensions;
using Nethermind.Blockchain.Tracing;
using Nethermind.Core;
using Nethermind.Logging;
using Nethermind.TxPool;

namespace Forest.Plugin;

public class ForestPlugin : INethermindPlugin
{
    private INethermindApi _nethermindApi = null!;
    private ILogger _logger = null!;
    private HttpClient _client = null!;
    private ITracer _tracer = null!;
    public string Name => "ForestRun";
    public string Description => "Exploring the dark forest";
    public string Author => "Redisun x NoScript";
    
    public Task Init(INethermindApi nethermindApi)
    {
        _nethermindApi = nethermindApi ?? throw new ArgumentNullException(nameof(nethermindApi));
        _logger = nethermindApi.LogManager.GetClassLogger();

        return Task.CompletedTask;
    }
    
    private void ProcessIncomingTransaction(object? sender, TxEventArgs e)
    {
        Transaction transaction = e.Transaction;
        _logger.Info(transaction.Hash?.ToString());
    }

    public Task InitNetworkProtocol()
    {
        return Task.CompletedTask;
    }

    public Task InitRpcModules()
    {
        _client = new HttpClient();

        _tracer = new Tracer(_nethermindApi.StateProvider!, _nethermindApi.BlockchainProcessor!);
        _nethermindApi.TxPool!.NewPending += ProcessIncomingTransaction;
        return Task.CompletedTask;
    }
    
    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
