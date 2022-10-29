using Nethereum.HdWallet;
using Nethereum.Web3.Accounts;

namespace Web3Utility;

public class WalletHelper
{
    public static Account GetWalletFromSeedPhrase(string seedPhrase, int index = 0)
    {
        var password = "password";
        var wallet = new Wallet(seedPhrase, password);
        var account = wallet.GetAccount(index);
        return account;
    }
}