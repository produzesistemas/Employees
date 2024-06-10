namespace Employees.Models
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual int Age { get; set; }
        public virtual decimal Salary  { get; set ;}

    }
}
