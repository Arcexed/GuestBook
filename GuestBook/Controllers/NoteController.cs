﻿using System;
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
        public IActionResult GetAll()
        {
            return Ok(_noteRepository.GetNotes());
        }
        
        [HttpPost(Notes.Create)]
        public IActionResult Add([FromBody] CreateNoteRequest request)
        {
            Note note = new Note()
            {
                Text = request.Text,
                Email = request.Email,
                Name = request.Name,
            };
            return Ok(_noteRepository.InsertNote(note));
        }
        
    }
}