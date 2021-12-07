using Nethermind.Api;
using Nethermind.Api.Extensions;
using Nethermind.Blockchain.Tracing;
using Nethermind.Core;
using Nethermind.Logging;
using Nethermind.Network.Discovery;
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
        (IApiWithStores getFromApi, _) = _nethermindApi.ForBlockchain;
    }
    private void ProcessNodeDiscovered(object? sender, NodeEventArgs e)
    {
        long currentRep = e.Node.CurrentReputation;
        _logger.Info($"Node discovered! Current reputation: ${currentRep}");
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
        _nethermindApi.ForNetwork.GetFromApi.DiscoveryApp.NodeDiscovered
        
        
        return Task.CompletedTask;
    }
    
    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
