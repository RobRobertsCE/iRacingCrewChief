using System;
using iRacing.Models;

namespace iRacing.CrewChief.SDKComm
{
    public interface IiRacingSDKComm
    {
        event DataSampleReceivedHandler DataSampleReceived;
        void Dispose();
        DataSample GetDataSample();
        event IRacingCommMessageHandler IRacingCommMessage;
    }
}
