using System.Data.Entity.ModelConfiguration;
using ODataWebAPI.Domain.Entities;

namespace ODataWebAPI.Mapper.Mapping
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");
            Property(e => e.CompanyId).IsRequired();
            Property(e => e.AddressId).IsRequired();
        }
    }
}
