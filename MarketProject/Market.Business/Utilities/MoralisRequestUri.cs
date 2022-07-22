namespace Fahax.Business.Utilities
{
    public static class MoralisRequestUri
    {
        public static class Account
        {
            //Get Native Transactions
            public static string Address { get; } = "?chain=bsc";
            public static string Erc20 { get; } = "/erc20?chain=bsc";
        }
        public static class Token
        {
            public static string Allowence { get; } = "/erc20?chain=bsc";
            public static string Price { get; } = "/price?chain=bsc";
        }
    }
}

