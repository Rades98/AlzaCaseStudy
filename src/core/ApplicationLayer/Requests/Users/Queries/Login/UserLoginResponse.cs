using ApplicationLayer.Dtos;

namespace ApplicationLayer.Requests.Users.Queries.Login
{
	public class UserLoginResponse : RestDtoBase
	{
		public string UserName { get; set; } = string.Empty;
		public string Token { get; set; } = string.Empty;
	}
}
