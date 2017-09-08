namespace ODataWebAPI.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
