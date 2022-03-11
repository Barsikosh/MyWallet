using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWallet.Dal
{
    public interface IRepository<TModel> where TModel: IModelWithId
    {
        public Task AddAsync(TModel model);

        public Task<TModel> FindAsync(Guid id);
    }
}
