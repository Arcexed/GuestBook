using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GuestBook.Models
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        [NotNull]
        public DateTime CreatingDateTime { get; set;}
        public string Email {get;set;}
        public string Name {get;set;}
        public string Text {get;set;}
    }
    
}