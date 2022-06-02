using EggStore.Domains.Packages.Dto;

namespace EggStore.Domains.Eggs.Dto
{
    public class EggsDto
    {
        public Guid Id { get; set; } = default;
        public string EggName { get; set; }
        public int Stok { get; set; } 
        public double Price { get; set; } 
        public PackagesDto PackageId { get; set; }
    }
}
