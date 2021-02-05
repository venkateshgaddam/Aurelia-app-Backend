using System;

namespace Hahn.ApplicatonProcess.December2020.Data.Entity
{
    public class Applicant
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string FamilyName { get; set; }
        
        public string Address { get; set; }
        
        public string CountryOfOrigin { get; set; }
        
        public string EmailAddress { get; set; }

        public int Age { get; set; }
        
        public bool Hired { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
