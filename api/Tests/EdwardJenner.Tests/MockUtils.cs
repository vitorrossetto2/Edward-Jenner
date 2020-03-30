using System.Collections.Generic;
using EdwardJenner.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace EdwardJenner.Tests
{
    public static class MockUtils
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }

        public static Mock<CacheService<TModel>> MockCacheService<TModel>() where TModel : class
        {
            var store = new Mock<IUserStore<TModel>>();
            var mgr = new Mock<CacheService<TModel>>(store.Object, null, null, null, null, null, null, null, null);
            return mgr;
        }
    }
}
