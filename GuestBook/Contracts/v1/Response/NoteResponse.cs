using System;

namespace GuestBook.Contracts.v1.Response
{
    public class NoteResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatingDateTime { get; set;}
        public string Email {get;set;}
        public string Name {get;set;}
        public string Text {get;set;}
    }
}