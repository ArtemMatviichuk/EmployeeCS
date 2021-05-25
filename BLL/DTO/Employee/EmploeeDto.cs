using EmployeeCS.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCS.DTO.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name can not be null")]
        [MinLength(3, ErrorMessage = "First name must contain at least 3 characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name can not be null")]
        [MinLength(3, ErrorMessage = "Last name must contain at least 3 characters")]
        public string LastName { get; set; }
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City can not be null")]
        [MinLength(2, ErrorMessage = "City must contain at least 2 characters")]
        public string City { get; set; }
    }
}
