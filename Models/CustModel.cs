using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dapper_Project.Models;

namespace Dapper_Project.Models
{
    public class CustModel
    {
        [Display(Name = "Id")]
        public int Custid { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}