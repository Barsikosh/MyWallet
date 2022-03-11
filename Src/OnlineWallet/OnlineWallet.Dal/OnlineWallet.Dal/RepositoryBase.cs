using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OnlineWallet.Dal
{
    internal abstract class RepositoryBase<TDbContext, TDbEntity, TModel>
        where TDbContext : DbContext
        where TDbEntity : class, IDbEntity, new()
        where TModel : IModelWithId
    {
        protected readonly TDbContext Context;

        protected readonly IMapper Mapper;

        protected virtual IQueryable<TDbEntity> BaseQuery() => Context.Set<TDbEntity>();
        protected virtual IQueryable<TDbEntity> Query() => BaseQuery();

        protected RepositoryBase(TDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task AddAsync(TModel model)
        {
            await using var dataBase = Context;
            var table = dataBase.Set<TDbEntity>();
            await table.AddAsync(Mapper.Map<TDbEntity>(model));
            await Context.SaveChangesAsync();
        }

        public virtual async Task<TModel> FindAsync(Guid id)
        {
            var exist = await Query().Where(x => x.Id == id)
                .Select(x => Mapper.Map<TModel>(x))
                .FirstOrDefaultAsync();
            return exist;
        }
    }
}
