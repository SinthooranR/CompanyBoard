using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
