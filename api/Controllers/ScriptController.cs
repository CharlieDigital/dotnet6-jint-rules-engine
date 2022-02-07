using System.Dynamic;
using System.Text.Json;
using Jint;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Plugins;

namespace pplreign.Controllers;

[ApiController]
public class ScriptController : ControllerBase
{
    private readonly ILogger<ScriptController> _logger;

    public ScriptController(ILogger<ScriptController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Allows the requester to provide a script and associated context to be executed, and provides the result of that script in response.
    /// </summary>
    /// <param name="request">The incoming request which includes the scriptlet and context parameters.</param>
    /// <returns>A response message which indicates the status of the script execution.</returns>
    [HttpPost("/run", Name = nameof(RunScript))]
    public RunResponse RunScript([FromBody] RunRequest request)
    {
        // TODO: Error checking
        // TODO: Scrub malicious code
        // TODO: Logging of request
        // TODO: Instrumentation
        RunResponse response = new RunResponse();

        var engine = new Engine()
            .SetValue("log", new Action<object>(Console.WriteLine));

        Console.WriteLine(request.Script);

        try
        {
            dynamic res = new ExpandoObject();

            request.Script = $"let ctx = {request.Ctx}; {request.Script}";

            engine
                .SetValue("req", request)
                .SetValue("res", res)
                .SetValue("http", Jint.Runtime.Interop.TypeReference.CreateTypeReference(engine, typeof(HttpPlugin)))
                .Execute(request.Script);

            response.Res = JsonSerializer.Serialize(res);
            response.Success = true;
        }
        catch(Exception exception)
        {
            response.Message = exception.Message;
        }

        return response;
    }
}
