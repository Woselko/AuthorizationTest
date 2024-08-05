using System.Text.Json;

namespace Test.Shared.Controllers;

public interface IMinimalApiController : IAppController
{
    [HttpGet("api/minimal-api-sample/{routeParameter}{?queryStringParameter}")]
    Task<JsonElement> MinimalApiSample(string routeParameter, string queryStringParameter, CancellationToken cancellationToken);
}
