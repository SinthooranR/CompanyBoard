using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBoard_Library.Models.Entity.EmployeeInfo
{
    public class Comment
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Text { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket? Ticket { get; set; }
    }
}
