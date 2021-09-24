using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreTraining.Models
{
    [Table("MeasurementUnitValue")]
    public partial class MeasurementUnitValue : BaseModel
    {
        public MeasurementUnitValue()
        {
            ActivityQuotingRentMaxes = new HashSet<Activity>();
            ActivityQuotingRentMins = new HashSet<Activity>();
        }

        [Column(TypeName = "decimal(20, 2)")]
        public decimal? SquareFeet { get; set; }
        [Column(TypeName = "decimal(20, 2)")]
        public decimal? SquareMeter { get; set; }

        [InverseProperty(nameof(Activity.QuotingRentMax))]
        public virtual ICollection<Activity> ActivityQuotingRentMaxes { get; set; }
        [InverseProperty(nameof(Activity.QuotingRentMin))]
        public virtual ICollection<Activity> ActivityQuotingRentMins { get; set; }
    }
}
