using Olm.Domain.Commons;

namespace Olm.Domain.Entities.ProgressTrackings;

public class ProgressTracking : Auditable
{
    public string Description { get; set; }
    public long UserId { get; set; }
    public long LessonId { get; set; }
}
