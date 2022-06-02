using EggStore.Infrastucture.Shareds.DataAccess;

namespace EggStore.Infrastucture
{
    public class BaseRepository
    {
        protected readonly DataContext _dbContext;

        public BaseRepository(DataContext dataContext)
        {
            dataContext.Database.SetCommandTimeout(180);
            _dbContext = dataContext;
        }
    }
}
