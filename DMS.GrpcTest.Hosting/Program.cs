using DMS.GrpcTest.ProtocolImpl;
using System;

namespace DMS.GrpcTest.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            RpcConfig.Start();
        }
    }
}
