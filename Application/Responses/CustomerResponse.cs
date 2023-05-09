﻿namespace Application.Responses;

public struct CustomerResponse
{
    public Ulid CustomerId { get; set; }
    public string FirstName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public Ulid? CityId { get; set; }
    public string CityName { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CustomerCategoryId { get; set; }
    public StatusType CustomerStatusType { get; set; }
    public CustomerStateTypes CustomerStateType { get; set; }
    public DateTime? From { get; set; }
    public DateTime? UpTo { get; set; }
    public Ulid? MoshtaryMoAref { get; set; }
    public string MoarefFullName { get; set; }
    public Ulid ProductId { get; set; }
    public string ProductName { get; set; }

    public DateTime? DateCreated { get; set; }
    // public Ulid? ProductCustomerFavorite { get; set; }
    //public GenderTypes? Gender { get; set; }
    //public Ulid? CityId { get; set; }
    //public Ulid? ProvinceId { get; set; }
}