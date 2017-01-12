﻿namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request get a token using the Resource Owner Grant flow
    /// </summary>
    public class ResourceOwnerTokenRequest
    {
        /// <summary>
        /// Gets or sets the client (app) identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client (app) secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the realm where to do the authentication.
        /// </summary>
        public string Realm { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the requested scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
    }
}