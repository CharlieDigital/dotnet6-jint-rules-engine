namespace api.Models;

/// <summary>
/// Represents a request to execute an arbitrary JavaScript snippet.
/// </summary>
public class RunRequest
{
    /// <summary>
    /// Contains data passed in from Virtual Agent that can be accessed and used by the provided script.
    /// </summary>
    public string Ctx { get; set; } = string.Empty;

    /// <summary>
    /// Represents the JavaScript snippet to execute.
    /// </summary>
    public string Script { get; set; } = string.Empty;
}