using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.SDKComm;
using Newtonsoft.Json;

namespace iRacing.CrewChief.Server
{
    class TcpServerErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; private set; }
        public string StackTrace { get; private set; }

        public TcpServerErrorEventArgs(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.StackTrace = ex.ToString();
        }
    }
    class TcpServerMessageEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public TcpServerMessageEventArgs(String message)
        {
            this.Message = message;
        }
    }
    class TcpServerListener : IDisposable
    {
        #region events
        public delegate void TcpServerErrorHandler(object sender, TcpServerErrorEventArgs e);
        public event TcpServerErrorHandler TcpServerError;
        void OnTcpServerError(Exception ex)
        {
            var handler = this.TcpServerError;

            if (null != handler)
            {
                TcpServerError(this, new TcpServerErrorEventArgs(ex));
            }
        }

        public delegate void TcpServerMessageHandler(object sender, TcpServerMessageEventArgs e);
        public event TcpServerMessageHandler TcpServerMessage;
        void OnTcpServerMessage(String message)
        {
            if (!RaiseMessageEvents) return;

            var handler = this.TcpServerMessage;

            if (null != handler)
            {
                TcpServerMessage(this, new TcpServerMessageEventArgs(message));
            }
        }
        #endregion

        #region consts
        const Int32 DefaultPort = 13000;
        const String DefaultAddress = "127.0.0.1";
        const bool DefaultRaiseMessageEvents = false;
        const bool DefaultLogDataSamples = true;
        const string DefaultFileDirectory = @"C:\Users\rroberts\Documents\Dump\DataSamples\";
        #endregion

        #region fields
        IiRacingSDKComm _service;
        TcpListener _server;
        IDictionary<string, SortedList<int, string>> _trackFileLists;
        #endregion

        #region props
        bool _logDataSamples = DefaultLogDataSamples;
        public bool LogDataSamples { get { return _logDataSamples; } set { _logDataSamples = value; } }

        bool _raiseMessageEvents = DefaultRaiseMessageEvents;
        public bool RaiseMessageEvents { get { return _raiseMessageEvents; } set { _raiseMessageEvents = value; } }

        string _currentTrack = String.Empty;
        public string CurrentTrack { get { return _currentTrack; } set { _currentTrack = value; } }

        int _dataSampleIndex = 0;
        public int DataSampleIndex { get { return _dataSampleIndex; } set { _dataSampleIndex = value; } }

        string _fileDirectory = DefaultFileDirectory;
        public string FileDirectory { get { return _fileDirectory; } set { _fileDirectory = value; } }

        bool _useFileData = false;
        public bool UseFileData
        {
            get { return _useFileData; }
            set
            {
                _useFileData = value;
                if (_useFileData)
                {
                    LoadFileLists();
                    _dataSampleIndex = 0;
                }
            }
        }

        Int32 _port = DefaultPort;
        public Int32 ServerPort
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        String _serverAddress = DefaultAddress;
        public String ServerAddress
        {
            get
            {
                return _serverAddress;
            }
            set
            {
                _serverAddress = value;
            }
        }
        #endregion

        #region ctor
        public TcpServerListener()
        {
        }
        #endregion

        #region public Run
        public void Run()
        {
            try
            {
                _service = new iRacingComm();

                Int32 port = ServerPort;
                IPAddress localAddr = IPAddress.Parse(ServerAddress);

                _server = new TcpListener(localAddr, port);
                _server.Start();

                while (true)
                {
                    OnTcpServerMessage("TcpServer listening for incoming connections...");

                    TcpClient client = _server.AcceptTcpClient();

                    HandleIncomingConnection(client);
                }
            }
            catch (SocketException ex)
            {
                if (ex.HResult != -2147467259)
                {
                    OnTcpServerError(ex);
                }
            }
            catch (Exception ex)
            {
                OnTcpServerError(ex);
            }
            finally
            {
                OnTcpServerMessage("TcpServer is closing the listening socket!");
                _server.Stop();
            }
        }
        #endregion

        #region request handlers
        void HandleIncomingConnection(TcpClient client)
        {
            OnTcpServerMessage("TcpServer accepted incoming connection!");

            Byte[] bytes = new Byte[256];
            NetworkStream stream = client.GetStream();
            int byteCount = stream.Read(bytes, 0, bytes.Length);
            String requestData = System.Text.Encoding.ASCII.GetString(bytes, 0, byteCount);

            OnTcpServerMessage(String.Format("TCPServer Received Request: {0}", requestData));

            string dataOut = String.Empty;

            if (UseFileData)
                dataOut = HandleFileRequest(requestData);
            else
                dataOut = HandleLiveRequest(requestData);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(dataOut);

            stream.Write(msg, 0, msg.Length);

            client.Close();
        }

        string HandleFileRequest(string requestData)
        {
            return ReadFileData();
        }

        string HandleLiveRequest(string requestData)
        {
            string responseDate = String.Empty;
            switch (requestData)
            {
                case "DataSample":
                    {
                        var dataSample = _service.GetDataSample();
                        responseDate = JsonConvert.SerializeObject(dataSample);

                        if (dataSample.IsConnected)
                            SaveDataFile(dataSample.SessionData.WeekendInfo.TrackName, responseDate);
                        break;
                    }
                default:
                    {
                        OnTcpServerMessage(String.Format("*** Unrecognized Tcp Server request: {0}", requestData));
                        break;
                    }
            }
            return responseDate;
        }
        #endregion

        #region private methods
        int LoadFileLists()
        {
            int trackCount = 0;
            try
            {
                _trackFileLists = new Dictionary<string, SortedList<int, string>>();

                DirectoryInfo rootdi = new DirectoryInfo(FileDirectory);
                int insertIdx = 0;
                foreach (var di in rootdi.GetDirectories())
                {
                    var trackFiles = new SortedList<int, string>();
                    foreach (var fi in di.GetFiles("*.*", SearchOption.AllDirectories).OrderBy((f) => Convert.ToInt32(f.Name.Split('-')[0])))
                    {
                        trackFiles.Add(insertIdx++, fi.FullName);
                    }
                    _trackFileLists.Add(di.Name, trackFiles);
                }
                trackCount = _trackFileLists.Count();
            }
            catch (Exception ex)
            {
                OnTcpServerError(ex);
            }
            return trackCount;
        }

        void SaveDataFile(string trackName, string data)
        {
            if (!LogDataSamples) return;

            Task.Factory.StartNew(() =>
            {
                string outputDirectory = Path.Combine(FileDirectory, trackName);
                if (!Directory.Exists(outputDirectory))
                    Directory.CreateDirectory(outputDirectory);
                DataSampleIndex = System.IO.Directory.GetFiles(outputDirectory).Count() + 1;
                string fileName = String.Format(@"{0}\{1}-{2}.json", outputDirectory, DataSampleIndex.ToString(), trackName);
                System.IO.File.WriteAllText(fileName, data);
                CurrentTrack = trackName;
            });
        }

        string ReadFileData()
        {
            if (_trackFileLists == null || _trackFileLists.Count == 0)
            {
                if (0 == LoadFileLists())
                    throw new InvalidOperationException("No tracks files found!");
            }

            if (String.IsNullOrEmpty(CurrentTrack))
            {
                if (_trackFileLists.Count > 0)
                {
                    CurrentTrack = _trackFileLists.Keys.FirstOrDefault();
                    DataSampleIndex = 0;
                }
            }
            else if (!_trackFileLists.ContainsKey(CurrentTrack))
            {
                throw new ArgumentException("Track not in list");
            }
            else if (_trackFileLists[CurrentTrack].Count() == 0)
            {
                throw new ArgumentException("Track has no files");
            }

            var trackFileList = _trackFileLists[CurrentTrack];
            if (DataSampleIndex > trackFileList.Count() - 1)
            {
                DataSampleIndex = 0;
            }

            return System.IO.File.ReadAllText(trackFileList[DataSampleIndex++]);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            try
            {
                if (null != _server)
                {
                    if (null != _server.Server)
                    {
                        _server.Stop();
                        //_server.Server.Disconnect(false);
                        //_server.Server.Dispose();
                    }
                    _server = null;
                }
            }
            catch (Exception ex)
            {
                this.OnTcpServerError(ex);
            }
        }
        #endregion
    }
}
