using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Services
{
    public class DefaultAdmin
    {
        private readonly RequestDelegate _next;

        public DefaultAdmin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<IdentityUser> userManager)
        {
            var admin = userManager.Users.Where((user) => user.Email == "admin@admin.dk").FirstOrDefault();
            if (admin == null)
            {
                var result = await userManager.CreateAsync(new IdentityUser() { Email = "admin@admin.dk", UserName = "admin@admin.dk" }, "admin");
            }

            await _next(context);
        }
    }
}
