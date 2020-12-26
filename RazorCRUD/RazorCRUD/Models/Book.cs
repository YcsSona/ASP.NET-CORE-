using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorCRUD.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Book Name")]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }
    }
}
