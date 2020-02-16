using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using Models;

namespace SoapService
{
    [ServiceContract]
    public interface IInfo
    {
        [OperationContract]
        string PostInfo(long iin, string surname, string firstname, string patronymic);
        [OperationContract]
        Profiles[] GetInfo();
    }
}
