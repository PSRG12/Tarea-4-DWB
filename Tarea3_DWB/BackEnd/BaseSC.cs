using System;
using System.Collections.Generic;
using System.Text;
using Tarea3_DWB.NorthwindData;

namespace Tarea3_DWB.BackEnd
{
    public class BaseSC
    {
       protected NorthwindContext dbContext = new NorthwindContext();
    }
}
