using Olm.Service.DTOs.Courses;

namespace Olm.Service.DTOs.Quizzes;

public class QuestionResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CourseResultDto Course { get; set; }
}
