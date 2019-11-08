using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UstabilkodeApi.Data;
using UstabilkodeApi.Models;

namespace UstabilkodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private UstabilkodeContext _context;

        public CommentController(UstabilkodeContext context)
        {
            _context = context;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        {
            return await _context.Comment.AsNoTracking().ToListAsync();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comment.AsNoTracking().FirstAsync((c) => c.ID == id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comment/5
        [HttpPut]
        public async Task<IActionResult> PutComment(Comment comment)
        {
            if (!CommentExists(comment.ID))
                return NotFound();


            try
            {
                _context.Entry(comment).State = EntityState.Modified;
            }
            catch(Exception e) { }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(comment.ID))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            return NoContent();
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comment.Add(comment);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e) { }

            return CreatedAtAction("GetComment", new { id = comment.ID }, comment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.ID == id);
        }
    }
}
