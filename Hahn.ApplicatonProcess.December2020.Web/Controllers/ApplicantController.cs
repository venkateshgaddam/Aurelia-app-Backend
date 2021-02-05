using Hahn.ApplicatonProcess.December2020.Domain.Biz;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : Controller
    {
        #region Properties

        public IApplicantBiz applicantBiz { get; set; }

        private readonly ILogger<AddApplicant> _logger;
        private readonly ILogger<UpdateApplicant> updateLogger;

        #endregion

        #region Constructor

        public ApplicantController(IApplicantBiz applicantBiz, ILogger<AddApplicant> logger, ILogger<UpdateApplicant> updateLogger)
        {
            this.applicantBiz = applicantBiz;
            this._logger = logger;
            this.updateLogger = updateLogger;
        }

        #endregion


        #region ActionMethods


        // POST api/<ApplicantController>
        [HttpPost()]
        [SwaggerRequestExample(typeof(AddApplicant), typeof(AddApplicantExample))]
        public async Task<IActionResult> Post([FromBody] AddApplicant addApplicant)
        {
            _logger.LogInformation("this is test");
            var applicant = await applicantBiz.AddApplicant(addApplicant);
            var result = Json(applicant);
            result.StatusCode = (int)HttpStatusCode.Created;
            return result;
        }

        // PUT api/<ApplicantController>/5
        [HttpPut()]
        [SwaggerRequestExample(typeof(UpdateApplicant), typeof(UpdateApplicantExample))]
        public async Task<IActionResult> Put([FromBody] UpdateApplicant updateApplicant)
        {
            var applicant = await applicantBiz.UpdateApplicant(updateApplicant);
            var result = Json(applicant);
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var applicant = await applicantBiz.GetApplicant(id);
            if (applicant != null)
            {
                var result = Json(applicant);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }


        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await applicantBiz.DeleteApplicant(id);
                return new NoContentResult();
            }
            throw new ArgumentException($"InValid Id {id} to Delete.Please check!!");
        }

        #endregion

    }
}
