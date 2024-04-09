using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleAPI.infrastructure.Auth
{
    public interface IApiKeyValidator
    {
        bool isValid(string apiKey);
    }
}
