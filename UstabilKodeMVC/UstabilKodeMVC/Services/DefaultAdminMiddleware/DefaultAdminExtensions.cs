using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Services.DefaultAdminMiddleware
{
    public static class DefaultAdminExtensions
    {
        public static IApplicationBuilder UseDefaultAdmin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DefaultAdmin>();
        }
    }
}
