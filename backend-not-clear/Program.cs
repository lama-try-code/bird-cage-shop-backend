using backend_not_clear.Interface;
using backend_not_clear.Models;
using backend_not_clear.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<BCS_ShopContext>(options => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IBlog, BlogServices>();
builder.Services.AddScoped<IStyle, StyleServices>();
builder.Services.AddScoped<ICategory, CategoryServices>();
builder.Services.AddScoped<ISize, SizeServices>();
builder.Services.AddScoped<IMaterial, MaterialServices>();
builder.Services.AddScoped<IColor, ColorServices>();
builder.Services.AddScoped<IProduct, ProductServices>();
builder.Services.AddScoped<IProductCustom, ProductCustomService>();
builder.Services.AddScoped<IBird, BirdServices>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IOrderDetail, OrderDetailService>();
builder.Services.AddScoped<IVoucher, VoucherService>();
builder.Services.AddScoped<IVoucherUserOrder, VoucherUserOrderService>();
builder.Services.AddScoped<IFeedback, FeedbackService>();
builder.Services.AddScoped<IPayment, PaymentServices>();

builder.Services.AddScoped(typeof(BCS_ShopContext));
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("BCSShop", new OpenApiInfo() { Title = "BCSShop", Version = "v1" });
    //setup comment in swagger UI
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentFileFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    option.IncludeXmlComments(xmlCommentFileFullPath);

    //set up jwt token authorize
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


// add jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/BCSShop/swagger.json", "BSCShopApi v1"));
}

app.UseCors(x => x.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
