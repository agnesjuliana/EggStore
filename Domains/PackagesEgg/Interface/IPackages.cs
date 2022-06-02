using EggStore.Domains.Packages.Dto;
using EggStore.Domains.Packages.Entities;

namespace EggStore.Domains.Packages.Interface
{
    public interface IPackages
    {
        List<PackagesEntity> FindAll();
        PackagesEntity FindById(Guid id);
        public PackagesEntity Create(PackagesDto param);
        public PackagesEntity Update(PackagesDto param, Guid id);
        public PackagesEntity Delete(Guid id);
    }
}
