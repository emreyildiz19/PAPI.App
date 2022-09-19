using PAPI.Core.DTOs;
//using ProductCreateConsumer;

namespace RabbitMQ
{
    class Program
    {
        private static readonly string _queueName = "productCreateQueue";

        //private static Publisher _publisher;

        static void Main(string[] args)
        {
          //  _publisher = new Publisher(_queueName, new CustomResponseDto<List<ProductDto>>());

            Console.ReadKey();
        }
    }
}

