using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Repository
{
    public interface IAuthenticationManager
    {
        public string Authenticate(string emailId, string password);

    }
}
