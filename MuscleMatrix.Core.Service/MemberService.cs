using AutoMapper;
using CloudinaryDotNet;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Core.Service.Helper;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service
{
    public class MemberService :IMemberService
    {
        private readonly IMemberRepository _imemberRepository;
        private readonly IMapper _mapper;
        private readonly IFileUploadHelper _fileUploadHelper;
        
        public MemberService(IMemberRepository imemberRepository, IMapper mapper , IFileUploadHelper fileUploadHelper)
        {
            _imemberRepository = imemberRepository;
            _mapper = mapper;
            _fileUploadHelper = fileUploadHelper;
        }

        public async Task<int> AddMemberAsync(MemberRequestModel memberRequestModel, string image)
        {
        //    var addMember1 = new MemberBuilder();
         //   var addMember = addMember1.Build(memberRequestModel);
            var addMember = MemberBuilder.Build(memberRequestModel, image);

            var useMember = await _imemberRepository.AddMember(addMember);

            var uploadImage = memberRequestModel.Photo;
          //  var cloudinary = new Cloudinary("CLOUDINARY_URL=cloudinary://256532249671949:zYaObf6qQeiSh-WlCEJbWU4QTdo@dcky8arhy");

            await _fileUploadHelper.UploadImage(uploadImage);


            return useMember;
         
            
        }
        public async Task<List<MemberResponseModel>> GetMemberAsync()
        {
            var getMembers = await _imemberRepository.GetMember();

            var mapper = _mapper.Map<List<MemberResponseModel>>(getMembers);

            return mapper;
        }

        public async Task<int> DeleteMemberAsync(int id)
        {
            var deleteMember = await _imemberRepository.DeleteMember(id);

            if (deleteMember == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }

        public async Task<MemberResponseModel> UpdateMemberAsync(MemberRequestModel memberRequestModel, int id)
        {
         
            
            var getMember = await _imemberRepository.GetMemberById(id);

            if (getMember == null)
                throw new Exception("Member Not Found");

            //      var getMemberByUpdate =MemberBuilder.Build(memberRequestModel);

            //MemberBuilder memberBuilder = new MemberBuilder();
            
            //memberBuilder.Build(memberRequestModel);

             getMember.UpdateData(memberRequestModel.UserId, memberRequestModel.LocationId, memberRequestModel.WeightId, memberRequestModel.HeightId, memberRequestModel.Photo.FileName);
         
            var updateMember = await _imemberRepository.UpdateMember(getMember);
            var mapping = _mapper.Map<MemberResponseModel>(updateMember);
           
            return mapping;
        }
    }
}
