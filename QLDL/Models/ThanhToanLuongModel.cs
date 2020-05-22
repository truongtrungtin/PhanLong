using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDL.Models
{
    public class ThanhToanLuongModel
    {
        public string TaiXe { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public int SoNgayLV { get; set; }     
    }
}