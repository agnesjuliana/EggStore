using EggStore.Domains.Users.Dto;
using EggStore.Domains.Users.Entities;
using EggStore.Domains.Users.Interface;
using EggStore.Infrastucture.Shareds.DataAccess;

namespace EggStore.Domains.Users.Repositories
{
    public class UsersRepository : IUsers
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }
        private UsersEntity AssignData(UsersEntity userItem, UsersDto param)
        {
            userItem.Name = param.Name;
            userItem.Username = param.Username;
            userItem.Password = param.Password;
            userItem.Email = param.Email;
            userItem.Role = param.Role;

            return userItem;
        }

        // Acctually this is repository
        public async Task<List<UsersEntity>> FindAll()
        {
            var data = await _context.UsersEntities.ToListAsync();
            return data;
        }

        public async Task<UsersEntity> FindById(Guid id)
        {
            var data = await _context.UsersEntities.FindAsync(id);
            return data;
        }

        public async Task<UsersEntity> Create(UsersDto param)
        {
            UsersEntity userItem = new UsersEntity();
            userItem = AssignData(userItem, param);

            _context.UsersEntities.Add(userItem);
            await _context.SaveChangesAsync();
            return userItem;
        }

        public async Task<UsersEntity> Update(UsersDto param, Guid id)
        {
            UsersEntity userItem = _context.UsersEntities.FirstOrDefault(x => x.Id.Equals(id));
            userItem = AssignData(userItem, param);

            _context.UsersEntities.Update(userItem);
            await _context.SaveChangesAsync();

            return userItem;
        }

        public async Task<UsersEntity> Delete(Guid id)
        {
            var data = await _context.UsersEntities.FindAsync(id);
            if (data == null)
                return null;

            _context.UsersEntities.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
