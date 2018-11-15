using DEKL.CP.Infra.CrossCutting.Identity.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DEKL.CP.Infra.CrossCutting.Identity.Models
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        private readonly ApplicationDbContext _context;

        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
