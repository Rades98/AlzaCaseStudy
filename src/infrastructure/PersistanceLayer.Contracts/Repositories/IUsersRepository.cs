using DomainLayer.Entities.Users;

namespace PersistanceLayer.Contracts.Repositories
{
	public interface IUsersRepository
	{
		/// <summary>
		/// Confirm user registration
		/// </summary>
		/// <param name="registrationCode">registration code</param>
		/// <param name="ct">cancellation code</param>
		/// <returns></returns>
		Task ConfirmUserRegistrationAsync(string registrationCode, CancellationToken ct);

		/// <summary>
		/// Register user
		/// </summary>
		/// <param name="userName">user name</param>
		/// <param name="email">email</param>
		/// <param name="firstName">first name</param>
		/// <param name="surname">surname</param>
		/// <param name="password">pw</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>new user</returns>
		Task<UserEntity> RegisterUserAsync(string userName, string email, string firstName, string surname, string password, CancellationToken ct);

		/// <summary>
		/// Login user
		/// </summary>
		/// <param name="userName">user name</param>
		/// <param name="password">password</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task<UserEntity> LoginUserAsync(string userName, string password, CancellationToken ct);
	}
}
