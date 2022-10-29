using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts.Standards.ERC20.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Web3Utility.Tokens.ContractDefinitons;

namespace Web3Utility.Tokens;

public class Erc20TokenService
{
    public Erc20TokenService(Web3 web3, string contractAddress)
    {
        Web3 = web3;
        ContractHandler = web3.Eth.GetContractHandler(contractAddress);
    }

    private Web3 Web3 { get; }

    private ContractHandler ContractHandler { get; }

    private static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Web3 web3,
        Erc20TokenDeployment erc20TokenDeployment, CancellationTokenSource cancellationTokenSource = null)
    {
        return web3.Eth.GetContractDeploymentHandler<Erc20TokenDeployment>()
            .SendRequestAndWaitForReceiptAsync(erc20TokenDeployment, cancellationTokenSource);
    }

    public static Task<string> DeployContractAsync(Web3 web3, Erc20TokenDeployment erc20TokenDeployment)
    {
        return web3.Eth.GetContractDeploymentHandler<Erc20TokenDeployment>().SendRequestAsync(erc20TokenDeployment);
    }

    public static async Task<Erc20TokenService> DeployContractAndGetServiceAsync(Web3 web3,
        Erc20TokenDeployment erc20TokenDeployment, CancellationTokenSource cancellationTokenSource = null)
    {
        var receipt = await DeployContractAndWaitForReceiptAsync(web3, erc20TokenDeployment, cancellationTokenSource);
        return new Erc20TokenService(web3, receipt.ContractAddress);
    }

    public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction,
        BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
    }


    public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
    {
        var allowanceFunction = new AllowanceFunction
        {
            Owner = owner,
            Spender = spender
        };

        return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
    }

    public Task<BigInteger> AllowedQueryAsync(AllowedFunction allowedFunction, BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<AllowedFunction, BigInteger>(allowedFunction, blockParameter);
    }


    public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
    {
        return ContractHandler.SendRequestAsync(approveFunction);
    }

    public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction,
        CancellationTokenSource cancellationToken = null)
    {
        return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
    }

    public Task<string> ApproveRequestAsync(string spender, BigInteger value)
    {
        var approveFunction = new ApproveFunction
        {
            Spender = spender,
            Value = value
        };

        return ContractHandler.SendRequestAsync(approveFunction);
    }

    public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value,
        CancellationTokenSource cancellationToken = null)
    {
        var approveFunction = new ApproveFunction
        {
            Spender = spender,
            Value = value
        };

        return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
    }

    public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction,
        BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
    }


    public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
    {
        var balanceOfFunction = new BalanceOfFunction
        {
            Owner = owner
        };

        return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
    }

    public Task<BigInteger> BalancesQueryAsync(BalancesFunction balancesFunction, BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<BalancesFunction, BigInteger>(balancesFunction, blockParameter);
    }


    public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
    }


    public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
    }

    public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
    }


    public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
    }

    public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
    }


    public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
    }

    public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction,
        BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
    }


    public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
    {
        return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
    }

    public Task<string> TransferRequestAsync(TransferFunction transferFunction)
    {
        return ContractHandler.SendRequestAsync(transferFunction);
    }

    public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction,
        CancellationTokenSource cancellationToken = null)
    {
        return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
    }

    public Task<string> TransferRequestAsync(string to, BigInteger value)
    {
        var transferFunction = new TransferFunction
        {
            To = to,
            Value = value
        };

        return ContractHandler.SendRequestAsync(transferFunction);
    }

    public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value,
        CancellationTokenSource cancellationToken = null)
    {
        var transferFunction = new TransferFunction
        {
            To = to,
            Value = value
        };

        return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
    }

    public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
    {
        return ContractHandler.SendRequestAsync(transferFromFunction);
    }

    public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction,
        CancellationTokenSource cancellationToken = null)
    {
        return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
    }

    public Task<string> TransferFromRequestAsync(string from, string to, BigInteger value)
    {
        var transferFromFunction = new TransferFromFunction
        {
            From = from,
            To = to,
            Value = value
        };

        return ContractHandler.SendRequestAsync(transferFromFunction);
    }

    public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value,
        CancellationTokenSource cancellationToken = null)
    {
        var transferFromFunction = new TransferFromFunction
        {
            From = from,
            To = to,
            Value = value
        };

        return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
    }
}