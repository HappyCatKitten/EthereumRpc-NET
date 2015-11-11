
# Ethereum Rpc .NET

**C# .NET wrapper for Ethereum RPC client**

Supported RPC calls
--------

- web3_clientVersion
- web3_sha3
- net_version
- net_peerCount
- net_listening
- eth_protocolVersion
- eth_syncing
- eth_coinbase
- eth_mining
- eth_hashrate
- eth_gasPrice
- eth_accounts
- eth_blockNumber
- eth_getBalance
- eth_getStorageAt
- eth_getTransactionCount
- eth_getBlockTransactionCountByHash
- eth_getBlockTransactionCountByNumber
- eth_getUncleCountByBlockHash
- eth_getUncleCountByBlockNumber
- eth_getCode
- eth_sign
- eth_sendTransaction - **unfinished**
- eth_sendRawTransaction - **unfinished**
- eth_call - **unfinished**
- eth_estimateGas
- eth_getBlockByHash
- eth_getBlockByNumber
- eth_getTransactionByHash
- eth_getTransactionByBlockHashAndIndex
- eth_getTransactionByBlockNumberAndIndex
- eth_getTransactionReceipt
- eth_getUncleByBlockHashAndIndex - **untested**
- eth_getUncleByBlockNumberAndIndex - **untested**
- eth_getCompilers
- eth_compileLLL
- eth_compileSolidity
- eth_compileSerpent
- eth_newFilter
- eth_newBlockFilter
- eth_newPendingTransactionFilter
- eth_uninstallFilter
- eth_getFilterChanges -**untested**
- eth_getFilterLogs - **untested**
- eth_getLogs
- eth_getWork
- eth_submitWork -**untested**
- eth_submitHashrate -**untested**
- shh_version

Roadmap
--------

- All RPC calls implemented - December 1st
- Address Parser - December 1st
- Hashing functions - December 1st
