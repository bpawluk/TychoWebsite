using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using TychoWebsite.Courses;
using TychoWebsite.Courses.Contract.Incoming.Events;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Learning.Messaging.Mappers;
using TychoWebsite.Students;
using TychoWebsite.Students.Contract.Incoming.Events;
using TychoWebsite.Students.Contract.Incoming.Requests;
using CoursesIn = TychoWebsite.Courses.Contract.Incoming.Requests;
using StudentsOut = TychoWebsite.Students.Contract.Outgoing.Requests;

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
        module.Uses<CoursesModule>();
        
        module.Uses<StudentsModule>(studentsRequests => 
        {
            studentsRequests.ForwardAs<
                StudentsOut.GetCourse, StudentsOut.GetCourse.Response,
                CoursesIn.GetCourse, CoursesIn.GetCourse.Response,
                CoursesModule>(
                    RequestMapper.MapRequest,
                    RequestMapper.MapResponse);
        });
    }

    protected override void RegisterServices(IServiceCollection module) { }
}