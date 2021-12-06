using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBook.Contracts.v1.Request;
using GuestBook.Migrations;
using GuestBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly GuestBookDbContext _db;
        public NoteRepository(GuestBookDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Note> GetNotes()
        {
            return _db.Notes.ToList();
        }

       

        public Note InsertNote(Note note)
        {
            note.Id = Guid.NewGuid();
            note.CreatingDateTime = DateTime.Now;
            _db.Notes.Add(note);
            Save();
            return note;
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0;
        }

        
    }
}