﻿using Domain.Models.Customers.Forosh;

namespace Domain.Models.Customers;

public class Customer : BaseEntity
{
    public Customer()
    {
        CustomerId = Ulid.NewUlid();
        CustomerState = CustomerStateTypes.Belghoveh;
        CustomerStatus = Status.Show;
        CustomerActivationStatus = CustomerActivationStatus.Active;
    }

    public Ulid CustomerId { get; set; }
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDayDate { get; set; }
    public byte[] CustomerPic { get; set; }
    public required string InsertedBy { get; set; }
    public string UpdatedBy { get; set; }
    public required string UserId { get; set; }
    public required Ulid CityId { get; set; }
    public required Ulid BusinessId { get; set; }
    public required Ulid CustomerCategoryId { get; set; }
    public required GenderTypes Gender { get; set; }
    public Status CustomerStatus { get; set; }
    public CustomerStateTypes CustomerState { get; set; }
    public CustomerActivationStatus CustomerActivationStatus { get; set; }
    

    #region Moaref
    public Ulid CustomerMoarefId { get; set; }
    public Customer CustomerMoaref { get; set; }
    public ICollection<Customer>? CustomersMoaref { get; set; }
    #endregion

    public User UserEntity { get; set; }                                                                //Relation OK
    public Business Business { get; set; }                                                              //Relation OK
    public City City { get; set; }                                                                      //Relation OK
    public CustomerCategory CustomerCategory { get; set; }                                              //Relation OK
    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; set; }                       //Relation OK
    public ICollection<CustomersEmailAddress>? EmailAddresses { get; set; }                              //Relation OK
    public ICollection<CustomersPhoneNumber>? PhoneNumbers { get; set; }                                 //Relation OK
    public ICollection<CustomerNote>? CustomerNotes { get; set; }                                        //Relation OK
    public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }                                 //Relation OK
    public ICollection<CustomersAddress>? CustomersAddresses { get; set; }                               //Relation OK
    public ICollection<ForoshFactor>? ForoshFactors { get; set; }                                          //Relation OK

    #region Old Relations
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    public ICollection<CustomerActivity> CustomerActivities { get; set; }
    public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    #endregion
}