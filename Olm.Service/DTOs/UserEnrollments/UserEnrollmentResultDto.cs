using Olm.Service.DTOs.Courses;

namespace Olm.Service.DTOs.UserEnrollments;

public class UserEnrollmentResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public CourseResultDto Course { get; set; }
}
