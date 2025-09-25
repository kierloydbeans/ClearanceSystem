using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ClearanceApplications
{
    public class UpdateClearanceApplicationStatusDto
    {
        public string ApplicationId { get; set; } 
        public string Status { get; set; }
    }
}
