global using Application.Interfaces;
global using Application.Interfaces.Account;
global using Application.Interfaces.Businesses;
global using Application.Interfaces.Contacts;
global using Application.Interfaces.Customers;
global using Application.Interfaces.Customers.Feedback;
global using Application.Interfaces.Customers.Foroosh;
global using Application.Interfaces.Customers.Notes;
global using Application.Interfaces.Customers.PeyGiry;
global using Application.Interfaces.Locations;
global using Application.Interfaces.Plans;
global using Application.Interfaces.Products;
global using Application.Interfaces.SpecialFields;
global using Application.Responses;
global using Application.Services.BusinessPlansService.Commands;
global using Application.Services.BusinessService.Commands;
global using Application.Services.ContactEmailAddressService.Commands;
global using Application.Services.ContactGroupService.Commands;
global using Application.Services.ContactPhoneNumberService.Commands;
global using Application.Services.ContactService.Commands;
global using Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Commands;
global using Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;
global using Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;
global using Application.Services.Customer.Foroosh.ForooshFactorService.Commands;
global using Application.Services.Customer.Foroosh.PaymentService.Commands;
global using Application.Services.CustomerActivityService.Commands;
global using Application.Services.CustomerNoteService.Commands;
global using Application.Services.CustomerPeyGiryService.Commands;
global using Application.Services.CustomerPhoneNumberService.Commands;
global using Application.Services.CustomersAddressService.Commands;
global using Application.Services.CustomersEmailAddressService.Commands;
global using Application.Services.CustomerService.Commands;
global using Application.Services.CustomerService.Query;
global using Application.Services.Login.Commands;
global using Application.Services.Login.Queries;
global using Application.Services.NoteAttachmentService.Commands;
global using Application.Services.NoteHashTableService.Commands;
global using Application.Services.NoteHashTagService.Commands;
global using Application.Services.PeyGiryAttachmentService.Commands;
global using Application.Services.PlanService.Commands;
global using Application.Services.ProductCategoryService.Commands;
global using Application.Services.ProductCustomerFavoritesListService.Commands;
global using Application.Services.ProductService.Commands;
global using Application.Services.SanAtService.Commands;
global using Application.Services.SpecialFields.AttributeOptionService.Commands;
global using Application.Services.SpecialFields.AttributeOptionsValueService.Commands;
global using Application.Services.SpecialFields.AttributeService.Commands;
global using Domain.Enum;
global using Domain.Mapping;
global using Domain.Mapping.Address;
global using Domain.Mapping.BusinessMapping;
global using Domain.Mapping.Contacts;
global using Domain.Mapping.Customers;
global using Domain.Mapping.Customers.Feedback;
global using Domain.Mapping.Customers.Foroosh;
global using Domain.Mapping.Customers.Note;
global using Domain.Mapping.Customers.PeyGiry;
global using Domain.Mapping.IdentityMapping;
global using Domain.Mapping.Location;
global using Domain.Mapping.Plans;
global using Domain.Mapping.Products;
global using Domain.Mapping.SpecialFields;
global using Domain.Models;
global using Domain.Models.Address;
global using Domain.Models.Businesses;
global using Domain.Models.Businesses.Plans;
global using Domain.Models.Contacts;
global using Domain.Models.Customers;
global using Domain.Models.Customers.FeedBack;
global using Domain.Models.Customers.Foroosh;
global using Domain.Models.Customers.Notes;
global using Domain.Models.Customers.PeyGiry;
global using Domain.Models.IdentityModels;
global using Domain.Models.Location;
global using Domain.Models.Products;
global using Domain.Models.SpecialFields;
global using Domain.UnDifined;
global using LanguageExt;
global using LanguageExt.Common;
global using LanguageExt.Pipes;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Application.Services.Customer.Foroosh.ForoshOrderService.Commands;
global using Attribute = Domain.Models.SpecialFields.Attribute;
