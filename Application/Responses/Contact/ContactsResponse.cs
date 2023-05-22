﻿namespace Application.Responses;

public struct ContactsResponse
{
    public Ulid IdContact { get; set; }
    public string? FirstName { get; set; }
    public string LastName { get; set; }
    public string? FullName { get; set; }
    public string? Job { get; set; }
    public string MobileNumber { get; set; }
    public string? EmailAddress { get; set; }
    public Ulid? IdContactGroup { get; set; }
    public string? ContactGroupName { get; set; }
    public StatusType Status { get; set; }
}