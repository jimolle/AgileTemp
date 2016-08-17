using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTemp.WebUi.Models
{
    public class Profile
    {
        public int Id { get; set; }
        //public string Username { get; set; }    //Or just email?
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public DateTime BirthYear { get; set; }
        public UserType UserType { get; set; }
        //public string HomeTown { get; set; }
        // + LocationLatitude & LocationLongitude = UserPosition

        // + Monitored keywords/EventTags?

        public virtual List<ProfileSearch> ProfileSearches { get; set; }
        public virtual List<EventProfile> EventSignups { get; set; }
    }

    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public int? MaxSignups { get; set; }
        public decimal? Cost { get; set; }

        public virtual Profile Owner { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public virtual List<EventTag> EventTags { get; set; }
        public virtual List<EventProfile> EventSignups { get; set; }
    }

    public class EventProfile
    {
        public int Id { get; set; }
        public DateTime SignupDate { get; set; }
        public SignupStatus SignupStatus { get; set; }

        public virtual List<Profile> Users { get; set; }
        public virtual List<Event> Events { get; set; }
    }

    public class EventTag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual Event Event { get; set; }
    }

    public class EventCategory
    {
        [ForeignKey("Event")]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual Event Event { get; set; }
    }

    public class ProfileSearch
    {
        public int Id { get; set; }
        public string SearchString { get; set; }

        public virtual Profile User { get; set; }
    }

    public enum UserType
    {
        Private,
        Commercial
    }

    public enum SignupStatus
    {
        Pending,
        Confirmed
    }
}
