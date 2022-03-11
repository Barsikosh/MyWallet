using System;

namespace OnlineWallet
{
    public class Wallet : IModelWithId
    {
        public Guid? Id { get; set; }

        public int Balance { get; set; }

        public Guid CustomerId { get; set; }
    }
}
