using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using iRacing.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public partial class TelemetryDataModel : iRacing.CrewChief.Models.ITelemetryDataModel
    {
        #region fields
        private IDictionary<string, object> _data = new Dictionary<string, object>();
        #endregion

        #region arrays
        /// <summary>
        /// Lap count by car index
        /// </summary>       
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxLap
        {
            get
            {
                if (_data.ContainsKey("CarIdxLap"))
                {
                    JArray array = (JArray)_data["CarIdxLap"];
                    var fromJArray = array.ToObject<Int32[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Percentage distance around lap by car index
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxLapDistPct
        {
            get
            {
                if (_data.ContainsKey("CarIdxLapDistPct"))
                {
                    JArray array = (JArray)_data["CarIdxLapDistPct"];
                    var fromJArray = array.ToObject<Single[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Track surface type by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public TrackLocation[] CarIdxTrackSurface
        {
            get
            {
                if (_data.ContainsKey("CarIdxTrackSurface"))
                {
                    JArray array = (JArray)_data["CarIdxTrackSurface"];
                    var fromJArray = (TrackLocation[])array.ToObject<TrackLocation[]>();
                    return fromJArray;
                }
                else
                    return null;

            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// On pit road between the cones by car index
        /// </summary>
        [JsonConverter(typeof(BooleanArrayConverter))]
        public System.Boolean[] CarIdxOnPitRoad
        {
            get
            {
                if (_data.ContainsKey("CarIdxOnPitRoad"))
                {
                    JArray array = (JArray)_data["CarIdxOnPitRoad"];
                    var fromJArray = array.ToObject<bool[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Cars position in race by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxPosition
        {
            get
            {
                if (_data.ContainsKey("CarIdxPosition"))
                {
                    JArray array = (JArray)_data["CarIdxPosition"];
                    var fromJArray = array.ToObject<Int32[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Cars class position in race by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxClassPosition
        {
            get
            {
                if (_data.ContainsKey("CarIdxClassPosition"))
                {
                    JArray array = (JArray)_data["CarIdxClassPosition"];
                    var fromJArray = array.ToObject<Int32[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Race time behind leader or fastest lap time otherwise
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxF2Time
        {
            get
            {
                if (_data.ContainsKey("CarIdxF2Time"))
                {
                    JArray array = (JArray)_data["CarIdxF2Time"];
                    var fromJArray = array.ToObject<Single[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Estimated time to reach current location on track
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxEstTime
        {
            get
            {
                if (_data.ContainsKey("CarIdxEstTime"))
                {
                    JArray array = (JArray)_data["CarIdxEstTime"];
                    var fromJArray = array.ToObject<Single[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Steering wheel angle by car index
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxSteer
        {
            get
            {
                if (_data.ContainsKey("CarIdxSteer"))
                {
                    JArray array = (JArray)_data["CarIdxSteer"];
                    var fromJArray = array.ToObject<Single[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// Engine rpm by car index
        /// </summary>
        [JsonConverter(typeof(SingleArrayConverter))]
        public System.Single[] CarIdxRPM
        {
            get
            {
                if (_data.ContainsKey("CarIdxRPM"))
                {
                    JArray array = (JArray)_data["CarIdxRPM"];
                    var fromJArray = array.ToObject<Single[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }

        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear by car index
        /// </summary>
        [JsonConverter(typeof(IntArrayConverter))]
        public System.Int32[] CarIdxGear
        {
            get
            {
                if (_data.ContainsKey("CarIdxGear"))
                {
                    JArray array = (JArray)_data["CarIdxGear"];
                    var fromJArray = array.ToObject<Int32[]>();
                    return fromJArray;
                }
                else
                    return null;
            }
            set
            {
                _data["CarIdxLap"] = new JArray(value).ToString();
            }
        }
        #endregion

        #region ctor
        public TelemetryDataModel()
        {
        }

        public TelemetryDataModel(SerializationInfo info, StreamingContext context)
        {

        }
        #endregion

        //#region props

        //public SessionDataModel SessionData { get; set; }

        ///// <summary>
        ///// Seconds since session start
        ///// </summary>
        //public System.Double SessionTime
        //{
        //    get { return (System.Double)_data["SessionTime"]; }

        //    set { _data["SessionTime"] = (Double)value; }
        //}

        ///// <summary>
        ///// Session number
        ///// </summary>
        //public System.Int32 SessionNum
        //{
        //    get { return (System.Int32)_data["SessionNum"]; }

        //    set { _data["SessionNum"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Session state
        ///// </summary>
        //public SessionState SessionState
        //{
        //    get { return (SessionState)_data["SessionState"]; }

        //    set { _data["SessionState"] = (Single)value; }
        //}

        ///// <summary>
        ///// Session ID
        ///// </summary>
        //public System.Int32 SessionUniqueID
        //{
        //    get { return (System.Int32)_data["SessionUniqueID"]; }

        //    set { _data["SessionUniqueID"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Session flags
        ///// </summary>
        //public SessionFlags SessionFlags
        //{
        //    get { return (SessionFlags)_data["SessionFlags"]; }

        //    set { _data["SessionFlags"] = (SessionFlags)value; }
        //}

        ///// <summary>
        ///// Seconds left till session ends
        ///// </summary>
        //public System.Double SessionTimeRemain
        //{
        //    get { return (System.Double)_data["SessionTimeRemain"]; }

        //    set { _data["SessionTimeRemain"] = (Double)value; }
        //}

        ///// <summary>
        ///// Laps left till session ends
        ///// </summary>
        //public System.Int32 SessionLapsRemain
        //{
        //    get { return (System.Int32)_data["SessionLapsRemain"]; }

        //    set { _data["SessionLapsRemain"] = (Int32)value; }
        //}

        ///// <summary>
        ///// The car index of the current person speaking on the radio
        ///// </summary>
        //public System.Int32 RadioTransmitCarIdx
        //{
        //    get { return (System.Int32)_data["RadioTransmitCarIdx"]; }

        //    set { _data["RadioTransmitCarIdx"] = (Single)value; }
        //}

        ///// <summary>
        ///// The radio index of the current person speaking on the radio
        ///// </summary>
        //public System.Int32 RadioTransmitRadioIdx
        //{
        //    get { return (System.Int32)_data["RadioTransmitRadioIdx"]; }

        //    set { _data["RadioTransmitRadioIdx"] = (Int32)value; }
        //}

        ///// <summary>
        ///// The frequency index of the current person speaking on the radio
        ///// </summary>
        //public System.Int32 RadioTransmitFrequencyIdx
        //{
        //    get { return (System.Int32)_data["RadioTransmitFrequencyIdx"]; }

        //    set { _data["RadioTransmitFrequencyIdx"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Default units for the user interface 0 = english 1 = metric
        ///// </summary>
        //public System.Int32 DisplayUnits
        //{
        //    get { return (System.Int32)_data["DisplayUnits"]; }

        //    set { _data["DisplayUnits"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Driver activated flag
        ///// </summary>
        //public System.Boolean DriverMarker
        //{
        //    get { return (System.Boolean)_data["DriverMarker"]; }

        //    set { _data["DriverMarker"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// 1=Car on track physics running with player in car
        ///// </summary>
        //public System.Boolean IsOnTrack
        //{
        //    get { return (System.Boolean)_data["IsOnTrack"]; }

        //    set { _data["IsOnTrack"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// 0=replay not playing  1=replay playing
        ///// </summary>
        //public System.Boolean IsReplayPlaying
        //{
        //    get { return (System.Boolean)_data["IsReplayPlaying"]; }

        //    set { _data["IsReplayPlaying"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Integer replay frame number (60 per second)
        ///// </summary>
        //public System.Int32 ReplayFrameNum
        //{
        //    get { return (System.Int32)_data["ReplayFrameNum"]; }

        //    set { _data["ReplayFrameNum"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Integer replay frame number from end of tape
        ///// </summary>
        //public System.Int32 ReplayFrameNumEnd
        //{
        //    get { return (System.Int32)_data["ReplayFrameNumEnd"]; }

        //    set { _data["ReplayFrameNumEnd"] = (Int32)value; }
        //}

        ///// <summary>
        ///// 0=disk based telemetry turned off  1=turned on
        ///// </summary>
        //public System.Boolean IsDiskLoggingEnabled
        //{
        //    get { return (System.Boolean)_data["IsDiskLoggingEnabled"]; }

        //    set { _data["IsDiskLoggingEnabled"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// 0=disk based telemetry file not being written  1=being written
        ///// </summary>
        //public System.Boolean IsDiskLoggingActive
        //{
        //    get { return (System.Boolean)_data["IsDiskLoggingActive"]; }

        //    set { _data["IsDiskLoggingActive"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Average frames per second
        ///// </summary>
        //public System.Single FrameRate
        //{
        //    get { return (System.Single)_data["FrameRate"]; }

        //    set { _data["FrameRate"] = (Single)value; }
        //}

        ///// <summary>
        ///// Percent of available tim bg thread took with a 1 sec avg
        ///// </summary>
        //public System.Single CpuUsageBG
        //{
        //    get { return (System.Single)_data["CpuUsageBG"]; }

        //    set { _data["CpuUsageBG"] = (Single)value; }
        //}

        ///// <summary>
        ///// Players position in race
        ///// </summary>
        //public System.Int32 PlayerCarPosition
        //{
        //    get { return (System.Int32)_data["PlayerCarPosition"]; }

        //    set { _data["PlayerCarPosition"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Players class position in race
        ///// </summary>
        //public System.Int32 PlayerCarClassPosition
        //{
        //    get { return (System.Int32)_data["PlayerCarClassPosition"]; }

        //    set { _data["PlayerCarClassPosition"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Is the player car on pit road between the cones
        ///// </summary>
        //public System.Boolean OnPitRoad
        //{
        //    get { return (System.Boolean)_data["OnPitRoad"]; }

        //    set { _data["OnPitRoad"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Steering wheel angle
        ///// </summary>
        //public System.Single SteeringWheelAngle
        //{
        //    get { return (System.Single)_data["SteeringWheelAngle"]; }

        //    set { _data["SteeringWheelAngle"] = (Single)value; }
        //}

        ///// <summary>
        ///// 0=off throttle to 1=full throttle
        ///// </summary>
        //public System.Single Throttle
        //{
        //    get { return (System.Single)_data["Throttle"]; }

        //    set { _data["Throttle"] = (Single)value; }
        //}

        ///// <summary>
        ///// 0=brake released to 1=max pedal force
        ///// </summary>
        //public System.Single Brake
        //{
        //    get { return (System.Single)_data["Brake"]; }

        //    set { _data["Brake"] = (Single)value; }
        //}

        ///// <summary>
        ///// 0=disengaged to 1=fully engaged
        ///// </summary>
        //public System.Single Clutch
        //{
        //    get { return (System.Single)_data["Clutch"]; }

        //    set { _data["Clutch"] = (Single)value; }
        //}

        ///// <summary>
        ///// -1=reverse  0=neutral  1..n=current gear
        ///// </summary>
        //public System.Int32 Gear
        //{
        //    get { return (System.Int32)_data["Gear"]; }

        //    set { _data["Gear"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Engine rpm
        ///// </summary>
        //public System.Single RPM
        //{
        //    get { return (System.Single)_data["RPM"]; }

        //    set { _data["RPM"] = (Single)value; }
        //}

        ///// <summary>
        ///// Lap count
        ///// </summary>
        //public System.Int32 Lap
        //{
        //    get { return (System.Int32)_data["Lap"]; }

        //    set { _data["Lap"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Meters traveled from S/F this lap
        ///// </summary>
        //public System.Single LapDist
        //{
        //    get { return (System.Single)_data["LapDist"]; }

        //    set { _data["LapDist"] = (Single)value; }
        //}

        ///// <summary>
        ///// Percentage distance around lap
        ///// </summary>
        //public System.Single LapDistPct
        //{
        //    get { return (System.Single)_data["LapDistPct"]; }

        //    set { _data["LapDistPct"] = (Single)value; }
        //}

        ///// <summary>
        ///// Laps completed in race
        ///// </summary>
        //public System.Int32 RaceLaps
        //{
        //    get { return (System.Int32)_data["RaceLaps"]; }

        //    set { _data["RaceLaps"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Players best lap number
        ///// </summary>
        //public System.Int32 LapBestLap
        //{
        //    get { return (System.Int32)_data["LapBestLap"]; }

        //    set { _data["LapBestLap"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Players best lap time
        ///// </summary>
        //public System.Single LapBestLapTime
        //{
        //    get { return (System.Single)_data["LapBestLapTime"]; }

        //    set { _data["LapBestLapTime"] = (Single)value; }
        //}

        ///// <summary>
        ///// Players last lap time
        ///// </summary>
        //public System.Single LapLastLapTime
        //{
        //    get { return (System.Single)_data["LapLastLapTime"]; }

        //    set { _data["LapLastLapTime"] = (Single)value; }
        //}

        ///// <summary>
        ///// Estimate of players current lap time as shown in F3 box
        ///// </summary>
        //public System.Single LapCurrentLapTime
        //{
        //    get { return (System.Single)_data["LapCurrentLapTime"]; }

        //    set { _data["LapCurrentLapTime"] = (Single)value; }
        //}

        ///// <summary>
        ///// Player num consecutive clean laps completed for N average
        ///// </summary>
        //public System.Int32 LapLasNLapSeq
        //{
        //    get { return (System.Int32)_data["LapLasNLapSeq"]; }

        //    set { _data["LapLasNLapSeq"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Player last N average lap time
        ///// </summary>
        //public System.Single LapLastNLapTime
        //{
        //    get { return (System.Single)_data["LapLastNLapTime"]; }

        //    set { _data["LapLastNLapTime"] = (Single)value; }
        //}

        ///// <summary>
        ///// Player last lap in best N average lap time
        ///// </summary>
        //public System.Int32 LapBestNLapLap
        //{
        //    get { return (System.Int32)_data["LapBestNLapLap"]; }

        //    set { _data["LapBestNLapLap"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Player best N average lap time
        ///// </summary>
        //public System.Single LapBestNLapTime
        //{
        //    get { return (System.Single)_data["LapBestNLapTime"]; }

        //    set { _data["LapBestNLapTime"] = (Single)value; }
        //}

        ///// <summary>
        ///// Delta time for best lap
        ///// </summary>
        //public System.Single LapDeltaToBestLap
        //{
        //    get { return (System.Single)_data["LapDeltaToBestLap"]; }

        //    set { _data["LapDeltaToBestLap"] = (Single)value; }
        //}

        ///// <summary>
        ///// Rate of change of delta time for best lap
        ///// </summary>
        //public System.Single LapDeltaToBestLap_DD
        //{
        //    get { return (System.Single)_data["LapDeltaToBestLap_DD"]; }

        //    set { _data["LapDeltaToBestLap_DD"] = (Single)value; }
        //}

        ///// <summary>
        ///// Delta time for best lap is valid
        ///// </summary>
        //public System.Boolean LapDeltaToBestLap_OK
        //{
        //    get { return (System.Boolean)_data["LapDeltaToBestLap_OK"]; }

        //    set { _data["LapDeltaToBestLap_OK"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Delta time for optimal lap
        ///// </summary>
        //public System.Single LapDeltaToOptimalLap
        //{
        //    get { return (System.Single)_data["LapDeltaToOptimalLap"]; }

        //    set { _data["LapDeltaToOptimalLap"] = (Single)value; }
        //}

        ///// <summary>
        ///// Rate of change of delta time for optimal lap
        ///// </summary>
        //public System.Single LapDeltaToOptimalLap_DD
        //{
        //    get { return (System.Single)_data["LapDeltaToOptimalLap_DD"]; }

        //    set { _data["LapDeltaToOptimalLap_DD"] = (Single)value; }
        //}

        ///// <summary>
        ///// Delta time for optimal lap is valid
        ///// </summary>
        //public System.Boolean LapDeltaToOptimalLap_OK
        //{
        //    get { return (System.Boolean)_data["LapDeltaToOptimalLap_OK"]; }

        //    set { _data["LapDeltaToOptimalLap_OK"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Delta time for session best lap
        ///// </summary>
        //public System.Single LapDeltaToSessionBestLap
        //{
        //    get { return (System.Single)_data["LapDeltaToSessionBestLap"]; }

        //    set { _data["LapDeltaToSessionBestLap"] = (Single)value; }
        //}

        ///// <summary>
        ///// Rate of change of delta time for session best lap
        ///// </summary>
        //public System.Single LapDeltaToSessionBestLap_DD
        //{
        //    get { return (System.Single)_data["LapDeltaToSessionBestLap_DD"]; }

        //    set { _data["LapDeltaToSessionBestLap_DD"] = (Single)value; }
        //}

        ///// <summary>
        ///// Delta time for session best lap is valid
        ///// </summary>
        //public System.Boolean LapDeltaToSessionBestLap_OK
        //{
        //    get { return (System.Boolean)_data["LapDeltaToSessionBestLap_OK"]; }

        //    set { _data["LapDeltaToSessionBestLap_OK"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Delta time for session optimal lap
        ///// </summary>
        //public System.Single LapDeltaToSessionOptimalLap
        //{
        //    get { return (System.Single)_data["LapDeltaToSessionOptimalLap"]; }

        //    set { _data["LapDeltaToSessionOptimalLap"] = (Single)value; }
        //}

        ///// <summary>
        ///// Rate of change of delta time for session optimal lap
        ///// </summary>
        //public System.Single LapDeltaToSessionOptimalLap_DD
        //{
        //    get { return (System.Single)_data["LapDeltaToSessionOptimalLap_DD"]; }

        //    set { _data["LapDeltaToSessionOptimalLap_DD"] = (Single)value; }
        //}

        ///// <summary>
        ///// Delta time for session optimal lap is valid
        ///// </summary>
        //public System.Boolean LapDeltaToSessionOptimalLap_OK
        //{
        //    get { return (System.Boolean)_data["LapDeltaToSessionOptimalLap_OK"]; }

        //    set { _data["LapDeltaToSessionOptimalLap_OK"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Delta time for session last lap
        ///// </summary>
        //public System.Single LapDeltaToSessionLastlLap
        //{
        //    get { return (System.Single)_data["LapDeltaToSessionLastlLap"]; }

        //    set { _data["LapDeltaToSessionLastlLap"] = (Single)value; }
        //}

        ///// <summary>
        ///// Rate of change of delta time for session last lap
        ///// </summary>
        //public System.Single LapDeltaToSessionLastlLap_DD
        //{
        //    get { return (System.Single)_data["LapDeltaToSessionLastlLap_DD"]; }

        //    set { _data["LapDeltaToSessionLastlLap_DD"] = (Single)value; }
        //}

        ///// <summary>
        ///// Delta time for session last lap is valid
        ///// </summary>
        //public System.Boolean LapDeltaToSessionLastlLap_OK
        //{
        //    get { return (System.Boolean)_data["LapDeltaToSessionLastlLap_OK"]; }

        //    set { _data["LapDeltaToSessionLastlLap_OK"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Longitudinal acceleration (including gravity)
        ///// </summary>
        //public System.Single LongAccel
        //{
        //    get { return (System.Single)_data["LongAccel"]; }

        //    set { _data["LongAccel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Lateral acceleration (including gravity)
        ///// </summary>
        //public System.Single LatAccel
        //{
        //    get { return (System.Single)_data["LatAccel"]; }

        //    set { _data["LatAccel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Vertical acceleration (including gravity)
        ///// </summary>
        //public System.Single VertAccel
        //{
        //    get { return (System.Single)_data["VertAccel"]; }

        //    set { _data["VertAccel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Roll rate
        ///// </summary>
        //public System.Single RollRate
        //{
        //    get { return (System.Single)_data["RollRate"]; }

        //    set { _data["RollRate"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pitch rate
        ///// </summary>
        //public System.Single PitchRate
        //{
        //    get { return (System.Single)_data["PitchRate"]; }

        //    set { _data["PitchRate"] = (Single)value; }
        //}

        ///// <summary>
        ///// Yaw rate
        ///// </summary>
        //public System.Single YawRate
        //{
        //    get { return (System.Single)_data["YawRate"]; }

        //    set { _data["YawRate"] = (Single)value; }
        //}

        ///// <summary>
        ///// GPS vehicle speed
        ///// </summary>
        //public System.Single Speed
        //{
        //    get { return (System.Single)_data["Speed"]; }

        //    set { _data["Speed"] = (Single)value; }
        //}

        ///// <summary>
        ///// X velocity
        ///// </summary>
        //public System.Single VelocityX
        //{
        //    get { return (System.Single)_data["VelocityX"]; }

        //    set { _data["VelocityX"] = (Single)value; }
        //}

        ///// <summary>
        ///// Y velocity
        ///// </summary>
        //public System.Single VelocityY
        //{
        //    get { return (System.Single)_data["VelocityY"]; }

        //    set { _data["VelocityY"] = (Single)value; }
        //}

        ///// <summary>
        ///// Z velocity
        ///// </summary>
        //public System.Single VelocityZ
        //{
        //    get { return (System.Single)_data["VelocityZ"]; }

        //    set { _data["VelocityZ"] = (Single)value; }
        //}

        ///// <summary>
        ///// Yaw orientation
        ///// </summary>
        //public System.Single Yaw
        //{
        //    get { return (System.Single)_data["Yaw"]; }

        //    set { _data["Yaw"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pitch orientation
        ///// </summary>
        //public System.Single Pitch
        //{
        //    get { return (System.Single)_data["Pitch"]; }

        //    set { _data["Pitch"] = (Single)value; }
        //}

        ///// <summary>
        ///// Roll orientation
        ///// </summary>
        //public System.Single Roll
        //{
        //    get { return (System.Single)_data["Roll"]; }

        //    set { _data["Roll"] = (Single)value; }
        //}

        ///// <summary>
        ///// Indicate action the reset key will take 0 enter 1 exit 2 reset
        ///// </summary>
        //public System.Int32 EnterExitReset
        //{
        //    get { return (System.Int32)_data["EnterExitReset"]; }

        //    set { _data["EnterExitReset"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Temperature of track at start/finish line
        ///// </summary>
        //public System.Single TrackTemp
        //{
        //    get { return (System.Single)_data["TrackTemp"]; }

        //    set { _data["TrackTemp"] = (Single)value; }
        //}

        ///// <summary>
        ///// Temperature of air at start/finish line
        ///// </summary>
        //public System.Single AirTemp
        //{
        //    get { return (System.Single)_data["AirTemp"]; }

        //    set { _data["AirTemp"] = (Single)value; }
        //}

        ///// <summary>
        ///// Weather type (0=constant  1=dynamic)
        ///// </summary>
        //public System.Int32 WeatherType
        //{
        //    get { return (System.Int32)_data["WeatherType"]; }

        //    set { _data["WeatherType"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Skies (0=clear/1=p cloudy/2=m cloudy/3=overcast)
        ///// </summary>
        //public System.Int32 Skies
        //{
        //    get { return (System.Int32)_data["Skies"]; }

        //    set { _data["Skies"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Density of air at start/finish line
        ///// </summary>
        //public System.Single AirDensity
        //{
        //    get { return (System.Single)_data["AirDensity"]; }

        //    set { _data["AirDensity"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pressure of air at start/finish line
        ///// </summary>
        //public System.Single AirPressure
        //{
        //    get { return (System.Single)_data["AirPressure"]; }

        //    set { _data["AirPressure"] = (Single)value; }
        //}

        ///// <summary>
        ///// Wind velocity at start/finish line
        ///// </summary>
        //public System.Single WindVel
        //{
        //    get { return (System.Single)_data["WindVel"]; }

        //    set { _data["WindVel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Wind direction at start/finish line
        ///// </summary>
        //public System.Single WindDir
        //{
        //    get { return (System.Single)_data["WindDir"]; }

        //    set { _data["WindDir"] = (Single)value; }
        //}

        ///// <summary>
        ///// Relative Humidity
        ///// </summary>
        //public System.Single RelativeHumidity
        //{
        //    get { return (System.Single)_data["RelativeHumidity"]; }

        //    set { _data["RelativeHumidity"] = (Single)value; }
        //}

        ///// <summary>
        ///// Fog level
        ///// </summary>
        //public System.Single FogLevel
        //{
        //    get { return (System.Single)_data["FogLevel"]; }

        //    set { _data["FogLevel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Status of driver change lap requirements
        ///// </summary>
        //public System.Int32 DCLapStatus
        //{
        //    get { return (System.Int32)_data["DCLapStatus"]; }

        //    set { _data["DCLapStatus"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Number of team drivers who have run a stint
        ///// </summary>
        //public System.Int32 DCDriversSoFar
        //{
        //    get { return (System.Int32)_data["DCDriversSoFar"]; }

        //    set { _data["DCDriversSoFar"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Time left for mandatory pit repairs if repairs are active
        ///// </summary>
        //public System.Single PitRepairLeft
        //{
        //    get { return (System.Single)_data["PitRepairLeft"]; }

        //    set { _data["PitRepairLeft"] = (Single)value; }
        //}

        ///// <summary>
        ///// Time left for optional repairs if repairs are active
        ///// </summary>
        //public System.Single PitOptRepairLeft
        //{
        //    get { return (System.Single)_data["PitOptRepairLeft"]; }

        //    set { _data["PitOptRepairLeft"] = (Single)value; }
        //}

        ///// <summary>
        ///// Active camera's focus car index
        ///// </summary>
        //public System.Int32 CamCarIdx
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CamCarIdx"))
        //            return -1;
        //        else
        //            return (System.Int32)_data["CamCarIdx"];
        //    }

        //    set { _data["CamCarIdx"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Active camera number
        ///// </summary>
        //public System.Int32 CamCameraNumber
        //{
        //    get { return (System.Int32)_data["CamCameraNumber"]; }

        //    set { _data["CamCameraNumber"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Active camera group number
        ///// </summary>
        //public System.Int32 CamGroupNumber
        //{
        //    get { return (System.Int32)_data["CamGroupNumber"]; }

        //    set { _data["CamGroupNumber"] = (Int32)value; }
        //}

        ///// <summary>
        ///// State of camera system
        ///// </summary>
        //public System.Int32 CamCameraState
        //{
        //    get { return (System.Int32)_data["CamCameraState"]; }

        //    set { _data["CamCameraState"] = (Int32)value; }
        //}

        ///// <summary>
        ///// 1=Car on track physics running
        ///// </summary>
        //public System.Boolean IsOnTrackCar
        //{
        //    get { return (System.Boolean)_data["IsOnTrackCar"]; }

        //    set { _data["IsOnTrackCar"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// 1=Car in garage physics running
        ///// </summary>
        //public System.Boolean IsInGarage
        //{
        //    get { return (System.Boolean)_data["IsInGarage"]; }

        //    set { _data["IsInGarage"] = (Boolean)value; }
        //}

        ///// <summary>
        ///// Output torque on steering shaft
        ///// </summary>
        //public System.Single SteeringWheelTorque
        //{
        //    get { return (System.Single)_data["SteeringWheelTorque"]; }

        //    set { _data["SteeringWheelTorque"] = (Single)value; }
        //}

        ///// <summary>
        ///// Force feedback % max torque on steering shaft unsigned
        ///// </summary>
        //public System.Single SteeringWheelPctTorque
        //{
        //    get { return (System.Single)_data["SteeringWheelPctTorque"]; }

        //    set { _data["SteeringWheelPctTorque"] = (Single)value; }
        //}

        ///// <summary>
        ///// Force feedback % max torque on steering shaft signed
        ///// </summary>
        //public System.Single SteeringWheelPctTorqueSign
        //{
        //    get { return (System.Single)_data["SteeringWheelPctTorqueSign"]; }

        //    set { _data["SteeringWheelPctTorqueSign"] = (Single)value; }
        //}

        ///// <summary>
        ///// Force feedback % max torque on steering shaft signed stops
        ///// </summary>
        //public System.Single SteeringWheelPctTorqueSignStops
        //{
        //    get { return (System.Single)_data["SteeringWheelPctTorqueSignStops"]; }

        //    set { _data["SteeringWheelPctTorqueSignStops"] = (Single)value; }
        //}

        ///// <summary>
        ///// Force feedback % max damping
        ///// </summary>
        //public System.Single SteeringWheelPctDamper
        //{
        //    get { return (System.Single)_data["SteeringWheelPctDamper"]; }

        //    set { _data["SteeringWheelPctDamper"] = (Single)value; }
        //}

        ///// <summary>
        ///// Steering wheel max angle
        ///// </summary>
        //public System.Single SteeringWheelAngleMax
        //{
        //    get { return (System.Single)_data["SteeringWheelAngleMax"]; }

        //    set { _data["SteeringWheelAngleMax"] = (Single)value; }
        //}

        ///// <summary>
        ///// DEPRECATED use DriverCarSLBlinkRPM instead
        ///// </summary>
        //public System.Single ShiftIndicatorPct
        //{
        //    get { return (System.Single)_data["ShiftIndicatorPct"]; }

        //    set { _data["ShiftIndicatorPct"] = (Single)value; }
        //}

        ///// <summary>
        ///// Friction torque applied to gears when shifting or grinding
        ///// </summary>
        //public System.Single ShiftPowerPct
        //{
        //    get { return (System.Single)_data["ShiftPowerPct"]; }

        //    set { _data["ShiftPowerPct"] = (Single)value; }
        //}

        ///// <summary>
        ///// RPM of shifter grinding noise
        ///// </summary>
        //public System.Single ShiftGrindRPM
        //{
        //    get { return (System.Single)_data["ShiftGrindRPM"]; }

        //    set { _data["ShiftGrindRPM"] = (Single)value; }
        //}

        ///// <summary>
        ///// Raw throttle input 0=off throttle to 1=full throttle
        ///// </summary>
        //public System.Single ThrottleRaw
        //{
        //    get { return (System.Single)_data["ThrottleRaw"]; }

        //    set { _data["ThrottleRaw"] = (Single)value; }
        //}

        ///// <summary>
        ///// Raw brake input 0=brake released to 1=max pedal force
        ///// </summary>
        //public System.Single BrakeRaw
        //{
        //    get { return (System.Single)_data["BrakeRaw"]; }

        //    set { _data["BrakeRaw"] = (Single)value; }
        //}

        ///// <summary>
        ///// Peak torque mapping to direct input units for FFB
        ///// </summary>
        //public System.Single SteeringWheelPeakForceNm
        //{
        //    get { return (System.Single)_data["SteeringWheelPeakForceNm"]; }

        //    set { _data["SteeringWheelPeakForceNm"] = (Single)value; }
        //}

        ///// <summary>
        ///// Bitfield for warning lights
        ///// </summary>
        //public System.Int32 EngineWarnings
        //{
        //    get { return (System.Int32)_data["EngineWarnings"]; }

        //    set { _data["EngineWarnings"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Liters of fuel remaining
        ///// </summary>
        //public System.Single FuelLevel
        //{
        //    get { return (System.Single)_data["FuelLevel"]; }

        //    set { _data["FuelLevel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Percent fuel remaining
        ///// </summary>
        //public System.Single FuelLevelPct
        //{
        //    get { return (System.Single)_data["FuelLevelPct"]; }

        //    set { _data["FuelLevelPct"] = (Single)value; }
        //}

        ///// <summary>
        ///// Bitfield of pit service checkboxes
        ///// </summary>
        //public System.Int32 PitSvFlags
        //{
        //    get { return (System.Int32)_data["PitSvFlags"]; }

        //    set { _data["PitSvFlags"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Pit service left front tire pressure
        ///// </summary>
        //public System.Single PitSvLFP
        //{
        //    get { return (System.Single)_data["PitSvLFP"]; }

        //    set { _data["PitSvLFP"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pit service right front tire pressure
        ///// </summary>
        //public System.Single PitSvRFP
        //{
        //    get { return (System.Single)_data["PitSvRFP"]; }

        //    set { _data["PitSvRFP"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pit service left rear tire pressure
        ///// </summary>
        //public System.Single PitSvLRP
        //{
        //    get { return (System.Single)_data["PitSvLRP"]; }

        //    set { _data["PitSvLRP"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pit service right rear tire pressure
        ///// </summary>
        //public System.Single PitSvRRP
        //{
        //    get { return (System.Single)_data["PitSvRRP"]; }

        //    set { _data["PitSvRRP"] = (Single)value; }
        //}

        ///// <summary>
        ///// Pit service fuel add amount
        ///// </summary>
        //public System.Single PitSvFuel
        //{
        //    get { return (System.Single)_data["PitSvFuel"]; }

        //    set { _data["PitSvFuel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Replay playback speed
        ///// </summary>
        //public System.Int32 ReplayPlaySpeed
        //{
        //    get { return (System.Int32)_data["ReplayPlaySpeed"]; }

        //    set { _data["ReplayPlaySpeed"] = (Int32)value; }
        //}

        ///// <summary>
        ///// 0=not slow motion  1=replay is in slow motion
        ///// </summary>
        //public System.Boolean ReplayPlaySlowMotion
        //{
        //    get { return (System.Boolean)_data["ReplayPlaySlowMotion"]; }

        //    set { _data["ReplayPlaySlowMotion"] = (bool)value; }
        //}

        ///// <summary>
        ///// Seconds since replay session start
        ///// </summary>
        //public System.Double ReplaySessionTime
        //{
        //    get { return (System.Double)_data["ReplaySessionTime"]; }

        //    set { _data["ReplaySessionTime"] = (Double)value; }
        //}

        ///// <summary>
        ///// Replay session number
        ///// </summary>
        //public System.Int32 ReplaySessionNum
        //{
        //    get { return (System.Int32)_data["ReplaySessionNum"]; }

        //    set { _data["ReplaySessionNum"] = (Int32)value; }
        //}

        ///// <summary>
        ///// Pitstop qtape adjustment
        ///// </summary>
        //public System.Single dpQtape
        //{
        //    get { return (System.Single)_data["dpQtape"]; }

        //    set { _data["dpQtape"] = (Single)value; }
        //}

        ///// <summary>
        ///// In car brake bias adjustment
        ///// </summary>
        //public System.Single dcBrakeBias
        //{
        //    get { return (System.Single)_data["dcBrakeBias"]; }

        //    set { _data["dcBrakeBias"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine coolant temp
        ///// </summary>
        //public System.Single WaterTemp
        //{
        //    get { return (System.Single)_data["WaterTemp"]; }

        //    set { _data["WaterTemp"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine coolant level
        ///// </summary>
        //public System.Single WaterLevel
        //{
        //    get { return (System.Single)_data["WaterLevel"]; }

        //    set { _data["WaterLevel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine fuel pressure
        ///// </summary>
        //public System.Single FuelPress
        //{
        //    get { return (System.Single)_data["FuelPress"]; }

        //    set { _data["FuelPress"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine oil temperature
        ///// </summary>
        //public System.Single OilTemp
        //{
        //    get { return (System.Single)_data["OilTemp"]; }

        //    set { _data["OilTemp"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine oil pressure
        ///// </summary>
        //public System.Single OilPress
        //{
        //    get { return (System.Single)_data["OilPress"]; }

        //    set { _data["OilPress"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine oil level
        ///// </summary>
        //public System.Single OilLevel
        //{
        //    get { return (System.Single)_data["OilLevel"]; }

        //    set { _data["OilLevel"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine voltage
        ///// </summary>
        //public System.Single Voltage
        //{
        //    get { return (System.Single)_data["Voltage"]; }

        //    set { _data["Voltage"] = (Single)value; }
        //}

        ///// <summary>
        ///// Engine manifold pressure
        ///// </summary>
        //public System.Single ManifoldPress
        //{
        //    get { return (System.Single)_data["ManifoldPress"]; }

        //    set { _data["ManifoldPress"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR brake line pressure
        ///// </summary>
        //public System.Single RRbrakeLinePress
        //{
        //    get { return (System.Single)_data["RRbrakeLinePress"]; }

        //    set { _data["RRbrakeLinePress"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire cold pressure  as set in the garage
        ///// </summary>
        //public System.Single RRcoldPressure
        //{
        //    get { return (System.Single)_data["RRcoldPressure"]; }

        //    set { _data["RRcoldPressure"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire left carcass temperature
        ///// </summary>
        //public System.Single RRtempCL
        //{
        //    get { return (System.Single)_data["RRtempCL"]; }

        //    set { _data["RRtempCL"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire middle carcass temperature
        ///// </summary>
        //public System.Single RRtempCM
        //{
        //    get { return (System.Single)_data["RRtempCM"]; }

        //    set { _data["RRtempCM"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire right carcass temperature
        ///// </summary>
        //public System.Single RRtempCR
        //{
        //    get { return (System.Single)_data["RRtempCR"]; }

        //    set { _data["RRtempCR"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire left percent tread remaining
        ///// </summary>
        //public System.Single RRwearL
        //{
        //    get { return (System.Single)_data["RRwearL"]; }

        //    set { _data["RRwearL"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire middle percent tread remaining
        ///// </summary>
        //public System.Single RRwearM
        //{
        //    get { return (System.Single)_data["RRwearM"]; }

        //    set { _data["RRwearM"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR tire right percent tread remaining
        ///// </summary>
        //public System.Single RRwearR
        //{
        //    get { return (System.Single)_data["RRwearR"]; }

        //    set { _data["RRwearR"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR brake line pressure
        ///// </summary>
        //public System.Single LRbrakeLinePress
        //{
        //    get { return (System.Single)_data["LRbrakeLinePress"]; }

        //    set { _data["LRbrakeLinePress"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire cold pressure  as set in the garage
        ///// </summary>
        //public System.Single LRcoldPressure
        //{
        //    get { return (System.Single)_data["LRcoldPressure"]; }

        //    set { _data["LRcoldPressure"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire left carcass temperature
        ///// </summary>
        //public System.Single LRtempCL
        //{
        //    get { return (System.Single)_data["LRtempCL"]; }

        //    set { _data["LRtempCL"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire middle carcass temperature
        ///// </summary>
        //public System.Single LRtempCM
        //{
        //    get { return (System.Single)_data["LRtempCM"]; }

        //    set { _data["LRtempCM"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire right carcass temperature
        ///// </summary>
        //public System.Single LRtempCR
        //{
        //    get { return (System.Single)_data["LRtempCR"]; }

        //    set { _data["LRtempCR"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire left percent tread remaining
        ///// </summary>
        //public System.Single LRwearL
        //{
        //    get { return (System.Single)_data["LRwearL"]; }

        //    set { _data["LRwearL"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire middle percent tread remaining
        ///// </summary>
        //public System.Single LRwearM
        //{
        //    get { return (System.Single)_data["LRwearM"]; }

        //    set { _data["LRwearM"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR tire right percent tread remaining
        ///// </summary>
        //public System.Single LRwearR
        //{
        //    get { return (System.Single)_data["LRwearR"]; }

        //    set { _data["LRwearR"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF brake line pressure
        ///// </summary>
        //public System.Single RFbrakeLinePress
        //{
        //    get { return (System.Single)_data["RFbrakeLinePress"]; }

        //    set { _data["RFbrakeLinePress"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire cold pressure  as set in the garage
        ///// </summary>
        //public System.Single RFcoldPressure
        //{
        //    get { return (System.Single)_data["RFcoldPressure"]; }

        //    set { _data["RFcoldPressure"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire left carcass temperature
        ///// </summary>
        //public System.Single RFtempCL
        //{
        //    get { return (System.Single)_data["RFtempCL"]; }

        //    set { _data["RFtempCL"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire middle carcass temperature
        ///// </summary>
        //public System.Single RFtempCM
        //{
        //    get { return (System.Single)_data["RFtempCM"]; }

        //    set { _data["RFtempCM"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire right carcass temperature
        ///// </summary>
        //public System.Single RFtempCR
        //{
        //    get { return (System.Single)_data["RFtempCR"]; }

        //    set { _data["RFtempCR"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire left percent tread remaining
        ///// </summary>
        //public System.Single RFwearL
        //{
        //    get { return (System.Single)_data["RFwearL"]; }

        //    set { _data["RFwearL"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire middle percent tread remaining
        ///// </summary>
        //public System.Single RFwearM
        //{
        //    get { return (System.Single)_data["RFwearM"]; }

        //    set { _data["RFwearM"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF tire right percent tread remaining
        ///// </summary>
        //public System.Single RFwearR
        //{
        //    get { return (System.Single)_data["RFwearR"]; }

        //    set { _data["RFwearR"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF brake line pressure
        ///// </summary>
        //public System.Single LFbrakeLinePress
        //{
        //    get { return (System.Single)_data["LFbrakeLinePress"]; }

        //    set { _data["LFbrakeLinePress"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire cold pressure  as set in the garage
        ///// </summary>
        //public System.Single LFcoldPressure
        //{
        //    get { return (System.Single)_data["LFcoldPressure"]; }

        //    set { _data["LFcoldPressure"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire left carcass temperature
        ///// </summary>
        //public System.Single LFtempCL
        //{
        //    get { return (System.Single)_data["LFtempCL"]; }

        //    set { _data["LFtempCL"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire middle carcass temperature
        ///// </summary>
        //public System.Single LFtempCM
        //{
        //    get { return (System.Single)_data["LFtempCM"]; }

        //    set { _data["LFtempCM"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire right carcass temperature
        ///// </summary>
        //public System.Single LFtempCR
        //{
        //    get { return (System.Single)_data["LFtempCR"]; }

        //    set { _data["LFtempCR"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire left percent tread remaining
        ///// </summary>
        //public System.Single LFwearL
        //{
        //    get { return (System.Single)_data["LFwearL"]; }

        //    set { _data["LFwearL"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire middle percent tread remaining
        ///// </summary>
        //public System.Single LFwearM
        //{
        //    get { return (System.Single)_data["LFwearM"]; }

        //    set { _data["LFwearM"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF tire right percent tread remaining
        ///// </summary>
        //public System.Single LFwearR
        //{
        //    get { return (System.Single)_data["LFwearR"]; }

        //    set { _data["LFwearR"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR shock deflection
        ///// </summary>
        //public System.Single RRshockDefl
        //{
        //    get { return (System.Single)_data["RRshockDefl"]; }

        //    set { _data["RRshockDefl"] = (Single)value; }
        //}

        ///// <summary>
        ///// RR shock velocity
        ///// </summary>
        //public System.Single RRshockVel
        //{
        //    get { return (System.Single)_data["RRshockVel"]; }

        //    set { _data["RRshockVel"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR shock deflection
        ///// </summary>
        //public System.Single LRshockDefl
        //{
        //    get { return (System.Single)_data["LRshockDefl"]; }

        //    set { _data["LRshockDefl"] = (Single)value; }
        //}

        ///// <summary>
        ///// LR shock velocity
        ///// </summary>
        //public System.Single LRshockVel
        //{
        //    get { return (System.Single)_data["LRshockVel"]; }

        //    set { _data["LRshockVel"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF shock deflection
        ///// </summary>
        //public System.Single RFshockDefl
        //{
        //    get { return (System.Single)_data["RFshockDefl"]; }

        //    set { _data["RFshockDefl"] = (Single)value; }
        //}

        ///// <summary>
        ///// RF shock velocity
        ///// </summary>
        //public System.Single RFshockVel
        //{
        //    get { return (System.Single)_data["RFshockVel"]; }

        //    set { _data["RFshockVel"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF shock deflection
        ///// </summary>
        //public System.Single LFshockDefl
        //{
        //    get { return (System.Single)_data["LFshockDefl"]; }

        //    set { _data["LFshockDefl"] = (Single)value; }
        //}

        ///// <summary>
        ///// LF shock velocity
        ///// </summary>
        //public System.Single LFshockVel
        //{
        //    get { return (System.Single)_data["LFshockVel"]; }

        //    set { _data["LFshockVel"] = (Single)value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public System.Int32 TickCount
        //{
        //    get { return (Int32)_data["TickCount"]; }

        //    set { _data["TickCount"] = (Int32)value; }
        //}
        //#endregion
        
        #region properties
        //#region array properties

        ///// <summary>
        ///// Lap count by car index
        ///// </summary>
        //public System.Int32[] CarIdxLap
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxLap"))
        //            return 0;
        //        else
        //            return (System.Int32[])_data["CarIdxLap"];
        //    }

        //    set
        //    {
        //        _data["CarIdxLap"] = (System.Int32[])value;
        //    }
        //}

        ///// <summary>
        ///// Percentage distance around lap by car index
        ///// </summary>
        //public System.Single[] CarIdxLapDistPct
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxLapDistPct"))
        //            return 0;
        //        else
        //            return (System.Single[])_data["CarIdxLapDistPct"];
        //    }

        //    set
        //    {
        //        _data["CarIdxLapDistPct"] = (System.Single[])value;
        //    }
        //}

        ///// <summary>
        ///// Track surface type by car index
        ///// </summary>
        //public TrackLocation[] CarIdxTrackSurface
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxTrackSurface"))
        //            return null;
        //        else
        //            return (TrackLocation[])_data["CarIdxTrackSurface"];
        //    }

        //    set
        //    {
        //        _data["CarIdxTrackSurface"] = (TrackLocation[])value;
        //    }
        //}

        ///// <summary>
        ///// On pit road between the cones by car index
        ///// </summary>
        //public System.Boolean[] CarIdxOnPitRoad
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxOnPitRoad"))
        //            return 0;
        //        else
        //            return (System.Boolean[])_data["CarIdxOnPitRoad"];
        //    }

        //    set
        //    {
        //        _data["CarIdxOnPitRoad"] = (System.Boolean[])value;
        //    }
        //}

        ///// <summary>
        ///// Cars position in race by car index
        ///// </summary>
        //public System.Int32[] CarIdxPosition
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxPosition"))
        //            return 0;
        //        else
        //            return (System.Int32[])_data["CarIdxPosition"];
        //    }

        //    set
        //    {
        //        _data["CarIdxPosition"] = (System.Int32[])value;
        //    }
        //}

        ///// <summary>
        ///// Cars class position in race by car index
        ///// </summary>
        //public System.Int32[] CarIdxClassPosition
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxClassPosition"))
        //            return 0;
        //        else
        //            return (System.Int32[])_data["CarIdxClassPosition"];
        //    }

        //    set
        //    {
        //        _data["CarIdxClassPosition"] = (System.Int32[])value;
        //    }
        //}

        ///// <summary>
        ///// Race time behind leader or fastest lap time otherwise
        ///// </summary>
        //public System.Single[] CarIdxF2Time
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxF2Time"))
        //            return 0;
        //        else
        //            return (System.Single[])_data["CarIdxF2Time"];
        //    }

        //    set
        //    {
        //        _data["CarIdxF2Time"] = (System.Single[])value;
        //    }
        //}

        ///// <summary>
        ///// Estimated time to reach current location on track
        ///// </summary>
        //public System.Single[] CarIdxEstTime
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxEstTime"))
        //            return 0;
        //        else
        //            return (System.Single[])_data["CarIdxEstTime"];
        //    }

        //    set
        //    {
        //        _data["CarIdxEstTime"] = (System.Single[])value;
        //    }
        //}

        ///// <summary>
        ///// Steering wheel angle by car index
        ///// </summary>
        //public System.Single[] CarIdxSteer
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxSteer"))
        //            return 0;
        //        else
        //            return (System.Single[])_data["CarIdxSteer"];
        //    }

        //    set
        //    {
        //        _data["CarIdxSteer"] = (System.Single[])value;
        //    }
        //}

        ///// <summary>
        ///// Engine rpm by car index
        ///// </summary>
        //public System.Single[] CarIdxRPM
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxRPM"))
        //            return 0;
        //        else
        //            return (System.Single[])_data["CarIdxRPM"];
        //    }

        //    set
        //    {
        //        _data["CarIdxRPM"] = (System.Single[])value;
        //    }
        //}

        ///// <summary>
        ///// -1=reverse  0=neutral  1..n=current gear by car index
        ///// </summary>
        //public System.Int32[] CarIdxGear
        //{
        //    get
        //    {
        //        if (!_data.ContainsKey("CarIdxGear"))
        //            return 0;
        //        else
        //            return (System.Int32[])_data["CarIdxGear"];
        //    }

        //    set
        //    {
        //        _data["CarIdxGear"] = (System.Int32[])value;
        //    }
        //}
        //#endregion

        public SessionDataModel SessionData { get; set; }

        /// <summary>
        /// Pitstop qtape adjustment
        /// </summary>
        public System.Single dpQtape
        {
            get
            {
                if (!_data.ContainsKey("dpQtape"))
                    return 0;
                else
                    return (System.Single)_data["dpQtape"];
            }

            set { _data["dpQtape"] = (Single)value; }
        }

        /// <summary>
        /// In car brake bias adjustment
        /// </summary>
        public System.Single dcBrakeBias
        {
            get
            {
                if (!_data.ContainsKey("dcBrakeBias"))
                    return 0;
                else
                    return (System.Single)_data["dcBrakeBias"];
            }

            set { _data["dcBrakeBias"] = (Single)value; }
        }

        /// <summary>
        /// Seconds since session start
        /// </summary>
        public System.Double SessionTime
        {
            get
            {
                if (!_data.ContainsKey("SessionTime"))
                    return 0;
                else
                    return (System.Double)_data["SessionTime"];
            }

            set
            {
                _data["SessionTime"] = (System.Double)value;
            }
        }

        /// <summary>
        /// Session number
        /// </summary>
        public System.Int32 SessionNum
        {
            get
            {
                if (!_data.ContainsKey("SessionNum"))
                    return 0;
                else
                    return (System.Int32)_data["SessionNum"];
            }

            set
            {
                _data["SessionNum"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Session state
        /// </summary>
        public SessionState SessionState
        {
            get
            {
                if (!_data.ContainsKey("SessionState"))
                    return 0;
                else
                    return (SessionState)_data["SessionState"];
            }

            set
            {
                _data["SessionState"] = (SessionState)value;
            }
        }

        /// <summary>
        /// Session ID
        /// </summary>
        public System.Int32 SessionUniqueID
        {
            get
            {
                if (!_data.ContainsKey("SessionUniqueID"))
                    return 0;
                else
                    return (System.Int32)_data["SessionUniqueID"];
            }

            set
            {
                _data["SessionUniqueID"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Session flags
        /// </summary>
        public SessionFlags SessionFlags
        {
            get
            {
                if (!_data.ContainsKey("SessionFlags"))
                    return 0;
                else
                    return (SessionFlags)_data["SessionFlags"];
            }

            set
            {
                _data["SessionFlags"] = (SessionFlags)value;
            }
        }

        /// <summary>
        /// Seconds left till session ends
        /// </summary>
        public System.Double SessionTimeRemain
        {
            get
            {
                if (!_data.ContainsKey("SessionTimeRemain"))
                    return 0;
                else
                    return (System.Double)_data["SessionTimeRemain"];
            }

            set
            {
                _data["SessionTimeRemain"] = (System.Double)value;
            }
        }

        /// <summary>
        /// Laps left till session ends
        /// </summary>
        public System.Int32 SessionLapsRemain
        {
            get
            {
                if (!_data.ContainsKey("SessionLapsRemain"))
                    return 0;
                else
                    return (System.Int32)_data["SessionLapsRemain"];
            }

            set
            {
                _data["SessionLapsRemain"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// The car index of the current person speaking on the radio
        /// </summary>
        public System.Int32 RadioTransmitCarIdx
        {
            get
            {
                if (!_data.ContainsKey("RadioTransmitCarIdx"))
                    return 0;
                else
                    return (System.Int32)_data["RadioTransmitCarIdx"];
            }

            set
            {
                _data["RadioTransmitCarIdx"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// The radio index of the current person speaking on the radio
        /// </summary>
        public System.Int32 RadioTransmitRadioIdx
        {
            get
            {
                if (!_data.ContainsKey("RadioTransmitRadioIdx"))
                    return 0;
                else
                    return (System.Int32)_data["RadioTransmitRadioIdx"];
            }

            set
            {
                _data["RadioTransmitRadioIdx"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// The frequency index of the current person speaking on the radio
        /// </summary>
        public System.Int32 RadioTransmitFrequencyIdx
        {
            get
            {
                if (!_data.ContainsKey("RadioTransmitFrequencyIdx"))
                    return 0;
                else
                    return (System.Int32)_data["RadioTransmitFrequencyIdx"];
            }

            set
            {
                _data["RadioTransmitFrequencyIdx"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Default units for the user interface 0 = english 1 = metric
        /// </summary>
        public System.Int32 DisplayUnits
        {
            get
            {
                if (!_data.ContainsKey("DisplayUnits"))
                    return 0;
                else
                    return (System.Int32)_data["DisplayUnits"];
            }

            set
            {
                _data["DisplayUnits"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Driver activated flag
        /// </summary>
        public System.Boolean DriverMarker
        {
            get
            {
                if (!_data.ContainsKey("DriverMarker"))
                    return false;
                else
                    return (System.Boolean)_data["DriverMarker"];
            }

            set
            {
                _data["DriverMarker"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// 1=Car on track physics running with player in car
        /// </summary>
        public System.Boolean IsOnTrack
        {
            get
            {
                if (!_data.ContainsKey("IsOnTrack"))
                    return false;
                else
                    return (System.Boolean)_data["IsOnTrack"];
            }

            set
            {
                _data["IsOnTrack"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// 0=replay not playing  1=replay playing
        /// </summary>
        public System.Boolean IsReplayPlaying
        {
            get
            {
                if (!_data.ContainsKey("IsReplayPlaying"))
                    return false;
                else
                    return (System.Boolean)_data["IsReplayPlaying"];
            }

            set
            {
                _data["IsReplayPlaying"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Integer replay frame number (60 per second)
        /// </summary>
        public System.Int32 ReplayFrameNum
        {
            get
            {
                if (!_data.ContainsKey("ReplayFrameNum"))
                    return 0;
                else
                    return (System.Int32)_data["ReplayFrameNum"];
            }

            set
            {
                _data["ReplayFrameNum"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Integer replay frame number from end of tape
        /// </summary>
        public System.Int32 ReplayFrameNumEnd
        {
            get
            {
                if (!_data.ContainsKey("ReplayFrameNumEnd"))
                    return 0;
                else
                    return (System.Int32)_data["ReplayFrameNumEnd"];
            }

            set
            {
                _data["ReplayFrameNumEnd"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// 0=disk based telemetry turned off  1=turned on
        /// </summary>
        public System.Boolean IsDiskLoggingEnabled
        {
            get
            {
                if (!_data.ContainsKey("IsDiskLoggingEnabled"))
                    return false;
                else
                    return (System.Boolean)_data["IsDiskLoggingEnabled"];
            }

            set
            {
                _data["IsDiskLoggingEnabled"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// 0=disk based telemetry file not being written  1=being written
        /// </summary>
        public System.Boolean IsDiskLoggingActive
        {
            get
            {
                if (!_data.ContainsKey("IsDiskLoggingActive"))
                    return false;
                else
                    return (System.Boolean)_data["IsDiskLoggingActive"];
            }

            set
            {
                _data["IsDiskLoggingActive"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Average frames per second
        /// </summary>
        public System.Single FrameRate
        {
            get
            {
                if (!_data.ContainsKey("FrameRate"))
                    return 0;
                else
                    return (System.Single)_data["FrameRate"];
            }

            set
            {
                _data["FrameRate"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Percent of available tim bg thread took with a 1 sec avg
        /// </summary>
        public System.Single CpuUsageBG
        {
            get
            {
                if (!_data.ContainsKey("CpuUsageBG"))
                    return 0;
                else
                    return (System.Single)_data["CpuUsageBG"];
            }

            set
            {
                _data["CpuUsageBG"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Players position in race
        /// </summary>
        public System.Int32 PlayerCarPosition
        {
            get
            {
                if (!_data.ContainsKey("PlayerCarPosition"))
                    return 0;
                else
                    return (System.Int32)_data["PlayerCarPosition"];
            }

            set
            {
                _data["PlayerCarPosition"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Players class position in race
        /// </summary>
        public System.Int32 PlayerCarClassPosition
        {
            get
            {
                if (!_data.ContainsKey("PlayerCarClassPosition"))
                    return 0;
                else
                    return (System.Int32)_data["PlayerCarClassPosition"];
            }

            set
            {
                _data["PlayerCarClassPosition"] = (System.Int32)value;
            }
        }


        /// <summary>
        /// Is the player car on pit road between the cones
        /// </summary>
        public System.Boolean OnPitRoad
        {
            get
            {
                if (!_data.ContainsKey("OnPitRoad"))
                    return false;
                else
                    return (System.Boolean)_data["OnPitRoad"];
            }

            set
            {
                _data["OnPitRoad"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Steering wheel angle
        /// </summary>
        public System.Single SteeringWheelAngle
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelAngle"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelAngle"];
            }

            set
            {
                _data["SteeringWheelAngle"] = (System.Single)value;
            }
        }

        /// <summary>
        /// 0=off throttle to 1=full throttle
        /// </summary>
        public System.Single Throttle
        {
            get
            {
                if (!_data.ContainsKey("Throttle"))
                    return 0;
                else
                    return (System.Single)_data["Throttle"];
            }

            set
            {
                _data["Throttle"] = (System.Single)value;
            }
        }

        /// <summary>
        /// 0=brake released to 1=max pedal force
        /// </summary>
        public System.Single Brake
        {
            get
            {
                if (!_data.ContainsKey("Brake"))
                    return 0;
                else
                    return (System.Single)_data["Brake"];
            }

            set
            {
                _data["Brake"] = (System.Single)value;
            }
        }

        /// <summary>
        /// 0=disengaged to 1=fully engaged
        /// </summary>
        public System.Single Clutch
        {
            get
            {
                if (!_data.ContainsKey("Clutch"))
                    return 0;
                else
                    return (System.Single)_data["Clutch"];
            }

            set
            {
                _data["Clutch"] = (System.Single)value;
            }
        }

        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear
        /// </summary>
        public System.Int32 Gear
        {
            get
            {
                if (!_data.ContainsKey("Gear"))
                    return 0;
                else
                    return (System.Int32)_data["Gear"];
            }

            set
            {
                _data["Gear"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Engine rpm
        /// </summary>
        public System.Single RPM
        {
            get
            {
                if (!_data.ContainsKey("RPM"))
                    return 0;
                else
                    return (System.Single)_data["RPM"];
            }

            set
            {
                _data["RPM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Lap count
        /// </summary>
        public System.Int32 Lap
        {
            get
            {
                if (!_data.ContainsKey("Lap"))
                    return 0;
                else
                    return (System.Int32)_data["Lap"];
            }

            set
            {
                _data["Lap"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Meters traveled from S/F this lap
        /// </summary>
        public System.Single LapDist
        {
            get
            {
                if (!_data.ContainsKey("LapDist"))
                    return 0;
                else
                    return (System.Single)_data["LapDist"];
            }

            set
            {
                _data["LapDist"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Percentage distance around lap
        /// </summary>
        public System.Single LapDistPct
        {
            get
            {
                if (!_data.ContainsKey("LapDistPct"))
                    return 0;
                else
                    return (System.Single)_data["LapDistPct"];
            }

            set
            {
                _data["LapDistPct"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Laps completed in race
        /// </summary>
        public System.Int32 RaceLaps
        {
            get
            {
                if (!_data.ContainsKey("RaceLaps"))
                    return 0;
                else
                    return (System.Int32)_data["RaceLaps"];
            }

            set
            {
                _data["RaceLaps"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Players best lap number
        /// </summary>
        public System.Int32 LapBestLap
        {
            get
            {
                if (!_data.ContainsKey("LapBestLap"))
                    return 0;
                else
                    return (System.Int32)_data["LapBestLap"];
            }

            set
            {
                _data["LapBestLap"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Players best lap time
        /// </summary>
        public System.Single LapBestLapTime
        {
            get
            {
                if (!_data.ContainsKey("LapBestLapTime"))
                    return 0;
                else
                    return (System.Single)_data["LapBestLapTime"];
            }

            set
            {
                _data["LapBestLapTime"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Players last lap time
        /// </summary>
        public System.Single LapLastLapTime
        {
            get
            {
                if (!_data.ContainsKey("LapLastLapTime"))
                    return 0;
                else
                    return (System.Single)_data["LapLastLapTime"];
            }

            set
            {
                _data["LapLastLapTime"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Estimate of players current lap time as shown in F3 box
        /// </summary>
        public System.Single LapCurrentLapTime
        {
            get
            {
                if (!_data.ContainsKey("LapCurrentLapTime"))
                    return 0;
                else
                    return (System.Single)_data["LapCurrentLapTime"];
            }

            set
            {
                _data["LapCurrentLapTime"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Player num consecutive clean laps completed for N average
        /// </summary>
        public System.Int32 LapLasNLapSeq
        {
            get
            {
                if (!_data.ContainsKey("LapLasNLapSeq"))
                    return 0;
                else
                    return (System.Int32)_data["LapLasNLapSeq"];
            }

            set
            {
                _data["LapLasNLapSeq"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Player last N average lap time
        /// </summary>
        public System.Single LapLastNLapTime
        {
            get
            {
                if (!_data.ContainsKey("LapLastNLapTime"))
                    return 0;
                else
                    return (System.Single)_data["LapLastNLapTime"];
            }

            set
            {
                _data["LapLastNLapTime"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Player last lap in best N average lap time
        /// </summary>
        public System.Int32 LapBestNLapLap
        {
            get
            {
                if (!_data.ContainsKey("LapBestNLapLap"))
                    return 0;
                else
                    return (System.Int32)_data["LapBestNLapLap"];
            }

            set
            {
                _data["LapBestNLapLap"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Player best N average lap time
        /// </summary>
        public System.Single LapBestNLapTime
        {
            get
            {
                if (!_data.ContainsKey("LapBestNLapTime"))
                    return 0;
                else
                    return (System.Single)_data["LapBestNLapTime"];
            }

            set
            {
                _data["LapBestNLapTime"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Delta time for best lap
        /// </summary>
        public System.Single LapDeltaToBestLap
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToBestLap"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToBestLap"];
            }

            set
            {
                _data["LapDeltaToBestLap"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Rate of change of delta time for best lap
        /// </summary>
        public System.Single LapDeltaToBestLap_DD
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToBestLap_DD"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToBestLap_DD"];
            }

            set
            {
                _data["LapDeltaToBestLap_DD"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Delta time for best lap is valid
        /// </summary>
        public System.Boolean LapDeltaToBestLap_OK
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToBestLap_OK"))
                    return false;
                else
                    return (System.Boolean)_data["LapDeltaToBestLap_OK"];
            }

            set
            {
                _data["LapDeltaToBestLap_OK"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Delta time for optimal lap
        /// </summary>
        public System.Single LapDeltaToOptimalLap
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToOptimalLap"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToOptimalLap"];
            }

            set
            {
                _data["LapDeltaToOptimalLap"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Rate of change of delta time for optimal lap
        /// </summary>
        public System.Single LapDeltaToOptimalLap_DD
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToOptimalLap_DD"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToOptimalLap_DD"];
            }

            set
            {
                _data["LapDeltaToOptimalLap_DD"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Delta time for optimal lap is valid
        /// </summary>
        public System.Boolean LapDeltaToOptimalLap_OK
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToOptimalLap_OK"))
                    return false;
                else
                    return (System.Boolean)_data["LapDeltaToOptimalLap_OK"];
            }

            set
            {
                _data["LapDeltaToOptimalLap_OK"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Delta time for session best lap
        /// </summary>
        public System.Single LapDeltaToSessionBestLap
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionBestLap"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToSessionBestLap"];
            }

            set
            {
                _data["LapDeltaToSessionBestLap"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Rate of change of delta time for session best lap
        /// </summary>
        public System.Single LapDeltaToSessionBestLap_DD
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionBestLap_DD"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToSessionBestLap_DD"];
            }

            set
            {
                _data["LapDeltaToSessionBestLap_DD"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Delta time for session best lap is valid
        /// </summary>
        public System.Boolean LapDeltaToSessionBestLap_OK
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionBestLap_OK"))
                    return false;
                else
                    return (System.Boolean)_data["LapDeltaToSessionBestLap_OK"];
            }

            set
            {
                _data["LapDeltaToSessionBestLap_OK"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Delta time for session optimal lap
        /// </summary>
        public System.Single LapDeltaToSessionOptimalLap
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionOptimalLap"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToSessionOptimalLap"];
            }

            set
            {
                _data["LapDeltaToSessionOptimalLap"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Rate of change of delta time for session optimal lap
        /// </summary>
        public System.Single LapDeltaToSessionOptimalLap_DD
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionOptimalLap_DD"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToSessionOptimalLap_DD"];
            }

            set
            {
                _data["LapDeltaToSessionOptimalLap_DD"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Delta time for session optimal lap is valid
        /// </summary>
        public System.Boolean LapDeltaToSessionOptimalLap_OK
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionOptimalLap_OK"))
                    return false;
                else
                    return (System.Boolean)_data["LapDeltaToSessionOptimalLap_OK"];
            }

            set
            {
                _data["LapDeltaToSessionOptimalLap_OK"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Delta time for session last lap
        /// </summary>
        public System.Single LapDeltaToSessionLastlLap
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionLastlLap"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToSessionLastlLap"];
            }

            set
            {
                _data["LapDeltaToSessionLastlLap"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Rate of change of delta time for session last lap
        /// </summary>
        public System.Single LapDeltaToSessionLastlLap_DD
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionLastlLap_DD"))
                    return 0;
                else
                    return (System.Single)_data["LapDeltaToSessionLastlLap_DD"];
            }

            set
            {
                _data["LapDeltaToSessionLastlLap_DD"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Delta time for session last lap is valid
        /// </summary>
        public System.Boolean LapDeltaToSessionLastlLap_OK
        {
            get
            {
                if (!_data.ContainsKey("LapDeltaToSessionLastlLap_OK"))
                    return false;
                else
                    return (System.Boolean)_data["LapDeltaToSessionLastlLap_OK"];
            }

            set
            {
                _data["LapDeltaToSessionLastlLap_OK"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Longitudinal acceleration (including gravity)
        /// </summary>
        public System.Single LongAccel
        {
            get
            {
                if (!_data.ContainsKey("LongAccel"))
                    return 0;
                else
                    return (System.Single)_data["LongAccel"];
            }

            set
            {
                _data["LongAccel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Lateral acceleration (including gravity)
        /// </summary>
        public System.Single LatAccel
        {
            get
            {
                if (!_data.ContainsKey("LatAccel"))
                    return 0;
                else
                    return (System.Single)_data["LatAccel"];
            }

            set
            {
                _data["LatAccel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Vertical acceleration (including gravity)
        /// </summary>
        public System.Single VertAccel
        {
            get
            {
                if (!_data.ContainsKey("VertAccel"))
                    return 0;
                else
                    return (System.Single)_data["VertAccel"];
            }

            set
            {
                _data["VertAccel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Roll rate
        /// </summary>
        public System.Single RollRate
        {
            get
            {
                if (!_data.ContainsKey("RollRate"))
                    return 0;
                else
                    return (System.Single)_data["RollRate"];
            }

            set
            {
                _data["RollRate"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pitch rate
        /// </summary>
        public System.Single PitchRate
        {
            get
            {
                if (!_data.ContainsKey("PitchRate"))
                    return 0;
                else
                    return (System.Single)_data["PitchRate"];
            }

            set
            {
                _data["PitchRate"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Yaw rate
        /// </summary>
        public System.Single YawRate
        {
            get
            {
                if (!_data.ContainsKey("YawRate"))
                    return 0;
                else
                    return (System.Single)_data["YawRate"];
            }

            set
            {
                _data["YawRate"] = (System.Single)value;
            }
        }

        /// <summary>
        /// GPS vehicle speed
        /// </summary>
        public System.Single Speed
        {
            get
            {
                if (!_data.ContainsKey("Speed"))
                    return 0;
                else
                    return (System.Single)_data["Speed"];
            }

            set
            {
                _data["Speed"] = (System.Single)value;
            }
        }

        /// <summary>
        /// X velocity
        /// </summary>
        public System.Single VelocityX
        {
            get
            {
                if (!_data.ContainsKey("VelocityX"))
                    return 0;
                else
                    return (System.Single)_data["VelocityX"];
            }

            set
            {
                _data["VelocityX"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Y velocity
        /// </summary>
        public System.Single VelocityY
        {
            get
            {
                if (!_data.ContainsKey("VelocityY"))
                    return 0;
                else
                    return (System.Single)_data["VelocityY"];
            }

            set
            {
                _data["VelocityY"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Z velocity
        /// </summary>
        public System.Single VelocityZ
        {
            get
            {
                if (!_data.ContainsKey("VelocityZ"))
                    return 0;
                else
                    return (System.Single)_data["VelocityZ"];
            }

            set
            {
                _data["VelocityZ"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Yaw orientation
        /// </summary>
        public System.Single Yaw
        {
            get
            {
                if (!_data.ContainsKey("Yaw"))
                    return 0;
                else
                    return (System.Single)_data["Yaw"];
            }

            set
            {
                _data["Yaw"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pitch orientation
        /// </summary>
        public System.Single Pitch
        {
            get
            {
                if (!_data.ContainsKey("Pitch"))
                    return 0;
                else
                    return (System.Single)_data["Pitch"];
            }

            set
            {
                _data["Pitch"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Roll orientation
        /// </summary>
        public System.Single Roll
        {
            get
            {
                if (!_data.ContainsKey("Roll"))
                    return 0;
                else
                    return (System.Single)_data["Roll"];
            }

            set
            {
                _data["Roll"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Indicate action the reset key will take 0 enter 1 exit 2 reset
        /// </summary>
        public System.Int32 EnterExitReset
        {
            get
            {
                if (!_data.ContainsKey("EnterExitReset"))
                    return 0;
                else
                    return (System.Int32)_data["EnterExitReset"];
            }

            set
            {
                _data["EnterExitReset"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Temperature of track at start/finish line
        /// </summary>
        public System.Single TrackTemp
        {
            get
            {
                if (!_data.ContainsKey("TrackTemp"))
                    return 0;
                else
                    return (System.Single)_data["TrackTemp"];
            }

            set
            {
                _data["TrackTemp"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Temperature of air at start/finish line
        /// </summary>
        public System.Single AirTemp
        {
            get
            {
                if (!_data.ContainsKey("AirTemp"))
                    return 0;
                else
                    return (System.Single)_data["AirTemp"];
            }

            set
            {
                _data["AirTemp"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Weather type (0=constant  1=dynamic)
        /// </summary>
        public System.Int32 WeatherType
        {
            get
            {
                if (!_data.ContainsKey("WeatherType"))
                    return 0;
                else
                    return (System.Int32)_data["WeatherType"];
            }

            set
            {
                _data["WeatherType"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Skies (0=clear/1=p cloudy/2=m cloudy/3=overcast)
        /// </summary>
        public System.Int32 Skies
        {
            get
            {
                if (!_data.ContainsKey("Skies"))
                    return 0;
                else
                    return (System.Int32)_data["Skies"];
            }

            set
            {
                _data["Skies"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Density of air at start/finish line
        /// </summary>
        public System.Single AirDensity
        {
            get
            {
                if (!_data.ContainsKey("AirDensity"))
                    return 0;
                else
                    return (System.Single)_data["AirDensity"];
            }

            set
            {
                _data["AirDensity"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pressure of air at start/finish line
        /// </summary>
        public System.Single AirPressure
        {
            get
            {
                if (!_data.ContainsKey("AirPressure"))
                    return 0;
                else
                    return (System.Single)_data["AirPressure"];
            }

            set
            {
                _data["AirPressure"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Wind velocity at start/finish line
        /// </summary>
        public System.Single WindVel
        {
            get
            {
                if (!_data.ContainsKey("WindVel"))
                    return 0;
                else
                    return (System.Single)_data["WindVel"];
            }

            set
            {
                _data["WindVel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Wind direction at start/finish line
        /// </summary>
        public System.Single WindDir
        {
            get
            {
                if (!_data.ContainsKey("WindDir"))
                    return 0;
                else
                    return (System.Single)_data["WindDir"];
            }

            set
            {
                _data["WindDir"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Relative Humidity
        /// </summary>
        public System.Single RelativeHumidity
        {
            get
            {
                if (!_data.ContainsKey("RelativeHumidity"))
                    return 0;
                else
                    return (System.Single)_data["RelativeHumidity"];
            }

            set
            {
                _data["RelativeHumidity"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Fog level
        /// </summary>
        public System.Single FogLevel
        {
            get
            {
                if (!_data.ContainsKey("FogLevel"))
                    return 0;
                else
                    return (System.Single)_data["FogLevel"];
            }

            set
            {
                _data["FogLevel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Status of driver change lap requirements
        /// </summary>
        public System.Int32 DCLapStatus
        {
            get
            {
                if (!_data.ContainsKey("DCLapStatus"))
                    return 0;
                else
                    return (System.Int32)_data["DCLapStatus"];
            }

            set
            {
                _data["DCLapStatus"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Number of team drivers who have run a stint
        /// </summary>
        public System.Int32 DCDriversSoFar
        {
            get
            {
                if (!_data.ContainsKey("DCDriversSoFar"))
                    return 0;
                else
                    return (System.Int32)_data["DCDriversSoFar"];
            }

            set
            {
                _data["DCDriversSoFar"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Time left for mandatory pit repairs if repairs are active
        /// </summary>
        public System.Single PitRepairLeft
        {
            get
            {
                if (!_data.ContainsKey("PitRepairLeft"))
                    return 0;
                else
                    return (System.Single)_data["PitRepairLeft"];
            }

            set
            {
                _data["PitRepairLeft"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Time left for optional repairs if repairs are active
        /// </summary>
        public System.Single PitOptRepairLeft
        {
            get
            {
                if (!_data.ContainsKey("PitOptRepairLeft"))
                    return 0;
                else
                    return (System.Single)_data["PitOptRepairLeft"];
            }

            set
            {
                _data["PitOptRepairLeft"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Active camera's focus car index
        /// </summary>
        public System.Int32 CamCarIdx
        {
            get
            {
                if (!_data.ContainsKey("CamCarIdx"))
                    return 0;
                else
                    return (System.Int32)_data["CamCarIdx"];
            }

            set
            {
                _data["CamCarIdx"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Active camera number
        /// </summary>
        public System.Int32 CamCameraNumber
        {
            get
            {
                if (!_data.ContainsKey("CamCameraNumber"))
                    return 0;
                else
                    return (System.Int32)_data["CamCameraNumber"];
            }

            set
            {
                _data["CamCameraNumber"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Active camera group number
        /// </summary>
        public System.Int32 CamGroupNumber
        {
            get
            {
                if (!_data.ContainsKey("CamGroupNumber"))
                    return 0;
                else
                    return (System.Int32)_data["CamGroupNumber"];
            }

            set
            {
                _data["CamGroupNumber"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// State of camera system
        /// </summary>
        public System.Int32 CamCameraState
        {
            get
            {
                if (!_data.ContainsKey("CamCameraState"))
                    return 0;
                else
                    return (System.Int32)_data["CamCameraState"];
            }

            set
            {
                _data["CamCameraState"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// 1=Car on track physics running
        /// </summary>
        public System.Boolean IsOnTrackCar
        {
            get
            {
                if (!_data.ContainsKey("IsOnTrackCar"))
                    return false;
                else
                    return (System.Boolean)_data["IsOnTrackCar"];
            }

            set
            {
                _data["IsOnTrackCar"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// 1=Car in garage physics running
        /// </summary>
        public System.Boolean IsInGarage
        {
            get
            {
                if (!_data.ContainsKey("IsInGarage"))
                    return false;
                else
                    return (System.Boolean)_data["IsInGarage"];
            }

            set
            {
                _data["IsInGarage"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Output torque on steering shaft
        /// </summary>
        public System.Single SteeringWheelTorque
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelTorque"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelTorque"];
            }

            set
            {
                _data["SteeringWheelTorque"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft unsigned
        /// </summary>
        public System.Single SteeringWheelPctTorque
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelPctTorque"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelPctTorque"];
            }

            set
            {
                _data["SteeringWheelPctTorque"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed
        /// </summary>
        public System.Single SteeringWheelPctTorqueSign
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelPctTorqueSign"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelPctTorqueSign"];
            }

            set
            {
                _data["SteeringWheelPctTorqueSign"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed stops
        /// </summary>
        public System.Single SteeringWheelPctTorqueSignStops
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelPctTorqueSignStops"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelPctTorqueSignStops"];
            }

            set
            {
                _data["SteeringWheelPctTorqueSignStops"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Force feedback % max damping
        /// </summary>
        public System.Single SteeringWheelPctDamper
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelPctDamper"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelPctDamper"];
            }

            set
            {
                _data["SteeringWheelPctDamper"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Steering wheel max angle
        /// </summary>
        public System.Single SteeringWheelAngleMax
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelAngleMax"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelAngleMax"];
            }

            set
            {
                _data["SteeringWheelAngleMax"] = (System.Single)value;
            }
        }

        /// <summary>
        /// DEPRECATED use DriverCarSLBlinkRPM instead
        /// </summary>
        public System.Single ShiftIndicatorPct
        {
            get
            {
                if (!_data.ContainsKey("ShiftIndicatorPct"))
                    return 0;
                else
                    return (System.Single)_data["ShiftIndicatorPct"];
            }

            set
            {
                _data["ShiftIndicatorPct"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Friction torque applied to gears when shifting or grinding
        /// </summary>
        public System.Single ShiftPowerPct
        {
            get
            {
                if (!_data.ContainsKey("ShiftPowerPct"))
                    return 0;
                else
                    return (System.Single)_data["ShiftPowerPct"];
            }

            set
            {
                _data["ShiftPowerPct"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RPM of shifter grinding noise
        /// </summary>
        public System.Single ShiftGrindRPM
        {
            get
            {
                if (!_data.ContainsKey("ShiftGrindRPM"))
                    return 0;
                else
                    return (System.Single)_data["ShiftGrindRPM"];
            }

            set
            {
                _data["ShiftGrindRPM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Raw throttle input 0=off throttle to 1=full throttle
        /// </summary>
        public System.Single ThrottleRaw
        {
            get
            {
                if (!_data.ContainsKey("ThrottleRaw"))
                    return 0;
                else
                    return (System.Single)_data["ThrottleRaw"];
            }

            set
            {
                _data["ThrottleRaw"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Raw brake input 0=brake released to 1=max pedal force
        /// </summary>
        public System.Single BrakeRaw
        {
            get
            {
                if (!_data.ContainsKey("BrakeRaw"))
                    return 0;
                else
                    return (System.Single)_data["BrakeRaw"];
            }

            set
            {
                _data["BrakeRaw"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Peak torque mapping to direct input units for FFB
        /// </summary>
        public System.Single SteeringWheelPeakForceNm
        {
            get
            {
                if (!_data.ContainsKey("SteeringWheelPeakForceNm"))
                    return 0;
                else
                    return (System.Single)_data["SteeringWheelPeakForceNm"];
            }

            set
            {
                _data["SteeringWheelPeakForceNm"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Bitfield for warning lights
        /// </summary>
        public System.Int32 EngineWarnings
        {
            get
            {
                if (!_data.ContainsKey("EngineWarnings"))
                    return 0;
                else
                    return (System.Int32)_data["EngineWarnings"];
            }

            set
            {
                _data["EngineWarnings"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Liters of fuel remaining
        /// </summary>
        public System.Single FuelLevel
        {
            get
            {
                if (!_data.ContainsKey("FuelLevel"))
                    return 0;
                else
                    return (System.Single)_data["FuelLevel"];
            }

            set
            {
                _data["FuelLevel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Percent fuel remaining
        /// </summary>
        public System.Single FuelLevelPct
        {
            get
            {
                if (!_data.ContainsKey("FuelLevelPct"))
                    return 0;
                else
                    return (System.Single)_data["FuelLevelPct"];
            }

            set
            {
                _data["FuelLevelPct"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Bitfield of pit service checkboxes
        /// </summary>
        public System.Int32 PitSvFlags
        {
            get
            {
                if (!_data.ContainsKey("PitSvFlags"))
                    return 0;
                else
                    return (System.Int32)_data["PitSvFlags"];
            }

            set
            {
                _data["PitSvFlags"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Pit service left front tire pressure
        /// </summary>
        public System.Single PitSvLFP
        {
            get
            {
                if (!_data.ContainsKey("PitSvLFP"))
                    return 0;
                else
                    return (System.Single)_data["PitSvLFP"];
            }

            set
            {
                _data["PitSvLFP"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pit service right front tire pressure
        /// </summary>
        public System.Single PitSvRFP
        {
            get
            {
                if (!_data.ContainsKey("PitSvRFP"))
                    return 0;
                else
                    return (System.Single)_data["PitSvRFP"];
            }

            set
            {
                _data["PitSvRFP"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pit service left rear tire pressure
        /// </summary>
        public System.Single PitSvLRP
        {
            get
            {
                if (!_data.ContainsKey("PitSvLRP"))
                    return 0;
                else
                    return (System.Single)_data["PitSvLRP"];
            }

            set
            {
                _data["PitSvLRP"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pit service right rear tire pressure
        /// </summary>
        public System.Single PitSvRRP
        {
            get
            {
                if (!_data.ContainsKey("PitSvRRP"))
                    return 0;
                else
                    return (System.Single)_data["PitSvRRP"];
            }

            set
            {
                _data["PitSvRRP"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Pit service fuel add amount
        /// </summary>
        public System.Single PitSvFuel
        {
            get
            {
                if (!_data.ContainsKey("PitSvFuel"))
                    return 0;
                else
                    return (System.Single)_data["PitSvFuel"];
            }

            set
            {
                _data["PitSvFuel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Replay playback speed
        /// </summary>
        public System.Int32 ReplayPlaySpeed
        {
            get
            {
                if (!_data.ContainsKey("ReplayPlaySpeed"))
                    return 0;
                else
                    return (System.Int32)_data["ReplayPlaySpeed"];
            }

            set
            {
                _data["ReplayPlaySpeed"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// 0=not slow motion  1=replay is in slow motion
        /// </summary>
        public System.Boolean ReplayPlaySlowMotion
        {
            get
            {
                if (!_data.ContainsKey("ReplayPlaySlowMotion"))
                    return false;
                else
                    return (System.Boolean)_data["ReplayPlaySlowMotion"];
            }

            set
            {
                _data["ReplayPlaySlowMotion"] = (System.Boolean)value;
            }
        }

        /// <summary>
        /// Seconds since replay session start
        /// </summary>
        public System.Double ReplaySessionTime
        {
            get
            {
                if (!_data.ContainsKey("ReplaySessionTime"))
                    return 0;
                else
                    return (System.Double)_data["ReplaySessionTime"];
            }

            set
            {
                _data["ReplaySessionTime"] = (System.Double)value;
            }
        }

        /// <summary>
        /// Replay session number
        /// </summary>
        public System.Int32 ReplaySessionNum
        {
            get
            {
                if (!_data.ContainsKey("ReplaySessionNum"))
                    return 0;
                else
                    return (System.Int32)_data["ReplaySessionNum"];
            }

            set
            {
                _data["ReplaySessionNum"] = (System.Int32)value;
            }
        }

        /// <summary>
        /// Engine coolant temp
        /// </summary>
        public System.Single WaterTemp
        {
            get
            {
                if (!_data.ContainsKey("WaterTemp"))
                    return 0;
                else
                    return (System.Single)_data["WaterTemp"];
            }

            set
            {
                _data["WaterTemp"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine coolant level
        /// </summary>
        public System.Single WaterLevel
        {
            get
            {
                if (!_data.ContainsKey("WaterLevel"))
                    return 0;
                else
                    return (System.Single)_data["WaterLevel"];
            }

            set
            {
                _data["WaterLevel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine fuel pressure
        /// </summary>
        public System.Single FuelPress
        {
            get
            {
                if (!_data.ContainsKey("FuelPress"))
                    return 0;
                else
                    return (System.Single)_data["FuelPress"];
            }

            set
            {
                _data["FuelPress"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine oil temperature
        /// </summary>
        public System.Single OilTemp
        {
            get
            {
                if (!_data.ContainsKey("OilTemp"))
                    return 0;
                else
                    return (System.Single)_data["OilTemp"];
            }

            set
            {
                _data["OilTemp"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine oil pressure
        /// </summary>
        public System.Single OilPress
        {
            get
            {
                if (!_data.ContainsKey("OilPress"))
                    return 0;
                else
                    return (System.Single)_data["OilPress"];
            }

            set
            {
                _data["OilPress"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine oil level
        /// </summary>
        public System.Single OilLevel
        {
            get
            {
                if (!_data.ContainsKey("OilLevel"))
                    return 0;
                else
                    return (System.Single)_data["OilLevel"];
            }

            set
            {
                _data["OilLevel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine voltage
        /// </summary>
        public System.Single Voltage
        {
            get
            {
                if (!_data.ContainsKey("Voltage"))
                    return 0;
                else
                    return (System.Single)_data["Voltage"];
            }

            set
            {
                _data["Voltage"] = (System.Single)value;
            }
        }

        /// <summary>
        /// Engine manifold pressure
        /// </summary>
        public System.Single ManifoldPress
        {
            get
            {
                if (!_data.ContainsKey("ManifoldPress"))
                    return 0;
                else
                    return (System.Single)_data["ManifoldPress"];
            }

            set
            {
                _data["ManifoldPress"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire cold pressure  as set in the garage
        /// </summary>
        public System.Single LFcoldPressure
        {
            get
            {
                if (!_data.ContainsKey("LFcoldPressure"))
                    return 0;
                else
                    return (System.Single)_data["LFcoldPressure"];
            }

            set
            {
                _data["LFcoldPressure"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire left carcass temperature
        /// </summary>
        public System.Single LFtempCL
        {
            get
            {
                if (!_data.ContainsKey("LFtempCL"))
                    return 0;
                else
                    return (System.Single)_data["LFtempCL"];
            }

            set
            {
                _data["LFtempCL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire middle carcass temperature
        /// </summary>
        public System.Single LFtempCM
        {
            get
            {
                if (!_data.ContainsKey("LFtempCM"))
                    return 0;
                else
                    return (System.Single)_data["LFtempCM"];
            }

            set
            {
                _data["LFtempCM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire right carcass temperature
        /// </summary>
        public System.Single LFtempCR
        {
            get
            {
                if (!_data.ContainsKey("LFtempCR"))
                    return 0;
                else
                    return (System.Single)_data["LFtempCR"];
            }

            set
            {
                _data["LFtempCR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire left percent tread remaining
        /// </summary>
        public System.Single LFwearL
        {
            get
            {
                if (!_data.ContainsKey("LFwearL"))
                    return 0;
                else
                    return (System.Single)_data["LFwearL"];
            }

            set
            {
                _data["LFwearL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire middle percent tread remaining
        /// </summary>
        public System.Single LFwearM
        {
            get
            {
                if (!_data.ContainsKey("LFwearM"))
                    return 0;
                else
                    return (System.Single)_data["LFwearM"];
            }

            set
            {
                _data["LFwearM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF tire right percent tread remaining
        /// </summary>
        public System.Single LFwearR
        {
            get
            {
                if (!_data.ContainsKey("LFwearR"))
                    return 0;
                else
                    return (System.Single)_data["LFwearR"];
            }

            set
            {
                _data["LFwearR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire cold pressure  as set in the garage
        /// </summary>
        public System.Single RRcoldPressure
        {
            get
            {
                if (!_data.ContainsKey("RRcoldPressure"))
                    return 0;
                else
                    return (System.Single)_data["RRcoldPressure"];
            }

            set
            {
                _data["RRcoldPressure"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire left carcass temperature
        /// </summary>
        public System.Single RRtempCL
        {
            get
            {
                if (!_data.ContainsKey("RRtempCL"))
                    return 0;
                else
                    return (System.Single)_data["RRtempCL"];
            }

            set
            {
                _data["RRtempCL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire middle carcass temperature
        /// </summary>
        public System.Single RRtempCM
        {
            get
            {
                if (!_data.ContainsKey("RRtempCM"))
                    return 0;
                else
                    return (System.Single)_data["RRtempCM"];
            }

            set
            {
                _data["RRtempCM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire right carcass temperature
        /// </summary>
        public System.Single RRtempCR
        {
            get
            {
                if (!_data.ContainsKey("RRtempCR"))
                    return 0;
                else
                    return (System.Single)_data["RRtempCR"];
            }

            set
            {
                _data["RRtempCR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire left percent tread remaining
        /// </summary>
        public System.Single RRwearL
        {
            get
            {
                if (!_data.ContainsKey("RRwearL"))
                    return 0;
                else
                    return (System.Single)_data["RRwearL"];
            }

            set
            {
                _data["RRwearL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire middle percent tread remaining
        /// </summary>
        public System.Single RRwearM
        {
            get
            {
                if (!_data.ContainsKey("RRwearM"))
                    return 0;
                else
                    return (System.Single)_data["RRwearM"];
            }

            set
            {
                _data["RRwearM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR tire right percent tread remaining
        /// </summary>
        public System.Single RRwearR
        {
            get
            {
                if (!_data.ContainsKey("RRwearR"))
                    return 0;
                else
                    return (System.Single)_data["RRwearR"];
            }

            set
            {
                _data["RRwearR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire cold pressure  as set in the garage
        /// </summary>
        public System.Single LRcoldPressure
        {
            get
            {
                if (!_data.ContainsKey("LRcoldPressure"))
                    return 0;
                else
                    return (System.Single)_data["LRcoldPressure"];
            }

            set
            {
                _data["LRcoldPressure"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire left carcass temperature
        /// </summary>
        public System.Single LRtempCL
        {
            get
            {
                if (!_data.ContainsKey("LRtempCL"))
                    return 0;
                else
                    return (System.Single)_data["LRtempCL"];
            }

            set
            {
                _data["LRtempCL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire middle carcass temperature
        /// </summary>
        public System.Single LRtempCM
        {
            get
            {
                if (!_data.ContainsKey("LRtempCM"))
                    return 0;
                else
                    return (System.Single)_data["LRtempCM"];
            }

            set
            {
                _data["LRtempCM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire right carcass temperature
        /// </summary>
        public System.Single LRtempCR
        {
            get
            {
                if (!_data.ContainsKey("LRtempCR"))
                    return 0;
                else
                    return (System.Single)_data["LRtempCR"];
            }

            set
            {
                _data["LRtempCR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire left percent tread remaining
        /// </summary>
        public System.Single LRwearL
        {
            get
            {
                if (!_data.ContainsKey("LRwearL"))
                    return 0;
                else
                    return (System.Single)_data["LRwearL"];
            }

            set
            {
                _data["LRwearL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire middle percent tread remaining
        /// </summary>
        public System.Single LRwearM
        {
            get
            {
                if (!_data.ContainsKey("LRwearM"))
                    return 0;
                else
                    return (System.Single)_data["LRwearM"];
            }

            set
            {
                _data["LRwearM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR tire right percent tread remaining
        /// </summary>
        public System.Single LRwearR
        {
            get
            {
                if (!_data.ContainsKey("LRwearR"))
                    return 0;
                else
                    return (System.Single)_data["LRwearR"];
            }

            set
            {
                _data["LRwearR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire cold pressure  as set in the garage
        /// </summary>
        public System.Single RFcoldPressure
        {
            get
            {
                if (!_data.ContainsKey("RFcoldPressure"))
                    return 0;
                else
                    return (System.Single)_data["RFcoldPressure"];
            }

            set
            {
                _data["RFcoldPressure"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire left carcass temperature
        /// </summary>
        public System.Single RFtempCL
        {
            get
            {
                if (!_data.ContainsKey("RFtempCL"))
                    return 0;
                else
                    return (System.Single)_data["RFtempCL"];
            }

            set
            {
                _data["RFtempCL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire middle carcass temperature
        /// </summary>
        public System.Single RFtempCM
        {
            get
            {
                if (!_data.ContainsKey("RFtempCM"))
                    return 0;
                else
                    return (System.Single)_data["RFtempCM"];
            }

            set
            {
                _data["RFtempCM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire right carcass temperature
        /// </summary>
        public System.Single RFtempCR
        {
            get
            {
                if (!_data.ContainsKey("RFtempCR"))
                    return 0;
                else
                    return (System.Single)_data["RFtempCR"];
            }

            set
            {
                _data["RFtempCR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire left percent tread remaining
        /// </summary>
        public System.Single RFwearL
        {
            get
            {
                if (!_data.ContainsKey("RFwearL"))
                    return 0;
                else
                    return (System.Single)_data["RFwearL"];
            }

            set
            {
                _data["RFwearL"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire middle percent tread remaining
        /// </summary>
        public System.Single RFwearM
        {
            get
            {
                if (!_data.ContainsKey("RFwearM"))
                    return 0;
                else
                    return (System.Single)_data["RFwearM"];
            }

            set
            {
                _data["RFwearM"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF tire right percent tread remaining
        /// </summary>
        public System.Single RFwearR
        {
            get
            {
                if (!_data.ContainsKey("RFwearR"))
                    return 0;
                else
                    return (System.Single)_data["RFwearR"];
            }

            set
            {
                _data["RFwearR"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR shock deflection
        /// </summary>
        public System.Single RRshockDefl
        {
            get
            {
                if (!_data.ContainsKey("RRshockDefl"))
                    return 0;
                else
                    return (System.Single)_data["RRshockDefl"];
            }

            set
            {
                _data["RRshockDefl"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RR shock velocity
        /// </summary>
        public System.Single RRshockVel
        {
            get
            {
                if (!_data.ContainsKey("RRshockVel"))
                    return 0;
                else
                    return (System.Single)_data["RRshockVel"];
            }

            set
            {
                _data["RRshockVel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR shock deflection
        /// </summary>
        public System.Single LRshockDefl
        {
            get
            {
                if (!_data.ContainsKey("LRshockDefl"))
                    return 0;
                else
                    return (System.Single)_data["LRshockDefl"];
            }

            set
            {
                _data["LRshockDefl"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LR shock velocity
        /// </summary>
        public System.Single LRshockVel
        {
            get
            {
                if (!_data.ContainsKey("LRshockVel"))
                    return 0;
                else
                    return (System.Single)_data["LRshockVel"];
            }

            set
            {
                _data["LRshockVel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF shock deflection
        /// </summary>
        public System.Single RFshockDefl
        {
            get
            {
                if (!_data.ContainsKey("RFshockDefl"))
                    return 0;
                else
                    return (System.Single)_data["RFshockDefl"];
            }

            set
            {
                _data["RFshockDefl"] = (System.Single)value;
            }
        }

        /// <summary>
        /// RF shock velocity
        /// </summary>
        public System.Single RFshockVel
        {
            get
            {
                if (!_data.ContainsKey("RFshockVel"))
                    return 0;
                else
                    return (System.Single)_data["RFshockVel"];
            }

            set
            {
                _data["RFshockVel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF shock deflection
        /// </summary>
        public System.Single LFshockDefl
        {
            get
            {
                if (!_data.ContainsKey("LFshockDefl"))
                    return 0;
                else
                    return (System.Single)_data["LFshockDefl"];
            }

            set
            {
                _data["LFshockDefl"] = (System.Single)value;
            }
        }

        /// <summary>
        /// LF shock velocity
        /// </summary>
        public System.Single LFshockVel
        {
            get
            {
                if (!_data.ContainsKey("LFshockVel"))
                    return 0;
                else
                    return (System.Single)_data["LFshockVel"];
            }

            set
            {
                _data["LFshockVel"] = (System.Single)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 TickCount
        {
            get
            {
                if (!_data.ContainsKey("TickCount"))
                    return 0;
                else
                    return (System.Int32)_data["TickCount"];
            }

            set
            {
                _data["TickCount"] = (System.Int32)value;
            }
        }
        #endregion

        #region calculated values
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
            set
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

        public bool[] HasSeenCheckeredFlag;
        public bool IsFinalLap;
        public bool LeaderHasFinished;
        public bool[] HasRetired;

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
            set { }
        }

        public SessionsModel Session
        {
            get
            {
                if (SessionNum < 0 || SessionNum >= SessionData.SessionInfo.Sessions.Length)
                    return null;

                return SessionData.SessionInfo.Sessions[SessionNum];
            }
            set { }
        }

        public CarModel CamCar { get { return Cars[CamCarIdx]; } }

        CarArrayModel cars;
        public CarArrayModel Cars
        {
            get
            {
                if (cars != null)
                    return cars;

                return cars = new CarArrayModel(this);
            }
        }

        public IEnumerable<CarModel> RaceCars
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
            set { }
        }
        #endregion

        #region missing
        public float LFSHshockDefl
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float LFSHshockVel
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float LRSHshockDefl
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float LRSHshockVel
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float RFSHshockDefl
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float RFSHshockVel
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float RRSHshockDefl
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }

        public float RRSHshockVel
        {
            get
            {
                return (float)0;
                //  throw new NotImplementedException();
            }
            set
            {
                //  throw new NotImplementedException();
            }
        }
        #endregion

        #region overrides
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var kv in _data)
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
