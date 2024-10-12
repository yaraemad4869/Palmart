using System.ComponentModel.DataAnnotations.Schema;

namespace Palmart.Models
{
    public class EmployeeContact
    {
        [ForeignKey("contact")]
        public int ContactID { get; set; }
        public Contact contact { get; set; }
        [ForeignKey("employee")]
        public int EmpID { get; set; }
        public Employee employee { get; set; }
    }
}