﻿/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using Nethermind.Core.Crypto;
using Nethermind.Core.Extensions;
using Nethermind.Core.Specs;
using NUnit.Framework;

namespace Nethermind.Core.Test
{
    [TestFixture]
    public class BlockHeaderTests
    {
        [Test]
        public void Hash_as_expected()
        {
            BlockHeader header = new BlockHeader();
            header.Bloom = new Bloom(
                Bytes.FromHexString("0x00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")
                    .ToBigEndianBitArray2048());
            header.Beneficiary = new Address("0x8888f1f195afa192cfee860698584c030f4c9db1");
            header.Difficulty = Bytes.FromHexString("0x020000").ToUInt256();
            header.ExtraData = Bytes.Empty;
            header.GasLimit = (long)Bytes.FromHexString("0x2fefba").ToUnsignedBigInteger();
            header.GasUsed = (long)Bytes.FromHexString("0x5208").ToUnsignedBigInteger();
            header.MixHash = new Keccak(Bytes.FromHexString("0x00be1f287e0911ea2f070b3650a1a0346535895b6c919d7e992a0c255a83fc8b"));
            header.Nonce = (ulong)Bytes.FromHexString("0xa0ddc06c6d7b9f48").ToUnsignedBigInteger();
            header.Number = Bytes.FromHexString("0x01").ToUInt256();
            header.ParentHash = new Keccak(Bytes.FromHexString("0x5a39ed1020c04d4d84539975b893a4e7c53eab6c2965db8bc3468093a31bc5ae"));
            header.ReceiptsRoot = new Keccak(Bytes.FromHexString("0x056b23fbba480696b65fe5a59b8f2148a1299103c4f57df839233af2cf4ca2d2"));
            header.StateRoot = new Keccak(Bytes.FromHexString("0x5c2e5a51a79da58791cdfe572bcfa3dfe9c860bf7fad7d9738a1aace56ef9332"));
            header.Timestamp = Bytes.FromHexString("0x59d79f18").ToUInt256();
            header.TransactionsRoot = new Keccak(Bytes.FromHexString("0x5c9151c2413d1cd25c51ffb4ac38948acc1359bf08c6b49f283660e9bcf0f516"));
            header.OmmersHash = new Keccak(Bytes.FromHexString("0x1dcc4de8dec75d7aab85b567b6ccd41ad312451b948a7413f0a142fd40d49347"));

            Assert.AreEqual(new Keccak(Bytes.FromHexString("0x19a24085f6b1fb174aee0463264cc7163a7ffa165af04d3f40431ab3c3b08b98")), BlockHeader.CalculateHash(header));
        }

        [Test]
        public void Hash_as_expected_2()
        {
            BlockHeader header = new BlockHeader();
            header.Bloom = new Bloom(
                Bytes.FromHexString("0x00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")
                    .ToBigEndianBitArray2048());
            header.Beneficiary = new Address("0x8888f1f195afa192cfee860698584c030f4c9db1");
            header.Difficulty = Bytes.FromHexString("0x020080").ToUInt256();
            header.ExtraData = Bytes.Empty;
            header.GasLimit = (long)Bytes.FromHexString("0x2fefba").ToUnsignedBigInteger();
            header.GasUsed = (long)Bytes.FromHexString("0x5208").ToUnsignedBigInteger();
            header.MixHash = new Keccak(Bytes.FromHexString("0x615bbf44eb133eab3cb24d5766ae9617d9e45ee00e7a5667db30672b47d22149"));
            header.Nonce = (ulong)Bytes.FromHexString("0x4c4f3d3e055cb264").ToUnsignedBigInteger();
            header.Number = Bytes.FromHexString("0x03").ToUInt256();
            header.ParentHash = new Keccak(Bytes.FromHexString("0xde1457da701ef916533750d46c124e9ae50b974410bd590fbcf4c935a4d19465"));
            header.ReceiptsRoot = new Keccak(Bytes.FromHexString("0x056b23fbba480696b65fe5a59b8f2148a1299103c4f57df839233af2cf4ca2d2"));
            header.StateRoot = new Keccak(Bytes.FromHexString("0xfb4084a7f8b57e370fefe24a3da3aaea6c4dd8b6f6251916c32440336035160b"));
            header.Timestamp = Bytes.FromHexString("0x59d79f1c").ToUInt256();
            header.TransactionsRoot = new Keccak(Bytes.FromHexString("0x1722b8a91bfc4f5614ce36ee77c7cce6620ab4af36d3c54baa66d7dbeb7bce1a"));
            header.OmmersHash = new Keccak(Bytes.FromHexString("0xe676a42c388d2d24bb2927605d5d5d82fba50fb60d74d44b1cd7d1c4e4eee3c0"));
            header.Hash = BlockHeader.CalculateHash(header);

            Assert.AreEqual(new Keccak(Bytes.FromHexString("0x1423c2875714c31049cacfea8450f66a73ecbd61d7a6ab13089406a491aa9fc2")), header.Hash);
        }

        [Test]
        public void Author()
        {
            Address author = new Address("0x05a56e2d52c817161883f50c441c3228cfe54d9f");

            BlockHeader header = new BlockHeader();
            header.Beneficiary = author;

            Assert.AreEqual(header.GetAuthor(MainNetSpecProvider.Instance), author);
            Assert.AreEqual(header.GetAuthor(RopstenSpecProvider.Instance), author);
        }

        [Test]
        public void BlockSealer()
        {
            BlockHeader header = new BlockHeader();

            header.Bloom = new Bloom(
                Bytes.FromHexString("0x00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")
                    .ToBigEndianBitArray2048());
            header.ParentHash = new Keccak("0x6d31ab6b6ee360d075bb032a094fb4ea52617268b760d15b47aa439604583453");
            header.OmmersHash = new Keccak("0x1dcc4de8dec75d7aab85b567b6ccd41ad312451b948a7413f0a142fd40d49347");
            header.Beneficiary = new Address("0x0000000000000000000000000000000000000000");
            header.StateRoot = new Keccak("0x9853b6c62bd454466f4843b73e2f0bdd655a4e754c259d6cc0ad4e580d788f43");
            header.TransactionsRoot = new Keccak("0x56e81f171bcc55a6ff8345e692c0f86e5b48e01b996cadc001622fb5e363b421");
            header.ReceiptsRoot = new Keccak("0x56e81f171bcc55a6ff8345e692c0f86e5b48e01b996cadc001622fb5e363b421");
            header.Difficulty = 2;
            header.Number = 269;
            header.GasLimit = 4712388;
            header.GasUsed = 0;
            header.Timestamp = 1492014479;
            header.ExtraData = Bytes.FromHexString("0xd783010600846765746887676f312e372e33856c696e757800000000000000004e2b663c52c4c1ef0db29649f1f4addd93257f33d6fe0ae6bd365e63ac9aac4169e2b761aa245fabbf0302055f01b8b5391fa0a134bab19710fd225ffac3afdf01");
            header.MixHash = new Keccak("0x0000000000000000000000000000000000000000000000000000000000000000");
            header.Nonce = 0;

            Address expectedBlockSealer = new Address("0xb279182d99e65703f0076e4812653aab85fca0f0");
            Address blockSealer = header.GetBlockSealer();
            Assert.AreEqual(expectedBlockSealer, blockSealer);
        }

        [Test]
        public void CliqueHashHeader()
        {
            BlockHeader header = new BlockHeader();

            header.Bloom = new Bloom(
                Bytes.FromHexString("0x00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")
                    .ToBigEndianBitArray2048());
            header.ParentHash = new Keccak("0x6d31ab6b6ee360d075bb032a094fb4ea52617268b760d15b47aa439604583453");
            header.OmmersHash = new Keccak("0x1dcc4de8dec75d7aab85b567b6ccd41ad312451b948a7413f0a142fd40d49347");
            header.Beneficiary = new Address("0x0000000000000000000000000000000000000000");
            header.StateRoot = new Keccak("0x9853b6c62bd454466f4843b73e2f0bdd655a4e754c259d6cc0ad4e580d788f43");
            header.TransactionsRoot = new Keccak("0x56e81f171bcc55a6ff8345e692c0f86e5b48e01b996cadc001622fb5e363b421");
            header.ReceiptsRoot = new Keccak("0x56e81f171bcc55a6ff8345e692c0f86e5b48e01b996cadc001622fb5e363b421");
            header.Difficulty = 2;
            header.Number = 269;
            header.GasLimit = 4712388;
            header.GasUsed = 0;
            header.Timestamp = 1492014479;
            header.ExtraData = Bytes.FromHexString("0xd783010600846765746887676f312e372e33856c696e757800000000000000004e2b663c52c4c1ef0db29649f1f4addd93257f33d6fe0ae6bd365e63ac9aac4169e2b761aa245fabbf0302055f01b8b5391fa0a134bab19710fd225ffac3afdf01");
            header.MixHash = new Keccak("0x0000000000000000000000000000000000000000000000000000000000000000");
            header.Nonce = 0;

            Keccak expectedHeaderHash = new Keccak("0x7b27b6add9e8d0184c722dde86a2a3f626630264bae3d62ffeea1585ce6e3cdd");
            Keccak headerHash = header.HashCliqueHeader();
            Assert.AreEqual(expectedHeaderHash, headerHash);
        }
    }
}