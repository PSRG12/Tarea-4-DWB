using System;
using System.Collections.Generic;

#nullable disable

namespace Tarea3_DWB.NorthwindData
{
    public partial class EmployeeTerritory
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
