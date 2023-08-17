using Olm.Domain.Entities.Quizzes;
using Olm.Service.DTOs.Courses;

namespace Olm.Service.DTOs.Quizzes;

public class QuizResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CourseResultDto Course { get; set; }
    public ICollection<Question> Questions { get; set; }
}
