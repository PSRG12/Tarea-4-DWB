﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tarea3_DWB.DataAccess
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
