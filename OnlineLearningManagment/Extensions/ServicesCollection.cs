using Olm.Data.IRepostiries;
using Olm.Data.Repositories;
using Olm.Service.Interfaces;
using Olm.Service.Mappers;
using Olm.Service.Services;

namespace OnlineLearningManagment.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IAssignmentService, AssignmentService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IProgressTrackingService, ProgressTrackingService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<IUserEnrollmentService, UserEnrollmentService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MapperProfile));
    }
}
