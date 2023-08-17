using AutoMapper;
using Olm.Domain.Entities.Assignments;
using Olm.Domain.Entities.Courses;
using Olm.Domain.Entities.Lessons;
using Olm.Domain.Entities.ProgressTrackings;
using Olm.Domain.Entities.Quizzes;
using Olm.Domain.Entities.UserEnrollments;
using Olm.Service.DTOs.Assigments;
using Olm.Service.DTOs.Courses;
using Olm.Service.DTOs.Lessons;
using Olm.Service.DTOs.ProgressTrackings;
using Olm.Service.DTOs.Quizzes;
using Olm.Service.DTOs.UserEnrollments;

namespace Olm.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Assignment
        CreateMap<AssignmentResultDto, Assignment>().ReverseMap();
        CreateMap<Assignment, AssignmentUpdateDto>().ReverseMap();
        CreateMap<Assignment, AssignmentCreationDto>().ReverseMap();

        // Course
        CreateMap<CourseResultDto, Course>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>().ReverseMap();
        CreateMap<Course, CourseCreationDto>().ReverseMap();

        // Lesson
        CreateMap<LessonResultDto, Lesson>().ReverseMap();
        CreateMap<Lesson, LessonUpdateDto>().ReverseMap();
        CreateMap<Lesson, LessonCreationDto>().ReverseMap();

        // ProgressTracking
        CreateMap<ProgressTrackingResultDto, ProgressTracking>().ReverseMap();
        CreateMap<ProgressTracking, ProgressTrackingUpdateDto>().ReverseMap();
        CreateMap<ProgressTracking, ProgressTrackingCreationDto>().ReverseMap();
        
        // UserEnrollment
        CreateMap<UserEnrollmentResultDto, UserEnrollment>().ReverseMap();
        CreateMap<UserEnrollment, UserEnrollmentUpdateDto>().ReverseMap();
        CreateMap<UserEnrollment, UserEnrollmentCreationDto>().ReverseMap();
        
        // Question
        CreateMap<QuestionResultDto, Question>().ReverseMap();
        CreateMap<Question, QuestionUpdateDto>().ReverseMap();
        CreateMap<Question, QuestionCreationDto>().ReverseMap();
        
        // Quiz
        CreateMap<QuizResultDto, Quiz>().ReverseMap();
        CreateMap<Quiz, QuizUpdateDto>().ReverseMap();
        CreateMap<Quiz, QuizCreationDto>().ReverseMap();

        // Answer
        CreateMap<AnswerResultDto, Answer>().ReverseMap();
        CreateMap<Answer, AnswerUpdateDto>().ReverseMap();
        CreateMap<Answer, AnswerCreationDto>().ReverseMap();
    }
}
