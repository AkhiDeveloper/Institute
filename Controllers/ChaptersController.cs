using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Institute.Data;
using Institute.Model;
using AutoMapper;
using Institute.DTOs;

namespace Institute.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly IInstituteDataRepo _repository;
        private readonly IMapper _mapper;

        public ChaptersController(IInstituteDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChapterReadDTO>>> 
            GetChapters()
        {
            var chapteritems = await _repository.GetAllChapters();
            if(chapteritems != null)
            {
                return Ok(_mapper.Map<IEnumerable<ChapterReadDTO>>
                    (chapteritems));
            }
            return NotFound();
            //var chapters= _context.Chapters.Include(d=>d.Lessons);
            //return await chapters.ToListAsync();
            // return await _context.Chapters.ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{chapterid}",Name = "GetChapter")]
        public async Task<ActionResult<ChapterReadDTO>> GetChapter(int chapterid)
        {
            var chapteritem = await _repository.GetChapter(chapterid);
            if(chapteritem!=null)
            {
                return Ok(_mapper.Map<ChapterReadDTO>(chapteritem));
            }
            return NotFound();

            //var chapter = await _context.Chapters.FindAsync(id);

            //if (chapter == null)
            //{
            //    return NotFound();
            //}

            //return chapter;
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapter
            (int id, ChapterUpdateDTO chapterUpdate)
        {
            var chapterolditem = await _repository.GetChapter(id);
            if (chapterolditem == null)
            {
                return NotFound();
            }

            _mapper.Map(chapterUpdate, chapterolditem);

            _repository.UpdateChapter(chapterolditem);

            await _repository.SaveChanges();

            return NoContent();
            //if (id != chapter.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(chapter).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ChapterExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Chapters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChapterReadDTO>> AddChapter
            (ChapterCreateForm newchapter, int targetCourseId)
        {
            var chaptermodel = _mapper.Map<Chapter>(newchapter);
            var targetCourse = await _repository.GetCourseById(targetCourseId);

            _repository.AddChapter(targetCourse, chaptermodel);
            await _repository.SaveChanges();

            var courseReadDTO = _mapper.Map<CourseReadDTO>(chaptermodel);

            //return CreatedAtAction("GetChapter", new { id = chaptermodel }, chaptermodel);

            return CreatedAtRoute(nameof(GetChapter),
                new { Id = chaptermodel.Id }, chaptermodel);

            //_context.Chapters.Add(chapter);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chapter>> DeleteChapter(int id)
        {
            var chapteritem = await _repository.GetChapter(id);
            if (chapteritem == null)
            {
                return NotFound();
            }

            _repository.DeleteChapter(chapteritem);
            await _repository.SaveChanges();

            return NoContent();
            //var chapter = await _context.Chapters.FindAsync(id);
            //if (chapter == null)
            //{
            //    return NotFound();
            //}

            //_context.Chapters.Remove(chapter);
            //await _context.SaveChangesAsync();

            //return chapter;
        }
    }
}
