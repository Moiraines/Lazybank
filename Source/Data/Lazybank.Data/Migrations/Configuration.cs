namespace Lazybank.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Lazybank.Common;
    using Lazybank.Data.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            var users = new List<ApplicationUser>();

            var adminUser = context.Users.FirstOrDefault(x => x.UserName == AdministratorUserName);
            users.Add(adminUser);

            if (!context.Individuals.Any())
            {
                var customer = new Individual
                {
                    Name = "Pavel Kolev",
                    ClientNumber = 120345678,
                    Address = "Sofia, ul. Talasam 5",
                    Users = users,
                    PersonalIdNumber = "9011014567"
                };

                var customer2 = new Individual
                {
                    Name = "Nikolay Kostov",
                    ClientNumber = 120345679,
                    Address = "Sofia, ul. Talasam 6",
                    Users = users,
                    PersonalIdNumber = "9108014568"
                };

                context.Individuals.Add(customer);
                context.Individuals.Add(customer2);

                context.SaveChanges();
            }

            if (!context.Accounts.Any())
            {
                var customer1 = context.Individuals.FirstOrDefault(x => x.Name == "Pavel Kolev");
                for (int i = 1; i < 12; i++)
                {
                    var account = new BankAccount
                    {
                        Number = "BG59UNCR7000452008289" + (i < 9 ? i.ToString() : (i - 9).ToString()),
                        Currency = CurrencyType.BGN,
                        Balance = 20 * i * i,
                        Type = AccountType.Current,
                        IndividualId = customer1.Id
                    };

                    context.Accounts.Add(account);
                }

                var customer2 = context.Individuals.FirstOrDefault(x => x.Name == "Nikolay Kostov");
                for (int i = 1; i < 12; i++)
                {
                    var account = new BankAccount
                    {
                        Number = "BG70UNCR7000432088287" + (i < 9 ? i.ToString() : (i - 9).ToString()),
                        Currency = CurrencyType.BGN,
                        Balance = 20 * i * i,
                        Type = AccountType.Current,
                        IndividualId = customer2.Id
                    };

                    context.Accounts.Add(account);
                }

                context.SaveChanges();
            }
        }
    }
}
