using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SoapService
{
    [ServiceContract]
    public interface IAuth
    {
        [OperationContract]
        string Register(string username, string password);
        [OperationContract]
        string Login(string username, string password);
    }
}
