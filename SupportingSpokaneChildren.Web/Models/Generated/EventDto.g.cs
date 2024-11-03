using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SupportingSpokaneChildren.Web.Models
{
    public partial class EventParameter : GeneratedParameterDto<SupportingSpokaneChildren.Data.Models.Event>
    {
        public EventParameter() { }

        private string _EventId;
        private string _EventName;
        private string _Description;
        private System.DateTimeOffset? _DateTime;
        private string _Location;
        private string _Link;
        private string _ImageUri;

        public string EventId
        {
            get => _EventId;
            set { _EventId = value; Changed(nameof(EventId)); }
        }
        public string EventName
        {
            get => _EventName;
            set { _EventName = value; Changed(nameof(EventName)); }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; Changed(nameof(Description)); }
        }
        public System.DateTimeOffset? DateTime
        {
            get => _DateTime;
            set { _DateTime = value; Changed(nameof(DateTime)); }
        }
        public string Location
        {
            get => _Location;
            set { _Location = value; Changed(nameof(Location)); }
        }
        public string Link
        {
            get => _Link;
            set { _Link = value; Changed(nameof(Link)); }
        }
        public string ImageUri
        {
            get => _ImageUri;
            set { _ImageUri = value; Changed(nameof(ImageUri)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SupportingSpokaneChildren.Data.Models.Event entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(EventName))) entity.EventName = EventName;
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(DateTime))) entity.DateTime = (DateTime ?? entity.DateTime);
            if (ShouldMapTo(nameof(Location))) entity.Location = Location;
            if (ShouldMapTo(nameof(Link))) entity.Link = Link;
            if (ShouldMapTo(nameof(ImageUri))) entity.ImageUri = ImageUri;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override SupportingSpokaneChildren.Data.Models.Event MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new SupportingSpokaneChildren.Data.Models.Event()
            {
                EventId = EventId,
                EventName = EventName,
                Location = Location,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(DateTime))) entity.DateTime = (DateTime ?? entity.DateTime);
            if (ShouldMapTo(nameof(Link))) entity.Link = Link;
            if (ShouldMapTo(nameof(ImageUri))) entity.ImageUri = ImageUri;

            return entity;
        }
    }

    public partial class EventResponse : GeneratedResponseDto<SupportingSpokaneChildren.Data.Models.Event>
    {
        public EventResponse() { }

        public string EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public System.DateTimeOffset? DateTime { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public string ImageUri { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SupportingSpokaneChildren.Data.Models.Event obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.EventId = obj.EventId;
            this.EventName = obj.EventName;
            this.Description = obj.Description;
            this.DateTime = obj.DateTime;
            this.Location = obj.Location;
            this.Link = obj.Link;
            this.ImageUri = obj.ImageUri;
        }
    }
}
