namespace Entities
{
    /// <summary>
    /// This class holds the constants.
    /// </summary>
    public class ExceptionDetails
    {
        /// <summary>
        ///  Gets or sets Exception.
        /// </summary>
        /// <value>
        /// Exception.
        /// </value>
        public string Exception { get; set; }

        /// <summary>
        ///  Gets or sets InnerException.
        /// </summary>
        /// <value>
        /// InnerException.
        /// </value>
        public string InnerException { get; set; }

        /// <summary>
        ///  Gets or sets StackTrace.
        /// </summary>
        /// <value>
        /// StackTrace.
        /// </value>
        public string StackTrace { get; set; }

        /// <summary>
        ///  Gets or sets MachineName.
        /// </summary>
        /// <value>
        /// MachineName.
        /// </value>
        public string MachineName { get; set; }

        /// <summary>
        ///  Gets or sets ControllerName.
        /// </summary>
        /// <value>
        /// ControllerName.
        /// </value>
        public string ControllerName { get; set; }

        /// <summary>
        ///  Gets or sets ActionName.
        /// </summary>
        /// <value>
        /// ActionName.
        /// </value>
        public string ActionName { get; set; }

        /// <summary>
        ///  Gets or sets Environment.
        /// </summary>
        /// <value>
        /// Environment.
        /// </value>
        public string Environment { get; set; }

        /// <summary>
        ///  Gets or sets UserName.
        /// </summary>
        /// <value>
        /// UserName.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        ///  Gets or sets ApiRequest.
        /// </summary>
        /// <value>
        /// ApiRequest.
        /// </value>
        public string ApiRequest { get; set; }

        /// <summary>
        ///  Gets or sets ApplicationName.
        /// </summary>
        /// <value>
        /// ApplicationName.
        /// </value>
        public string ApplicationName { get; set; }

        /// <summary>
        ///  Gets or sets EmailTo.
        /// </summary>
        /// <value>
        /// EmailTo.
        /// </value>
        public string EmailTo { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether gets or sets IsSeriLogRequired.
        /// </summary>
        /// <value>
        /// IsSeriLogRequired.
        /// </value>
        public bool IsSeriLogRequired { get; set; } = true;

        /// <summary>
        ///  Gets or sets a value indicating whether gets or sets IsEmailRequired.
        /// </summary>
        /// <value>
        /// IsEmailRequired.
        /// </value>
        public bool IsEmailRequired { get; set; } = true;

        /// <summary>
        ///  Gets or sets LogId.
        /// </summary>
        /// <value>
        /// LogId.
        /// </value>
        public string LogId { get; set; }
    }

    /// <summary>
    /// This class send the response of the logging.
    /// </summary>
    public class LogResponseData
    {
        /// <summary>
        ///  Gets or sets a value indicating whether gets or sets HasException.
        /// </summary>
        /// <value>
        /// HasException.
        /// </value>
        public bool HasException { get; set; }

        /// <summary>
        ///  Gets or sets ErrorMessage.
        /// </summary>
        /// <value>
        /// ErrorMessage.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
