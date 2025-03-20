using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WssApplication.Shared.Dtos.Department
{
    public class DepartmentMoveDto
    {
        public int DepartmentId { get; set; }
        public int ToPosition { get; set; }
    }
}
