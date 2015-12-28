using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfTestApp.WcfContracts
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        string ThrowNotice(string importance, string eventName, string message);
    }
}
