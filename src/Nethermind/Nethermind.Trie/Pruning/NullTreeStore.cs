using System;
using Nethermind.Core.Crypto;

namespace Nethermind.Trie.Pruning
{
    public class NullTreeStore : ITreeStore
    {
        public void Commit(long blockNumber, NodeCommitInfo nodeCommitInfo)
        {
        }

        public void FinishBlockCommit(long blockNumber, TrieNode? root)
        {
        }

        public TrieNode FindCachedOrUnknown(Keccak hash)
        {
            return new TrieNode(NodeType.Unknown, hash);
        }

        public byte[] LoadRlp(Keccak hash, bool allowCaching)
        {
            return Array.Empty<byte>();
        }

        public void Unwind()
        {
        }

        public event EventHandler<BlockNumberEventArgs> Stored;
    }
}
