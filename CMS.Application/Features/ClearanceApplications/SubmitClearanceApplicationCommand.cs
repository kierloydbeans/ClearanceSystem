using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ClearanceApplications
{
    public class SubmitClearanceApplicationCommand
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mi { get; set; }
        public string ContactNumber { get; set; }
        public string Birthday { get; set; } 
        public string Sex { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Section { get; set; }
        public string EmailAddress { get; set; }
        public string PurposeOfClearance { get; set; }
        public string SubmissionDate { get; set; } 
    }
}
