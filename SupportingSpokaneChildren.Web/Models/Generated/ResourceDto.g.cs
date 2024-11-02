using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SupportingSpokaneChildren.Web.Models
{
    public partial class ResourceParameter : GeneratedParameterDto<SupportingSpokaneChildren.Data.Models.Resource>
    {
        public ResourceParameter() { }

        private string _ResourceId;
        private string _Name;
        private string _Website;
        private string _Phone;
        private string _Address;
        private string _Email;
        private string _ResourceCategoryId;

        public string ResourceId
        {
            get => _ResourceId;
            set { _ResourceId = value; Changed(nameof(ResourceId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Website
        {
            get => _Website;
            set { _Website = value; Changed(nameof(Website)); }
        }
        public string Phone
        {
            get => _Phone;
            set { _Phone = value; Changed(nameof(Phone)); }
        }
        public string Address
        {
            get => _Address;
            set { _Address = value; Changed(nameof(Address)); }
        }
        public string Email
        {
            get => _Email;
            set { _Email = value; Changed(nameof(Email)); }
        }
        public string ResourceCategoryId
        {
            get => _ResourceCategoryId;
            set { _ResourceCategoryId = value; Changed(nameof(ResourceCategoryId)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SupportingSpokaneChildren.Data.Models.Resource entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Website))) entity.Website = Website;
            if (ShouldMapTo(nameof(Phone))) entity.Phone = Phone;
            if (ShouldMapTo(nameof(Address))) entity.Address = Address;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
            if (ShouldMapTo(nameof(ResourceCategoryId))) entity.ResourceCategoryId = ResourceCategoryId;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override SupportingSpokaneChildren.Data.Models.Resource MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new SupportingSpokaneChildren.Data.Models.Resource()
            {
                ResourceId = ResourceId,
                Name = Name,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(Website))) entity.Website = Website;
            if (ShouldMapTo(nameof(Phone))) entity.Phone = Phone;
            if (ShouldMapTo(nameof(Address))) entity.Address = Address;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
            if (ShouldMapTo(nameof(ResourceCategoryId))) entity.ResourceCategoryId = ResourceCategoryId;

            return entity;
        }
    }

    public partial class ResourceResponse : GeneratedResponseDto<SupportingSpokaneChildren.Data.Models.Resource>
    {
        public ResourceResponse() { }

        public string ResourceId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ResourceCategoryId { get; set; }
        public SupportingSpokaneChildren.Web.Models.ResourceCategoryResponse ResourceCategory { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SupportingSpokaneChildren.Data.Models.Resource obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.ResourceId = obj.ResourceId;
            this.Name = obj.Name;
            this.Website = obj.Website;
            this.Phone = obj.Phone;
            this.Address = obj.Address;
            this.Email = obj.Email;
            this.ResourceCategoryId = obj.ResourceCategoryId;
            if (tree == null || tree[nameof(this.ResourceCategory)] != null)
                this.ResourceCategory = obj.ResourceCategory.MapToDto<SupportingSpokaneChildren.Data.Models.ResourceCategory, ResourceCategoryResponse>(context, tree?[nameof(this.ResourceCategory)]);

        }
    }
}
