using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Masculino")]
        Masculine,
        [Display(Name = "Feminino")]
        Female
    }
}
