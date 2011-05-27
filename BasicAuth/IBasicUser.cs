using System.Security.Principal;

namespace BasicAuth {
	/// <summary>
	/// interface for a very simple user object that contains the bare 
	/// minimum to do authentication against a real backend
	/// </summary>
	public interface IBasicUser : IIdentity {
		/// <summary>
		/// Gets or sets the username of the user.
		/// </summary>
		/// <value>The username of the user.</value>
		string UserName {
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		string Password {
			get;
			set;
		}
	}
}