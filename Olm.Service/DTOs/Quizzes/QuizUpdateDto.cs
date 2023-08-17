namespace Olm.Service.DTOs.Quizzes;

public class QuizUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}
