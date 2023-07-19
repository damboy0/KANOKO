using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Admin> CreateAdminAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> DeleteAdminAsync(Admin admin)
        {
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> GetAdminAsync(int id)
        {
            return await _context.Admins.Include(x => x.User).SingleOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            var getadmin = await _context.Admins.Include(x => x.User).SingleOrDefaultAsync(c => c.User.Email == email);
            return getadmin;
        }

        public async Task<Admin> GetAdminByUserIdAsync(int userId)
        {
            return await _context.Admins.Include(x => x.User).SingleOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
