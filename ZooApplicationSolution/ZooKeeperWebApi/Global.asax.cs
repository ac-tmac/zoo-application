using System.Data.Entity;
using System.Web;
using System.Web.Http;

namespace ZooKeeperWebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new Models.ZooKeeperEntitiesInitialiser());
        }
    }
}
