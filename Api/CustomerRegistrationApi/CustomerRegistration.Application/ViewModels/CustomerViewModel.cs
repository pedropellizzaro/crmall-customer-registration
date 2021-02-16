using System;

namespace CustomerRegistration.Application.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public int? Number { get; set; }
        public string Complement { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}