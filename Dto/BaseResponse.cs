namespace KANOKO.Dto
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
    }
    public class LoginResponseModel
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public UserDto Data { get; set; }
        public string Token { get; set; }
    }
}
