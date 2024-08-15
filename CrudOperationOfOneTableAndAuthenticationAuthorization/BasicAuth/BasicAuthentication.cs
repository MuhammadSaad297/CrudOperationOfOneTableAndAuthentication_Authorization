//using System.Net;
//using System.Security.Principal;
//using System.Text;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace CrudOperationOfOneTableAndAuthenticationAuthorization.BasicAuth
//{
//    public class BasicAuthentication:AuthorizationFilterAttribute
//    {
//        public override void OnAuthorization(HttpActionContext actionContext)
//        {
//            if (actionContext.Request.Headers.Authorization == null)
//            {
//                actionContext.Response = actionContext.Request.
//                CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
//            }
//            else
//            {
//                string authToken = actionContext.Request.Headers.Authorization.Parameter; //is sy token mil jaye ga then isko decode kren gy

//                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
//                string[] usernamepassword = decodedAuthToken.Split(':');//: is base pr string array ki form mein splt ho jaye gi 

//                string username = usernamepassword[0];
//                string password = usernamepassword[1];

//                //check username and password is valid or not
            
//                if(ValidateUser.Login(username,password))
//                {
//                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);//null ki jaga hum user ka role bata skty hein
//                }
//                else
//                {
//                    actionContext.Response = actionContext.Request.
//                    CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
//                }

//            }
//        }
//    }
//}
