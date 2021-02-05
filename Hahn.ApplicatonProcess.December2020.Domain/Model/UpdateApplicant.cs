using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public class UpdateApplicant : AddApplicant
    {
        [Required]
        public int ID { get; set; }
    }

    public class UpdateApplicantExample : IExamplesProvider<UpdateApplicant>
    {
        public UpdateApplicant GetExamples()
        {
            return new UpdateApplicant()
            {
                ID = 1,
                Name = "Venkatesh",
                FamilyName = "Gaddam",
                Address = "234,SquirrelHomes,JublieeHills,Hyderabad",
                Age = 28,
                CountryOfOrigin = "India",
                EmailAddress = "v@gmail.com",
                Hired = true,
            };
        }
    }
}
