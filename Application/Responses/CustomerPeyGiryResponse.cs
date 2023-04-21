﻿namespace Application.Responses;

public struct CustomerPeyGiryResponse
{
    public string Description { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public Ulid CustomerPeyGiryId { get; set; }
}