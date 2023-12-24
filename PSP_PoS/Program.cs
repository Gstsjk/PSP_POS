using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.Category;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Employee;
using PSP_PoS.Components.Item;
using PSP_PoS.Components.Order;
using PSP_PoS.Components.OrderItem;
using PSP_PoS.Components.Reservation;
using PSP_PoS.Components.Service;
using PSP_PoS.Components.Tax;
using PSP_PoS.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ITaxService, TaxService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "POS System", Version = "v1" });
});
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "POS System");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
