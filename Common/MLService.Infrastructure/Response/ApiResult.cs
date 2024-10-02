namespace MLService.Infrastructure.Response
{
    public class ApiResult<TResponse>
    {
        public ApiResult(bool succeeded, int code, TResponse result, List<string> errors)
        {
            Succeeded = succeeded;
            Code = code;
            Result = result;
            Errors = errors;
        }
        public ApiResult() { }
        public bool Succeeded { get; set; }

        public int Code { get; set; }

        public TResponse Result { get; set; }

        public List<string> Errors { get; set; }

        public static ApiResult<TResponse> Success(int code, TResponse result)
            => new ApiResult<TResponse>(true, code, result, new List<string>());

        public static ApiResult<TResponse> Success200(TResponse result)
            => Success(200, result);

        public static ApiResult<TResponse> Fail(int code, List<string> errors)
            => new ApiResult<TResponse>(false, code, default, errors);
    }
}
