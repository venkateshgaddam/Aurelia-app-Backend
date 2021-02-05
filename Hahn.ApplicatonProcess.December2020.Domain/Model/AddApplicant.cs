using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public class AddApplicant
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool Hired { get; set; }
    }


    public class AddApplicantExample : IExamplesProvider<AddApplicant>
    {
        //public AddApplicant GetExamples()
        // {
        //     return new AddApplicant()
        //     {
        //         Name = "Venkatesh",
        //         FamilyName = "Gaddam",
        //         Address = "234,SquirrelHomes,JublieeHills,Hyderabad",
        //         Age = 28,
        //         CountryOfOrigin = "India",
        //         EmailAddress = "v@gmail.com",
        //         Hired = true,
        //     };
        // }
        public AddApplicant GetExamples()
        {
            return new AddApplicant()
            {
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
