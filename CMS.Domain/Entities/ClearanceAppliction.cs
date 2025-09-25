using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class ClearanceApplication
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mi { get; set; }
        public string ContactNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Section { get; set; }
        public string EmailAddress { get; set; }
        public string PurposeOfClearance { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string LibraryStatus { get; set; }
    }
}
