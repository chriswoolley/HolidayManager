using HolidayWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HolidayWeb.Core
{
    public class ApplicationUserManager : UserManager<HolidayUser>
    {
       //
        // Summary:
        //     Constructs a new instance of Microsoft.AspNetCore.Identity.UserManager`1.
        //
        // Parameters:
        //   store:
        //     The persistence store the manager will operate over.
        //
        //   optionsAccessor:
        //     The accessor used to access the Microsoft.AspNetCore.Identity.IdentityOptions.
        //
        //   passwordHasher:
        //     The password hashing implementation to use when saving passwords.
        //
        //   userValidators:
        //     A collection of Microsoft.AspNetCore.Identity.IUserValidator`1 to validate users
        //     against.
        //
        //   passwordValidators:
        //     A collection of Microsoft.AspNetCore.Identity.IPasswordValidator`1 to validate
        //     passwords against.
        //
        //   keyNormalizer:
        //     The Microsoft.AspNetCore.Identity.ILookupNormalizer to use when generating index
        //     keys for users.
        //
        //   errors:
        //     The Microsoft.AspNetCore.Identity.IdentityErrorDescriber used to provider error
        //     messages.
        //
        //   services:
        //     The System.IServiceProvider used to resolve services.
        //
        //   logger:
        //     The logger used to log messages, warnings and errors.
        public ApplicationUserManager(IUserStore<HolidayUser> store, IOptions<Microsoft.AspNetCore.Identity.IdentityOptions> optionsAccessor, IPasswordHasher<HolidayUser> passwordHasher, 
            IEnumerable<IUserValidator<HolidayUser>> userValidators, IEnumerable<IPasswordValidator<HolidayUser>> passwordValidators, ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<HolidayUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) { }

        public override Task<HolidayUser> FindByIdAsync(string userId)
        {
            return Users.Include(c => c.Department).Include(c => c.DepartmentManager).FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
