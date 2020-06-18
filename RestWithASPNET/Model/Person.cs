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

        public Person() { }

        public Person(Guid id, string firstName, string lastName, string address, Gender gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender;
        }

        public Person(string firstName, string lastName, string address, Gender gender)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender;
        }
    }

    public enum Gender
    {
        [Display(Name = "Masculino")]
        Masculine,
        [Display(Name = "Feminino")]
        Female
    }
}
