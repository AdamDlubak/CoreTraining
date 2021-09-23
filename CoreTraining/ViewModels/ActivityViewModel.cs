using System;

namespace CoreTraining.ViewModels
{
    public class ActivityViewModel
    {
        public Guid Id { get; set; }
        public string UniqueReferenceCode { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public Guid ActivityStatusId { get; set; }
        public Guid? QuotingRentMinId { get; set; }
        public Guid? QuotingRentMaxId { get; set; }
    }
}