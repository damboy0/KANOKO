using KANOKO.Context;
using KANOKO.Identity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            var users = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUser(int userId)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            return getUser;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var getByEmail = await _context.Users.Include(x => x.Admin).FirstOrDefaultAsync(x => x.Email == email);
            return getByEmail;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.AppUser.AnyAsync(c => c.Email == email);
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
