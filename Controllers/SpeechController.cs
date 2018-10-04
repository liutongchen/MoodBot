using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using MoodBot.Models;

/**
TODO: 1. Convert Speech To Text: /api/speech/stt
2. Anaylize Speech: api/speech/sentiment
3. Convert Text to Speech: api/speech/tts
 */

namespace MoodBot.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechController : ControllerBase 
    {
        private readonly SpeechContext _context;

        [HttpGet]
        public ActionResult<List<SpeechItem>> GetAll()
        {
            return _context.SpeechItems.ToList();
        }

        [HttpGet("{id}", Name = "GetSpeech")]
        public ActionResult<SpeechItem> GetById(long id)
        {
            var item = _context.SpeechItems.Find(id); 
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<SpeechItem> Create(SpeechItem item) 
        {
            _context.SpeechItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetSpeech", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult<SpeechItem> Update(long id, SpeechItem item) 
        {
            var speech = _context.SpeechItems.Find(id);
            if (speech == null)
            {
                return NotFound();
            }

            speech.IsComplete = item.IsComplete;
            speech.Name = item.Name;
            _context.SpeechItems.Update(speech);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var speech = _context.SpeechItems.Find(id);
            if (speech == null)
            {
                return NotFound();
            }
            _context.SpeechItems.Remove(speech);
            _context.SaveChanges();
            return NoContent();
        }
    }
}