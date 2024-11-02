
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportingSpokaneChildren.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SupportingSpokaneChildren.Web.Api
{
    [Route("api/Event")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class EventController
        : BaseApiController<SupportingSpokaneChildren.Data.Models.Event, EventParameter, EventResponse, SupportingSpokaneChildren.Data.AppDbContext>
    {
        public EventController(CrudContext<SupportingSpokaneChildren.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<SupportingSpokaneChildren.Data.Models.Event>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<EventResponse>> Get(
            string id,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<EventResponse>> List(
            [FromQuery] ListParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            [FromQuery] FilterParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Consumes("application/x-www-form-urlencoded", "multipart/form-data")]
        [Authorize(Roles = "Moderator")]
        public virtual Task<ItemResult<EventResponse>> Save(
            [FromForm] EventParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Event> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("save")]
        [Consumes("application/json")]
        [Authorize(Roles = "Moderator")]
        public virtual Task<ItemResult<EventResponse>> SaveFromJson(
            [FromBody] EventParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Event> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [AllowAnonymous]
        public virtual Task<ItemResult<EventResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize(Roles = "Moderator")]
        public virtual Task<ItemResult<EventResponse>> Delete(
            string id,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Event> behaviors,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
