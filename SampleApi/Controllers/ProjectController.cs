#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApi.Data;
using SampleApi.Services;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : RepositoryBase<ProjectEntity>
    {
        private readonly ApplicationDbContext _context;

        //Using generic repository pattern we can eliminate lot of code duplication for CRUD operations 
        public ProjectController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Added ok as return type for status 200 to be more explicit.
        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEntity>> GetProjectEntity(long id)
        {
            var projectEntity = await _context.Projects.FindAsync(id);

            if (projectEntity == null)
            {
                return NotFound();
            }

            return Ok(projectEntity);
        }

        // PUT: api/Project/5
        //Explicitly adding for body for good api practices.
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectEntity(long id,[FromBody] ProjectEntity projectEntity)
        {
            if (id != projectEntity.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // TODO: whats best status code to return after PUT is successfull
            return NoContent();
        }

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectEntity>> PostProjectEntity(ProjectEntity projectEntity)
        {
            _context.Projects.Add(projectEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectEntity", new { id = projectEntity.ProjectId }, projectEntity);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectEntity(long id)
        {
            var projectEntity = await _context.Projects.FindAsync(id);
            if (projectEntity == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectEntityExists(long id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
