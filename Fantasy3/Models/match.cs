//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fantasy3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class match
    {
        public match()
        {
            this.matchevents = new HashSet<matchevents>();
        }

        [DisplayName("ID")]
        public int idMatch { get; set; }
        [DisplayName("Kolo")]
        public int idGameWeek2 { get; set; }
        [DisplayName("Doma�i tim")]
        public int homeTeam { get; set; }
        [DisplayName("Gostuju�i tim")]
        public int awayTeam { get; set; }
    
        public virtual footballteam footballteam { get; set; }
        public virtual footballteam footballteam1 { get; set; }
        public virtual gameweek gameweek { get; set; }
        public virtual ICollection<matchevents> matchevents { get; set; }
    }
}
