namespace Olm.Service.DTOs.Lessons;

public class LessonCreationDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}