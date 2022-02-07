namespace api.Models;

/// <summary>
/// Represents the response from a RunRequest.
/// </summary>
public class RunResponse 
{
    /// <summary>
    /// Indicates whether the code succeeded or not
    /// </summary>    
    public bool Success { get; set; } = false;

    /// <summary>
    /// Contains data passed from script back to Virtual Agent.
    /// </summary>
    public string Res { get; set; } = string.Empty;

    /// <summary>
    /// Contains a description or traceback of the issue when a script-execution fails or triggers an unhandled exception.
    /// </summary>
    public string Message { get; set; } = string.Empty;
}