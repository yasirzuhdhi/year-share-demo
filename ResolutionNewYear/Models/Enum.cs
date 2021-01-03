using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ResolutionNewYear.Models
{
    public enum PostType
        {
            Event,
            Photo,
            Entry,
            [Display(Name = "Someone you Met")]
            PeopleYouMet,
            Occassions,
            [Display(Name = "Places you Visited")]
            PlacesYouVisted,
            Resolutions
        }

}