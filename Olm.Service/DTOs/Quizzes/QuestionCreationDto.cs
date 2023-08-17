namespace Olm.Service.DTOs.Quizzes;

public class QuestionCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}
