global using Application;
global using Application.Interfaces;
global using Application.Interfaces.Addresses;
global using Application.Interfaces.Contacts;
global using Application.Interfaces.Customers;
global using Application.Interfaces.Customers.Notes;
global using Application.Interfaces.Customers.PeyGiry;
global using Application.Interfaces.Products;
global using Application.Interfaces.SpecialFields;
global using Application.Services;
global using Application.Validation;
global using Application.Validator;
global using Application.Validator.Addresses;
global using Application.Validator.Contacts;
global using Application.Validator.Customers;
global using Application.Validator.Customers.Note;
global using Application.Validator.Customers.PeyGiry;
global using Application.Validator.Products;
global using Application.Validator.SpecialFields;
global using Coravel;
global using DataAccess;
global using DataAccess.Repositories;
global using DataAccess.Repositories.Contacts;
global using DataAccess.Repositories.Customers;
global using DataAccess.Repositories.Customers.Note;
global using DataAccess.Repositories.Customers.PeyGiry;
global using DataAccess.Repositories.Forosh;
global using DataAccess.Repositories.Products;
global using DataAccess.Repositories.SpecialFields;
global using Domain.Enum;
global using Domain.Models.IdentityModels;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MaadApi;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.AspNetCore.RateLimiting;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using System.Text;
global using System.Threading.RateLimiting;
global using Application.Interfaces.Customers.Forosh;
global using Application.Interfaces.Login;
global using Application.Interfaces.Plans;
global using Application.Validator.Customers.Forosh;
global using Application.Validator.Plans;
global using DataAccess.Repositories.Login;
global using DataAccess.Repositories.Plans;
global using WebApi.StartupConfiguration;
