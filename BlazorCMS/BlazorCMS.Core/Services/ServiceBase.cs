using BlazorCMS.Core.Data;

namespace BlazorCMS.Core.Services
{
    public abstract class ServiceBase
    {
        protected readonly CMSDbContext _context;
        public ServiceBase(CMSDbContext context)
        {
            _context = context;
        }
    }
}
