namespace ApplicationLayer.Requests.Users.Commands.Register
{
	using ApplicationLayer.Dtos;

	public class UserRegisterResponse : RestDtoBase
	{
		public string Code { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
	}
}
