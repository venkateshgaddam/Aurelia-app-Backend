using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Entity;
using Hahn.ApplicatonProcess.December2020.Data.Repository;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Service;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Biz
{
    public class ApplicantBiz : IApplicantBiz
    {
        #region Properties

        private readonly IMapper mapper;

        private readonly IRepository<Applicant> repository;
        private readonly ILogger<Applicant> _Logger;
        private readonly IIntegrationService integrationService;

        #endregion

        #region Constructor

        public ApplicantBiz(IRepository<Applicant> repository, IIntegrationService integrationService, ILogger<Applicant> logger)
        {
            this.repository = repository;
            this._Logger = logger;
            this.integrationService = integrationService;
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<AddApplicant, Applicant>();
                  cfg.CreateMap<UpdateApplicant, Applicant>();
              });
            mapper = config.CreateMapper();
        }

        #endregion

        #region Methods

        public async Task<Applicant> AddApplicant(AddApplicant addApplicant)
        {
            try
            {
                bool isValidCountry = await integrationService.IsCountryExist(addApplicant.CountryOfOrigin);

                if (isValidCountry)
                {
                    _Logger.LogInformation("Validation Success");
                    Applicant applicant = mapper.Map<Applicant>(addApplicant);
                    applicant.CreatedAt = DateTime.Now;
                    applicant.UpdatedAt = DateTime.Now;

                    _Logger.LogDebug($"The Object which gets inserted into the DB :- {JsonConvert.SerializeObject(applicant) }");
                    Applicant applicantfromDB = await repository.AddApplicant(applicant);
                    return applicantfromDB;
                }
                else
                {
                    _Logger.LogInformation($" Invalid Country {addApplicant.CountryOfOrigin}");
                    throw new ArgumentException($"{addApplicant.CountryOfOrigin} is Invalid. Please check the CountryOfOrigin again", addApplicant.CountryOfOrigin.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error Occured while processing the Add Request. {ex.Message}");
                throw ex;
            }
        }

        public async Task DeleteApplicant(int applicantId)
        {
            try
            {
                if (applicantId > 0)
                {
                    _Logger.LogInformation($"Deleting the applicant with applicantID {applicantId}");
                    Applicant ApplicantDetails = await repository.GetApplicant(applicantId);

                    if (ApplicantDetails != null)
                    {
                        _Logger.LogDebug($"Applicant Details :- {JsonConvert.SerializeObject(ApplicantDetails)}");
                        await repository.DeleteApplicant(ApplicantDetails);
                    }
                    else
                    {
                        _Logger.LogError($"No Applicant with the ID {applicantId} Exists. Unable to Delete the Record");
                        throw new ArgumentException($"No Applicant with the ID {applicantId} Exists. Unable to Delete the Record");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Applicant> GetApplicant(int applicantId)
        {
            try
            {
                _Logger.LogInformation($"Fetching the Applicant info with the ID {applicantId}");
                Applicant result = await repository.GetApplicant(applicantId);
                return result;
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Exception occured in fetching the Applicant info with the ID {applicantId}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Applicant> UpdateApplicant(UpdateApplicant updateApplicant)
        {
            _Logger.LogInformation($"Updating the applicant whose Name:- {updateApplicant.FamilyName} {updateApplicant.Name}");

            //Fetch the applicant Details
            Applicant applicantDetails = await repository.GetApplicant(updateApplicant.ID);

            bool isValidCountryOfOrigin = true;
            if (applicantDetails != null)
            {
                _Logger.LogInformation($"Applicant existing in the Database");
                if (applicantDetails.CountryOfOrigin != updateApplicant.CountryOfOrigin)
                {
                    _Logger.LogInformation($"Validating the Country if the Update Model has a different country than the Existing");
                    isValidCountryOfOrigin = await integrationService.IsCountryExist(updateApplicant.CountryOfOrigin);
                }

                if (isValidCountryOfOrigin)
                {
                    _Logger.LogInformation($"Country is Valid");
                    applicantDetails = mapper.Map<Applicant>(updateApplicant);
                    applicantDetails.UpdatedAt = DateTime.Now;
                    var applicantfromDB = await repository.UpdateApplicant(applicantDetails);

                    _Logger.LogDebug($"Updated Applicant Information {JsonConvert.SerializeObject(applicantDetails)}");
                    return applicantfromDB;
                }
                else
                {
                    _Logger.LogError($"{updateApplicant.CountryOfOrigin} is Invalid. Please check the CountryOfOrigin again", updateApplicant.CountryOfOrigin.GetType().Name);
                    throw new ArgumentException($"{updateApplicant.CountryOfOrigin} is Invalid. Please check the CountryOfOrigin again", updateApplicant.CountryOfOrigin.GetType().Name);
                }
            }
            else
            {
                _Logger.LogError($"No Applicant Exists with the Id {updateApplicant.ID}");
                throw new ArgumentException($"No Applicant Exists with the Id {updateApplicant.ID}");
            }
        }
    }

    #endregion

}
