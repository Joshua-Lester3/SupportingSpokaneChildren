using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SupportingSpokaneChildren.Web.Models
{
    public partial class ResourceCategoryParameter : GeneratedParameterDto<SupportingSpokaneChildren.Data.Models.ResourceCategory>
    {
        public ResourceCategoryParameter() { }

        private string _ResourceCategoryId;
        private string _CategoryName;

        public string ResourceCategoryId
        {
            get => _ResourceCategoryId;
            set { _ResourceCategoryId = value; Changed(nameof(ResourceCategoryId)); }
        }
        public string CategoryName
        {
            get => _CategoryName;
            set { _CategoryName = value; Changed(nameof(CategoryName)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SupportingSpokaneChildren.Data.Models.ResourceCategory entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(CategoryName))) entity.CategoryName = CategoryName;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override SupportingSpokaneChildren.Data.Models.ResourceCategory MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new SupportingSpokaneChildren.Data.Models.ResourceCategory()
            {
                ResourceCategoryId = ResourceCategoryId,
                CategoryName = CategoryName,
            };

            if (OnUpdate(entity, context)) return entity;

            return entity;
        }
    }

    public partial class ResourceCategoryResponse : GeneratedResponseDto<SupportingSpokaneChildren.Data.Models.ResourceCategory>
    {
        public ResourceCategoryResponse() { }

        public string ResourceCategoryId { get; set; }
        public string CategoryName { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SupportingSpokaneChildren.Data.Models.ResourceCategory obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.ResourceCategoryId = obj.ResourceCategoryId;
            this.CategoryName = obj.CategoryName;
        }
    }
}
