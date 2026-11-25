namespace OpenDota.NET.Routes.Request.Models;

/// <summary>
/// Represents a job.
/// </summary>
[UsedImplicitly]
public class Job
{
	/// <summary>
	/// Gets the job ID.
	/// </summary>
	[JsonPropertyName("jobId")]
	public long JobId { get; init; }
}