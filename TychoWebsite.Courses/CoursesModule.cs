using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoWebsite.Courses.Contract.Incoming.Events;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Courses.Messaging.Handlers;
using TychoWebsite.Courses.Persistence;

namespace TychoWebsite.Courses;

public class CoursesModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    {
        module.Handles<GetCourse, GetCourse.Response, GetCourseHandler>()
              .Handles<GetCourses, GetCourses.Response, GetCoursesHandler>()
              .Handles<GetLessons, GetLessons.Response, GetLessonsHandler>();
    }

    protected override void DefineEvents(IModuleEvents module) 
    {
        module.Handles<CourseRatingChanged, CourseRatingChangedHandler>();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<CoursesDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<CoursesDbContext>();
        await context.InitDatabase();
    }
}