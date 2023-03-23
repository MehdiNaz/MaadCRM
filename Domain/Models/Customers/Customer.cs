using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.General;
using Domain.Models.Notes;
using Domain.Models.SpecialFields;

namespace Domain.Models.Customers;

public class Customer:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? Age { get; set; }
    public string Email { get; set; }
    public int? PhoneNumberId { get; set; }
    public int? AddressId { get; set; }
    public int? ProfileImageId { get; set; }
    public int BusinessId { get; set; }
    [ForeignKey(nameof(BusinessId))]
    public Business Business { get; set; }
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    public ICollection<PhoneNubmer> PhoneNubmers { get; set; }
    public ICollection<Address> Addresses{ get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    public ICollection<CustomerActivityHistory> CustomerActivityHistorys { get; set; }
    public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    [InverseProperty(nameof(CustomerRepresentativeHistory.Customers))]
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory2 { get; set; }
    [InverseProperty(nameof(CustomerRepresentativeHistory.CustomerRepresentative))]
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory3 { get; set; }
}