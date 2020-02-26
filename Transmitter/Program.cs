using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace Transmitter
{
    class Program
    {
        public static void Main()
        {
            // using (var responder = new ResponseSocket())
            // {
            //     responder.Bind("tcp://*:5555");

            //     while (true)
            //     {
            //         string str = responder.ReceiveFrameString();
            //         Console.WriteLine(str);
            //         Thread.Sleep(50);  //  Do some 'work'
            //         responder.SendFrame("World");
            //     }
            // }
            Console.WriteLine("Connecting to hello world server…");
            using (var requester = new SubscriberSocket())
            {
                requester.Connect("tcp://localhost:5555");
                requester.Subscribe("PUB");
                int requestNumber = 0;
                while (true)
                {
                    NetMQMessage arr = requester.ReceiveMultipartMessage();
                    string str = arr[1].ConvertToString();
                    Console.WriteLine(str);
                    Console.WriteLine(requestNumber++);
                }

            }
        }
    }
}
