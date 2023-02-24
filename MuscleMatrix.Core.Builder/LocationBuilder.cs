using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Builder
{
    public class LocationBuilder
    {
        public static GymLocation Build(LocationRequestModel locationRequestModel)
        {
            return new GymLocation(locationRequestModel.LocationName);
        }
    }
}
