import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ViewModelCollection, ServiceViewModel, type DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface AnnouncementViewModel extends $models.Announcement {
  announcementId: string | null;
  title: string | null;
  description: string | null;
  datePosted: Date | null;
  imageUri: string | null;
}
export class AnnouncementViewModel extends ViewModel<$models.Announcement, $apiClients.AnnouncementApiClient, string> implements $models.Announcement  {
  static DataSources = $models.Announcement.DataSources;
  
  public get uploadImage() {
    const uploadImage = this.$apiClient.$makeCaller(
      this.$metadata.methods.uploadImage,
      (c, file: File | null) => c.uploadImage(this.$primaryKey, file),
      () => ({file: null as File | null, }),
      (c, args) => c.uploadImage(this.$primaryKey, args.file))
    
    Object.defineProperty(this, 'uploadImage', {value: uploadImage});
    return uploadImage
  }
  
  public get updateImageUri() {
    const updateImageUri = this.$apiClient.$makeCaller(
      this.$metadata.methods.updateImageUri,
      (c) => c.updateImageUri(this.$primaryKey),
      () => ({}),
      (c, args) => c.updateImageUri(this.$primaryKey))
    
    Object.defineProperty(this, 'updateImageUri', {value: updateImageUri});
    return updateImageUri
  }
  
  constructor(initialData?: DeepPartial<$models.Announcement> | null) {
    super($metadata.Announcement, new $apiClients.AnnouncementApiClient(), initialData)
  }
}
defineProps(AnnouncementViewModel, $metadata.Announcement)

export class AnnouncementListViewModel extends ListViewModel<$models.Announcement, $apiClients.AnnouncementApiClient, AnnouncementViewModel> {
  static DataSources = $models.Announcement.DataSources;
  
  constructor() {
    super($metadata.Announcement, new $apiClients.AnnouncementApiClient())
  }
}


export interface AuditLogViewModel extends $models.AuditLog {
  userId: string | null;
  get user(): UserViewModel | null;
  set user(value: UserViewModel | $models.User | null);
  id: number | null;
  type: string | null;
  keyValue: string | null;
  description: string | null;
  state: $models.AuditEntryState | null;
  date: Date | null;
  get properties(): ViewModelCollection<AuditLogPropertyViewModel, $models.AuditLogProperty>;
  set properties(value: (AuditLogPropertyViewModel | $models.AuditLogProperty)[] | null);
  clientIp: string | null;
  referrer: string | null;
  endpoint: string | null;
}
export class AuditLogViewModel extends ViewModel<$models.AuditLog, $apiClients.AuditLogApiClient, number> implements $models.AuditLog  {
  
  
  public addToProperties(initialData?: DeepPartial<$models.AuditLogProperty> | null) {
    return this.$addChild('properties', initialData) as AuditLogPropertyViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.AuditLog> | null) {
    super($metadata.AuditLog, new $apiClients.AuditLogApiClient(), initialData)
  }
}
defineProps(AuditLogViewModel, $metadata.AuditLog)

export class AuditLogListViewModel extends ListViewModel<$models.AuditLog, $apiClients.AuditLogApiClient, AuditLogViewModel> {
  
  constructor() {
    super($metadata.AuditLog, new $apiClients.AuditLogApiClient())
  }
}


export interface AuditLogPropertyViewModel extends $models.AuditLogProperty {
  id: number | null;
  parentId: number | null;
  propertyName: string | null;
  oldValue: string | null;
  oldValueDescription: string | null;
  newValue: string | null;
  newValueDescription: string | null;
}
export class AuditLogPropertyViewModel extends ViewModel<$models.AuditLogProperty, $apiClients.AuditLogPropertyApiClient, number> implements $models.AuditLogProperty  {
  
  constructor(initialData?: DeepPartial<$models.AuditLogProperty> | null) {
    super($metadata.AuditLogProperty, new $apiClients.AuditLogPropertyApiClient(), initialData)
  }
}
defineProps(AuditLogPropertyViewModel, $metadata.AuditLogProperty)

export class AuditLogPropertyListViewModel extends ListViewModel<$models.AuditLogProperty, $apiClients.AuditLogPropertyApiClient, AuditLogPropertyViewModel> {
  
  constructor() {
    super($metadata.AuditLogProperty, new $apiClients.AuditLogPropertyApiClient())
  }
}


export interface EventViewModel extends $models.Event {
  eventId: string | null;
  eventName: string | null;
  description: string | null;
  dateTime: Date | null;
  location: string | null;
  link: string | null;
  imageUri: string | null;
}
export class EventViewModel extends ViewModel<$models.Event, $apiClients.EventApiClient, string> implements $models.Event  {
  static DataSources = $models.Event.DataSources;
  
  public get uploadImage() {
    const uploadImage = this.$apiClient.$makeCaller(
      this.$metadata.methods.uploadImage,
      (c, file: File | null) => c.uploadImage(this.$primaryKey, file),
      () => ({file: null as File | null, }),
      (c, args) => c.uploadImage(this.$primaryKey, args.file))
    
    Object.defineProperty(this, 'uploadImage', {value: uploadImage});
    return uploadImage
  }
  
  public get updateImageUri() {
    const updateImageUri = this.$apiClient.$makeCaller(
      this.$metadata.methods.updateImageUri,
      (c) => c.updateImageUri(this.$primaryKey),
      () => ({}),
      (c, args) => c.updateImageUri(this.$primaryKey))
    
    Object.defineProperty(this, 'updateImageUri', {value: updateImageUri});
    return updateImageUri
  }
  
  constructor(initialData?: DeepPartial<$models.Event> | null) {
    super($metadata.Event, new $apiClients.EventApiClient(), initialData)
  }
}
defineProps(EventViewModel, $metadata.Event)

export class EventListViewModel extends ListViewModel<$models.Event, $apiClients.EventApiClient, EventViewModel> {
  static DataSources = $models.Event.DataSources;
  
  constructor() {
    super($metadata.Event, new $apiClients.EventApiClient())
  }
}


export interface ResourceViewModel extends $models.Resource {
  resourceId: string | null;
  name: string | null;
  website: string | null;
  phone: string | null;
  address: string | null;
  email: string | null;
  resourceCategoryId: string | null;
  get resourceCategory(): ResourceCategoryViewModel | null;
  set resourceCategory(value: ResourceCategoryViewModel | $models.ResourceCategory | null);
}
export class ResourceViewModel extends ViewModel<$models.Resource, $apiClients.ResourceApiClient, string> implements $models.Resource  {
  
  constructor(initialData?: DeepPartial<$models.Resource> | null) {
    super($metadata.Resource, new $apiClients.ResourceApiClient(), initialData)
  }
}
defineProps(ResourceViewModel, $metadata.Resource)

export class ResourceListViewModel extends ListViewModel<$models.Resource, $apiClients.ResourceApiClient, ResourceViewModel> {
  
  constructor() {
    super($metadata.Resource, new $apiClients.ResourceApiClient())
  }
}


export interface ResourceCategoryViewModel extends $models.ResourceCategory {
  resourceCategoryId: string | null;
  categoryName: string | null;
}
export class ResourceCategoryViewModel extends ViewModel<$models.ResourceCategory, $apiClients.ResourceCategoryApiClient, string> implements $models.ResourceCategory  {
  
  constructor(initialData?: DeepPartial<$models.ResourceCategory> | null) {
    super($metadata.ResourceCategory, new $apiClients.ResourceCategoryApiClient(), initialData)
  }
}
defineProps(ResourceCategoryViewModel, $metadata.ResourceCategory)

export class ResourceCategoryListViewModel extends ListViewModel<$models.ResourceCategory, $apiClients.ResourceCategoryApiClient, ResourceCategoryViewModel> {
  
  constructor() {
    super($metadata.ResourceCategory, new $apiClients.ResourceCategoryApiClient())
  }
}


export interface RoleViewModel extends $models.Role {
  name: string | null;
  permissions: $models.Permission[] | null;
  id: string | null;
}
export class RoleViewModel extends ViewModel<$models.Role, $apiClients.RoleApiClient, string> implements $models.Role  {
  
  constructor(initialData?: DeepPartial<$models.Role> | null) {
    super($metadata.Role, new $apiClients.RoleApiClient(), initialData)
  }
}
defineProps(RoleViewModel, $metadata.Role)

export class RoleListViewModel extends ListViewModel<$models.Role, $apiClients.RoleApiClient, RoleViewModel> {
  
  constructor() {
    super($metadata.Role, new $apiClients.RoleApiClient())
  }
}


export interface UserViewModel extends $models.User {
  fullName: string | null;
  userName: string | null;
  email: string | null;
  emailConfirmed: boolean | null;
  photoHash: string | null;
  
  /** If set, the user will be blocked from signing in until this date. */
  lockoutEnd: Date | null;
  
  /** If enabled, the user can be locked out. */
  lockoutEnabled: boolean | null;
  get userRoles(): ViewModelCollection<UserRoleViewModel, $models.UserRole>;
  set userRoles(value: (UserRoleViewModel | $models.UserRole)[] | null);
  roleNames: string[] | null;
  id: string | null;
}
export class UserViewModel extends ViewModel<$models.User, $apiClients.UserApiClient, string> implements $models.User  {
  static DataSources = $models.User.DataSources;
  
  
  public addToUserRoles(initialData?: DeepPartial<$models.UserRole> | null) {
    return this.$addChild('userRoles', initialData) as UserRoleViewModel
  }
  
  get roles(): ReadonlyArray<RoleViewModel> {
    return (this.userRoles || []).map($ => $.role!).filter($ => $)
  }
  
  public get getPhoto() {
    const getPhoto = this.$apiClient.$makeCaller(
      this.$metadata.methods.getPhoto,
      (c) => c.getPhoto(this.$primaryKey, this.photoHash),
      () => ({}),
      (c, args) => c.getPhoto(this.$primaryKey, this.photoHash))
    
    Object.defineProperty(this, 'getPhoto', {value: getPhoto});
    return getPhoto
  }
  
  constructor(initialData?: DeepPartial<$models.User> | null) {
    super($metadata.User, new $apiClients.UserApiClient(), initialData)
  }
}
defineProps(UserViewModel, $metadata.User)

export class UserListViewModel extends ListViewModel<$models.User, $apiClients.UserApiClient, UserViewModel> {
  static DataSources = $models.User.DataSources;
  
  constructor() {
    super($metadata.User, new $apiClients.UserApiClient())
  }
}


export interface UserRoleViewModel extends $models.UserRole {
  id: string | null;
  get user(): UserViewModel | null;
  set user(value: UserViewModel | $models.User | null);
  get role(): RoleViewModel | null;
  set role(value: RoleViewModel | $models.Role | null);
  userId: string | null;
  roleId: string | null;
}
export class UserRoleViewModel extends ViewModel<$models.UserRole, $apiClients.UserRoleApiClient, string> implements $models.UserRole  {
  static DataSources = $models.UserRole.DataSources;
  
  constructor(initialData?: DeepPartial<$models.UserRole> | null) {
    super($metadata.UserRole, new $apiClients.UserRoleApiClient(), initialData)
  }
}
defineProps(UserRoleViewModel, $metadata.UserRole)

export class UserRoleListViewModel extends ListViewModel<$models.UserRole, $apiClients.UserRoleApiClient, UserRoleViewModel> {
  static DataSources = $models.UserRole.DataSources;
  
  constructor() {
    super($metadata.UserRole, new $apiClients.UserRoleApiClient())
  }
}


export class SecurityServiceViewModel extends ServiceViewModel<typeof $metadata.SecurityService, $apiClients.SecurityServiceApiClient> {
  
  public get whoAmI() {
    const whoAmI = this.$apiClient.$makeCaller(
      this.$metadata.methods.whoAmI,
      (c) => c.whoAmI(),
      () => ({}),
      (c, args) => c.whoAmI())
    
    Object.defineProperty(this, 'whoAmI', {value: whoAmI});
    return whoAmI
  }
  
  constructor() {
    super($metadata.SecurityService, new $apiClients.SecurityServiceApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Announcement: AnnouncementViewModel,
  AuditLog: AuditLogViewModel,
  AuditLogProperty: AuditLogPropertyViewModel,
  Event: EventViewModel,
  Resource: ResourceViewModel,
  ResourceCategory: ResourceCategoryViewModel,
  Role: RoleViewModel,
  User: UserViewModel,
  UserRole: UserRoleViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Announcement: AnnouncementListViewModel,
  AuditLog: AuditLogListViewModel,
  AuditLogProperty: AuditLogPropertyListViewModel,
  Event: EventListViewModel,
  Resource: ResourceListViewModel,
  ResourceCategory: ResourceCategoryListViewModel,
  Role: RoleListViewModel,
  User: UserListViewModel,
  UserRole: UserRoleListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  SecurityService: SecurityServiceViewModel,
}

