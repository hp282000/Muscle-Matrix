using AutoMapper;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service
{
    public class UserRoleService:IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository iuserRoleRepository,IMapper mapper) 
        {
            _userRoleRepository = iuserRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> AddUserRoleAsync(UserRoleRequestModel userRoleRequestModel)
        {
            var addUserRole = UserRoleBuilder.Build(userRoleRequestModel);

            var userRole = await _userRoleRepository.AddUserRole(addUserRole);

            return userRole;
        }

        public async Task<List<UserRoleResponseModel>> GetUserRoleAsync()
        {
            var getUserRole = await _userRoleRepository.GetAllRoles();
            var mapper =  _mapper.Map<List<UserRoleResponseModel>>(getUserRole);
            return mapper;
        }
    }
}
