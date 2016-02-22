namespace Lazybank.Services.Data
{
    using System.Linq;

    using Lazybank.Data.Models;

    public interface IUsersService
    {
        IQueryable<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);
    }
}
