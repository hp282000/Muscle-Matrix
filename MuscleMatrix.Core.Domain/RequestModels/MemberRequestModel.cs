using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.RequestModels
{
    public class MemberRequestModel
    {
       
        public int HeightId { get; set; }

        public int WeightId { get; set; }

        public int LocationId { get; set; }
        
        public int UserId { get; set; }
        public IFormFile Photo { get; set; }

    }
}
