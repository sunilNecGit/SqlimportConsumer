using MassTransit;
using SqlimportConsumer.Services;

namespace SqlimportConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Start of services declaration for masstransit rabbitmq with EmployeesConsumer
            {
                builder.Services.AddMassTransit(config =>
                {
                    config.AddConsumer<EmployeesConsumer>();
                    config.UsingRabbitMq((ctx, cfg) =>
                    {
                        cfg.Host("amqp://guest:guest@localhost:5672");
                        cfg.ReceiveEndpoint("employee-order-queue", c =>
                        {
                            c.ConfigureConsumer<EmployeesConsumer>(ctx);
                        });
                    });
                });
            }
            //End of services declaration for masstransit rabbitmq with EmployeesConsumer

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}