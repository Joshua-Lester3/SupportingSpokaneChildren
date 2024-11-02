using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SupportingSpokaneChildren.Web.Models
{
    public partial class AnnouncementParameter : GeneratedParameterDto<SupportingSpokaneChildren.Data.Models.Announcement>
    {
        public AnnouncementParameter() { }

        private string _AnnouncementId;
        private string _Title;
        private string _Description;
        private string _ImageUri;

        public string AnnouncementId
        {
            get => _AnnouncementId;
            set { _AnnouncementId = value; Changed(nameof(AnnouncementId)); }
        }
        public string Title
        {
            get => _Title;
            set { _Title = value; Changed(nameof(Title)); }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; Changed(nameof(Description)); }
        }
        public string ImageUri
        {
            get => _ImageUri;
            set { _ImageUri = value; Changed(nameof(ImageUri)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SupportingSpokaneChildren.Data.Models.Announcement entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Title))) entity.Title = Title;
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(ImageUri))) entity.ImageUri = ImageUri;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override SupportingSpokaneChildren.Data.Models.Announcement MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new SupportingSpokaneChildren.Data.Models.Announcement()
            {
                AnnouncementId = AnnouncementId,
                Title = Title,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(ImageUri))) entity.ImageUri = ImageUri;

            return entity;
        }
    }

    public partial class AnnouncementResponse : GeneratedResponseDto<SupportingSpokaneChildren.Data.Models.Announcement>
    {
        public AnnouncementResponse() { }

        public string AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime? DatePosted { get; set; }
        public string ImageUri { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SupportingSpokaneChildren.Data.Models.Announcement obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.AnnouncementId = obj.AnnouncementId;
            this.Title = obj.Title;
            this.Description = obj.Description;
            this.DatePosted = obj.DatePosted;
            this.ImageUri = obj.ImageUri;
        }
    }
}
