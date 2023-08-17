namespace Olm.Service.DTOs.Quizzes;

public class AnswerCreationDto
{
    public string Title { get; set; }
    public bool IsCorrected { get; set; } = false;
    public long QuestionId { get; set; }
}
