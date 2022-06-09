using EggStore.Domains.Eggs.Dto;
using EggStore.Domains.Eggs.Entities;
using EggStore.Infrastucture.Shareds.DataAccess;

namespace EggStore.Domains.Eggs.Repositories
{
    public class EggsRepository
    {
        private readonly DataContext _context;
        public EggsRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public EggsEntity FindById(Guid id)
        {
            return _context.EggsEntities.FirstOrDefault(x => x.Id == id);
        }

        public List<EggsEntity> FindAll()
        {
            IQueryable<EggsEntity> eggItem = _context.EggsEntities.
                Include(x => x.PackageEntity).AsQueryable();
            return eggItem.ToList();
        }

        public EggsEntity Create(EggsDto param)
        {
            EggsEntity eggItem = new EggsEntity();
            eggItem = AssignData(eggItem, param);

            _context.EggsEntities.Add(eggItem);
            _context.SaveChanges();

            return eggItem;
        }

        public EggsEntity Update(EggsDto param, Guid id)
        {
            var eggItem = _context.EggsEntities.FirstOrDefault(x => x.Id == id);
            eggItem = AssignData(eggItem, param);

            _context.EggsEntities.Update(eggItem);
            _context.SaveChanges();

            return eggItem;
        }

        private EggsEntity AssignData(EggsEntity eggItem, EggsDto param)
        {
            eggItem.EggName = param.EggName;
            eggItem.Stok = param.Stok;
            eggItem.Price = param.Price;
            eggItem.PackageId = param.PackageId;

            return eggItem;
        }
    }
}
