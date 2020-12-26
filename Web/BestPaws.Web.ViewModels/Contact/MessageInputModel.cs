namespace BestPaws.Web.ViewModels.Contact
{
    using System.ComponentModel.DataAnnotations;

    public class MessageInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string AuthorFirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string AuthorLastName { get; set; }

        [Required]
        [EmailAddress]
        public string AuthorEmail { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }
    }
}
