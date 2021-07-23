using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HrAuth.Context;
using HrAuth.Models;

namespace HrAuth.Repository{

    public class UserRepository: IBaseRepository<Guid, User>
    {
        private readonly PostgreContext Context;
        public UserRepository(PostgreContext Context){
            this.Context = Context;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var user = await Context.Users.FindAsync(Id);
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(Guid Id)
        {
            var user = await Context.Users.FindAsync(Id);
            return user;
        }

        public async Task SaveAllAsync(IEnumerable<User> Values)
        {
            await Context.Users.AddRangeAsync(Values);
            await Context.SaveChangesAsync();
        }

        public async Task SaveAsync(User Value)
        {
            await Context.Users.AddAsync(Value);
            await Context.SaveChangesAsync();
        }
    }

}