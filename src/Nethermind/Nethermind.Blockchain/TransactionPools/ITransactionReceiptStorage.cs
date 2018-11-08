using Nethermind.Core;
using Nethermind.Core.Crypto;

namespace Nethermind.Blockchain.TransactionPools
{
    public interface ITransactionReceiptStorage
    {
        TransactionReceipt Get(Keccak hash);
        void Add(TransactionReceipt receipt);
    }
}