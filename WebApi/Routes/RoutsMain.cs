namespace WebApi.Routes;

public static class RoutsMain
{
    public static void MapRoutsMain(this IEndpointRouteBuilder app)
    {
        app.MapGroup("v1/Notification")
            .MapNotificationRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/login")
            .MapLoginRoute()
            .WithOpenApi()
            .AllowAnonymous();
        
        app.MapGroup("v1/profile")
            .MapProfileRoute()
            .WithOpenApi()
            .AllowAnonymous();
        
        app.MapGroup("v1/BusinessPlan")
            .MapBusinessPlanRout()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/Business")
            .MapBusinessRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/CustomerActivity")
            .MapCustomerActivityRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/CustomerAddress")
            .MapCustomerAddressRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        
        app.MapGroup("v1/CustomerPeyGiry")
            .MapCustomerPeyGiryRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/PeyGiryCategory")
            .MapPeyGiryCategoryRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/CustomerNote")
            .MapCustomerNoteRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/NoteHashTable")
            .MapNoteHashTableRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/Customer")
            .MapCustomerRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/NoteAttachment")
            .MapNoteAttachmentRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/NoteHashTag")
            .MapNoteHashTagRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/PeyGiryAttachment")
            .MapCustomerPeyGiryAttachmentRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/plan")
            .MapPlanRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/Product")
            .MapProductRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        
        app.MapGroup("v1/ProductCategory")
            .MapProductCategoryRoute()
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/City")
            .MapCityRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/Country")
            .MapCountryRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/Province")
            .MapProvinceRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/Contact")
            .MapContactRoute()
            .EnableOpenApiWithAuthentication().WithOpenApi();
        
        app.MapGroup("v1/ContactGroup")
            .MapContactGroupRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        
        app.MapGroup("v1/CustomerFeedback")
            .MapCustomerFeedbackRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/CustomerFeedbackCategory")
            .MapCustomerFeedbackCategoryRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        
        app.MapGroup("v1/CustomerFeedbackAttachment")
            .MapCustomerFeedbackAttachmentRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        
        app.MapGroup("v1/ForooshFactor")
            .MapForooshFactorRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        app.MapGroup("v1/Attribute")
            .MapAttributeRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        
        app.MapGroup("v1/AttributeOption")
            .MapAttributeOptionRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        
        app.MapGroup("v1/Log")
            .MapLogRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/ForooshOrder")
            .MapForooshOrderRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        app.MapGroup("v1/ForooshPayment")
            .MapPaymentRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
        
        
        app.MapGroup("v1/User")
            .MapUserRoute()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();
    }
}