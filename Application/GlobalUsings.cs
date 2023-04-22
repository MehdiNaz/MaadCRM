global using Application.Interfaces;
global using Application.Interfaces.Account;
global using Application.Interfaces.Addresses;
global using Application.Interfaces.Businesses;
global using Application.Interfaces.Contacts;
global using Application.Interfaces.Customers;
global using Application.Interfaces.Customers.Forosh;
global using Application.Interfaces.Customers.Notes;
global using Application.Interfaces.Customers.PeyGiry;
global using Application.Interfaces.Plans;
global using Application.Interfaces.Products;
global using Application.Responses;
global using Application.Services.BusinessPlansService.Commands;
global using Application.Services.BusinessPlansService.Queries;
global using Application.Services.BusinessService.Commands;
global using Application.Services.BusinessService.Queries;
global using Application.Services.CityService.Commands;
global using Application.Services.CityService.Queries;
global using Application.Services.ContactEmailAddressService.Commands;
global using Application.Services.ContactEmailAddressService.Queries;
global using Application.Services.ContactGroupService.Commands;
global using Application.Services.ContactGroupService.Queries;
global using Application.Services.ContactPhoneNumberService.Commands;
global using Application.Services.ContactPhoneNumberService.Queries;
global using Application.Services.ContactService.Commands;
global using Application.Services.ContactService.Queries;
global using Application.Services.CustomerActivityService.Commands;
global using Application.Services.CustomerActivityService.Queries;
global using Application.Services.CustomerCategoryService.Commands;
global using Application.Services.CustomerCategoryService.Queries;
global using Application.Services.CustomerFeedbackService.Commands;
global using Application.Services.CustomerNoteService.Commands;
global using Application.Services.CustomerNoteService.Queries;
global using Application.Services.CustomerPeyGiryService.Commands;
global using Application.Services.CustomerPeyGiryService.Queries;
global using Application.Services.CustomerPhoneNumberService.Commands;
global using Application.Services.CustomerPhoneNumberService.Queries;
global using Application.Services.CustomersAddressService.Commands;
global using Application.Services.CustomersAddressService.Queries;
global using Application.Services.CustomersEmailAddressService.Commands;
global using Application.Services.CustomersEmailAddressService.Queries;
global using Application.Services.CustomerService.Commands;
global using Application.Services.CustomerService.Query;
global using Application.Services.ForoshFactorService.Commands;
global using Application.Services.ForoshFactorService.Queries;
global using Application.Services.ForoshOrderService.Commands;
global using Application.Services.ForoshOrderService.Queries;
global using Application.Services.Jwt.Query;
global using Application.Services.Login.Commands;
global using Application.Services.Login.Queries;
global using Application.Services.NoteAttachmentService.Commands;
global using Application.Services.NoteAttachmentService.Queries;
global using Application.Services.NoteHashTableService.Commands;
global using Application.Services.NoteHashTableService.Queries;
global using Application.Services.NoteHashTagService.Commands;
global using Application.Services.NoteHashTagService.Queries;
global using Application.Services.PeyGiryAttachmentService.Commands;
global using Application.Services.PeyGiryAttachmentService.Queries;
global using Application.Services.PlanService.Commands;
global using Application.Services.PlanService.Queries;
global using Application.Services.ProductCategoryService.Commands;
global using Application.Services.ProductCategoryService.Queries;
global using Application.Services.ProductCustomerFavoritesListService.Commands;
global using Application.Services.ProductCustomerFavoritesListService.Queries;
global using Application.Services.ProductService.Commands;
global using Application.Services.ProductService.Queries;
global using Application.Services.Profile.Command;
global using Application.Services.SanAtService.Commands;
global using Application.Services.SanAtService.Queries;
global using Domain.Enum;
global using Domain.Models;
global using Domain.Models.Address;
global using Domain.Models.Businesses;
global using Domain.Models.Contacts;
global using Domain.Models.Customers;
global using Domain.Models.Customers.Notes;
global using Domain.Models.Customers.PeyGiry;
global using Domain.Models.IdentityModels;
global using Domain.Models.Plans;
global using Domain.Models.Products;
global using Domain.Models.SpecialFields;
global using FluentValidation;
global using LanguageExt;
global using LanguageExt.Common;
global using MediatR;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using System.Globalization;
global using System.IdentityModel.Tokens.Jwt;
global using System.Text;
