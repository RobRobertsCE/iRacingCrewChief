
// This file is part of iRacingSDK.
//
// Copyright 2014 Dean Netherton
// https://github.com/vipoo/iRacingSDK.Net
//
// iRacingSDK is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// iRacingSDK is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with iRacingSDK.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using iRacing.Models.Cars;
using iRacing.Models.Sessions;
using iRacing.Models.Timing;
using Newtonsoft.Json;

namespace iRacing.Models.Telemetry
{
    [Serializable()]
    public partial class Telemetry : IDictionary<string, object>, ITelemetry
    {
        private IDictionary<string, object> _data = new Dictionary<string, object>();

        #region ctor

        public Telemetry()
        {
        }

        public Telemetry(SerializationInfo info, StreamingContext context)
        {

        }
        
        #endregion

        #region patrials
        public Session Session
        {
            get
            {
                if (SessionNum < 0 || SessionNum >= SessionData.SessionInfo.Sessions.Length)
                    return null;

                return SessionData.SessionInfo.Sessions[SessionNum];
            }
        }

        public Car CamCar { get { return Cars[CamCarIdx]; } }

        CarArray cars;
        public CarArray Cars
        {
            get
            {
                if (cars != null)
                    return cars;

                return cars = new CarArray(this);
            }
        }

        public CarDetails[] CarDetails { get { return Cars.Select(c => c.Details).ToArray(); } }

        public IEnumerable<Car> RaceCars
        {
            get
            {
                return Cars.Where(c => !c.Details.IsPaceCar);
            }
        }

        public bool UnderPaceCar
        {
            get
            {
                return this.CarIdxTrackSurface[0] == TrackLocation.OnTrack;
            }
        }

        float[] carIdxDistance;
        public float[] CarIdxDistance
        {
            get
            {
                if (carIdxDistance == null)
                    carIdxDistance = Enumerable.Range(0, 64)
                        .Select(CarIdx => this.CarIdxLap[CarIdx] + this.CarIdxLapDistPct[CarIdx])
                        .ToArray();

                return carIdxDistance;
            }
            internal set
            {
                carIdxDistance = value;
            }
        }
        int[] carIdxPitStopCount;
        public int[] CarIdxPitStopCount
        {
            get
            {
                return carIdxPitStopCount;
            }
            set
            {
                carIdxPitStopCount = value;
            }
        }
        LapSector[] carSectorIdx;
        public LapSector[] CarSectorIdx //0 -> Start/Finish, 1 -> 33%, 2-> 66%
        {
            get
            {
                if (carSectorIdx != null)
                    return carSectorIdx;

                carSectorIdx = new LapSector[64];
                for (int i = 0; i < 64; i++)
                    carSectorIdx[i] = new LapSector(this.CarIdxLap[i], ToSectorFromPercentage(CarIdxLapDistPct[i]));

                return carSectorIdx;
            }
        }

        static int ToSectorFromPercentage(float percentage)
        {
            if (percentage > 0.66)
                return 2;

            else if (percentage > 0.33)
                return 1;

            return 0;
        }

        public FastLap FastestLap { get; set; }

        public bool[] HasSeenCheckeredFlag { get; set; }
        public bool IsFinalLap { get; set; }
        public bool LeaderHasFinished { get; set; }
        public bool[] HasRetired { get; set; }

        public bool HasData(int carIdx)
        {
            return this.CarIdxTrackSurface[carIdx] != TrackLocation.NotInWorld;
        }

        int[] positions;
        public int[] Positions
        {
            get
            {
                if (positions != null)
                    return positions;

                positions = new int[64];

                var runningOrder = CarIdxDistance
                    .Select((d, idx) => new { CarIdx = idx, Distance = d })
                    .Where(d => d.Distance > 0)
                    .Where(c => c.CarIdx != 0)
                    .OrderByDescending(c => c.Distance)
                    .Select((c, order) => new { CarIdx = c.CarIdx, Position = order + 1, Distance = c.Distance })
                    .ToList();

                var maxRunningOrderIndex = runningOrder.Count == 0 ? 0 : runningOrder.Max(ro => ro.CarIdx);
                var maxSessionIndex = this.SessionData.DriverInfo.CompetingDrivers.Length;

                positions = new int[Math.Max(maxRunningOrderIndex, maxSessionIndex) + 1];

                positions[0] = int.MaxValue;
                foreach (var runner in runningOrder)
                    positions[runner.CarIdx] = runner.Position;

                var lastKnownPosition = (runningOrder.Count == 0 ? 0 : runningOrder.Max(ro => ro.Position)) + 1;
                for (var i = 0; i < positions.Length; i++)
                    if (positions[i] == 0)
                        positions[i] = lastKnownPosition++;

                return positions;
            }
        }
        float? raceDistance;

        public float RaceDistance
        {
            get
            {
                if (raceDistance != null)
                    return raceDistance.Value;

                raceDistance = this.CarIdxLap
                    .Select((lap, idx) => new { Lap = lap, Distance = lap + this.CarIdxLapDistPct[idx] })
                    .Max(l => l.Distance);

                if (raceDistance.Value < this.RaceLaps)
                {
                    Console.WriteLine("WARNING! No cars on current RaceLaps", "DEBUG");
                    return this.RaceLaps;
                }

                return raceDistance.Value;
            }
        }
        LapSector? _raceLapSector;
        public LapSector RaceLapSector
        {
            get
            {
                if (_raceLapSector != null)
                    return _raceLapSector.Value;

                var firstSector = this.CarIdxLap
                    .Select((lap, idx) => new { Lap = lap, Idx = idx, Pct = this.CarIdxLapDistPct[idx] })
                    .Where(l => l.Lap == this.RaceLaps)
                    .OrderByDescending(l => l.Pct)
                    .FirstOrDefault();

                if (firstSector == null)
                    return (_raceLapSector = new LapSector(this.RaceLaps, 2)).Value;

                return (_raceLapSector = new LapSector(this.RaceLaps, ToSectorFromPercentage(firstSector.Pct))).Value;
            }
        }
        TimeSpan? sessionTimeSpan;
        public TimeSpan SessionTimeSpan
        {
            get
            {
                if (sessionTimeSpan == null)
                    sessionTimeSpan = TimeSpan.FromSeconds(SessionTime);

                return sessionTimeSpan.Value;
            }
        }

        #endregion

        #region properties
        public SessionData SessionData { get; set; }

        /// <summary>
        /// Seconds since session start
        /// </summary>
        public System.Double SessionTime
        {
            get { return (System.Double)_data["SessionTime"]; }

            set { _data["SessionTime"] = value.ToString(); }
        }

        /// <summary>
        /// Session number
        /// </summary>
        public System.Int32 SessionNum
        {
            get { return (System.Int32)_data["SessionNum"]; }

            set { _data["SessionNum"] = value.ToString(); }
        }

        /// <summary>
        /// Session state
        /// </summary>
        public SessionState SessionState
        {
            get { return (SessionState)_data["SessionState"]; }

            set { _data["SessionState"] = value.ToString(); }
        }

        /// <summary>
        /// Session ID
        /// </summary>
        public System.Int32 SessionUniqueID
        {
            get { return (System.Int32)_data["SessionUniqueID"]; }

            set { _data["SessionUniqueID"] = value.ToString(); }
        }

        /// <summary>
        /// Session flags
        /// </summary>
        public SessionFlags SessionFlags
        {
            get { return (SessionFlags)_data["SessionFlags"]; }

            set { _data["SessionFlags"] = value.ToString(); }
        }

        /// <summary>
        /// Seconds left till session ends
        /// </summary>
        public System.Double SessionTimeRemain
        {
            get { return (System.Double)_data["SessionTimeRemain"]; }

            set { _data["SessionTimeRemain"] = value.ToString(); }
        }

        /// <summary>
        /// Laps left till session ends
        /// </summary>
        public System.Int32 SessionLapsRemain
        {
            get { return (System.Int32)_data["SessionLapsRemain"]; }

            set { _data["SessionLapsRemain"] = value.ToString(); }
        }

        /// <summary>
        /// The car index of the current person speaking on the radio
        /// </summary>
        public System.Int32 RadioTransmitCarIdx
        {
            get { return (System.Int32)_data["RadioTransmitCarIdx"]; }

            set { _data["RadioTransmitCarIdx"] = value.ToString(); }
        }

        /// <summary>
        /// The radio index of the current person speaking on the radio
        /// </summary>
        public System.Int32 RadioTransmitRadioIdx
        {
            get { return (System.Int32)_data["RadioTransmitRadioIdx"]; }

            set { _data["RadioTransmitRadioIdx"] = value.ToString(); }
        }

        /// <summary>
        /// The frequency index of the current person speaking on the radio
        /// </summary>
        public System.Int32 RadioTransmitFrequencyIdx
        {
            get { return (System.Int32)_data["RadioTransmitFrequencyIdx"]; }

            set { _data["RadioTransmitFrequencyIdx"] = value.ToString(); }
        }

        /// <summary>
        /// Default units for the user interface 0 = english 1 = metric
        /// </summary>
        public System.Int32 DisplayUnits
        {
            get { return (System.Int32)_data["DisplayUnits"]; }

            set { _data["DisplayUnits"] = value.ToString(); }
        }

        /// <summary>
        /// Driver activated flag
        /// </summary>
        public System.Boolean DriverMarker
        {
            get { return (System.Boolean)_data["DriverMarker"]; }

            set { _data["DriverMarker"] = value.ToString(); }
        }

        /// <summary>
        /// 1=Car on track physics running with player in car
        /// </summary>
        public System.Boolean IsOnTrack
        {
            get { return (System.Boolean)_data["IsOnTrack"]; }

            set { _data["IsOnTrack"] = value.ToString(); }
        }

        /// <summary>
        /// 0=replay not playing  1=replay playing
        /// </summary>
        public System.Boolean IsReplayPlaying
        {
            get { return (System.Boolean)_data["IsReplayPlaying"]; }

            set { _data["IsReplayPlaying"] = value.ToString(); }
        }

        /// <summary>
        /// Integer replay frame number (60 per second)
        /// </summary>
        public System.Int32 ReplayFrameNum
        {
            get { return (System.Int32)_data["ReplayFrameNum"]; }

            set { _data["ReplayFrameNum"] = value.ToString(); }
        }

        /// <summary>
        /// Integer replay frame number from end of tape
        /// </summary>
        public System.Int32 ReplayFrameNumEnd
        {
            get { return (System.Int32)_data["ReplayFrameNumEnd"]; }

            set { _data["ReplayFrameNumEnd"] = value.ToString(); }
        }

        /// <summary>
        /// 0=disk based telemetry turned off  1=turned on
        /// </summary>
        public System.Boolean IsDiskLoggingEnabled
        {
            get { return (System.Boolean)_data["IsDiskLoggingEnabled"]; }

            set { _data["IsDiskLoggingEnabled"] = value.ToString(); }
        }

        /// <summary>
        /// 0=disk based telemetry file not being written  1=being written
        /// </summary>
        public System.Boolean IsDiskLoggingActive
        {
            get { return (System.Boolean)_data["IsDiskLoggingActive"]; }

            set { _data["IsDiskLoggingActive"] = value.ToString(); }
        }

        /// <summary>
        /// Average frames per second
        /// </summary>
        public System.Single FrameRate
        {
            get { return (System.Single)_data["FrameRate"]; }

            set { _data["FrameRate"] = value.ToString(); }
        }

        /// <summary>
        /// Percent of available tim bg thread took with a 1 sec avg
        /// </summary>
        public System.Single CpuUsageBG
        {
            get { return (System.Single)_data["CpuUsageBG"]; }

            set { _data["CpuUsageBG"] = value.ToString(); }
        }

        /// <summary>
        /// Players position in race
        /// </summary>
        public System.Int32 PlayerCarPosition
        {
            get { return (System.Int32)_data["PlayerCarPosition"]; }

            set { _data["PlayerCarPosition"] = value.ToString(); }
        }

        /// <summary>
        /// Players class position in race
        /// </summary>
        public System.Int32 PlayerCarClassPosition
        {
            get { return (System.Int32)_data["PlayerCarClassPosition"]; }

            set { _data["PlayerCarClassPosition"] = value.ToString(); }
        }

        /// <summary>
        /// Lap count by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxLap
        {
            get { return (System.Int32[])_data["CarIdxLap"]; }

            set { _data["CarIdxLap"] = value.ToString(); }
        }

        /// <summary>
        /// Percentage distance around lap by car index
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxLapDistPct
        {
            get { return (System.Single[])_data["CarIdxLapDistPct"]; }

            set { _data["CarIdxLapDistPct"] = value.ToString(); }
        }

        /// <summary>
        /// Track surface type by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public TrackLocation[] CarIdxTrackSurface
        {
            get { return (TrackLocation[])_data["CarIdxTrackSurface"]; }

            set { _data["CarIdxTrackSurface"] = value.ToString(); }
        }

        /// <summary>
        /// On pit road between the cones by car index
        /// </summary>
        [JsonConverter(typeof(BooleanArrayConverter))]
        public System.Boolean[] CarIdxOnPitRoad
        {
            get { return (System.Boolean[])_data["CarIdxOnPitRoad"]; }

            set { _data["CarIdxOnPitRoad"] = value.ToString(); }
        }

        /// <summary>
        /// Cars position in race by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxPosition
        {
            get { return (System.Int32[])_data["CarIdxPosition"]; }

            set { _data["CarIdxPosition"] = value.ToString(); }
        }

        /// <summary>
        /// Cars class position in race by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxClassPosition
        {
            get { return (System.Int32[])_data["CarIdxClassPosition"]; }

            set { _data["CarIdxClassPosition"] = value.ToString(); }
        }

        /// <summary>
        /// Race time behind leader or fastest lap time otherwise
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxF2Time
        {
            get { return (System.Single[])_data["CarIdxF2Time"]; }

            set { _data["CarIdxF2Time"] = value.ToString(); }
        }

        /// <summary>
        /// Estimated time to reach current location on track
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxEstTime
        {
            get { return (System.Single[])_data["CarIdxEstTime"]; }

            set { _data["CarIdxEstTime"] = value.ToString(); }
        }

        /// <summary>
        /// Is the player car on pit road between the cones
        /// </summary>
        public System.Boolean OnPitRoad
        {
            get { return (System.Boolean)_data["OnPitRoad"]; }

            set { _data["OnPitRoad"] = value.ToString(); }
        }

        /// <summary>
        /// Steering wheel angle by car index
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxSteer
        {
            get { return (System.Single[])_data["CarIdxSteer"]; }

            set { _data["CarIdxSteer"] = value.ToString(); }
        }

        /// <summary>
        /// Engine rpm by car index
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxRPM
        {
            get { return (System.Single[])_data["CarIdxRPM"]; }

            set { _data["CarIdxRPM"] = value.ToString(); }
        }

        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxGear
        {
            get { return (System.Int32[])_data["CarIdxGear"]; }

            set { _data["CarIdxGear"] = value.ToString(); }
        }

        /// <summary>
        /// Steering wheel angle
        /// </summary>
        public System.Single SteeringWheelAngle
        {
            get { return (System.Single)_data["SteeringWheelAngle"]; }

            set { _data["SteeringWheelAngle"] = value.ToString(); }
        }

        /// <summary>
        /// 0=off throttle to 1=full throttle
        /// </summary>
        public System.Single Throttle
        {
            get { return (System.Single)_data["Throttle"]; }

            set { _data["Throttle"] = value.ToString(); }
        }

        /// <summary>
        /// 0=brake released to 1=max pedal force
        /// </summary>
        public System.Single Brake
        {
            get { return (System.Single)_data["Brake"]; }

            set { _data["Brake"] = value.ToString(); }
        }

        /// <summary>
        /// 0=disengaged to 1=fully engaged
        /// </summary>
        public System.Single Clutch
        {
            get { return (System.Single)_data["Clutch"]; }

            set { _data["Clutch"] = value.ToString(); }
        }

        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear
        /// </summary>
        public System.Int32 Gear
        {
            get { return (System.Int32)_data["Gear"]; }

            set { _data["Gear"] = value.ToString(); }
        }

        /// <summary>
        /// Engine rpm
        /// </summary>
        public System.Single RPM
        {
            get { return (System.Single)_data["RPM"]; }

            set { _data["RPM"] = value.ToString(); }
        }

        /// <summary>
        /// Lap count
        /// </summary>
        public System.Int32 Lap
        {
            get { return (System.Int32)_data["Lap"]; }

            set { _data["Lap"] = value.ToString(); }
        }

        /// <summary>
        /// Meters traveled from S/F this lap
        /// </summary>
        public System.Single LapDist
        {
            get { return (System.Single)_data["LapDist"]; }

            set { _data["LapDist"] = value.ToString(); }
        }

        /// <summary>
        /// Percentage distance around lap
        /// </summary>
        public System.Single LapDistPct
        {
            get { return (System.Single)_data["LapDistPct"]; }

            set { _data["LapDistPct"] = value.ToString(); }
        }

        /// <summary>
        /// Laps completed in race
        /// </summary>
        public System.Int32 RaceLaps
        {
            get { return (System.Int32)_data["RaceLaps"]; }

            set { _data["RaceLaps"] = value.ToString(); }
        }

        /// <summary>
        /// Players best lap number
        /// </summary>
        public System.Int32 LapBestLap
        {
            get { return (System.Int32)_data["LapBestLap"]; }

            set { _data["LapBestLap"] = value.ToString(); }
        }

        /// <summary>
        /// Players best lap time
        /// </summary>
        public System.Single LapBestLapTime
        {
            get { return (System.Single)_data["LapBestLapTime"]; }

            set { _data["LapBestLapTime"] = value.ToString(); }
        }

        /// <summary>
        /// Players last lap time
        /// </summary>
        public System.Single LapLastLapTime
        {
            get { return (System.Single)_data["LapLastLapTime"]; }

            set { _data["LapLastLapTime"] = value.ToString(); }
        }

        /// <summary>
        /// Estimate of players current lap time as shown in F3 box
        /// </summary>
        public System.Single LapCurrentLapTime
        {
            get { return (System.Single)_data["LapCurrentLapTime"]; }

            set { _data["LapCurrentLapTime"] = value.ToString(); }
        }

        /// <summary>
        /// Player num consecutive clean laps completed for N average
        /// </summary>
        public System.Int32 LapLasNLapSeq
        {
            get { return (System.Int32)_data["LapLasNLapSeq"]; }

            set { _data["LapLasNLapSeq"] = value.ToString(); }
        }

        /// <summary>
        /// Player last N average lap time
        /// </summary>
        public System.Single LapLastNLapTime
        {
            get { return (System.Single)_data["LapLastNLapTime"]; }

            set { _data["LapLastNLapTime"] = value.ToString(); }
        }

        /// <summary>
        /// Player last lap in best N average lap time
        /// </summary>
        public System.Int32 LapBestNLapLap
        {
            get { return (System.Int32)_data["LapBestNLapLap"]; }

            set { _data["LapBestNLapLap"] = value.ToString(); }
        }

        /// <summary>
        /// Player best N average lap time
        /// </summary>
        public System.Single LapBestNLapTime
        {
            get { return (System.Single)_data["LapBestNLapTime"]; }

            set { _data["LapBestNLapTime"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for best lap
        /// </summary>
        public System.Single LapDeltaToBestLap
        {
            get { return (System.Single)_data["LapDeltaToBestLap"]; }

            set { _data["LapDeltaToBestLap"] = value.ToString(); }
        }

        /// <summary>
        /// Rate of change of delta time for best lap
        /// </summary>
        public System.Single LapDeltaToBestLap_DD
        {
            get { return (System.Single)_data["LapDeltaToBestLap_DD"]; }

            set { _data["LapDeltaToBestLap_DD"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for best lap is valid
        /// </summary>
        public System.Boolean LapDeltaToBestLap_OK
        {
            get { return (System.Boolean)_data["LapDeltaToBestLap_OK"]; }

            set { _data["LapDeltaToBestLap_OK"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for optimal lap
        /// </summary>
        public System.Single LapDeltaToOptimalLap
        {
            get { return (System.Single)_data["LapDeltaToOptimalLap"]; }

            set { _data["LapDeltaToOptimalLap"] = value.ToString(); }
        }

        /// <summary>
        /// Rate of change of delta time for optimal lap
        /// </summary>
        public System.Single LapDeltaToOptimalLap_DD
        {
            get { return (System.Single)_data["LapDeltaToOptimalLap_DD"]; }

            set { _data["LapDeltaToOptimalLap_DD"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for optimal lap is valid
        /// </summary>
        public System.Boolean LapDeltaToOptimalLap_OK
        {
            get { return (System.Boolean)_data["LapDeltaToOptimalLap_OK"]; }

            set { _data["LapDeltaToOptimalLap_OK"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for session best lap
        /// </summary>
        public System.Single LapDeltaToSessionBestLap
        {
            get { return (System.Single)_data["LapDeltaToSessionBestLap"]; }

            set { _data["LapDeltaToSessionBestLap"] = value.ToString(); }
        }

        /// <summary>
        /// Rate of change of delta time for session best lap
        /// </summary>
        public System.Single LapDeltaToSessionBestLap_DD
        {
            get { return (System.Single)_data["LapDeltaToSessionBestLap_DD"]; }

            set { _data["LapDeltaToSessionBestLap_DD"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for session best lap is valid
        /// </summary>
        public System.Boolean LapDeltaToSessionBestLap_OK
        {
            get { return (System.Boolean)_data["LapDeltaToSessionBestLap_OK"]; }

            set { _data["LapDeltaToSessionBestLap_OK"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for session optimal lap
        /// </summary>
        public System.Single LapDeltaToSessionOptimalLap
        {
            get { return (System.Single)_data["LapDeltaToSessionOptimalLap"]; }

            set { _data["LapDeltaToSessionOptimalLap"] = value.ToString(); }
        }

        /// <summary>
        /// Rate of change of delta time for session optimal lap
        /// </summary>
        public System.Single LapDeltaToSessionOptimalLap_DD
        {
            get { return (System.Single)_data["LapDeltaToSessionOptimalLap_DD"]; }

            set { _data["LapDeltaToSessionOptimalLap_DD"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for session optimal lap is valid
        /// </summary>
        public System.Boolean LapDeltaToSessionOptimalLap_OK
        {
            get { return (System.Boolean)_data["LapDeltaToSessionOptimalLap_OK"]; }

            set { _data["LapDeltaToSessionOptimalLap_OK"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for session last lap
        /// </summary>
        public System.Single LapDeltaToSessionLastlLap
        {
            get { return (System.Single)_data["LapDeltaToSessionLastlLap"]; }

            set { _data["LapDeltaToSessionLastlLap"] = value.ToString(); }
        }

        /// <summary>
        /// Rate of change of delta time for session last lap
        /// </summary>
        public System.Single LapDeltaToSessionLastlLap_DD
        {
            get { return (System.Single)_data["LapDeltaToSessionLastlLap_DD"]; }

            set { _data["LapDeltaToSessionLastlLap_DD"] = value.ToString(); }
        }

        /// <summary>
        /// Delta time for session last lap is valid
        /// </summary>
        public System.Boolean LapDeltaToSessionLastlLap_OK
        {
            get { return (System.Boolean)_data["LapDeltaToSessionLastlLap_OK"]; }

            set { _data["LapDeltaToSessionLastlLap_OK"] = value.ToString(); }
        }

        /// <summary>
        /// Longitudinal acceleration (including gravity)
        /// </summary>
        public System.Single LongAccel
        {
            get { return (System.Single)_data["LongAccel"]; }

            set { _data["LongAccel"] = value.ToString(); }
        }

        /// <summary>
        /// Lateral acceleration (including gravity)
        /// </summary>
        public System.Single LatAccel
        {
            get { return (System.Single)_data["LatAccel"]; }

            set { _data["LatAccel"] = value.ToString(); }
        }

        /// <summary>
        /// Vertical acceleration (including gravity)
        /// </summary>
        public System.Single VertAccel
        {
            get { return (System.Single)_data["VertAccel"]; }

            set { _data["VertAccel"] = value.ToString(); }
        }

        /// <summary>
        /// Roll rate
        /// </summary>
        public System.Single RollRate
        {
            get { return (System.Single)_data["RollRate"]; }

            set { _data["RollRate"] = value.ToString(); }
        }

        /// <summary>
        /// Pitch rate
        /// </summary>
        public System.Single PitchRate
        {
            get { return (System.Single)_data["PitchRate"]; }

            set { _data["PitchRate"] = value.ToString(); }
        }

        /// <summary>
        /// Yaw rate
        /// </summary>
        public System.Single YawRate
        {
            get { return (System.Single)_data["YawRate"]; }

            set { _data["YawRate"] = value.ToString(); }
        }

        /// <summary>
        /// GPS vehicle speed
        /// </summary>
        public System.Single Speed
        {
            get { return (System.Single)_data["Speed"]; }

            set { _data["Speed"] = value.ToString(); }
        }

        /// <summary>
        /// X velocity
        /// </summary>
        public System.Single VelocityX
        {
            get { return (System.Single)_data["VelocityX"]; }

            set { _data["VelocityX"] = value.ToString(); }
        }

        /// <summary>
        /// Y velocity
        /// </summary>
        public System.Single VelocityY
        {
            get { return (System.Single)_data["VelocityY"]; }

            set { _data["VelocityY"] = value.ToString(); }
        }

        /// <summary>
        /// Z velocity
        /// </summary>
        public System.Single VelocityZ
        {
            get { return (System.Single)_data["VelocityZ"]; }

            set { _data["VelocityZ"] = value.ToString(); }
        }

        /// <summary>
        /// Yaw orientation
        /// </summary>
        public System.Single Yaw
        {
            get { return (System.Single)_data["Yaw"]; }

            set { _data["Yaw"] = value.ToString(); }
        }

        /// <summary>
        /// Pitch orientation
        /// </summary>
        public System.Single Pitch
        {
            get { return (System.Single)_data["Pitch"]; }

            set { _data["Pitch"] = value.ToString(); }
        }

        /// <summary>
        /// Roll orientation
        /// </summary>
        public System.Single Roll
        {
            get { return (System.Single)_data["Roll"]; }

            set { _data["Roll"] = value.ToString(); }
        }

        /// <summary>
        /// Indicate action the reset key will take 0 enter 1 exit 2 reset
        /// </summary>
        public System.Int32 EnterExitReset
        {
            get { return (System.Int32)_data["EnterExitReset"]; }

            set { _data["EnterExitReset"] = value.ToString(); }
        }

        /// <summary>
        /// Temperature of track at start/finish line
        /// </summary>
        public System.Single TrackTemp
        {
            get { return (System.Single)_data["TrackTemp"]; }

            set { _data["TrackTemp"] = value.ToString(); }
        }

        /// <summary>
        /// Temperature of air at start/finish line
        /// </summary>
        public System.Single AirTemp
        {
            get { return (System.Single)_data["AirTemp"]; }

            set { _data["AirTemp"] = value.ToString(); }
        }

        /// <summary>
        /// Weather type (0=constant  1=dynamic)
        /// </summary>
        public System.Int32 WeatherType
        {
            get { return (System.Int32)_data["WeatherType"]; }

            set { _data["WeatherType"] = value.ToString(); }
        }

        /// <summary>
        /// Skies (0=clear/1=p cloudy/2=m cloudy/3=overcast)
        /// </summary>
        public System.Int32 Skies
        {
            get { return (System.Int32)_data["Skies"]; }

            set { _data["Skies"] = value.ToString(); }
        }

        /// <summary>
        /// Density of air at start/finish line
        /// </summary>
        public System.Single AirDensity
        {
            get { return (System.Single)_data["AirDensity"]; }

            set { _data["AirDensity"] = value.ToString(); }
        }

        /// <summary>
        /// Pressure of air at start/finish line
        /// </summary>
        public System.Single AirPressure
        {
            get { return (System.Single)_data["AirPressure"]; }

            set { _data["AirPressure"] = value.ToString(); }
        }

        /// <summary>
        /// Wind velocity at start/finish line
        /// </summary>
        public System.Single WindVel
        {
            get { return (System.Single)_data["WindVel"]; }

            set { _data["WindVel"] = value.ToString(); }
        }

        /// <summary>
        /// Wind direction at start/finish line
        /// </summary>
        public System.Single WindDir
        {
            get { return (System.Single)_data["WindDir"]; }

            set { _data["WindDir"] = value.ToString(); }
        }

        /// <summary>
        /// Relative Humidity
        /// </summary>
        public System.Single RelativeHumidity
        {
            get { return (System.Single)_data["RelativeHumidity"]; }

            set { _data["RelativeHumidity"] = value.ToString(); }
        }

        /// <summary>
        /// Fog level
        /// </summary>
        public System.Single FogLevel
        {
            get { return (System.Single)_data["FogLevel"]; }

            set { _data["FogLevel"] = value.ToString(); }
        }

        /// <summary>
        /// Status of driver change lap requirements
        /// </summary>
        public System.Int32 DCLapStatus
        {
            get { return (System.Int32)_data["DCLapStatus"]; }

            set { _data["DCLapStatus"] = value.ToString(); }
        }

        /// <summary>
        /// Number of team drivers who have run a stint
        /// </summary>
        public System.Int32 DCDriversSoFar
        {
            get { return (System.Int32)_data["DCDriversSoFar"]; }

            set { _data["DCDriversSoFar"] = value.ToString(); }
        }

        /// <summary>
        /// Time left for mandatory pit repairs if repairs are active
        /// </summary>
        public System.Single PitRepairLeft
        {
            get { return (System.Single)_data["PitRepairLeft"]; }

            set { _data["PitRepairLeft"] = value.ToString(); }
        }

        /// <summary>
        /// Time left for optional repairs if repairs are active
        /// </summary>
        public System.Single PitOptRepairLeft
        {
            get { return (System.Single)_data["PitOptRepairLeft"]; }

            set { _data["PitOptRepairLeft"] = value.ToString(); }
        }

        /// <summary>
        /// Active camera's focus car index
        /// </summary>
        public System.Int32 CamCarIdx
        {
            get { return (System.Int32)_data["CamCarIdx"]; }

            set { _data["CamCarIdx"] = value.ToString(); }
        }

        /// <summary>
        /// Active camera number
        /// </summary>
        public System.Int32 CamCameraNumber
        {
            get { return (System.Int32)_data["CamCameraNumber"]; }

            set { _data["CamCameraNumber"] = value.ToString(); }
        }

        /// <summary>
        /// Active camera group number
        /// </summary>
        public System.Int32 CamGroupNumber
        {
            get { return (System.Int32)_data["CamGroupNumber"]; }

            set { _data["CamGroupNumber"] = value.ToString(); }
        }

        /// <summary>
        /// State of camera system
        /// </summary>
        public System.Int32 CamCameraState
        {
            get { return (System.Int32)_data["CamCameraState"]; }

            set { _data["CamCameraState"] = value.ToString(); }
        }

        /// <summary>
        /// 1=Car on track physics running
        /// </summary>
        public System.Boolean IsOnTrackCar
        {
            get { return (System.Boolean)_data["IsOnTrackCar"]; }

            set { _data["IsOnTrackCar"] = value.ToString(); }
        }

        /// <summary>
        /// 1=Car in garage physics running
        /// </summary>
        public System.Boolean IsInGarage
        {
            get { return (System.Boolean)_data["IsInGarage"]; }

            set { _data["IsInGarage"] = value.ToString(); }
        }

        /// <summary>
        /// Output torque on steering shaft
        /// </summary>
        public System.Single SteeringWheelTorque
        {
            get { return (System.Single)_data["SteeringWheelTorque"]; }

            set { _data["SteeringWheelTorque"] = value.ToString(); }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft unsigned
        /// </summary>
        public System.Single SteeringWheelPctTorque
        {
            get { return (System.Single)_data["SteeringWheelPctTorque"]; }

            set { _data["SteeringWheelPctTorque"] = value.ToString(); }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed
        /// </summary>
        public System.Single SteeringWheelPctTorqueSign
        {
            get { return (System.Single)_data["SteeringWheelPctTorqueSign"]; }

            set { _data["SteeringWheelPctTorqueSign"] = value.ToString(); }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed stops
        /// </summary>
        public System.Single SteeringWheelPctTorqueSignStops
        {
            get { return (System.Single)_data["SteeringWheelPctTorqueSignStops"]; }

            set { _data["SteeringWheelPctTorqueSignStops"] = value.ToString(); }
        }

        /// <summary>
        /// Force feedback % max damping
        /// </summary>
        public System.Single SteeringWheelPctDamper
        {
            get { return (System.Single)_data["SteeringWheelPctDamper"]; }

            set { _data["SteeringWheelPctDamper"] = value.ToString(); }
        }

        /// <summary>
        /// Steering wheel max angle
        /// </summary>
        public System.Single SteeringWheelAngleMax
        {
            get { return (System.Single)_data["SteeringWheelAngleMax"]; }

            set { _data["SteeringWheelAngleMax"] = value.ToString(); }
        }

        /// <summary>
        /// DEPRECATED use DriverCarSLBlinkRPM instead
        /// </summary>
        public System.Single ShiftIndicatorPct
        {
            get { return (System.Single)_data["ShiftIndicatorPct"]; }

            set { _data["ShiftIndicatorPct"] = value.ToString(); }
        }

        /// <summary>
        /// Friction torque applied to gears when shifting or grinding
        /// </summary>
        public System.Single ShiftPowerPct
        {
            get { return (System.Single)_data["ShiftPowerPct"]; }

            set { _data["ShiftPowerPct"] = value.ToString(); }
        }

        /// <summary>
        /// RPM of shifter grinding noise
        /// </summary>
        public System.Single ShiftGrindRPM
        {
            get { return (System.Single)_data["ShiftGrindRPM"]; }

            set { _data["ShiftGrindRPM"] = value.ToString(); }
        }

        /// <summary>
        /// Raw throttle input 0=off throttle to 1=full throttle
        /// </summary>
        public System.Single ThrottleRaw
        {
            get { return (System.Single)_data["ThrottleRaw"]; }

            set { _data["ThrottleRaw"] = value.ToString(); }
        }

        /// <summary>
        /// Raw brake input 0=brake released to 1=max pedal force
        /// </summary>
        public System.Single BrakeRaw
        {
            get { return (System.Single)_data["BrakeRaw"]; }

            set { _data["BrakeRaw"] = value.ToString(); }
        }

        /// <summary>
        /// Peak torque mapping to direct input units for FFB
        /// </summary>
        public System.Single SteeringWheelPeakForceNm
        {
            get { return (System.Single)_data["SteeringWheelPeakForceNm"]; }

            set { _data["SteeringWheelPeakForceNm"] = value.ToString(); }
        }

        /// <summary>
        /// Bitfield for warning lights
        /// </summary>
        public System.Int32 EngineWarnings
        {
            get { return (System.Int32)_data["EngineWarnings"]; }

            set { _data["EngineWarnings"] = value.ToString(); }
        }

        /// <summary>
        /// Liters of fuel remaining
        /// </summary>
        public System.Single FuelLevel
        {
            get { return (System.Single)_data["FuelLevel"]; }

            set { _data["FuelLevel"] = value.ToString(); }
        }

        /// <summary>
        /// Percent fuel remaining
        /// </summary>
        public System.Single FuelLevelPct
        {
            get { return (System.Single)_data["FuelLevelPct"]; }

            set { _data["FuelLevelPct"] = value.ToString(); }
        }

        /// <summary>
        /// Bitfield of pit service checkboxes
        /// </summary>
        public System.Int32 PitSvFlags
        {
            get { return (System.Int32)_data["PitSvFlags"]; }

            set { _data["PitSvFlags"] = value.ToString(); }
        }

        /// <summary>
        /// Pit service left front tire pressure
        /// </summary>
        public System.Single PitSvLFP
        {
            get { return (System.Single)_data["PitSvLFP"]; }

            set { _data["PitSvLFP"] = value.ToString(); }
        }

        /// <summary>
        /// Pit service right front tire pressure
        /// </summary>
        public System.Single PitSvRFP
        {
            get { return (System.Single)_data["PitSvRFP"]; }

            set { _data["PitSvRFP"] = value.ToString(); }
        }

        /// <summary>
        /// Pit service left rear tire pressure
        /// </summary>
        public System.Single PitSvLRP
        {
            get { return (System.Single)_data["PitSvLRP"]; }

            set { _data["PitSvLRP"] = value.ToString(); }
        }

        /// <summary>
        /// Pit service right rear tire pressure
        /// </summary>
        public System.Single PitSvRRP
        {
            get { return (System.Single)_data["PitSvRRP"]; }

            set { _data["PitSvRRP"] = value.ToString(); }
        }

        /// <summary>
        /// Pit service fuel add amount
        /// </summary>
        public System.Single PitSvFuel
        {
            get { return (System.Single)_data["PitSvFuel"]; }

            set { _data["PitSvFuel"] = value.ToString(); }
        }

        /// <summary>
        /// Replay playback speed
        /// </summary>
        public System.Int32 ReplayPlaySpeed
        {
            get { return (System.Int32)_data["ReplayPlaySpeed"]; }

            set { _data["ReplayPlaySpeed"] = value.ToString(); }
        }

        /// <summary>
        /// 0=not slow motion  1=replay is in slow motion
        /// </summary>
        public System.Boolean ReplayPlaySlowMotion
        {
            get { return (System.Boolean)_data["ReplayPlaySlowMotion"]; }

            set { _data["ReplayPlaySlowMotion"] = value.ToString(); }
        }

        /// <summary>
        /// Seconds since replay session start
        /// </summary>
        public System.Double ReplaySessionTime
        {
            get { return (System.Double)_data["ReplaySessionTime"]; }

            set { _data["ReplaySessionTime"] = value.ToString(); }
        }

        /// <summary>
        /// Replay session number
        /// </summary>
        public System.Int32 ReplaySessionNum
        {
            get { return (System.Int32)_data["ReplaySessionNum"]; }

            set { _data["ReplaySessionNum"] = value.ToString(); }
        }

        /// <summary>
        /// Pitstop qtape adjustment
        /// </summary>
        public System.Single dpQtape
        {
            get { return (System.Single)_data["dpQtape"]; }

            set { _data["dpQtape"] = value.ToString(); }
        }

        /// <summary>
        /// In car brake bias adjustment
        /// </summary>
        public System.Single dcBrakeBias
        {
            get { return (System.Single)_data["dcBrakeBias"]; }

            set { _data["dcBrakeBias"] = value.ToString(); }
        }

        /// <summary>
        /// Engine coolant temp
        /// </summary>
        public System.Single WaterTemp
        {
            get { return (System.Single)_data["WaterTemp"]; }

            set { _data["WaterTemp"] = value.ToString(); }
        }

        /// <summary>
        /// Engine coolant level
        /// </summary>
        public System.Single WaterLevel
        {
            get { return (System.Single)_data["WaterLevel"]; }

            set { _data["WaterLevel"] = value.ToString(); }
        }

        /// <summary>
        /// Engine fuel pressure
        /// </summary>
        public System.Single FuelPress
        {
            get { return (System.Single)_data["FuelPress"]; }

            set { _data["FuelPress"] = value.ToString(); }
        }

        /// <summary>
        /// Engine oil temperature
        /// </summary>
        public System.Single OilTemp
        {
            get { return (System.Single)_data["OilTemp"]; }

            set { _data["OilTemp"] = value.ToString(); }
        }

        /// <summary>
        /// Engine oil pressure
        /// </summary>
        public System.Single OilPress
        {
            get { return (System.Single)_data["OilPress"]; }

            set { _data["OilPress"] = value.ToString(); }
        }

        /// <summary>
        /// Engine oil level
        /// </summary>
        public System.Single OilLevel
        {
            get { return (System.Single)_data["OilLevel"]; }

            set { _data["OilLevel"] = value.ToString(); }
        }

        /// <summary>
        /// Engine voltage
        /// </summary>
        public System.Single Voltage
        {
            get { return (System.Single)_data["Voltage"]; }

            set { _data["Voltage"] = value.ToString(); }
        }

        /// <summary>
        /// Engine manifold pressure
        /// </summary>
        public System.Single ManifoldPress
        {
            get { return (System.Single)_data["ManifoldPress"]; }

            set { _data["ManifoldPress"] = value.ToString(); }
        }

        /// <summary>
        /// RR brake line pressure
        /// </summary>
        public System.Single RRbrakeLinePress
        {
            get { return (System.Single)_data["RRbrakeLinePress"]; }

            set { _data["RRbrakeLinePress"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire cold pressure  as set in the garage
        /// </summary>
        public System.Single RRcoldPressure
        {
            get { return (System.Single)_data["RRcoldPressure"]; }

            set { _data["RRcoldPressure"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire left carcass temperature
        /// </summary>
        public System.Single RRtempCL
        {
            get { return (System.Single)_data["RRtempCL"]; }

            set { _data["RRtempCL"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire middle carcass temperature
        /// </summary>
        public System.Single RRtempCM
        {
            get { return (System.Single)_data["RRtempCM"]; }

            set { _data["RRtempCM"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire right carcass temperature
        /// </summary>
        public System.Single RRtempCR
        {
            get { return (System.Single)_data["RRtempCR"]; }

            set { _data["RRtempCR"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire left percent tread remaining
        /// </summary>
        public System.Single RRwearL
        {
            get { return (System.Single)_data["RRwearL"]; }

            set { _data["RRwearL"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire middle percent tread remaining
        /// </summary>
        public System.Single RRwearM
        {
            get { return (System.Single)_data["RRwearM"]; }

            set { _data["RRwearM"] = value.ToString(); }
        }

        /// <summary>
        /// RR tire right percent tread remaining
        /// </summary>
        public System.Single RRwearR
        {
            get { return (System.Single)_data["RRwearR"]; }

            set { _data["RRwearR"] = value.ToString(); }
        }

        /// <summary>
        /// LR brake line pressure
        /// </summary>
        public System.Single LRbrakeLinePress
        {
            get { return (System.Single)_data["LRbrakeLinePress"]; }

            set { _data["LRbrakeLinePress"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire cold pressure  as set in the garage
        /// </summary>
        public System.Single LRcoldPressure
        {
            get { return (System.Single)_data["LRcoldPressure"]; }

            set { _data["LRcoldPressure"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire left carcass temperature
        /// </summary>
        public System.Single LRtempCL
        {
            get { return (System.Single)_data["LRtempCL"]; }

            set { _data["LRtempCL"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire middle carcass temperature
        /// </summary>
        public System.Single LRtempCM
        {
            get { return (System.Single)_data["LRtempCM"]; }

            set { _data["LRtempCM"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire right carcass temperature
        /// </summary>
        public System.Single LRtempCR
        {
            get { return (System.Single)_data["LRtempCR"]; }

            set { _data["LRtempCR"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire left percent tread remaining
        /// </summary>
        public System.Single LRwearL
        {
            get { return (System.Single)_data["LRwearL"]; }

            set { _data["LRwearL"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire middle percent tread remaining
        /// </summary>
        public System.Single LRwearM
        {
            get { return (System.Single)_data["LRwearM"]; }

            set { _data["LRwearM"] = value.ToString(); }
        }

        /// <summary>
        /// LR tire right percent tread remaining
        /// </summary>
        public System.Single LRwearR
        {
            get { return (System.Single)_data["LRwearR"]; }

            set { _data["LRwearR"] = value.ToString(); }
        }

        /// <summary>
        /// RF brake line pressure
        /// </summary>
        public System.Single RFbrakeLinePress
        {
            get { return (System.Single)_data["RFbrakeLinePress"]; }

            set { _data["RFbrakeLinePress"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire cold pressure  as set in the garage
        /// </summary>
        public System.Single RFcoldPressure
        {
            get { return (System.Single)_data["RFcoldPressure"]; }

            set { _data["RFcoldPressure"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire left carcass temperature
        /// </summary>
        public System.Single RFtempCL
        {
            get { return (System.Single)_data["RFtempCL"]; }

            set { _data["RFtempCL"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire middle carcass temperature
        /// </summary>
        public System.Single RFtempCM
        {
            get { return (System.Single)_data["RFtempCM"]; }

            set { _data["RFtempCM"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire right carcass temperature
        /// </summary>
        public System.Single RFtempCR
        {
            get { return (System.Single)_data["RFtempCR"]; }

            set { _data["RFtempCR"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire left percent tread remaining
        /// </summary>
        public System.Single RFwearL
        {
            get { return (System.Single)_data["RFwearL"]; }

            set { _data["RFwearL"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire middle percent tread remaining
        /// </summary>
        public System.Single RFwearM
        {
            get { return (System.Single)_data["RFwearM"]; }

            set { _data["RFwearM"] = value.ToString(); }
        }

        /// <summary>
        /// RF tire right percent tread remaining
        /// </summary>
        public System.Single RFwearR
        {
            get { return (System.Single)_data["RFwearR"]; }

            set { _data["RFwearR"] = value.ToString(); }
        }

        /// <summary>
        /// LF brake line pressure
        /// </summary>
        public System.Single LFbrakeLinePress
        {
            get { return (System.Single)_data["LFbrakeLinePress"]; }

            set { _data["LFbrakeLinePress"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire cold pressure  as set in the garage
        /// </summary>
        public System.Single LFcoldPressure
        {
            get { return (System.Single)_data["LFcoldPressure"]; }

            set { _data["LFcoldPressure"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire left carcass temperature
        /// </summary>
        public System.Single LFtempCL
        {
            get { return (System.Single)_data["LFtempCL"]; }

            set { _data["LFtempCL"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire middle carcass temperature
        /// </summary>
        public System.Single LFtempCM
        {
            get { return (System.Single)_data["LFtempCM"]; }

            set { _data["LFtempCM"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire right carcass temperature
        /// </summary>
        public System.Single LFtempCR
        {
            get { return (System.Single)_data["LFtempCR"]; }

            set { _data["LFtempCR"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire left percent tread remaining
        /// </summary>
        public System.Single LFwearL
        {
            get { return (System.Single)_data["LFwearL"]; }

            set { _data["LFwearL"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire middle percent tread remaining
        /// </summary>
        public System.Single LFwearM
        {
            get { return (System.Single)_data["LFwearM"]; }

            set { _data["LFwearM"] = value.ToString(); }
        }

        /// <summary>
        /// LF tire right percent tread remaining
        /// </summary>
        public System.Single LFwearR
        {
            get { return (System.Single)_data["LFwearR"]; }

            set { _data["LFwearR"] = value.ToString(); }
        }

        /// <summary>
        /// RR shock deflection
        /// </summary>
        public System.Single RRshockDefl
        {
            get { return (System.Single)_data["RRshockDefl"]; }

            set { _data["RRshockDefl"] = value.ToString(); }
        }

        /// <summary>
        /// RR shock velocity
        /// </summary>
        public System.Single RRshockVel
        {
            get { return (System.Single)_data["RRshockVel"]; }

            set { _data["RRshockVel"] = value.ToString(); }
        }

        /// <summary>
        /// LR shock deflection
        /// </summary>
        public System.Single LRshockDefl
        {
            get { return (System.Single)_data["LRshockDefl"]; }

            set { _data["LRshockDefl"] = value.ToString(); }
        }

        /// <summary>
        /// LR shock velocity
        /// </summary>
        public System.Single LRshockVel
        {
            get { return (System.Single)_data["LRshockVel"]; }

            set { _data["LRshockVel"] = value.ToString(); }
        }

        /// <summary>
        /// RF shock deflection
        /// </summary>
        public System.Single RFshockDefl
        {
            get { return (System.Single)_data["RFshockDefl"]; }

            set { _data["RFshockDefl"] = value.ToString(); }
        }

        /// <summary>
        /// RF shock velocity
        /// </summary>
        public System.Single RFshockVel
        {
            get { return (System.Single)_data["RFshockVel"]; }

            set { _data["RFshockVel"] = value.ToString(); }
        }

        /// <summary>
        /// LF shock deflection
        /// </summary>
        public System.Single LFshockDefl
        {
            get { return (System.Single)_data["LFshockDefl"]; }

            set { _data["LFshockDefl"] = value.ToString(); }
        }

        /// <summary>
        /// LF shock velocity
        /// </summary>
        public System.Single LFshockVel
        {
            get { return (System.Single)_data["LFshockVel"]; }

            set { _data["LFshockVel"] = value.ToString(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 TickCount
        {
            get { return (System.Int32)_data["TickCount"]; }

            set { _data["TickCount"] = value.ToString(); }
        }
        #endregion

        #region IDictionary
        public bool ContainsKey(string key)
        {
            return _data.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return _data.Keys; }
        }

        public bool Remove(string key)
        {
            return _data.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _data.TryGetValue(key, out value);
        }

        public ICollection<object> Values
        {
            get { return _data.Values; }
        }

        public object this[string key]
        {
            get
            {
                return _data[key];
            }
            set
            {
                _data[key] = value;
            }
        }

        public void Add(string key, object item)
        {
            _data.Add(key, item);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _data.Add(item);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public bool IsReadOnly
        {
            get { return _data.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return _data.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator)_data.GetEnumerator();
        }
        #endregion

        #region overrides
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var kv in this)
            {
                result.Append(kv.Key.ToString());
                result.Append(": ");
                result.Append(kv.Value.ToString());
                result.Append("\n");
            }

            return result.ToString();
        }
        #endregion
    }
}