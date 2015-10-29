using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.CrewChief.Server
{
    public partial class frmiRacingTcpServer : Form
    {
        enum ServerStatus
        {
            Stopped,
            Live,
            File,
            Error
        }

        TcpServerListener _listener;

        public frmiRacingTcpServer()
        {
            InitializeComponent();
            SetStatusMessage("Server loaded and ready...");
            LaunchFileServer();
        }

        public void LaunchLiveServer()
        {
            LaunchServer(false);
            SetStatus(ServerStatus.Live);
        }

        public void LaunchFileServer()
        {
            LaunchServer(true);
            SetStatus(ServerStatus.File);
        }

        public void StopServer()
        {
            if (null != _listener)
            {
                _listener.TcpServerMessage -= _listener_TcpServerMessage;
                _listener.TcpServerError -= _listener_TcpServerError;                  
                _listener.Dispose();             
            }
            SetStatus(ServerStatus.Stopped);
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            LaunchLiveServer();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            LaunchFileServer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        void SetStatus(ServerStatus newStatus)
        {
            string statusMessage = null;
            Color indicatorColor = Color.White;

            switch (newStatus)
            {
                case ServerStatus.Stopped:
                    {
                        statusMessage = "Server stopped";
                        indicatorColor = Color.DimGray;
                        btnFile.Enabled = true;
                        btnLive.Enabled = true;
                        btnStop.Enabled = false;
                        break;
                    }
                case ServerStatus.Live:
                    {
                        statusMessage = "Running Live server";
                        indicatorColor = Color.LimeGreen;
                        btnFile.Enabled = false;
                        btnLive.Enabled = false;
                        btnStop.Enabled = true;
                        break;
                    }
                case ServerStatus.File:
                    {
                        statusMessage = "Running File server";
                        indicatorColor = Color.Blue;
                        btnFile.Enabled = false;
                        btnLive.Enabled = false;
                        btnStop.Enabled = true;
                        break;
                    }
                case ServerStatus.Error:
                    {
                        indicatorColor = Color.Red;
                        break;
                    }
            }

            picStatus.BackColor = indicatorColor;

            if (null!=statusMessage)
                SetStatusMessage(statusMessage);
        }

        void SetStatusMessage(string status)
        {
            lblStatus.Text = status;
            string statusMessage = String.Format("{0}: {1}", DateTime.Now.ToString(), status);
            AddMessage(statusMessage);
        }

        void AddMessage(string message)
        {
            txtMessage.InvokeIfRequired(s => { 
                s.Text += message + "\r\n";
                s.SelectionStart = s.TextLength;
                s.ScrollToCaret();
            });
        }

        void ExceptionHandler(Exception ex)
        {
            AddMessage(String.Format("Exception: {0}", ex.Message));
            Console.WriteLine(ex.ToString());
        }

        void LaunchServer(bool useFileData)
        {
            try
            {
                StopServer();
                _listener = new TcpServerListener();
                _listener.TcpServerMessage += _listener_TcpServerMessage;
                _listener.TcpServerError += _listener_TcpServerError;
                _listener.UseFileData = useFileData;
                Task.Factory.StartNew(() => { _listener.Run(); });
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void _listener_TcpServerMessage(object sender, TcpServerMessageEventArgs e)
        {
            AddMessage(e.Message);
        }

        void _listener_TcpServerError(object sender, TcpServerErrorEventArgs e)
        {
            AddMessage(String.Format("TcpServer Exception: {0}", e.ErrorMessage));
            Console.WriteLine(e.StackTrace);
        }
    }

    public static class ControlHelpers
    {
        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)), null);
            }
            else
            {
                action(control);
            }
        }
    }
}
