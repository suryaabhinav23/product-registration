using System.Net;

namespace ProductRegistration
{
    /// <summary>
    /// Response Info
    /// </summary>
    public class ResponseInfo
    {
        /// <summary>
        /// Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = new HttpStatusCode();

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Response
        /// </summary>
        public Object? Response { get; set; }

        /// <summary>
        /// Response Info
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="response"></param>
        public ResponseInfo(HttpStatusCode statusCode, string message, Object? response)
        {
            StatusCode = statusCode;
            Message = message;
            Response = response;
        }
    }
}
