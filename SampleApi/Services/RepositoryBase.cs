using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SampleApi.Data;

namespace SampleApi.Services
{
    public abstract class RepositoryBase<T> : ControllerBase where T : class
    {
        private readonly DbSet<T> _entity;

        public RepositoryBase (ApplicationDbContext context)
        {
            _entity = context.Set<T>();
        }

        [HttpGet]
        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _entity.ToListAsync();
            return result;
        }
    }
}
