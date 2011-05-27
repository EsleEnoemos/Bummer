using System;
using System.Web;

namespace BasicAuth {
	/// <summary>
	/// An authentication and authorization provider for very simple applications
	/// Should probably be either implemented with a database backend, 
	/// or using a web.config custom section
	/// Implementors of this interface should provide a default no args constructor to be used
	/// by the AuthenticationModule
	/// </summary>
	public interface IAuthProvider : IDisposable {
		/// <summary>
		/// Validates the username and password and returns whether or not the combination is a valid user
		/// </summary>
		/// <param name="userName">The username to validate</param>
		/// <param name="password">The password to match</param>
		/// <param name="user">The user object created</param>
		/// <returns>true if the combination is a valid user;false otherwise</returns>
		bool IsValidUser( string userName, string password, out IBasicUser user );

		/// <summary>
		/// Determines whether or not the current request is allowed to continue for the given user
		/// </summary>
		/// <param name="request">The request to check</param>
		/// <param name="user">The user</param>
		/// <returns>true if request is authorized;false otherwise</returns>
		bool IsRequestAllowed( HttpRequest request, IBasicUser user );

	}
}