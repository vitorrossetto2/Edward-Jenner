using System;
using EdwardJenner.Data.Repositories;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Security;
using Microsoft.AspNetCore.Identity;

namespace EdwardJenner.Security
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (!_context.Database.EnsureCreated()) return;

            if (!_roleManager.RoleExistsAsync(Roles.RoleApiEdwardJenner).Result)
            {
                var resultado = _roleManager.CreateAsync(new IdentityRole(Roles.RoleApiEdwardJenner)).Result;

                if (!resultado.Succeeded)
                {
                    throw new Exception($"Erro durante a criação da role {Roles.RoleApiEdwardJenner}.");
                }
            }

            CreateUser(new ApplicationUser()
            {
                UserName = "lennonalvesdias",
                Email = "lennonalvesdias@gmail.com",
                EmailConfirmed = true
            }, "FYUQ9PnWcvRZEoGVaux!", Roles.RoleApiEdwardJenner);
        }

        private void CreateUser(ApplicationUser user, string password, string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result != null) return;

            var result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded && !string.IsNullOrWhiteSpace(initialRole))
            {
                _userManager.AddToRoleAsync(user, initialRole).Wait();
            }
        }
    }
}
