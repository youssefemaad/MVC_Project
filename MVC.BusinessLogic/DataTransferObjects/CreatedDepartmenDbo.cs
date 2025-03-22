using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.DataTransferObjects
{
    public class CreatedDepartmenDbo
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly DateOfCreation { get; set; }
    }
}
