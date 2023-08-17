using Olm.Domain.Commons;
using Olm.Domain.Entities.Courses;

namespace Olm.Domain.Entities.UserEnrollments;

public class UserEnrollment : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
}

