
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
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<EventResponse>> Save(
            [FromForm] EventParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Event> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("save")]
        [Consumes("application/json")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public virtual Task<ItemResult<EventResponse>> Delete(
            string id,
            IBehaviors<SupportingSpokaneChildren.Data.Models.Event> behaviors,
            IDataSource<SupportingSpokaneChildren.Data.Models.Event> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: UploadImageAsync
        /// </summary>
        [HttpPost("UploadImage")]
        [HttpPost("UploadImageAsync")]
        [Authorize]
        [Consumes("application/x-www-form-urlencoded", "multipart/form-data")]
        public virtual async Task<ItemResult> UploadImage(
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] SupportingSpokaneChildren.Data.Blob.BlobStorageService service,
            [FromForm(Name = "id")] string id,
            Microsoft.AspNetCore.Http.IFormFile file)
        {
            var _params = new
            {
                Id = id,
                File = file == null ? null : new IntelliTect.Coalesce.Models.File { Name = file.FileName, ContentType = file.ContentType, Length = file.Length, Content = file.OpenReadStream() }
            };

            var dataSource = dataSourceFactory.GetDataSource<SupportingSpokaneChildren.Data.Models.Event, SupportingSpokaneChildren.Data.Models.Event>("Default");
            var itemResult = await dataSource.GetItemAsync(_params.Id, new DataSourceParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult(itemResult);
            }
            var item = itemResult.Object;
            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("UploadImageAsync"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return _validationResult;
            }

            var _methodResult = await item.UploadImageAsync(
                Db,
                service,
                _params.File
            );
            var _result = new ItemResult(_methodResult);
            return _result;
        }

        public class EventUploadImageParameters
        {
            public string Id { get; set; }
            public IntelliTect.Coalesce.Models.FileParameter File { get; set; }
        }

        /// <summary>
        /// Method: UploadImageAsync
        /// </summary>
        [HttpPost("UploadImage")]
        [HttpPost("UploadImageAsync")]
        [Authorize]
        [Consumes("application/json")]
        public virtual async Task<ItemResult> UploadImage(
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] SupportingSpokaneChildren.Data.Blob.BlobStorageService service,
            [FromBody] EventUploadImageParameters _params
        )
        {
            var dataSource = dataSourceFactory.GetDataSource<SupportingSpokaneChildren.Data.Models.Event, SupportingSpokaneChildren.Data.Models.Event>("Default");
            var itemResult = await dataSource.GetItemAsync(_params.Id, new DataSourceParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult(itemResult);
            }
            var item = itemResult.Object;
            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("UploadImageAsync"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return _validationResult;
            }

            var _methodResult = await item.UploadImageAsync(
                Db,
                service,
                _params.File
            );
            var _result = new ItemResult(_methodResult);
            return _result;
        }

        /// <summary>
        /// Method: UpdateImageUri
        /// </summary>
        [HttpPost("UpdateImageUri")]
        [Authorize]
        [Consumes("application/x-www-form-urlencoded", "multipart/form-data")]
        public virtual async Task<ItemResult<string>> UpdateImageUri(
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] SupportingSpokaneChildren.Data.Blob.BlobStorageService service,
            [FromForm(Name = "id")] string id)
        {
            var _params = new
            {
                Id = id
            };

            var dataSource = dataSourceFactory.GetDataSource<SupportingSpokaneChildren.Data.Models.Event, SupportingSpokaneChildren.Data.Models.Event>("Default");
            var itemResult = await dataSource.GetItemAsync(_params.Id, new DataSourceParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult<string>(itemResult);
            }
            var item = itemResult.Object;
            var _methodResult = item.UpdateImageUri(
                Db,
                service
            );
            var _result = new ItemResult<string>();
            _result.Object = _methodResult;
            return _result;
        }

        public class EventUpdateImageUriParameters
        {
            public string Id { get; set; }
        }

        /// <summary>
        /// Method: UpdateImageUri
        /// </summary>
        [HttpPost("UpdateImageUri")]
        [Authorize]
        [Consumes("application/json")]
        public virtual async Task<ItemResult<string>> UpdateImageUri(
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] SupportingSpokaneChildren.Data.Blob.BlobStorageService service,
            [FromBody] EventUpdateImageUriParameters _params
        )
        {
            var dataSource = dataSourceFactory.GetDataSource<SupportingSpokaneChildren.Data.Models.Event, SupportingSpokaneChildren.Data.Models.Event>("Default");
            var itemResult = await dataSource.GetItemAsync(_params.Id, new DataSourceParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult<string>(itemResult);
            }
            var item = itemResult.Object;
            var _methodResult = item.UpdateImageUri(
                Db,
                service
            );
            var _result = new ItemResult<string>();
            _result.Object = _methodResult;
            return _result;
        }
    }
}
