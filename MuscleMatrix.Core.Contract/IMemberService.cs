﻿using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Contract
{
    public interface IMemberService
    {
        Task<int> AddMemberAsync(MemberRequestModel memberRequestModel);

        Task<List<MemberResponseModel>> GetMemberAsync();

    }
}
