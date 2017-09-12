//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public partial class Route
    {
        public int RouteID { get; set; }
        [Display(Name ="Route Name")] 
        [Required(ErrorMessage = "Route Name is Required")]
        public string RouteName { get; set; }
     
        public int DriverID { get; set; }
  
        public int VehicleID { get; set; }
    
        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}