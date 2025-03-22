using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.DataTransferObjects
{
    public class DepartmentDetailsDbo
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; }
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
