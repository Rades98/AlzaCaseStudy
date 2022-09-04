using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AppUtils.PasswordHashing
{
	public static class PasswordHashing
	{
		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using var hmac = new HMACSHA512();
			passwordSalt = hmac.Key;
			passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
		}

		public static bool VerifyPasswordHash(string password, byte[] pwHash, byte[] pwSalt)
		{
			using var hmac = new HMACSHA512(pwSalt);
			byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			return computedHash.SequenceEqual(pwHash);
		}

		public static string CreateToken(int id, byte[] appToken, List<string> roles)
		{
			List<Claim> claims = new()
				{
					new Claim(ClaimTypes.NameIdentifier, id.ToString()),
				};

			roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

			var key = new SymmetricSecurityKey(appToken);

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);

			string jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}
