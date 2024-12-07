using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using TychoWebsite.Courses;
using TychoWebsite.Courses.Contract.Incoming.Events;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Students;
using TychoWebsite.Students.Contract.Incoming.Events;
using TychoWebsite.Students.Contract.Incoming.Requests;

namespace TychoWebsite.Learning;

public class LearningModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    { 
        module.Forwards<GetCourses, GetCourses.Response, CoursesModule>()
              .Forwards<GetLessons, GetLessons.Response, CoursesModule>();

        module.Forwards<CompleteLesson, StudentsModule>()
              .Forwards<GetProgress, GetProgress.Response, StudentsModule>();
    }

    protected override void DefineEvents(IModuleEvents module) 
    {
        module.Routes<CourseRatingChanged>()
              .Forwards<CoursesModule>();

        module.Routes<CourseObtained>()
              .Forwards<StudentsModule>();
    }

    protected override void IncludeModules(IModuleStructure module) 
    {
        module.Uses<CoursesModule>()
              .Uses<StudentsModule>();
    }

    protected override void RegisterServices(IServiceCollection module) { }
}