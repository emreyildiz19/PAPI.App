using PAPI.Core.DTOs;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCreatePublisher
{
    public class Publisher
    {
        //private string queueName;
        //private CustomResponseDto<List<ProductDto>> customResponseDto;

        //public Publisher(string queueName, CustomResponseDto<List<ProductDto>> customResponseDto)
        //{
        //    //this.queueName = queueName;
        //    //this.customResponseDto = customResponseDto;
        //}

        //public void Main(string queueName, CustomResponseDto<List<ProductDto>> ProductDto)
        //{
        //    var factory = new ConnectionFactory();
        //    factory.Uri = new Uri("amqps://cwiaqspq:qFvwpyFVFIvKkHecif-wj9K4ohcBTKCK@hawk.rmq.cloudamqp.com/cwiaqspq");

        //    using var connection = factory.CreateConnection();

        //    var channel = connection.CreateModel();

        //    channel.QueueDeclare("papi-product", true, false, false);

        //    var message = Newtonsoft.Json.JsonConvert.SerializeObject(ProductDto);

        //    var messageBody = Encoding.UTF8.GetBytes(message);

        //    channel.BasicPublish(string.Empty, "papi-product", null, messageBody);

        //    Console.WriteLine("oluşturulan ürün gönderildi");

        //    Console.ReadLine();

        //}





        //private readonly RabbitMQService _rabbitMQService;


        //public Publisher(string queueName, CustomResponseDto<List<ProductDto>> ProductDto)
        //{
        //    _rabbitMQService = new RabbitMQService();
        //    var connection = _rabbitMQService.GetRabbitMQConnection();
        //    var channel = connection.CreateModel();
        //    channel.QueueDeclare(queueName, false, false, false, null);
        //    var message = Newtonsoft.Json.JsonConvert.SerializeObject(ProductDto);
        //    var body = Encoding.UTF8.GetBytes(message);
        //    channel.BasicPublish("", queueName, null, body);
        //    Console.WriteLine(" {0} queue su üzerine,\"{1}\" mesajı gönderildi.", queueName, message);
        //}
        //        {
        //            _rabbitMQService = new RabbitMQService();

        //            using (var connection = _rabbitMQService.GetRabbitMQConnection())
        //            {
        //                using (var channel = connection.CreateModel())
        //                {
        //                    channel.QueueDeclare(queueName,false,false,false,null);


        //                    var body = Encoding.UTF8.GetBytes(CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>);

        //                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>));
        //                    Console.WriteLine("{0} sent {1}", queueName, CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>);
        //                }
        //            }
        ////        }
    }
}
