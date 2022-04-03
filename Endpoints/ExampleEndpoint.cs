using FastEndpoints;

namespace FastAPI.Endpoints
{
    public class ExampleEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("example");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {

            await SendAsync(new
            {
                message = "Hello World"
            }, cancellation: ct);
        }
    }
}
