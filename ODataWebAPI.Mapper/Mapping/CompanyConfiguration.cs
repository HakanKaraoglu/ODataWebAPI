using System.Data.Entity.ModelConfiguration;
using ODataWebAPI.Domain.Entities;

namespace ODataWebAPI.Mapper.Mapping
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("Companies");
        }
    }
}
