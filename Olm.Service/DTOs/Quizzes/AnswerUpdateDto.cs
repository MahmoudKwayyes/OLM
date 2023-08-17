namespace Olm.Service.DTOs.Quizzes;

public class AnswerUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsCorrected { get; set; } = false;
    public long QuestionId { get; set; }
}
