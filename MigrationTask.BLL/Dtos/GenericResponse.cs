using MigrationTask.BLL.Interfaces;
using System.Net;

namespace MigrationTask.BLL.Dtos
{
    public class GenericResponse<T> : IGenericResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public Exception? Exception { get; set; }




        public GenericResponse(T? data, string msg = "", bool isSuccess = true, int statusCode = (int)HttpStatusCode.OK)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Data = data;
            Message = msg;
        }
        public GenericResponse(string msg)
        {
            IsSuccess = false;
            StatusCode = (int)HttpStatusCode.BadRequest;
            Message = msg;
        }

        public GenericResponse(Exception? exception)
        {
            IsSuccess = false;
            StatusCode = (int)HttpStatusCode.InternalServerError;
            Exception = exception;
            Message = exception?.Message;

        }
    }
}
