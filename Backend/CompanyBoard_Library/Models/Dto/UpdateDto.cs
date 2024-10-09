namespace CompanyBoard_Library.Models.Dto
{
    public class UpdateDto
    {
    }


    public class TicketUpdateDto
    {
        public string EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

    }
}
