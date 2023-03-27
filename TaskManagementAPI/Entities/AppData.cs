using Microsoft.Extensions.Configuration;

namespace TaskManagementAPI.Entities
{
    /// <summary>
    /// This class holds the constants.
    /// </summary>
    public static class AppData
    {
        /// <summary>
        /// Gets or sets Configuration.
        /// </summary>
        /// <value>
        /// Configuration.
        /// </value>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets or sets Environment.
        /// </summary>
        /// <value>
        /// Environment.
        /// </value>
        public static string Environment { get; set; }

        /// <summary>
        /// Gets or sets Jwt.
        /// </summary>
        /// <value>
        /// Jwt.
        /// </value>
        public static Jwt Jwt { get; set; }
    }

    /// <summary>
    /// This class dynamically holds the secret manager settings.
    /// </summary>
    public class SecretManagerKeys
    {
        /// <summary>
        /// Gets or sets ConsumerKey.
        /// </summary>
        /// <value>
        /// ConsumerKey.
        /// </value>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets ConsumerSecret.
        /// </summary>
        /// <value>
        /// ConsumerSecret.
        /// </value>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets Jwt.
        /// </summary>
        /// <value>
        /// Jwt.
        /// </value>
        public Jwt Jwt { get; set; }
    }

    /// <summary>
    ///  JWT configurations.
    /// </summary>
    public class Jwt
    {
        /// <summary>
        /// Gets or sets ClientId.
        /// </summary>
        /// <value>
        /// ClientId.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets ClientSecret.
        /// </summary>
        /// <value>
        /// ClientSecret.
        /// </value>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets Audience.
        /// </summary>
        /// <value>
        /// Audience.
        /// </value>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets TokenUrl.
        /// </summary>
        /// <value>
        /// TokenUrl.
        /// </value>
        public string TokenUrl { get; set; }

        /// <summary>
        /// Gets or sets AuthorizationUrl.
        /// </summary>
        /// <value>
        /// AuthorizationUrl.
        /// </value>
        public string AuthorizationUrl { get; set; }

        /// <summary>
        /// Gets or sets Secret.
        /// </summary>
        /// <value>
        /// Secret.
        /// </value>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets ExpirationInMinutes.
        /// </summary>
        /// <value>
        /// ExpirationInMinutes.
        /// </value>
        public string ExpirationInMinutes { get; set; }
    }
}
