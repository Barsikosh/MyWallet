using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineWallet.Dal
{
    public interface IDbEntity
    {
        public Guid Id { get; set; }
    }
}
