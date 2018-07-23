using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DMS.GrpcTest.Protocol;

namespace DMS.GrpcTest.ProtocolImpl
{
    public class MsgServiceImpl : MsgService.MsgServiceBase
    {
        public MsgServiceImpl()
        {
        }


        public override Task<GetMsgSumReply> GetSum(GetMsgNumRequest request, ServerCallContext context)
        {
            var result = new GetMsgSumReply();

            result.Sum = request.Num1 + request.Num2;

            // return result;

            return Task.FromResult(result);
        }
    }
}
