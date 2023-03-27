namespace TaskManagementAPI.Entities
{
    /// <summary>
    ///  OauthToken.
    /// </summary>
    public class OauthToken : InvalidCredential
    {
        /// <summary>
        /// Gets or sets access_token.
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Gets or sets expires_in.
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// Gets or sets token_type.
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// Gets or sets scope.
        /// </summary>
        /// <value>
        /// scope.
        /// </value>
        public string scope { get; set; }
    }

    /// <summary>
    /// Gets or sets InvalidCredential.
    /// </summary>
    /// <value>
    /// InvalidCredential.
    /// </value>
    public class InvalidCredential
    {
        /// <summary>
        /// Gets or sets error.
        /// </summary>
        /// <value>
        /// Error.
        /// </value>
        public string Error { get; set; }
    }
}
