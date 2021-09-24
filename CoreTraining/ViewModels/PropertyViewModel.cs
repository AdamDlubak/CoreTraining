using System;
using System.Collections.Generic;

namespace CoreTraining.ViewModels
{
    public class PropertyViewModel
    {
        public Guid Id { get; set; }
        public string UniqueReferenceCode { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public Guid PropertyTypeId { get; set; }
        public AddressViewModel Address { get; set; }
        public ICollection<ActivityViewModel> Activities { get; set; }
    }
}