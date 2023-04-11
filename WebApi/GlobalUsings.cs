global using Application;
global using Application.Beach.Query;
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
global using Application.Interfaces.SpecialFields;
global using Application.Services.BusinessPlansService.Commands;
global using Application.Services.BusinessPlansService.Queries;
global using Application.Services.BusinessPlansService.Validation;
global using Application.Services.BusinessService.Commands;
global using Application.Services.BusinessService.Queries;
global using Application.Services.CustomerActivityService.Commands;
global using Application.Services.CustomerActivityService.Queries;
global using Application.Services.CustomerActivityService.Validation;
global using Application.Services.CustomerCategoryService.Commands;
global using Application.Services.CustomerCategoryService.Queries;
global using Application.Services.CustomerCategoryService.Validation;
global using Application.Services.CustomerFeedbackService.Commands;
global using Application.Services.CustomerFeedbackService.Queries;
global using Application.Services.CustomerNoteService.Commands;
global using Application.Services.CustomerNoteService.Queries;
global using Application.Services.CustomerNoteService.Validation;
global using Application.Services.CustomerPeyGiryService.Commands;
global using Application.Services.CustomerPeyGiryService.Queries;
global using Application.Services.CustomerPeyGiryService.Validation;
global using Application.Services.CustomerPhoneNumberService.Validation;
global using Application.Services.CustomersAddressService.Commands;
global using Application.Services.CustomersAddressService.Queries;
global using Application.Services.CustomersAddressService.Validation;
global using Application.Services.CustomersEmailAddressService.Validation;
global using Application.Services.CustomerService.Commands;
global using Application.Services.CustomerService.Query;
global using Application.Services.CustomerService.Validation;
global using Application.Services.Login.Commands;
global using Application.Services.Login.Queries;
global using Application.Services.NoteAttachmentService.Commands;
global using Application.Services.NoteAttachmentService.Queries;
global using Application.Services.NoteAttachmentService.Validation;
global using Application.Services.NoteHashTagService.Commands;
global using Application.Services.NoteHashTagService.Queries;
global using Application.Services.NoteHashTagService.Validation;
global using Application.Services.PeyGiryAttachmentService.Commands;
global using Application.Services.PeyGiryAttachmentService.Queries;
global using Application.Services.PeyGiryAttachmentService.Validation;
global using Application.Services.PlanService.Commands;
global using Application.Services.PlanService.Queries;
global using Application.Services.PlanService.Validation;
global using Application.Services.Role;
global using Application.Services.SanAtService.Validation;
global using Application.Validator;
global using Application.Validator.Addresses;
global using Application.Validator.Contacts;
global using Application.Validator.Customers;
global using Application.Validator.Customers.Forosh;
global using Application.Validator.Products;
global using Application.Validator.SpecialFields;
// global using Coravel;
global using DataAccess;
global using DataAccess.Repositories;
global using DataAccess.Repositories.Account;
global using DataAccess.Repositories.Businesses;
global using DataAccess.Repositories.Contacts;
global using DataAccess.Repositories.Customers;
global using DataAccess.Repositories.Customers.Note;
global using DataAccess.Repositories.Customers.PeyGiry;
global using DataAccess.Repositories.Forosh;
global using DataAccess.Repositories.Login;
global using DataAccess.Repositories.Plans;
global using DataAccess.Repositories.Products;
global using DataAccess.Repositories.SpecialFields;
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
global using WebApi.Routes;
global using WebApi.Routes.Account;
global using WebApi.Routes.Customers;
global using WebApi.Routes.Customers.Notes;
global using WebApi.Routes.Customers.PeyGiry;
global using WebApi.StartupConfiguration;
