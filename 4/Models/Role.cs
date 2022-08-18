using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4.Models
{
    public class Role
    {
        [Key]
        public int RoleId { set; get; }

        public string RoleName { set; get; }
    }
}