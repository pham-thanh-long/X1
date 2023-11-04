using BusinessObjects.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Repository;
using AutoMapper;
using xAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100).AddRouteComponents("odata", GetEdmModel()));

//Register HttpClient
builder.Services.AddHttpClient();

//Register Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//Register DbContext
builder.Services.AddDbContext<xDbContext>();

//Register Repository
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();



//Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(

               options =>
               {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
               }
               ).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidIssuer = builder.Configuration["Security:Issuer"],
                   ValidAudience = builder.Configuration["Security:Audience"],

                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Security:Key"])),

                   ValidateIssuer = true,
                   ValidateAudience = true,

                   ValidateLifetime = false,
                   ValidateIssuerSigningKey = true
               });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();


IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();

    builder.EntitySet<Song>("Sóng").EntityType.HasKey(entity => entity.Id);
    builder.EntitySet<Album>("Albums").EntityType.HasKey(entity => entity.Id);
    builder.EntitySet<Artist>("Artists").EntityType.HasKey(entity => entity.Id);

    return builder.GetEdmModel();
}