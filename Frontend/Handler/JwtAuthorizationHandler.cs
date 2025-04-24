using System.Net.Http.Headers;
using Frontend.Utilities;

namespace Frontend.Handler
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly CookieService _cookieService;
        private readonly IConfiguration _configuration;

        public JwtAuthorizationHandler(CookieService cookieService, IConfiguration configuration)
        {
            _cookieService = cookieService;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _cookieService.GetCookieAsync(_configuration["CookieName"]);

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}