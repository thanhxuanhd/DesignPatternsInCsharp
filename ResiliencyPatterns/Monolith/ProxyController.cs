using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Monolith
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<IActionResult> _retryPolicy;
        private static AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncPolicyWrap<IActionResult> _policy;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _retryPolicy = Policy<IActionResult>
                .Handle<Exception>()
                .RetryAsync();

            _circuitBreakerPolicy ??= Policy
                    .Handle<Exception>()
                    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

            _policy = Policy<IActionResult>
                   .Handle<Exception>()
                   .FallbackAsync(Content("Sorry, we are currently experiencing issues. Please try again later"))
                   .WrapAsync(_retryPolicy)
                   .WrapAsync(_circuitBreakerPolicy);

            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("Books", Name = "Books")]
        public async Task<IActionResult> Books()
            => await ProxyTo("https://localhost:6001/api/books");

        [HttpGet("Authors", Name = "Authors")]
        public async Task<IActionResult> Authors()
            => await ProxyTo("https://localhost:5001/api/authors");

        private async Task<IActionResult> ProxyTo(string url)
                => await _policy.ExecuteAsync(async () => Content(await _httpClient.GetStringAsync(url)));
    }
}