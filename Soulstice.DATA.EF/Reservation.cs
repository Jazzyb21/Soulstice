//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Soulstice.DATA.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int ReservationID { get; set; }
        public string GymID { get; set; }
        public int ClassID { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual GymMember GymMember { get; set; }
    }
}
