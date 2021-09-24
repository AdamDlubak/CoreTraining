using System;

namespace CoreTraining.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyNumber { get; set; }
        public string Line1 { get; set; }
        public string Postcode{ get; set; }
        public string City{ get; set; }
    }
}