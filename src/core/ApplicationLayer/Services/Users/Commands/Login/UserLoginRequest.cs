namespace ApplicationLayer.Services.Users.Commands.Login
{
    using DomainLayer.Entities.Users;
    using Exceptions;
    using Interfaces;
    using MediatR;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Utils.PasswordHashing;

    public class UserLoginRequest : IRequest<UserLoginResponse>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[] Token { get; set; } = new byte[128];

        public class Handler : IRequestHandler<UserLoginRequest, UserLoginResponse>
        {
            //This logic should be in some procedure
            private readonly IGenericRepository<UserEntity> _userRepo;
            private readonly IGenericRepository<UserRoleEntity> _userRoleRepo;
            private readonly IGenericRepository<UserRoleRelationEntity> _userRoleRelationRepo;

            public Handler(
                IGenericRepository<UserEntity> userRepo,
                IGenericRepository<UserRoleEntity> userRoleRepo,
                IGenericRepository<UserRoleRelationEntity> userRoleRelationRepo
                ) => (_userRepo, _userRoleRepo, _userRoleRelationRepo) = (userRepo, userRoleRepo, userRoleRelationRepo);

            public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
            {
                // add procedure to obtain these data, cause there is no way to make it generic and nice
                var user = (await _userRepo.GetAllAsync(false, x => x.UserName, cancellationToken)).FirstOrDefault(u => u.Name == request.UserName);

                if (user == null)
                {
                    throw new UserLoginException("User not found");
                }

                if (!PasswordHashing.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new UserLoginException("Wrong PW");
                }

                var roleRelations = (await _userRoleRelationRepo.GetAllAsync(false, x => x.UserId, cancellationToken)).Where(rr => rr.UserId == user.Id).ToList();

                var roles = (await _userRoleRepo.GetAllAsync(false, x => x.Id, cancellationToken)).Select(role => role.Name).ToList();

                return new UserLoginResponse()
                {
                    UserName = user.Name,
                    Token = CreateToken(user.Name, request.Token, roles),
                    Roles = roles
                };
            }

            private static string CreateToken(string name, byte[] appToken, List<string> roles)
            {
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name, name),
                };

                roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

                var key = new SymmetricSecurityKey(appToken);

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
        }
    }
}
