export interface ApiResponse<T>{
    succcess: boolean,
    data: T,
    message?: string,
    errors: BaseError[]
}

export interface BaseError{
    propertyMessage?: string,
    errorMessage?: string
}