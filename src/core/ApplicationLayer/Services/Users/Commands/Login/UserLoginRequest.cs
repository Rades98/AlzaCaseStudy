﻿namespace ApplicationLayer.Services.Users.Commands.Login
{
    using DomainLayer.Entities.Users;
    using Exceptions;
    using Interfaces;
    using MediatR;
    using System.Linq.Expressions;
    using Utils.PasswordHashing;

    public class UserLoginRequest : IRequest<UserLoginResponse>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[] Token { get; set; } = new byte[128];

        public class Handler : IRequestHandler<UserLoginRequest, UserLoginResponse>
        {
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
                var user = await _userRepo.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);

                if (user == null)
                {
                    throw new UserLoginException(UserLoginException.UsrNotFound);
                }

                if (!PasswordHashing.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new UserLoginException(UserLoginException.WrongPw);
                }

                var roleRelations = await _userRoleRelationRepo
                    .GetAllWhereAsync(rr => rr.UserId == user.Id, cancellationToken);

                var roles = (await _userRoleRepo.GetAllWhereAsync(role => roleRelations.Select(x => x.RoleId).Contains(role.Id), cancellationToken)).Select(role => role.Name).ToList();

                return new UserLoginResponse()
                {
                    UserName = user.UserName,
                    Token = PasswordHashing.CreateToken(user.UserName, request.Token, roles),
                    Roles = roles
                };
            }
        }
    }
}