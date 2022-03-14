using System;

namespace OnlineWallet.Models
{
    public class Customer : IModelWithId
    {
        public Guid? Id { get; set; }

        public string UserName { get; set; }

        public string HashPassword { get; set; }

        public bool PassAllAuthorization { get; set; }

        public Guid WalletId { get; set; }
    }
}
