using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MyPlugins
{
    public class ContactPreCreate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory =
      (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService svc = serviceFactory.CreateOrganizationService(context.UserId);

             //Retrive a record which user working on
           
               if( context.InputParameters["Target"] is Entity)
                {
                Entity ContactRecord = (Entity)context.InputParameters["Target"];
                // From here you can add custom code

                string lastname= ContactRecord.Attributes["lastname"].ToString();
                if( lastname.Length >= 20 )
                {
                    throw new InvalidPluginExecutionException("Lastname lenght should be less than 20 char");
                }

            }
        }
    }
}
