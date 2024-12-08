using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoWebsite.Students.Contract.Incoming.Events;
using TychoWebsite.Students.Contract.Incoming.Requests;
using TychoWebsite.Students.Contract.Outgoing.Requests;
using TychoWebsite.Students.Messaging.Handlers;
using TychoWebsite.Students.Persistence;

namespace TychoWebsite.Students;

public class StudentsModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    {
        module.Handles<CompleteLesson, CompleteLessonHandler>()
              .Handles<GetProgress, GetProgress.Response, GetProgressHandler>();

        module.Requires<GetCourse, GetCourse.Response>();
    }

    protected override void DefineEvents(IModuleEvents module) 
    {
        module.Handles<CourseObtained, CourseObtainedHandler>();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<StudentsDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<StudentsDbContext>();
        await context.InitDatabase();
    }
}