namespace UnitTests.Mocks.GenericRepo.Users
{
    using ApplicationLayer.Utils.PasswordHashing;
    using DomainLayer.Entities.Users;

    public static class UsersRepositoryResultsMock
    {
        public static readonly UserEntity TestUser = GetTestUser();

        private static UserEntity GetTestUser()
        {
            PasswordHashing.CreatePasswordHash(UsersRepositoryRequestsMock.UserLoginRequest.Password, out byte[] hash, out byte[] salt);

            return new()
            {
                Id = System.Guid.NewGuid(),
                UserName = UsersRepositoryRequestsMock.UserLoginRequest.UserName,
                Created = System.DateTime.Now,
                PasswordHash = hash,
                PasswordSalt = salt
            };
        }
    }
}
