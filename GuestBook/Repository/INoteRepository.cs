
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestBook.Contracts.v1.Request;
using GuestBook.Models;

namespace GuestBook.Repository
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> InsertNoteAsync(Note note);
        Task<bool> SaveAsync();
        
    }
}