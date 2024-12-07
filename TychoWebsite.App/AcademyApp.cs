using Microsoft.Extensions.DependencyInjection;
using Tycho.Apps;
using TychoWebsite.App.Messaging.Mappers;
using TychoWebsite.Courses.Contract.Incoming.Events;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Learning;
using TychoWebsite.Rating;
using TychoWebsite.Rating.Contract.Incoming.Requests;
using TychoWebsite.Rating.Contract.Outgoing.Events;
using TychoWebsite.Store;
using TychoWebsite.Store.Contract.Incoming.Requests;
using TychoWebsite.Store.Contract.Outgoing.Events;
using TychoWebsite.Students.Contract.Incoming.Events;
using TychoWebsite.Students.Contract.Incoming.Requests;

namespace TychoWebsite.App;

public class AcademyApp : TychoApp
{
    protected override void DefineContract(IAppContract app) 
    {
        app.Forwards<GetCourses, GetCourses.Response, LearningModule>()
           .Forwards<GetLessons, GetLessons.Response, LearningModule>()
           .Forwards<GetProgress, GetProgress.Response, LearningModule>()
           .Forwards<CompleteLesson, LearningModule>();

        app.Forwards<GetBalance, GetBalance.Response, StoreModule>()
           .Forwards<AddFunds, StoreModule>()
           .Forwards<PurchaseItem, StoreModule>();

        app.Forwards<Rate, RatingModule>();
    }

    protected override void DefineEvents(IAppEvents app) 
    {
        app.Routes<RatingChanged>()
           .ForwardsAs<CourseRatingChanged, LearningModule>(EventMapper.Map);

        app.Routes<ItemPurchased>()
           .ForwardsAs<CourseObtained, LearningModule>(EventMapper.Map);
    }

    protected override void IncludeModules(IAppStructure app) 
    {
        app.Uses<LearningModule>()
           .Uses<StoreModule>()
           .Uses<RatingModule>();
    }

    protected override void RegisterServices(IServiceCollection app) { }
}