namespace ApplicationLayer.Utils.PasswordHashing
{
    using System.Security.Cryptography;

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
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(pwHash);
        }
    }
}
