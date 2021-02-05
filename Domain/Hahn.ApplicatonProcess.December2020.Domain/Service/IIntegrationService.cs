using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Service
{
    /// <summary>
    ///     This class is used to fetch the Countries Data inorder to Validate the Country
    /// </summary>
    public interface IIntegrationService
    {
        public Task<bool> IsCountryExist(string countryName);
    }
}
