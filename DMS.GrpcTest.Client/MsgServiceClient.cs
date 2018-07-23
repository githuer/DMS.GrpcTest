using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using DMS.GrpcTest.Protocol;

namespace DMS.GrpcTest.Client
{
    public class MsgServiceClient
    {
        private static Channel _channel;
        private static MsgService.MsgServiceClient _client;

        static MsgServiceClient()
        {
            _channel = new Channel("127.0.0.1:40001", ChannelCredentials.Insecure);
            _client = new MsgService.MsgServiceClient(_channel);
        }

        public static GetMsgSumReply GetSum(int num1, int num2)
        {
            return _client.GetSum(new GetMsgNumRequest
            {
                Num1 = num1,
                Num2 = num2
            });
        }
    }
}
