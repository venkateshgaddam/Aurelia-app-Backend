using Hahn.ApplicatonProcess.December2020.Data.Entity;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Biz
{
    public interface IApplicantBiz
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addApplicant"></param>
        /// <returns></returns>
        Task<Applicant> AddApplicant(AddApplicant addApplicant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addApplicant"></param>
        /// <returns></returns>
        Task<Applicant> UpdateApplicant(UpdateApplicant addApplicant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        Task<Applicant> GetApplicant(int applicantId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        Task DeleteApplicant(int applicantId);

    }
}
