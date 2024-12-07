using CoursesIn = TychoWebsite.Courses.Contract.Incoming.Events;
using RatingOut = TychoWebsite.Rating.Contract.Outgoing.Events;
using StoreOut = TychoWebsite.Store.Contract.Outgoing.Events;
using StudentsIn = TychoWebsite.Students.Contract.Incoming.Events;

namespace TychoWebsite.App.Messaging.Mappers;

internal static class EventMapper
{
    public static CoursesIn.CourseRatingChanged Map(RatingOut.RatingChanged eventData)
    {
        return new(eventData.TargetId, eventData.NewValue);
    }

    public static StudentsIn.CourseObtained Map(StoreOut.ItemPurchased eventData)
    {
        return new(eventData.PurchaserId, eventData.ItemId, eventData.ItemName);
    }
}