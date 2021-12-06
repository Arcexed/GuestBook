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
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _db.Notes.ToListAsync();
        }

       

        public async Task<Note> InsertNoteAsync(Note note)
        {
            note.Id = Guid.NewGuid();
            note.CreatingDateTime = DateTime.Now;
            await _db.Notes.AddAsync(note);
            await SaveAsync();
            return note;
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _db.SaveChangesAsync();
            return saved > 0;
        }

        
    }
}