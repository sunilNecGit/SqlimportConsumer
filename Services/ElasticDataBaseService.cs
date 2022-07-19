using Model;
using Nest;

namespace SqlimportConsumer.Services
{
    internal class ElasticDataBaseService
    {
        /// <summary>
        /// It's a method that will create employee index into elastic search.
        /// </summary>
        /// <remarks>
        /// Created by  :   Sunil Thakur,
        /// Created on  :   15/07/2022
        /// Purpose     :   It's a method that will create employee index into elastic search.
        /// </remarks>
        /// <param name=""></param>
        /// <returns></returns>
        public void IndexEmployees(Employee employee)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("employees");
            var client = new ElasticClient(settings);

            var indexResponse = client.IndexDocument(employee);

            if (indexResponse.IsValid)
            {
                Console.WriteLine($"employee {employee.ID}, Done!");
            }
            else
            {
                Console.WriteLine(indexResponse.OriginalException);
            }
        }   //IndexEmployees
    }
}
