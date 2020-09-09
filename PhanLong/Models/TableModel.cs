using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhanLong.Models
{
    public class TableModel
    {
        [Display(Name = "Tên bảng")]
        public string Table { set; get; }

        [Display(Name = "Tên Cột")]
        public string Column { set; get; }
    }
}