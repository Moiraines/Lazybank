namespace Lazybank.Services.Data
{
    using System.Linq;

    using Lazybank.Data.Common;
    using Lazybank.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<ApplicationUser> users;

        public UsersService(IDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public ApplicationUser GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
