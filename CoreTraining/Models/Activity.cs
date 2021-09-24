using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTraining.Models
{
    [Table("Activity")]
    public partial class Activity : BaseCreationModel
    {
        [Required]
        [StringLength(20)]
        public string UniqueReferenceCode { get; set; }
        public Guid PropertyId { get; set; }
        public Guid ActivityStatusId { get; set; }
        public Guid? QuotingRentMinId { get; set; }
        public Guid? QuotingRentMaxId { get; set; }

        [ForeignKey(nameof(ActivityStatusId))]
        [InverseProperty(nameof(EnumTypeItem.Activities))]
        public virtual EnumTypeItem ActivityStatus { get; set; }
        [ForeignKey(nameof(PropertyId))]
        [InverseProperty("Activities")]
        public virtual Property Property { get; set; }
        [ForeignKey(nameof(QuotingRentMaxId))]
        [InverseProperty(nameof(MeasurementUnitValue.ActivityQuotingRentMaxes))]
        public virtual MeasurementUnitValue QuotingRentMax { get; set; }
        [ForeignKey(nameof(QuotingRentMinId))]
        [InverseProperty(nameof(MeasurementUnitValue.ActivityQuotingRentMins))]
        public virtual MeasurementUnitValue QuotingRentMin { get; set; }
    }
}
