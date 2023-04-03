using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLBanHang.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name ="Role Name")]
        public string Name { get; set; }
    }
}