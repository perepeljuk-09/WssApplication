using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WssApplication.Shared.Dtos.Division
{
    public class DivisionMoveDto
    {
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int ToPosition { get; set; }
    }
}
