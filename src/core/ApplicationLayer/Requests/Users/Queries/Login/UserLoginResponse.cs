﻿namespace ApplicationLayer.Requests.Users.Queries.Login
{
	using Dtos;

	public class UserLoginResponse : RestDtoBase
	{
		public string UserName { get; set; } = string.Empty;
		public string Token { get; set; } = string.Empty;
	}
}