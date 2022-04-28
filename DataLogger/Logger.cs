using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace DataLogger
{
    public class Logger
    {
        ServiceBusClient _client;
        ServiceBusProcessor _processor;
        public Logger()
        {
            _client = new ServiceBusClient("Endpoint=sb://studentsportalysu.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=FUe+IPKnwWEp6ru9CZwbb5lT81diSjPO4p2GVG1ka3A=");
            _processor = _client.CreateProcessor("studentportalqueue");
            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;
        }

        public async Task ProcessMessages() 
        {


            await _processor.StartProcessingAsync();
            Thread.Sleep(1000);
            await _processor.StopProcessingAsync();

            //try
            //{
            //    // add handler to process messages
            //    processor.ProcessMessageAsync += MessageHandler;

            //    // add handler to process any errors
            //    processor.ProcessErrorAsync += ErrorHandler;

            //    // start processing 
            //    await processor.StartProcessingAsync();

            //    Console.WriteLine("Wait for a minute and then press any key to end the processing");
            //    Console.ReadKey();

            //    // stop processing 
            //    Console.WriteLine("\nStopping the receiver...");
            //    await processor.StopProcessingAsync();
            //    Console.WriteLine("Stopped receiving messages");
            //}
            //finally
            //{
            //    // Calling DisposeAsync on client types is required to ensure that network
            //    // resources and other unmanaged objects are properly cleaned up.
            //    await processor.DisposeAsync();
            //    await _client.DisposeAsync();
            //}


        }

        public async Task MessageHandler(ProcessMessageEventArgs args) 
        {
            Console.WriteLine($"{args.Message.Body} - message received");

            await args.CompleteMessageAsync(args.Message);
        }

        public async Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"{args.ErrorSource} - error");
        }
    }
}
