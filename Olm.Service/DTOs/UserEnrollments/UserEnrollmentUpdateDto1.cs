namespace Olm.Service.DTOs.UserEnrollments;

public class UserEnrollmentUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public long CourseId { get; set; }
}
