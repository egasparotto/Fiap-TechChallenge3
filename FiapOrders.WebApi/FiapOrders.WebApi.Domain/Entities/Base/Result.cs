namespace FiapOrders.WebApi.Domain.Entities.Base
{
    public class Result<T>
    {

        public Result(T data)
        {
            Data = data;
        }

        public Result(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
