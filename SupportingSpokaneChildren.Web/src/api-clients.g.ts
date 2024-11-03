import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { ModelApiClient, ServiceApiClient } from 'coalesce-vue/lib/api-client'
import type { AxiosPromise, AxiosRequestConfig, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'

export class AnnouncementApiClient extends ModelApiClient<$models.Announcement> {
  constructor() { super($metadata.Announcement) }
  public uploadImage(id: string | null, file: File | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.uploadImage
    const $params =  {
      id,
      file,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public updateImageUri(id: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<string>> {
    const $method = this.$metadata.methods.updateImageUri
    const $params =  {
      id,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class AuditLogApiClient extends ModelApiClient<$models.AuditLog> {
  constructor() { super($metadata.AuditLog) }
}


export class AuditLogPropertyApiClient extends ModelApiClient<$models.AuditLogProperty> {
  constructor() { super($metadata.AuditLogProperty) }
}


export class EventApiClient extends ModelApiClient<$models.Event> {
  constructor() { super($metadata.Event) }
  public uploadImage(id: string | null, file: File | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.uploadImage
    const $params =  {
      id,
      file,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public updateImageUri(id: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<string>> {
    const $method = this.$metadata.methods.updateImageUri
    const $params =  {
      id,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class ResourceApiClient extends ModelApiClient<$models.Resource> {
  constructor() { super($metadata.Resource) }
}


export class ResourceCategoryApiClient extends ModelApiClient<$models.ResourceCategory> {
  constructor() { super($metadata.ResourceCategory) }
}


export class RoleApiClient extends ModelApiClient<$models.Role> {
  constructor() { super($metadata.Role) }
}


export class UserApiClient extends ModelApiClient<$models.User> {
  constructor() { super($metadata.User) }
  public getPhoto(id: string | null, etag?: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<File>> {
    const $method = this.$metadata.methods.getPhoto
    const $params =  {
      id,
      etag,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class UserRoleApiClient extends ModelApiClient<$models.UserRole> {
  constructor() { super($metadata.UserRole) }
}


export class SecurityServiceApiClient extends ServiceApiClient<typeof $metadata.SecurityService> {
  constructor() { super($metadata.SecurityService) }
  public whoAmI($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.UserInfo>> {
    const $method = this.$metadata.methods.whoAmI
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
}


