using Microsoft.Extensions.DependencyInjection;
using Tycho.Apps;
using TychoWebsite.App.Messaging.Mappers;
using TychoWebsite.Learning;
using TychoWebsite.Rating;
using TychoWebsite.Store;
using CoursesIn = TychoWebsite.Courses.Contract.Incoming;
using RatingIn = TychoWebsite.Rating.Contract.Incoming;
using RatingOut = TychoWebsite.Rating.Contract.Outgoing;
using StoreIn = TychoWebsite.Store.Contract.Incoming;
using StoreOut = TychoWebsite.Store.Contract.Outgoing;
using StudentsIn = TychoWebsite.Students.Contract.Incoming;

namespace TychoWebsite.App;

public class AcademyApp : TychoApp
{
    protected override void DefineContract(IAppContract app) 
    {
        app.Forwards<CoursesIn.Requests.GetCourses, CoursesIn.Requests.GetCourses.Response, LearningModule>()
           .Forwards<CoursesIn.Requests.GetLessons, CoursesIn.Requests.GetLessons.Response, LearningModule>();
           
        app.Forwards<StudentsIn.Requests.GetProgress, StudentsIn.Requests.GetProgress.Response, LearningModule>()
           .Forwards<StudentsIn.Requests.CompleteLesson, LearningModule>();

        app.Forwards<StoreIn.Requests.GetBalance, StoreIn.Requests.GetBalance.Response, StoreModule>()
           .Forwards<StoreIn.Requests.AddFunds, StoreModule>()
           .Forwards<StoreIn.Requests.PurchaseItem, StoreModule>();

        app.Forwards<RatingIn.Requests.Rate, RatingModule>();
    }

    protected override void DefineEvents(IAppEvents app) 
    {
        app.Routes<RatingOut.Events.RatingChanged>()
           .ForwardsAs<CoursesIn.Events.CourseRatingChanged, LearningModule>(EventMapper.Map);

        app.Routes<StoreOut.Events.ItemPurchased>()
           .ForwardsAs<StudentsIn.Events.CourseObtained, LearningModule>(EventMapper.Map);
    }

    protected override void IncludeModules(IAppStructure app) 
    {
        app.Uses<LearningModule>()
           .Uses<StoreModule>()
           .Uses<RatingModule>();
    }

    protected override void RegisterServices(IServiceCollection app) { }
}