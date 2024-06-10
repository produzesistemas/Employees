using Employees.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Employees.Mappings
{
    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap() { 
            Id(x => x.Id, map =>
            {
                map.Generator(Generators.Native);

            });
            Property(x => x.Name, x =>
            {
                x.Length(255);
                x.NotNullable(true);
            });
            Property(x => x.Age, x =>
            {
                x.NotNullable(true);
            });
            Property(x => x.Salary, x =>
            {
                x.NotNullable(true);
            });
            Table("Employee");
        }
    }
}
