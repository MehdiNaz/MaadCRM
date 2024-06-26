global using Application;
global using Application.Interfaces;
global using Application.Interfaces.Account;
global using Application.Interfaces.Businesses;
global using Application.Interfaces.Contacts;
global using Application.Interfaces.Customers;
global using Application.Interfaces.Customers.Feedback;
global using Application.Interfaces.Customers.Foroosh;
global using Application.Interfaces.Customers.Notes;
global using Application.Interfaces.Customers.PeyGiry;
global using Application.Interfaces.IdentityUsers;
global using Application.Interfaces.Locations;
global using Application.Interfaces.LogsUser;
global using Application.Interfaces.Plans;
global using Application.Interfaces.Products;
global using Application.Interfaces.SpecialFields;
global using Application.Requests;
global using Application.Responses;
global using Application.Services.BusinessPlansService.Commands;
global using Application.Services.BusinessPlansService.Queries;
global using Application.Services.BusinessPlansService.Validation;
global using Application.Services.BusinessService.Commands;
global using Application.Services.BusinessService.Queries;
global using Application.Services.ContactGroupService.Commands;
global using Application.Services.ContactGroupService.Queries;
global using Application.Services.ContactService.Commands;
global using Application.Services.ContactService.Queries;
global using Application.Services.Customer.CustomerPeyGiryService.Commands;
global using Application.Services.Customer.CustomerPeyGiryService.Queries;
global using Application.Services.Customer.CustomerService.Commands;
global using Application.Services.Customer.CustomerService.Query;
global using Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Commands;
global using Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Queries;
global using Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;
global using Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;
global using Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;
global using Application.Services.Customer.Feedback.CustomerFeedbackService.Queries;
global using Application.Services.Customer.Foroosh.ForooshFactorService.Commands;
global using Application.Services.Customer.Foroosh.ForooshFactorService.Queries;
global using Application.Services.Customer.Foroosh.ForoshOrderService.Commands;
global using Application.Services.Customer.Foroosh.ForoshOrderService.Queries;
global using Application.Services.Customer.Foroosh.PaymentService.Commands;
global using Application.Services.Customer.Foroosh.PaymentService.Queries;
global using Application.Services.Customer.PeyGiryCategoryService.Commands;
global using Application.Services.Customer.PeyGiryCategoryService.Queries;
global using Application.Services.CustomerNoteService.Commands;
global using Application.Services.CustomerNoteService.Queries;
global using Application.Services.CustomerNoteService.Validation;
global using Application.Services.CustomerPhoneNumberService.Validation;
global using Application.Services.CustomersAddressService.Commands;
global using Application.Services.CustomersAddressService.Queries;
global using Application.Services.CustomersAddressService.Validation;
global using Application.Services.CustomersEmailAddressService.Validation;
global using Application.Services.Jwt.Query;
global using Application.Services.Locations.CityService.Queries;
global using Application.Services.Locations.CountryService.Queries;
global using Application.Services.Locations.ProvinceService.Queries;
global using Application.Services.Login.Queries;
global using Application.Services.LogsUserService.Query;
global using Application.Services.NoteAttachmentService.Commands;
global using Application.Services.NoteAttachmentService.Queries;
global using Application.Services.NoteAttachmentService.Validation;
global using Application.Services.NoteHashTableService.Commands;
global using Application.Services.NoteHashTableService.Queries;
global using Application.Services.NoteHashTableService.Validation;
global using Application.Services.NoteHashTagService.Commands;
global using Application.Services.NoteHashTagService.Queries;
global using Application.Services.NoteHashTagService.Validation;
global using Application.Services.PeyGiryAttachmentService.Commands;
global using Application.Services.PeyGiryAttachmentService.Queries;
global using Application.Services.PeyGiryAttachmentService.Validation;
global using Application.Services.PlanService.Commands;
global using Application.Services.PlanService.Queries;
global using Application.Services.PlanService.Validation;
global using Application.Services.ProductCategoryService.Commands;
global using Application.Services.ProductCategoryService.Queries;
global using Application.Services.ProductCategoryService.Validation;
global using Application.Services.ProductService.Commands;
global using Application.Services.ProductService.Queries;
global using Application.Services.ProductService.Validation;
global using Application.Services.Profile.Command;
global using Application.Services.SpecialFields.AttributeOptionService.Commands;
global using Application.Services.SpecialFields.AttributeOptionService.Queries;
global using Application.Services.SpecialFields.AttributeService.Commands;
global using Application.Services.SpecialFields.AttributeService.Queries;
global using Application.Services.UserService.Queries;
global using Application.Validator;
global using Application.Validator.Addresses;
global using Application.Validator.Contacts;
global using Application.Validator.Customers;
global using Application.Validator.Customers.Foroosh;
global using Application.Validator.SpecialFields;
global using DataAccess;
global using DataAccess.Repositories;
global using DataAccess.Repositories.Account;
global using DataAccess.Repositories.Businesses;
global using DataAccess.Repositories.Contacts;
global using DataAccess.Repositories.Customers;
global using DataAccess.Repositories.Customers.Feedback;
global using DataAccess.Repositories.Customers.Foroosh;
global using DataAccess.Repositories.Customers.Note;
global using DataAccess.Repositories.Customers.PeyGiry;
global using DataAccess.Repositories.IdentityUser;
global using DataAccess.Repositories.Locations;
global using DataAccess.Repositories.Plans;
global using DataAccess.Repositories.Products;
global using DataAccess.Repositories.SpecialFields;
global using DataAccess.Repositories.UsersLog;
global using Domain.Enum;
global using Domain.Models.IdentityModels;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MaadApi;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.AspNetCore.RateLimiting;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using System.Text;
global using System.Threading.RateLimiting;
global using Application.Services.Notification.Commands;
global using Application.Services.Notification.Queries;
global using WebApi.Routes;
global using WebApi.Routes.Account;
global using WebApi.Routes.Business;
global using WebApi.Routes.Contacts;
global using WebApi.Routes.Customers;
global using WebApi.Routes.Customers.Feedback;
global using WebApi.Routes.Customers.Foroosh;
global using WebApi.Routes.Customers.Notes;
global using WebApi.Routes.Customers.PeyGiry;
global using WebApi.Routes.IdentityUser;
global using WebApi.Routes.Locations;
global using WebApi.Routes.Notification;
global using WebApi.Routes.Products;
global using WebApi.Routes.SpecialFields;
global using WebApi.Routes.UsersLog;
global using WebApi.StartupConfiguration;
