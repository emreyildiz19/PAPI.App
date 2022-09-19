using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://cwiaqspq:qFvwpyFVFIvKkHecif-wj9K4ohcBTKCK@hawk.rmq.cloudamqp.com/cwiaqspq");

        using var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare("papi-product", true, false, false);

        var consumer = new EventingBasicConsumer(channel);

        channel.BasicConsume("papi-product", true, consumer);

        consumer.Received += (object sender, BasicDeliverEventArgs e) =>
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            Console.WriteLine(message);
        };

        Console.ReadLine();
    }
}