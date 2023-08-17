using Olm.Domain.Commons;

namespace Olm.Domain.Entities.Quizzes;

public class Answer : Auditable
{
    public string Title { get; set; }
    public bool IsCorrected { get; set; } = false;
    public long QuestionId { get; set; }
    public Question Question { get; set; }
}

