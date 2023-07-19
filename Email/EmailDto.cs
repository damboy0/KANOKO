namespace KANOKO.Email
{
    public class EmailDto
    {
        public class EmailRequestModel
        {
            public string ToEmail { get; set; }
            public string ToName { get; set; }
            public string AttachmentName { get; set; }
            public string HtmlContent { get; set; }
            public string Subject { get; set; }
        }
        public class EmailResponseModel
        {
            public string Message { get; set; }
        }
    }
}
