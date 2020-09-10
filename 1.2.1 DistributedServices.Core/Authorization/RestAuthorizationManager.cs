using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Olimpiadas.DistributedServices.Core.Authorization
{
    /// <summary>
    /// 
    /// </summary>
    public class RestAuthorizationManager : ServiceAuthorizationManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationContext"></param>
        /// <returns></returns>
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            try
            {
                var credencialesUser = ConfigurationManager.AppSettings["RestAuthorizationUser"];
                var credencialesPassword = ConfigurationManager.AppSettings["RestAuthorizationPassword"];

                if (string.IsNullOrEmpty(credencialesUser) || string.IsNullOrEmpty(credencialesPassword)) return true;

                var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                if ((authHeader != null) && (authHeader != string.Empty))
                {
                    var svcCredentials = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(authHeader.Substring(6))).Split(':');
                    var user = new { Name = svcCredentials[0], Password = svcCredentials[1] };
                    if ((user.Name == credencialesUser && user.Password == credencialesPassword))
                    {
                        //Usuario autorizado
                        return true;
                    }
                    else
                    {
                        //No authorization header was provided, so challenge the client to provide before proceeding:
                        WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"RutasCortas.svc\"");

                        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;

                        //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                        throw new WebFaultException(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    //No authorization header was provided, so challenge the client to provide before proceeding:
                    WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"RutasCortas.svc\"");

                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;

                    //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                    throw new WebFaultException(HttpStatusCode.Unauthorized);
                }
            }
            catch
            {
                //No authorization header was provided, so challenge the client to provide before proceeding:
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"RutasCortas.svc\"");

                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;

                //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }
    }
}