﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.Models
{
    public class CongNoModel
    {
        public DateTime Ngay { get; set; }
        public string KhachHang { get; set; }
        public string Cont { get; set; }
        public decimal? Cuoc { get; set; }
        public decimal? ChiHo { get; set; }
        public decimal? tienthu { get; set; }
    }
}