using Ijora.Domain.Interactions;
using Ijora.Domain.Interactions.Complexes.Enums;
using Ijora.Domain.Interactions.Complexes.Models;
using Ijora.Storage.Entity;

namespace Ijora.Data.Mappers
{
    public static class ComplexesMapper
    {
        public static ComplexEntity ToDatabaseEntity(this ComplexModel complex)
        {
            return new ComplexEntity()
            {
                Id = complex.Id,
                Name = complex.Name,
                Address = complex.Address,
                BuildYear = complex.BuildYear,
                CompletionYear = complex.CompletionYear,
                CreatedAt = complex.CreatedAt,
                Description = complex.Description,
                Developer = complex.Developer,
                UpdatedAt = complex.UpdatedAt,
                ImageUrls = String.Join(",", complex.ImageUrls),
                IsCompleted = complex.IsCompleted,
                PublisherUserId = complex.PublisherUserId,
                ConstructionStatus = complex.ConstructionStatus.ToString(),
            };
        }

        public static ComplexModel ToDomainModel(this ComplexEntity complex)
        {
            return new ComplexModel()
            {
                Id = complex.Id,
                Name = complex.Name,
                Address = complex.Address,
                BuildYear = complex.BuildYear,
                CompletionYear = complex.CompletionYear,
                CreatedAt = complex.CreatedAt,
                Description = complex.Description,
                Developer = complex.Developer,
                UpdatedAt = complex.UpdatedAt,
                ImageUrls = complex.ImageUrls.Split(",").ToList(),
                IsCompleted = complex.IsCompleted,
                PublisherUserId = complex.PublisherUserId,
                ConstructionStatus = (ConstructionStatus)EnumExtensions.ConvertToEnum<ConstructionStatus>(complex.ConstructionStatus),
            };
        }
    }
}
