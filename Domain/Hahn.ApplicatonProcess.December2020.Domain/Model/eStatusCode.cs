using Hahn.ApplicatonProcess.December2020.Domain.Utils;
using System;
using System.ComponentModel;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public enum eStatusCode
    {
        [HttpCode(200)]
        [Description("Operation Success!")]
        OK = 200,

        [HttpCode(201)]
        [Description("The Request has been Succeded and the new Resource has been Created")]
        Created = 201,

        [HttpCode(204)]
        [Description("The Request was Successfully Processed")]
        NoContent = 204,

        [HttpCode(400)]
        [Description("The Request has Invalid Arguments")]
        InValidArgument = 400,

        [HttpCode(400)]
        [Description("InValid Inputs were Provided")]
        InValidInputs = 400,

        [HttpCode(500)]
        [Description("Internal Server Error")]
        Internal = 500,
    }

}
