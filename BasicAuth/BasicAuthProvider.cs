using System.Web;

namespace BasicAuth {
	/// <summary>
	/// Sample IAuthProvider that will authenticate all users, and only allow access to user with a username of nobody
	/// </summary>
	public class BasicAuthProvider : IAuthProvider {
		/// <summary>
		/// Validates the username and password and returns whether or not the combination is a valid user
		/// </summary>
		/// <param name="userName">The username to validate</param>
		/// <param name="password">The password to match</param>
		/// <param name="user">The user object created</param>
		/// <returns>
		/// true if the combination is a valid user;false otherwise
		/// </returns>
		public bool IsValidUser( string userName, string password, out IBasicUser user ) {
			user = new BasicUser();
			user.UserName = userName;
			user.Password = password;
			return true;

		}

		/// <summary>
		/// Determines whether or not the current request is allowed to continue for the given user
		/// </summary>
		/// <param name="request">The request to check</param>
		/// <param name="user">The user</param>
		/// <returns>
		/// true if request is authorized;false otherwise
		/// </returns>
		public bool IsRequestAllowed( HttpRequest request, IBasicUser user ) {
			return user.UserName == "nobody";
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose() {
			//This is intentional, since we don't have any resources to free in this very simple sample IAuthProvider
		}
	}
}