﻿using Digital.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Infrastructure.Model.ProcessModel
{
    public class ProcessStepModel
    {
        public float? OrderIndex { get; set; }
        public Guid UserId { get; set; }
        public float XPoint { get; set; }
        public float YPoint { get; set; }
        public float XPointPercent { get; set; }
        public float YPointPercent { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int PageSign { get; set; }
    }
}