using Ijora.Domain.Interactions;
using Ijora.Domain.Interactions.RealEstates.Models;
using Ijora.Storage.Entity;

namespace Ijora.Data.Mappers
{
    public static class RealEstateMapper
    {
        public static RealEstateModel ToDomainModel(this RealEstateEntity e)
        {
            return new RealEstateModel()
            {
                Id = e.Id,
                UserId = e.UserId,
                CreatedAt = e.CreatedAt,
                PropertyUsageType = (PropertyUsageType)EnumExtensions.ConvertToEnum<PropertyUsageType>(e.PropertyUsageType),
                SquareMeters = e.SquareMeters,
                Price = e.Price,
                PropertyType = (PropertyType)EnumExtensions.ConvertToEnum<PropertyType>(e.PropertyType),
                Address = e.Address,
                RoomCount = e.RoomCount,
                Floor = e.RoomCount,
                TotalFloors = e.TotalFloors,
                HasParking = e.HasParking,
                HasBalcony = e.HasBalcony,
                YearBuilt = e.YearBuilt,
                IsFurnished = e.IsFurnished,
                OwnershipType = (OwnershipType)EnumExtensions.ConvertToEnum<OwnershipType>(e.OwnershipType),
                Renovation = (Renovation)EnumExtensions.ConvertToEnum<Renovation>(e.Renovation),
                KitchenArea = e.KitchenArea,
                LivingArea = e.LivingArea,
                LandArea = e.LandArea,
                WallMaterial = (WallMaterial)EnumExtensions.ConvertToEnum<WallMaterial>(e.WallMaterial),
                IsInGatedCommunity = e.IsInGatedCommunity,
                HasElevator = e.HasElevator,
                AllowsChildren = e.AllowsChildren,
                AllowsPets = e.AllowsPets,
                Description = e.Description,
                ImageUrls = e.ImageUrls.Split(",").ToList()
            };
        }

        public static RealEstateEntity ToDatabaseEntity(this RealEstateModel e)
        {
            return new RealEstateEntity()
            {
                Id = e.Id,
                UserId = e.UserId,
                CreatedAt = e.CreatedAt,
                PropertyUsageType = e.PropertyUsageType.ToString(),
                SquareMeters = e.SquareMeters,
                Price = e.Price,
                PropertyType = e.PropertyType.ToString(),
                Address = e.Address,
                RoomCount = e.RoomCount,
                Floor = e.RoomCount,
                TotalFloors = e.TotalFloors,
                HasParking = e.HasParking,
                HasBalcony = e.HasBalcony,
                YearBuilt = e.YearBuilt,
                IsFurnished = e.IsFurnished,
                OwnershipType = e.OwnershipType.ToString(),
                Renovation = e.Renovation.ToString(),
                KitchenArea = e.KitchenArea,
                LivingArea = e.LivingArea,
                LandArea = e.LandArea,
                WallMaterial = e.WallMaterial.ToString(),
                IsInGatedCommunity = e.IsInGatedCommunity,
                HasElevator = e.HasElevator,
                AllowsChildren = e.AllowsChildren,
                AllowsPets = e.AllowsPets,
                Description = e.Description,
                ImageUrls = String.Join(",", e.ImageUrls)
            };
        }
    }
}
