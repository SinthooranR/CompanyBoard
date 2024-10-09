using CompanyBoard_Library.Models.Entity.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBoard_Library.Models.Entity.EmployeeInfo
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; }
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
