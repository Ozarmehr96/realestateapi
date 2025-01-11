using Ijora.Domain.Interactions;
using Ijora.Domain.Interactions.RealEstates.Models;
using Ijora.Storage.Entity;
using System.Drawing;

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
                PublicationDate = e.PublicationDate,
                PublisherPhoneNumber = e.PublisherPhoneNumber,
                WindowView = EnumExtensions.ConvertToEnum<WindowViewType>(e.WindowView),
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
                Renovation = EnumExtensions.ConvertToEnum<Renovation>(e.Renovation),
                KitchenArea = e.KitchenArea,
                LivingArea = e.LivingArea,
                WallMaterial = EnumExtensions.ConvertToEnum<WallMaterial>(e.WallMaterial),
                IsInGatedCommunity = e.IsInGatedCommunity,
                HasElevator = e.HasElevator,
                AllowsChildren = e.AllowsChildren,
                AllowsPets = e.AllowsPets,
                Description = e.Description,
                ImageUrls = e.ImageUrls.Split(",").ToList(),
                BathroomCount = e.BathroomCount,
                CargoElevatorCount = e.CargoElevatorCount,
                CeilingHeight = e.CeilingHeight,
                HeatingType = EnumExtensions.ConvertToEnum<HeatingType>(e.HeatingType),
                OwnerCount = e.OwnerCount,
                OwnershipType = EnumExtensions.ConvertToEnum<OwnershipType>(e.OwnershipType),
                OwnershipYears = e.OwnershipYears,
                PropertyCondition = EnumExtensions.ConvertToEnum<PropertyCondition>(e.PropertyCondition)
            };
        }

        public static RealEstateEntity ToDatabaseEntity(this RealEstateModel e)
        {
            return new RealEstateEntity()
            {
                Id = e.Id,
                UserId = e.UserId,
                PublicationDate = e.PublicationDate,
                PublisherPhoneNumber = e.PublisherPhoneNumber,
                WindowView = e.WindowView?.ToString(),
                PropertyUsageType = (PropertyUsageType)EnumExtensions.ConvertToEnum<PropertyUsageType>(e.PropertyUsageType),
                SquareMeters = e.SquareMeters,
                Price = e.Price,
                PropertyType = e.PropertyType?.ToString(),
                Address = e.Address,
                RoomCount = e.RoomCount,
                Floor = e.RoomCount,
                TotalFloors = e.TotalFloors,
                HasParking = e.HasParking,
                HasBalcony = e.HasBalcony,
                YearBuilt = e.YearBuilt,
                IsFurnished = e.IsFurnished,
                Renovation = e.Renovation?.ToString(),
                KitchenArea = e.KitchenArea,
                LivingArea = e.LivingArea,
                WallMaterial = e.WallMaterial?.ToString(),
                IsInGatedCommunity = e.IsInGatedCommunity,
                HasElevator = e.HasElevator,
                AllowsChildren = e.AllowsChildren,
                AllowsPets = e.AllowsPets,
                Description = e.Description,
                ImageUrls = String.Join(",", e.ImageUrls),
                BathroomCount = e.BathroomCount,
                CargoElevatorCount = e.CargoElevatorCount,
                CeilingHeight = e.CeilingHeight,
                HeatingType = e.HeatingType?.ToString(),
                OwnerCount = e.OwnerCount,
                OwnershipType = e.OwnershipType?.ToString(),
                OwnershipYears = e.OwnershipYears,
                PropertyCondition = e.PropertyCondition?.ToString()
            };
        }
    }
}
