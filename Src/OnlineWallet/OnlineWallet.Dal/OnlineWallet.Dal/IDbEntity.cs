using System;

namespace OnlineWallet.Dal
{
    public interface IDbEntity
    {
        public Guid Id { get; set; }
    }
}
