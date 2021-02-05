using Hahn.ApplicatonProcess.December2020.Data.Entity;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        Task<Applicant> AddApplicant(TEntity applicant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        Task<Applicant> UpdateApplicant(TEntity applicant);

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
        Task DeleteApplicant(TEntity applicant);

    }
}
