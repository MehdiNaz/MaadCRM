var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

#region Services
LogConfiguration.Configuration(builder);

CorsConfiguration.Configure(builder.Services, myAllowSpecificOrigins);

DataBaseConnectionConfiguration.Configure(builder.Services, configuration);

IdentityConfiguration.Configure(builder.Services, configuration);

SwaggerConfiguration.Configure(builder.Services);

RepositoryConfiguration.Configure(builder.Services);

RateLimiterConfiguration.Configure(builder.Services);

ServiceConfiguration.Configuration(builder.Services, configuration);

FluentValidationConfiguration.Configure(builder.Services);
#endregion

#region App
var app = builder.Build();

app.UseCors();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseCors(myAllowSpecificOrigins);

app.UseFileServer();

// app.UseSerilogRequestLogging();

#endregion

#region Routes


app.MapProfileRoute();
app.MapLoginRoute();
app.MapBusinessPlanRout();
app.MapBusinessRoute();
app.MapCustomerActivityRoute();
app.MapCustomerAddressRoute();
app.MapCustomerPeyGiryRoute();
app.MapPeyGiryCategoryRoute();
app.MapCustomerNoteRoute();
app.MapNoteHashTableRoute();
app.MapCustomerRoute();
app.MapNoteAttachmentRoute();
app.MapNoteHashTagRoute();
app.MapCustomerPeyGiryAttachmentRoute();
app.MapPlanRoute();
app.MapProductRoute();
app.MapProductCategoryRoute();
app.MapCityRoute();
app.MapCountryRoute();
app.MapProvinceRoute();
app.MapContactRoute();
app.MapContactGroupRoute();
app.MapCustomerFeedbackRoute();
app.MapCustomerFeedbackCategoryRoute();
app.MapCustomerFeedbackAttachmentRoute();
app.MapForooshFactorRoute();
app.MapPaymentRoute();
app.MapAttributeRoute();
app.MapAttributeOptionRoute();
app.MapLogRoute();
#endregion

app.Run();
