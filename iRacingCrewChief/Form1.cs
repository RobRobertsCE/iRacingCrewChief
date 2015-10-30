using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iRacingCrewChief.Controls.ViewModels;

namespace iRacingCrewChief
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UpdateUI();
        }

        void UpdateUI()
        {
            try
            {
                this.sessionStatusView.ViewModel = new Controls.ViewModels.SessionStateViewModel()
                {
                    VehicleDescription = "Fast Car",
                    DriverName = "Rob Roberts",
                    SessionName = "Practice",
                    SetupName = "br-549",
                    SessionState = "Green",
                    SessionNumber = 1,
                    TrackName = "Orange County Speedway",
                    TrackLength = .375F,
                    WeatherSummary = "Sunny, 88*, 29.67 Hg rising",
                    IsFixedSetup = false,
                    CurrentLapNumber = 88,
                    SessionLapLimit = 126,
                    SessionTimeRemaining = new TimeSpan(1, 13, 44),
                    IsLapLimitedSession = true,
                    IsTimedSession = false
                };

                var d1 = new Controls.ViewModels.DriverViewModel()
                {
                    Name = "Rob Roberts",
                    LicenseLevel = "A",
                    SR = 2.37F,
                    iRating = 2000,
                    Vehicle = "SK Modified",
                    Team = "R2 Motorsports",
                    Club = "Carolinas"
                };
                this.driverView1.ViewModel = d1;

                var d2 = new Controls.ViewModels.DriverViewModel()
                {
                    Name = "John Smith",
                    LicenseLevel = "B",
                    SR = 1.22F,
                    iRating = 1354,
                    Vehicle = "SK Modified",
                    Team = "Broke Racing",
                    Club = "Sweden"
                };

                var d3 = new Controls.ViewModels.DriverViewModel()
                {
                    Name = "Cole Trickle",
                    LicenseLevel = "A",
                    SR = 3.99F,
                    iRating = 5625,
                    Vehicle = "SK Modified",
                    Team = "Hendrick Motorsports",
                    Club = "Carolinas"
                };

                var lap1 = new Controls.ViewModels.LapTimeViewModel()
                {
                    LapNumber = 7,
                    LapTime = 18.993F,
                    LapMPH = 98.234F
                };
                this.lapTimeView1.ViewModel = lap1;

                var lap2 = new Controls.ViewModels.LapTimeViewModel()
                {
                    LapNumber = 8,
                    LapTime = 18.813F,
                    LapMPH = 99.764F,
                    LastLap = lap1,
                    Interval = 0.3F
                };

                this.lapTimeView2.ViewModel = lap2;
                this.lapTimeView2.DisplayLapTimeDelta = false;

                var lap3 = new Controls.ViewModels.LapTimeViewModel()
                {
                    LapNumber = 9,
                    LapTime = 19.223F,
                    LapMPH = 96.299F,
                    LastLap = lap2,
                    Interval = 1.8F
                };
                this.lapTimeView3.ViewModel = lap3;
                this.lapTimeView3.DisplayLapMPHDelta = false;
                this.lapTimeView3.DisplayLapTimeDelta = false;
                this.lapTimeView3.DisplayLapMPH = false;

                var l1= new LeaderboardViewModel()
                {
                    Driver = d1,
                    Lap = lap1,
                    Position = 1,
                    ClassPosition = 1
                };
                this.leaderboardView1.ViewModel = l1;
                var l2 = new LeaderboardViewModel()
                {
                    Driver = d2,
                    Lap = lap2,
                    Position = 2,
                    ClassPosition = 2
                };
                this.leaderboardView2.ViewModel = l2;
                var l3 = new LeaderboardViewModel()
                {
                    Driver = d3,
                    Lap = lap3,
                    Position = 3,
                    ClassPosition = 3
                };
                this.leaderboardView3.ViewModel = l3;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
