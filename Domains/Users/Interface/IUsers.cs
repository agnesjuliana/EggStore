using EggStore.Domains.Users.Dto;
using EggStore.Domains.Users.Entities;

namespace EggStore.Domains.Users.Interface
{
    public interface IUsers
    {
        Task<List<UsersEntity>> FindAll();
        Task<UsersEntity> FindById(Guid id);
        public Task<UsersEntity> Create(UsersDto param);
        public Task<UsersEntity> Update(UsersDto param, Guid id);
        public Task<UsersEntity> Delete(Guid id);
    }
}
