
# Ethereum Rpc .NET

**C# .NET wrapper for Ethereum RPC client**

Notes: Shh protocol is partially implemented and db_putString, db_getString, db_putHex, db_getHex have been deprecitated

Supported objects
--------

- Address
- Block
- Filter
- Log
- Whisper
- Work

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
- eth_sendTransaction
- eth_sendRawTransaction
- eth_call
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
- eth_getFilterChanges
- eth_getFilterLogs
- eth_getLogs
- eth_getWork
- eth_submitWork
- eth_submitHashrate
- shh_version

Configuration
-------------

	<?xml version="1.0" encoding="utf-8"?>
	<configuration>
	
		<appSettings>
			<add key="EthereumRpcUrl" value="http://localhost"/>
			<add key="EthereumRpcPort" value="8545"/>
		</appSettings>
				
	</configuration>
	
	
Getting started
--------

	var connectionOptions = new ConnectionOptions()
	{
		Port = "8545",
		Url = "http://localhost"
	};
	
	var ethereumService = new EthereumService(connectionOptions);

Roadmap
--------

- All RPC calls implemented
- Address Parser
- Hash functions
- Helpers for non ethereum types

Support

lawrence@9thirteencreative.com
