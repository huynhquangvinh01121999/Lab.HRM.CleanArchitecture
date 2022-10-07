using System.Collections.Generic;

namespace Application.DTOs.ResultDto
{
    public class HandlerResult<T>
    {
        public bool isSuccessed { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public HandlerResult<T> Successed(string message, T obj) => new HandlerResult<T> { isSuccessed = true, Message = message, Data = obj };
        public HandlerResult<T> Successed(string message) => new HandlerResult<T> { isSuccessed = true, Message = message };
        public HandlerResult<T> Successed(T obj) => new HandlerResult<T> { isSuccessed = true, Data = obj };

        public HandlerResult<T> Failed(string message, T obj) => new HandlerResult<T> { isSuccessed = false, Message = message, Data = obj };
        public HandlerResult<T> Failed(string message) => new HandlerResult<T> { isSuccessed = false, Message = message };
    }
}
