
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
    [Route("api/ResourceCategory")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ResourceCategoryController
        : BaseApiController<SupportingSpokaneChildren.Data.Models.ResourceCategory, ResourceCategoryParameter, ResourceCategoryResponse, SupportingSpokaneChildren.Data.AppDbContext>
    {
        public ResourceCategoryController(CrudContext<SupportingSpokaneChildren.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<SupportingSpokaneChildren.Data.Models.ResourceCategory>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<ResourceCategoryResponse>> Get(
            string id,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<ResourceCategoryResponse>> List(
            [FromQuery] ListParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            [FromQuery] FilterParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Consumes("application/x-www-form-urlencoded", "multipart/form-data")]
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<ResourceCategoryResponse>> Save(
            [FromForm] ResourceCategoryParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.ResourceCategory> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("save")]
        [Consumes("application/json")]
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<ResourceCategoryResponse>> SaveFromJson(
            [FromBody] ResourceCategoryParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.ResourceCategory> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [AllowAnonymous]
        public virtual Task<ItemResult<ResourceCategoryResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<ResourceCategoryResponse>> Delete(
            string id,
            IBehaviors<SupportingSpokaneChildren.Data.Models.ResourceCategory> behaviors,
            IDataSource<SupportingSpokaneChildren.Data.Models.ResourceCategory> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
