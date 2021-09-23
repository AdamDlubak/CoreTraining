using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTraining.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string UniqueReferenceCode { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public Guid ActivityStatusId { get; set; }
        public Guid? QuotingRentMinId { get; set; }
        public Guid? QuotingRentMaxId { get; set; }
    }
}
