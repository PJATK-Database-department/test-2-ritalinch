using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<IDoctorsService, DoctorsService>();
// builder.Services.AddScoped<IPrescriptionsService, PrescriptionsService>();
// builder.Services.AddScoped<HospitalContext>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();