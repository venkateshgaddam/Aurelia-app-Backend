using Hahn.ApplicatonProcess.December2020.Data.EFCore;
using Hahn.ApplicatonProcess.December2020.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Properties

        private readonly DbContextOptions<ApplicantContext> dbContextOptions;


        #endregion

        #region Constructor

        public Repository()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicantContext>()
                                            .UseInMemoryDatabase(databaseName: "Applicant")
                                            .Options;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task<Applicant>  AddApplicant(T applicant)
        {
            Applicant applicantDB = applicant as Applicant;
            using (var context = new ApplicantContext(dbContextOptions))
            {
                //logger.LogInformation($"Db Connvetion Successful");
                context.Applicants.Add(applicantDB);
                //logger.LogInformation($"Entity Data was added into the Context");
                
                await context.SaveChangesAsync(acceptAllChangesOnSuccess: true);
                //logger.LogInformation($"Entity Data was saved in the DB");

            }
            return applicantDB;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public Task DeleteApplicant(T applicant)
        {
            Applicant applicantDB = applicant as Applicant;
            using (var context = new ApplicantContext(dbContextOptions))
            {
                context.Applicants.Remove(applicantDB);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public async Task<Applicant> GetApplicant(int applicantId)
        {
            using var context = new ApplicantContext(dbContextOptions);
            return await context.Applicants.FirstOrDefaultAsync(a => a.ID == applicantId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task<Applicant> UpdateApplicant(T applicant)
        {
            Applicant applicantDB = applicant as Applicant;
            using (var context = new ApplicantContext(dbContextOptions))
            {
                context.Applicants.Update(applicantDB);
                await context.SaveChangesAsync();
            }
            return applicantDB;
        }

        #endregion

    }
}
