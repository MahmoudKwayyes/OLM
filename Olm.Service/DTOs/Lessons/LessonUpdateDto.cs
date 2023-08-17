namespace Olm.Service.DTOs.Lessons;

public class LessonUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}