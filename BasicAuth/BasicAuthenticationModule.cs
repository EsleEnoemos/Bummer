using System;
using System.Configuration;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace BasicAuth {
	/// <summary>
	/// All thanks for this goes to
	/// http://blog.smithfamily.dk/category/Authentication.aspx
	/// Thanks!
	/// </summary>
	/// <remarks></remarks>
	/// <example></example>
	public class BasicAuthenticationModule : IHttpModule {
		private static IAuthProvider authProvider;

		/// <summary>
		/// Initializes the <see cref="BasicAuthenticationModule"/> class.
		/// Instantiates the IAuthProvider configured in the web.config
		/// </summary>
		static BasicAuthenticationModule() {

			//string provider = ConfigurationManager.AppSettings[ "Smithfamily.Blog.Samples.BasicAuthenticationModule.AuthProvider" ];
			string provider = ConfigurationManager.AppSettings[ "CustomAuthenticationProvider" ];
			Type providerType = Type.GetType( provider, true );
			authProvider = Activator.CreateInstance( providerType, false ) as IAuthProvider;
		}

		/// <summary>
		/// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
		/// </summary>
		public void Dispose() {
			authProvider.Dispose();
			authProvider = null;
		}

		/// <summary>
		/// Initializes a module and prepares it to handle requests.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
		public void Init( HttpApplication context ) {
			context.AuthenticateRequest += context_AuthenticateRequest;
			context.AuthorizeRequest += context_AuthorizeRequest;
			context.BeginRequest += context_BeginRequest;
		}



		#region void context_BeginRequest( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the context's BeginRequest event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		void context_BeginRequest( object sender, EventArgs e ) {



			//HttpApplication context = sender as HttpApplication;
			HttpApplication context = (HttpApplication)sender;
			if( context == null ) {
				return;
			}
			if( context.User == null ) {

				if( !TryAuthenticate( context ) ) {

					SendAuthHeader( context );

					return;

				}



			}

			//if( context.User != null ) {
			//    BasicUser bu = context.User.Identity as BasicUser;

			//    if( bu != null ) {
			//        context.Response.Write( string.Format( "Welcome {0} with the password:{1}", bu.UserName, bu.Password ) );
			//    }
			//}
		}
		#endregion

		/// <summary>
		/// Sends the Unauthorized header to the user, telling the user to provide a valid username and password
		/// </summary>
		/// <param name="context">The context.</param>
		private void SendAuthHeader( HttpApplication context ) {
			context.Response.Clear();
			context.Response.StatusCode = 401;
			context.Response.StatusDescription = "Unauthorized";
			context.Response.AddHeader( "WWW-Authenticate", "Basic realm=\"Secure Area\"" );
			context.Response.Write( "401 Authentication required" );
			context.Response.End();
		}

		/// <summary>
		/// Handles the AuthorizeRequest event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void context_AuthorizeRequest( object sender, EventArgs e ) {
			HttpApplication context = sender as HttpApplication;
			if( context == null ) {
				return;
			}
			BasicUser bu = context.User.Identity as BasicUser;
			if( !authProvider.IsRequestAllowed( context.Request, bu ) ) {
				SendNotAuthorized( context );
			}
		}

		/// <summary>
		/// Sends the not authorized headers to the user
		/// </summary>
		/// <param name="context">The context.</param>
		private void SendNotAuthorized( HttpApplication context ) {
			context.Response.Clear();
			context.Response.StatusCode = 403;
			context.Response.StatusDescription = "Forbidden";
			context.Response.Write( "403 Access denied" );
			context.Response.End();
		}



		/// <summary>
		/// Tries to authenticate the user
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		private bool TryAuthenticate( HttpApplication context ) {
			string authHeader = context.Request.Headers[ "Authorization" ];
			if( !string.IsNullOrEmpty( authHeader ) ) {
				if( authHeader.StartsWith( "basic ", StringComparison.InvariantCultureIgnoreCase ) ) {
					string userNameAndPassword = Encoding.Default.GetString( Convert.FromBase64String( authHeader.Substring( 6 ) ) );
					string[] parts = userNameAndPassword.Split( ':' );
					IBasicUser bu;
					if( authProvider.IsValidUser( parts[ 0 ], parts[ 1 ], out bu ) ) {
						context.Context.User = new GenericPrincipal( bu, new string[] { } );
						if( !authProvider.IsRequestAllowed( context.Request, bu ) ) {
							SendNotAuthorized( context );
							return false;
						}
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Handles the AuthenticateRequest event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void context_AuthenticateRequest( object sender, EventArgs e ) {
			HttpApplication context = sender as HttpApplication;
			TryAuthenticate( context );
		}
	}
}
