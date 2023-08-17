using Olm.Domain.Commons;
using Olm.Domain.Entities.Courses;

namespace Olm.Domain.Entities.Quizzes;

public class Question : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
}

