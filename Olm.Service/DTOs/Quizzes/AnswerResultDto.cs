namespace Olm.Service.DTOs.Quizzes;

public class AnswerResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsCorrected { get; set; } = false;
    public QuestionResultDto Question { get; set; }
}
