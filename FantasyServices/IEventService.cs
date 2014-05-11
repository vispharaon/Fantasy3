using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FantasyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventService" in both code and config file together.
    [ServiceContract]
    public interface IEventService
    {
      
        [OperationContract]
        bool CreateEvent(string obj);
        [OperationContract]
        bool UpdateEvent(string obj, string id);
        [OperationContract]
        bool DeleteEvent(string id);
        [OperationContract]
        string ReadEvent(string id);
        [OperationContract]
        List<string> ReadAllEvents();
    }
}
