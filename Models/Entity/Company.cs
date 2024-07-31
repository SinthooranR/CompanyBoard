namespace PayrollManagerAPI.Models.Entity
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Industry { get; set; }
        public DateTime Founded { get; set; }
        public int OwnerID { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Stakeholder> Stakeholders { get; set; }

        public ICollection<Owner> Owners { get; set; }
    }
}
