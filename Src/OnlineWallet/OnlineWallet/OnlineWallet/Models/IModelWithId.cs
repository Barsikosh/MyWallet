using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineWallet
{
    public interface IModelWithId
    {
        public Guid? Id { get; set; }
    }
}
