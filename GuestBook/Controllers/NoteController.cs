using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBook.Contracts.v1.Request;
using GuestBook.Contracts.v1.Response;
using GuestBook.Migrations;
using GuestBook.Models;
using GuestBook.Options;
using GuestBook.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static GuestBook.Options.ApiRoutes;

namespace GuestBook.Controllers
{
    [ApiController]
    public class NoteController : ControllerBase
    {

        private readonly INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet(Notes.GetAll)]
        [ProducesResponseType(200, Type = typeof(NoteResponse[]))]
        public async Task<IActionResult> GetAll()
        {
            List<NoteResponse> noteResponses = new List<NoteResponse>();
            var notes = await _noteRepository.GetNotesAsync();
            foreach (var note in notes)
            {
                NoteResponse noteResponse = new NoteResponse()
                {
                    Id = note.Id,
                    Email = note.Email,
                    Name = note.Email,
                    Text = note.Text,
                    CreatingDateTime = note.CreatingDateTime,
                };
                noteResponses.Add(noteResponse);
            }
            return Ok(noteResponses);
        }
        
        [HttpPost(Notes.Create)]
        public async Task<IActionResult> Add([FromBody] CreateNoteRequest request)
        {
            Note note = new Note()
            {
                Text = request.Text,
                Email = request.Email,
                Name = request.Name,
            };
            return Ok(await _noteRepository.InsertNoteAsync(note));
        }
        
    }
}