using System;

namespace OnlineWallet
{
    public interface IModelWithId
    {
        public Guid? Id { get; set; }
    }
}
