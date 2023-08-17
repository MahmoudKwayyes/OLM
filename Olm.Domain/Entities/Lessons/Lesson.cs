using Olm.Domain.Commons;
using Olm.Domain.Entities.Courses;

namespace Olm.Domain.Entities.Lessons;

public class Lesson : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
}

