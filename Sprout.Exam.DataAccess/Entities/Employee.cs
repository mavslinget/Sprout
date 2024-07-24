using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprout.Exam.DataAccess.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        [Column("Tin")]
        public string Tin { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
