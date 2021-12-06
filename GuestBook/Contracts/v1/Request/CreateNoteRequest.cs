using System.ComponentModel.DataAnnotations;

namespace GuestBook.Contracts.v1.Request
{
    public class CreateNoteRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter you email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [MinLength(6)]
        public string Email { get; set; }
        
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter you name")]
        [MinLength(3)]
        public string Name { get; set; }
        
        
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please enter text")]
        [DataType(DataType.Text)]
        public string Text { get; set; }
    }
}