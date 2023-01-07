using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Client.HttpHandlers
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ClientCredentialsTokenRequest clientCredentialsTokenRequest;

        public AuthenticationDelegatingHandler(
            IHttpClientFactory httpClientFactory,
            ClientCredentialsTokenRequest clientCredentialsTokenRequest)
        {
            this.httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(this.httpClientFactory));

            this.clientCredentialsTokenRequest = clientCredentialsTokenRequest 
                ?? throw new ArgumentNullException(nameof(this.clientCredentialsTokenRequest));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpClient = this.httpClientFactory.CreateClient("IDPClient");

            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(
                this.clientCredentialsTokenRequest, cancellationToken);

            if (tokenResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }

            request.SetBearerToken(tokenResponse.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
