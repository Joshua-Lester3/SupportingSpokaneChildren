import * as metadata from './metadata.g'
import { convertToModel, mapToModel, reactiveDataSource } from 'coalesce-vue/lib/model'
import type { Model, DataSource } from 'coalesce-vue/lib/model'

export enum AuditEntryState {
  EntityAdded = 0,
  EntityDeleted = 1,
  EntityModified = 2,
}


export enum Permission {
  
  /** Modify application configuration and other administrative functions excluding user/role management. */
  Admin = 1,
  
  /** Add and modify users accounts and their assigned roles. Edit roles and their permissions. */
  UserAdmin = 2,
  ViewAuditLogs = 3,
}


export interface Announcement extends Model<typeof metadata.Announcement> {
  announcementId: string | null
  title: string | null
  description: string | null
  datePosted: Date | null
  imageUri: string | null
}
export class Announcement {
  
  /** Mutates the input object and its descendents into a valid Announcement implementation. */
  static convert(data?: Partial<Announcement>): Announcement {
    return convertToModel(data || {}, metadata.Announcement) 
  }
  
  /** Maps the input object and its descendents to a new, valid Announcement implementation. */
  static map(data?: Partial<Announcement>): Announcement {
    return mapToModel(data || {}, metadata.Announcement) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Announcement; }
  
  /** Instantiate a new Announcement, optionally basing it on the given data. */
  constructor(data?: Partial<Announcement> | {[k: string]: any}) {
    Object.assign(this, Announcement.map(data || {}));
  }
}


export interface AuditLog extends Model<typeof metadata.AuditLog> {
  userId: string | null
  user: User | null
  id: number | null
  type: string | null
  keyValue: string | null
  description: string | null
  state: AuditEntryState | null
  date: Date | null
  properties: AuditLogProperty[] | null
  clientIp: string | null
  referrer: string | null
  endpoint: string | null
}
export class AuditLog {
  
  /** Mutates the input object and its descendents into a valid AuditLog implementation. */
  static convert(data?: Partial<AuditLog>): AuditLog {
    return convertToModel(data || {}, metadata.AuditLog) 
  }
  
  /** Maps the input object and its descendents to a new, valid AuditLog implementation. */
  static map(data?: Partial<AuditLog>): AuditLog {
    return mapToModel(data || {}, metadata.AuditLog) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.AuditLog; }
  
  /** Instantiate a new AuditLog, optionally basing it on the given data. */
  constructor(data?: Partial<AuditLog> | {[k: string]: any}) {
    Object.assign(this, AuditLog.map(data || {}));
  }
}


export interface AuditLogProperty extends Model<typeof metadata.AuditLogProperty> {
  id: number | null
  parentId: number | null
  propertyName: string | null
  oldValue: string | null
  oldValueDescription: string | null
  newValue: string | null
  newValueDescription: string | null
}
export class AuditLogProperty {
  
  /** Mutates the input object and its descendents into a valid AuditLogProperty implementation. */
  static convert(data?: Partial<AuditLogProperty>): AuditLogProperty {
    return convertToModel(data || {}, metadata.AuditLogProperty) 
  }
  
  /** Maps the input object and its descendents to a new, valid AuditLogProperty implementation. */
  static map(data?: Partial<AuditLogProperty>): AuditLogProperty {
    return mapToModel(data || {}, metadata.AuditLogProperty) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.AuditLogProperty; }
  
  /** Instantiate a new AuditLogProperty, optionally basing it on the given data. */
  constructor(data?: Partial<AuditLogProperty> | {[k: string]: any}) {
    Object.assign(this, AuditLogProperty.map(data || {}));
  }
}


export interface Event extends Model<typeof metadata.Event> {
  eventId: string | null
  eventName: string | null
  description: string | null
  dateTime: Date | null
  location: string | null
  link: string | null
  imageUri: string | null
}
export class Event {
  
  /** Mutates the input object and its descendents into a valid Event implementation. */
  static convert(data?: Partial<Event>): Event {
    return convertToModel(data || {}, metadata.Event) 
  }
  
  /** Maps the input object and its descendents to a new, valid Event implementation. */
  static map(data?: Partial<Event>): Event {
    return mapToModel(data || {}, metadata.Event) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Event; }
  
  /** Instantiate a new Event, optionally basing it on the given data. */
  constructor(data?: Partial<Event> | {[k: string]: any}) {
    Object.assign(this, Event.map(data || {}));
  }
}
export namespace Event {
  export namespace DataSources {
    
    export class EventLoader implements DataSource<typeof metadata.Event.dataSources.eventLoader> {
      readonly $metadata = metadata.Event.dataSources.eventLoader
    }
  }
}


export interface Resource extends Model<typeof metadata.Resource> {
  resourceId: string | null
  name: string | null
  website: string | null
  phone: string | null
  address: string | null
  email: string | null
  resourceCategoryId: string | null
  resourceCategory: ResourceCategory | null
}
export class Resource {
  
  /** Mutates the input object and its descendents into a valid Resource implementation. */
  static convert(data?: Partial<Resource>): Resource {
    return convertToModel(data || {}, metadata.Resource) 
  }
  
  /** Maps the input object and its descendents to a new, valid Resource implementation. */
  static map(data?: Partial<Resource>): Resource {
    return mapToModel(data || {}, metadata.Resource) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Resource; }
  
  /** Instantiate a new Resource, optionally basing it on the given data. */
  constructor(data?: Partial<Resource> | {[k: string]: any}) {
    Object.assign(this, Resource.map(data || {}));
  }
}


export interface ResourceCategory extends Model<typeof metadata.ResourceCategory> {
  resourceCategoryId: string | null
  categoryName: string | null
}
export class ResourceCategory {
  
  /** Mutates the input object and its descendents into a valid ResourceCategory implementation. */
  static convert(data?: Partial<ResourceCategory>): ResourceCategory {
    return convertToModel(data || {}, metadata.ResourceCategory) 
  }
  
  /** Maps the input object and its descendents to a new, valid ResourceCategory implementation. */
  static map(data?: Partial<ResourceCategory>): ResourceCategory {
    return mapToModel(data || {}, metadata.ResourceCategory) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.ResourceCategory; }
  
  /** Instantiate a new ResourceCategory, optionally basing it on the given data. */
  constructor(data?: Partial<ResourceCategory> | {[k: string]: any}) {
    Object.assign(this, ResourceCategory.map(data || {}));
  }
}


export interface Role extends Model<typeof metadata.Role> {
  name: string | null
  permissions: Permission[] | null
  id: string | null
}
export class Role {
  
  /** Mutates the input object and its descendents into a valid Role implementation. */
  static convert(data?: Partial<Role>): Role {
    return convertToModel(data || {}, metadata.Role) 
  }
  
  /** Maps the input object and its descendents to a new, valid Role implementation. */
  static map(data?: Partial<Role>): Role {
    return mapToModel(data || {}, metadata.Role) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Role; }
  
  /** Instantiate a new Role, optionally basing it on the given data. */
  constructor(data?: Partial<Role> | {[k: string]: any}) {
    Object.assign(this, Role.map(data || {}));
  }
}


export interface User extends Model<typeof metadata.User> {
  fullName: string | null
  userName: string | null
  email: string | null
  emailConfirmed: boolean | null
  photoHash: string | null
  
  /** If set, the user will be blocked from signing in until this date. */
  lockoutEnd: Date | null
  
  /** If enabled, the user can be locked out. */
  lockoutEnabled: boolean | null
  userRoles: UserRole[] | null
  roleNames: string[] | null
  id: string | null
}
export class User {
  
  /** Mutates the input object and its descendents into a valid User implementation. */
  static convert(data?: Partial<User>): User {
    return convertToModel(data || {}, metadata.User) 
  }
  
  /** Maps the input object and its descendents to a new, valid User implementation. */
  static map(data?: Partial<User>): User {
    return mapToModel(data || {}, metadata.User) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.User; }
  
  /** Instantiate a new User, optionally basing it on the given data. */
  constructor(data?: Partial<User> | {[k: string]: any}) {
    Object.assign(this, User.map(data || {}));
  }
}
export namespace User {
  export namespace DataSources {
    
    export class DefaultSource implements DataSource<typeof metadata.User.dataSources.defaultSource> {
      readonly $metadata = metadata.User.dataSources.defaultSource
    }
  }
}


export interface UserRole extends Model<typeof metadata.UserRole> {
  id: string | null
  user: User | null
  role: Role | null
  userId: string | null
  roleId: string | null
}
export class UserRole {
  
  /** Mutates the input object and its descendents into a valid UserRole implementation. */
  static convert(data?: Partial<UserRole>): UserRole {
    return convertToModel(data || {}, metadata.UserRole) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserRole implementation. */
  static map(data?: Partial<UserRole>): UserRole {
    return mapToModel(data || {}, metadata.UserRole) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.UserRole; }
  
  /** Instantiate a new UserRole, optionally basing it on the given data. */
  constructor(data?: Partial<UserRole> | {[k: string]: any}) {
    Object.assign(this, UserRole.map(data || {}));
  }
}
export namespace UserRole {
  export namespace DataSources {
    
    export class DefaultSource implements DataSource<typeof metadata.UserRole.dataSources.defaultSource> {
      readonly $metadata = metadata.UserRole.dataSources.defaultSource
    }
  }
}


export interface UserInfo extends Model<typeof metadata.UserInfo> {
  id: string | null
  userName: string | null
  email: string | null
  fullName: string | null
  roles: string[] | null
  permissions: string[] | null
}
export class UserInfo {
  
  /** Mutates the input object and its descendents into a valid UserInfo implementation. */
  static convert(data?: Partial<UserInfo>): UserInfo {
    return convertToModel(data || {}, metadata.UserInfo) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserInfo implementation. */
  static map(data?: Partial<UserInfo>): UserInfo {
    return mapToModel(data || {}, metadata.UserInfo) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.UserInfo; }
  
  /** Instantiate a new UserInfo, optionally basing it on the given data. */
  constructor(data?: Partial<UserInfo> | {[k: string]: any}) {
    Object.assign(this, UserInfo.map(data || {}));
  }
}


declare module "coalesce-vue/lib/model" {
  interface EnumTypeLookup {
    AuditEntryState: AuditEntryState
    Permission: Permission
  }
  interface ModelTypeLookup {
    Announcement: Announcement
    AuditLog: AuditLog
    AuditLogProperty: AuditLogProperty
    Event: Event
    Resource: Resource
    ResourceCategory: ResourceCategory
    Role: Role
    User: User
    UserInfo: UserInfo
    UserRole: UserRole
  }
}
