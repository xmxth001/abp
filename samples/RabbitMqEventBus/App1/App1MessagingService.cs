﻿using System;
using SharedModule;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;

namespace App2
{
    public class App1MessagingService : ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public App1MessagingService(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public void Run()
        {
            Console.WriteLine("Press ENTER (without writing a message) to stop application...");
            Console.WriteLine();

            string message;
            do
            {
                message = Console.ReadLine();

                if (!message.IsNullOrEmpty())
                {
                    _distributedEventBus.Publish(new TextEventData { TextMessage = message });
                }
                else
                {
                    _distributedEventBus.Publish(new TextEventData { TextMessage = "App1 is exiting. Bye bye...!" });
                }

            } while (!message.IsNullOrEmpty());
        }
    }
}