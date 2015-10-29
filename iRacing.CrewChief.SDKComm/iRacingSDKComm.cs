using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iRacing.Models;

namespace iRacing.CrewChief.SDKComm
{
    public delegate void DataSampleReceivedHandler(object sender, DataSample dataSample);
    public delegate void IRacingCommMessageHandler(object sender, string message);

    public class iRacingSDKComm : IiRacingSDKComm
    {
        private int modInterval = 20;
        private int modCounter = 1;
        #region ' events
        public event DataSampleReceivedHandler DataSampleReceived;
        void OnDataSampleReceived(DataSample dataSample)
        {
            var handler = DataSampleReceived;
            if (null != handler)
            {
                DataSampleReceived(null, dataSample);
            }
        }

        public event IRacingCommMessageHandler IRacingCommMessage;
        void OnIRacingCommMessage(string message)
        {
            var handler = IRacingCommMessage;
            if (null != handler)
            {
                IRacingCommMessage(null, message);
            }
        }
        #endregion

        #region ' fields
        private iRacingConnection _iRacingConnection;
        private iRacingEvents _iRacingEvents;
        private Thread _iRacingThread;
        private readonly bool _isAutoSend = false;
        private DataSample _sample;
        private object _syncObj = new object();
        #endregion

        #region ' properties
        iRacingConnection iRacingConnection
        {
            get
            {
                return _iRacingConnection;
            }
        }
        #endregion

        #region ' ctor
        public iRacingSDKComm()
        {
            _isAutoSend = true;

            Action action = new Action(Run);
            if (_iRacingThread != null)
                _iRacingThread.Abort();
            _iRacingThread = new Thread(() => action());
            _iRacingThread.Priority = ThreadPriority.Normal;
            _iRacingThread.Start();
        }
        #endregion

        #region ' Run
        private void Run()
        {
            _iRacingConnection = new iRacingConnection();
            _iRacingConnection.Connected += _iracing_Connected;

            if (_isAutoSend)
            {
                _iRacingEvents = new iRacingEvents();
                _iRacingEvents.Connected += _iracingEvents_Connected;
                _iRacingEvents.Disconnected += _iracingEvents_Disconnected;
                _iRacingEvents.NewData += _iracingEvents_NewData;
                _iRacingEvents.NewSessionData += _iracingEvents_NewSessionData;

                _iRacingEvents.StartListening();
            }
        }
        #endregion

        #region ' Get Data methods
        public DataSample GetDataSample()
        {
            lock (_syncObj)
            {
                if (null == _sample)
                    _sample = iRacingConnection.GetDataFeed().First();

                return _sample;
            }
        }
        #endregion

        #region ' iRacingEvents event handlers
        void _iracingEvents_NewData(DataSample obj)
        {
            if (modCounter % modInterval == 0)
            {
                lock (_syncObj)
                {
                    _sample = obj;
                }
                //OnDataSampleReceived(obj);
                OnIRacingCommMessage("_iracingEvents_NewData");
                modCounter = 1;
            }
            else
            {
                modCounter++;
            }
           
        }

        void _iracingEvents_NewSessionData(DataSample obj)
        {
            lock (_syncObj)
            {
                _sample = obj;
            }
            //OnDataSampleReceived(obj);
            OnIRacingCommMessage("_iracingEvents_NewSessionData");
        }

        void _iracingEvents_Disconnected()
        {
            OnIRacingCommMessage("_iracingEvents_Disconnected");
        }

        void _iracingEvents_Connected()
        {
            OnIRacingCommMessage("_iracingEvents_Connected");
        }
        #endregion

        #region ' iracing event handlers
        void _iracing_Connected()
        {
           OnIRacingCommMessage("_iracing_Connected");
        }
        #endregion

        #region ' dispose
        public void Dispose()
        {
            if (null != _iRacingConnection)
            {
                _iRacingConnection.Connected -= _iracing_Connected;
                _iRacingConnection = null;
            }

            if (null != _iRacingEvents)
            {
                _iRacingEvents.StopListening();
                _iRacingEvents.Connected -= _iracingEvents_Connected;
                _iRacingEvents.Disconnected -= _iracingEvents_Disconnected;
                _iRacingEvents.NewData -= _iracingEvents_NewData;
                _iRacingEvents.NewSessionData -= _iracingEvents_NewSessionData;
                _iRacingEvents.Dispose();
            }

            if (null != _iRacingThread)
            {
                _iRacingThread.Abort();
            }
        }
        #endregion
    }
}

