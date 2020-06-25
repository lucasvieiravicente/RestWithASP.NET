using Newtonsoft.Json;
using RestWithASPNET.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.VO
{
    //DataContract not working on .NET Core 3, so work with Newsoft Json (https://github.com/dotnet/aspnetcore/issues/14158) - (https://stackoverflow.com/questions/57965350/datamember-attribute-is-not-honored-in-dotnet-core-3-0)
    //[DataContract]
    public class PersonVO
    {        
        [JsonProperty("PersonId", Order = 1)]
        public Guid Id { get; set; }
        [JsonProperty(Order = 2)]
        public string FirstName { get; set; }
        [JsonProperty(Order = 3)]
        public string LastName { get; set; }
        [JsonProperty(Order = 5)]
        public string Address { get; set; }
        [JsonProperty(Order = 4)]
        public Gender Gender { get; set; }

        public PersonVO() { }

        public PersonVO(Guid id, string firstName, string lastName, string address, Gender gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender;
        }

        public PersonVO(string firstName, string lastName, string address, Gender gender)
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
