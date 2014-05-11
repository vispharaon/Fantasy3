using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace FantasyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool IsValid(string user, string password);
        [OperationContract]
        bool CreateUser(string obj);
        [OperationContract]
        bool UpdateUser(string obj, string email);
        [OperationContract]
        bool DeleteUser(string email);
        [OperationContract]
        string ReadUser(string email);
        [OperationContract]
        List<string> ReadAllUsers();
        [OperationContract]
        bool InsertImage(string path, string mail);
    }
}
