using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTakerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly Services.NoteStorage _noteStorage;

        public NotesController(ILogger<NotesController> logger, Services.NoteStorage noteStorage)
        {
            _logger = logger;
            _noteStorage = noteStorage;
        }

        /// <summary>
        /// Fetch a list of all stored notes.
        /// </summary>
        /// <returns>All notes in the storage</returns>
        [HttpGet]
        public ActionResult<List<Models.Note>> Get()
        {
            return _noteStorage.GetAll();
        }

        /// <summary>
        /// Generates an ID for the note and stores it in memory.
        /// </summary>
        /// <param name="note"></param>
        /// <returns>The created note with a proper ID</returns>
        [HttpPost]
        public ActionResult Create([FromBody] Models.Note note)
        {
            note.Id = _noteStorage.CreateNew(note);
            return new OkObjectResult(note);
        }

        /// <summary>
        /// If there is note with the same ID as in the route, then updates it
        /// using the data in the POST-body.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] Models.Note note)
        {
            if (_noteStorage.ContainsId(id))
            {
                _noteStorage.Update(id, note);
                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        /// Deletes a note that has the same ID as in the route.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            if (_noteStorage.ContainsId(id))
            {
                _noteStorage.Delete(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
