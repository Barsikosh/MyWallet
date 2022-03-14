using System;
using System.Threading.Tasks;

namespace OnlineWallet.Dal
{
    public interface IRepository<TModel> where TModel: IModelWithId
    {
        public Task AddAsync(TModel model);

        public Task<TModel> FindAsync(Guid id);
    }
}
