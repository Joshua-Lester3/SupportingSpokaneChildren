
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
    [Route("api/Resource")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ResourceController
        : BaseApiController<SupportingSpokaneChildren.Data.Models.Resource, ResourceParameter, ResourceResponse, SupportingSpokaneChildren.Data.AppDbContext>
    {
        public ResourceController(CrudContext<SupportingSpokaneChildren.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<SupportingSpokaneChildren.Data.Models.Resource>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<ResourceResponse>> Get(
            string id,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<ResourceResponse>> List(
            [FromQuery] ListParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            [FromQuery] FilterParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Consumes("application/x-www-form-urlencoded", "multipart/form-data")]
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<ResourceResponse>> Save(
            [FromForm] ResourceParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Resource> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("save")]
        [Consumes("application/json")]
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<ResourceResponse>> SaveFromJson(
            [FromBody] ResourceParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Resource> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [AllowAnonymous]
        public virtual Task<ItemResult<ResourceResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<ResourceResponse>> Delete(
            string id,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Resource> behaviors,
            IDataSource<SupportingSpokaneChildren.Data.Models.Resource> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
