using Ijora.Domain.Interactions;
using Ijora.Domain.Interactions.Complexes.Enums;
using Ijora.Domain.Interactions.Complexes.Models;
using Ijora.Storage.Entity;

namespace Ijora.Data.Mappers
{
    public static class ComplexesMapper
    {
        public static ComplexModel ToDomainModel(this ComplexEntity e)
        {
            return new ComplexModel()
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                BuildYear = e.BuildYear,
                CompletionYear = e.CompletionYear,
                CreatedAt = e.CreatedAt,
                Description = e.Description,
                Developer = e.Developer,
                UpdatedAt = e.UpdatedAt,
                ImageUrls = e.ImageUrls.Split(",").ToList(),
                IsCompleted = e.IsCompleted,
                PublisherUserId = e.PublisherUserId,
                ConstructionStatus = (ConstructionStatus)EnumExtensions.ConvertToEnum<ConstructionStatus>(e.ConstructionStatus),
            };
        }
    }
}
