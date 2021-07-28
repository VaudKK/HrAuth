using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrAuth.Context;
using HrAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace HrAuth.Repository{

    public class UserRepository: IBaseRepository<Guid, User>
    {
        private readonly PostgreContext Context;
        public UserRepository(PostgreContext Context){
            this.Context = Context;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var user = await Context.HrUsers.FindAsync(Id);
            Context.HrUsers.Remove(user);
            await Context.SaveChangesAsync();
        }

        public async Task<User> FindByEmail(string email)
        {
            return await Context.HrUsers.Where(user => user.Email == email).FirstOrDefaultAsync<User>();
        }

        public async Task<User> FindByIdAsync(Guid Id)
        {
            var user = await Context.HrUsers.FindAsync(Id);
            return user;
        }

        public async Task SaveAllAsync(IEnumerable<User> Values)
        {
            await Context.HrUsers.AddRangeAsync(Values);
            await Context.SaveChangesAsync();
        }

        public async Task<Int32> SaveAsync(User Value)
        {
            await Context.HrUsers.AddAsync(Value);
            return await Context.SaveChangesAsync();
        }
    }

}