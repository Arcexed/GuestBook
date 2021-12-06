
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestBook.Contracts.v1.Request;
using GuestBook.Models;

namespace GuestBook.Repository
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotes();
        Note InsertNote(Note note);
        bool Save();
        
    }
}