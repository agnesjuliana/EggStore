using EggStore.Domains.Packages.Dto;
using EggStore.Domains.Packages.Entities;
using EggStore.Domains.Packages.Interface;
using EggStore.Infrastucture.Shareds.DataAccess;

namespace EggStore.Domains.Packages.Repositories
{
    public class PackagesRepository : IPackages
    {
        readonly DataContext _context;

        public PackagesRepository(DataContext context)
        {
            _context = context;
        }

        public PackagesEntity FindById(Guid id)
        {
            return _context.PackagesEntities.First(x=>x.Id == id);
        }

        public List<PackagesEntity> FindAll()
        {
            return _context.PackagesEntities.ToList();
        }

        public PackagesEntity Create(PackagesDto param)
        {
            PackagesEntity packageItem = new PackagesEntity();
            packageItem = AssignData(packageItem, param);

            _context.Add(packageItem);
            _context.SaveChanges();

            return packageItem;

        }

        public PackagesEntity Delete(Guid id)
        {
            var data = _context.PackagesEntities.Find(id);
            if (data == null)
                return null;

            _context.PackagesEntities.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public PackagesEntity Update(PackagesDto param, Guid id)
        {
            var packageItem = _context.PackagesEntities.Find(id);
            packageItem = AssignData(packageItem, param);

            _context.PackagesEntities.Update(packageItem);
            _context.SaveChanges();

            return packageItem;
        }


        private PackagesEntity AssignData(PackagesEntity packageItem, PackagesDto param)
        {
            packageItem.PackageName = param.PackageName;

            return packageItem;
        }
    }
}
