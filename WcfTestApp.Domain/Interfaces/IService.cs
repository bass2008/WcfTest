using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfTestApp.Domain.Interfaces
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        string ThrowNotice(string impotance, string eventName, string message);
    }
}
