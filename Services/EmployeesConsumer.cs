using MassTransit;
using Model;

namespace SqlimportConsumer.Services
{

    internal class EmployeesConsumer : IConsumer<Employee>
    {
        private readonly ILogger<EmployeesConsumer> logger;

        /// <summary>
        /// It's a constructor of EmployeesConsumer class
        /// </summary>
        /// <remarks>
        /// Created by  :   Sunil Thakur,
        /// Created on  :   15/07/2022
        /// Purpose     :   It's a constructor of EmployeesConsumer class
        /// </remarks>
        /// <param name="publishEndpoint></param>
        /// <returns></returns>
        public EmployeesConsumer(ILogger<EmployeesConsumer> logger)
        {
            this.logger = logger;
        }   //EmployeesConsumer

        /// <summary>
        /// It's a method that will create employee index into elastic search by calling IndexEmployees method.
        /// </summary>
        /// <remarks>
        /// Created by  :   Sunil Thakur,
        /// Created on  :   15/07/2022
        /// Purpose     :   It's a method that will create employee index into elastic search by calling IndexEmployees method.
        /// </remarks>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<Employee> context)
        {
            ElasticDataBaseService elasticDataBaseService = new ElasticDataBaseService();

            await Console.Out.WriteLineAsync(context.Message.Name);

            elasticDataBaseService.IndexEmployees(context.Message);
        }   //Consume
    }
}
