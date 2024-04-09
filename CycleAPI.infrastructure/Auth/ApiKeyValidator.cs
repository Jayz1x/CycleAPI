using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleAPI.infrastructure;

namespace CycleAPI.infrastructure.Auth
{
    public class ApiKeyValidator : IApiKeyValidator
    {

        //lista de keys para la validacion
        private List<string> validApiKeys = new List<string>
        {
            "validkey1",
            "validkey2",
            "validkey3",
            "validkey4"
        };
        public bool isValid(string apiKey)
        {
            return validApiKeys.Contains(apiKey);
        }
    }
}
