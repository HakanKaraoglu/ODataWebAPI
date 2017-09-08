using System.Collections.Generic;

namespace ODataWebAPI.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
        }
    }
}