using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using TychoWebsite.Courses;
using TychoWebsite.Learning.Messaging.Mappers;
using TychoWebsite.Students;
using CoursesIn = TychoWebsite.Courses.Contract.Incoming;
using StudentsIn = TychoWebsite.Students.Contract.Incoming;
using StudentsOut = TychoWebsite.Students.Contract.Outgoing;

namespace TychoWebsite.Learning;

public class LearningModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    { 
        module.Forwards<CoursesIn.Requests.GetCourses, CoursesIn.Requests.GetCourses.Response, CoursesModule>()
              .Forwards<CoursesIn.Requests.GetLessons, CoursesIn.Requests.GetLessons.Response, CoursesModule>();

        module.Forwards<StudentsIn.Requests.CompleteLesson, StudentsModule>()
              .Forwards<StudentsIn.Requests.GetProgress, StudentsIn.Requests.GetProgress.Response, StudentsModule>();
    }

    protected override void DefineEvents(IModuleEvents module) 
    {
        module.Routes<CoursesIn.Events.CourseRatingChanged>()
              .Forwards<CoursesModule>();

        module.Routes<StudentsIn.Events.CourseObtained>()
              .Forwards<StudentsModule>();
    }

    protected override void IncludeModules(IModuleStructure module) 
    {
        module.Uses<CoursesModule>();
        
        module.Uses<StudentsModule>(studentsRequests => 
        {
            studentsRequests.ForwardAs<
                StudentsOut.Requests.GetCourse, StudentsOut.Requests.GetCourse.Response,
                CoursesIn.Requests.GetCourse, CoursesIn.Requests.GetCourse.Response,
                CoursesModule>(
                    RequestMapper.MapRequest,
                    RequestMapper.MapResponse);
        });
    }

    protected override void RegisterServices(IServiceCollection module) { }
}