using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace WikiTutorial.EntityFramework.Repositories
{
    public abstract class WikiTutorialRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<WikiTutorialDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected WikiTutorialRepositoryBase(IDbContextProvider<WikiTutorialDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class WikiTutorialRepositoryBase<TEntity> : WikiTutorialRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected WikiTutorialRepositoryBase(IDbContextProvider<WikiTutorialDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
