﻿using System.ComponentModel.DataAnnotations;

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