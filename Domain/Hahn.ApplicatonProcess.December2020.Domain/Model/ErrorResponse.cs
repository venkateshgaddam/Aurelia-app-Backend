using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
