

namespace MigrationTask.BLL.Interfaces
{
    public interface IGenericResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public Exception? Exception { get; set; }

    }
}
