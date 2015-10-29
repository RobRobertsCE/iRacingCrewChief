using System;
using System.Collections.Generic;
using iRacing.Models.Cars;
using iRacing.Models.Sessions;
using iRacing.Models.Timing;

namespace iRacing.Models.Telemetry
{
    public interface ITelemetry : IDictionary<string, object>
    {
        bool HasData(int carIdx);

        Session Session { get; }
        TimeSpan SessionTimeSpan { get; }
        Car CamCar { get; }
        CarArray Cars { get; }
        CarDetails[] CarDetails { get; }
        IEnumerable<Car> RaceCars { get; }
        bool UnderPaceCar { get; }
        LapSector[] CarSectorIdx { get; }
        float RaceDistance { get; }
        int[] Positions { get; }
        FastLap FastestLap { get; set; }
        int[] CarIdxPitStopCount { get; set; }

        bool[] HasSeenCheckeredFlag { get; set; }
        bool IsFinalLap { get; set; }
        bool LeaderHasFinished { get; set; }
        bool[] HasRetired { get; set; }

        float AirDensity { get; set; }
        float AirPressure { get; set; }
        float AirTemp { get; set; }
        float Brake { get; set; }
        float BrakeRaw { get; set; }
        int CamCameraNumber { get; set; }
        int CamCameraState { get; set; }
        int CamCarIdx { get; set; }
        int CamGroupNumber { get; set; }
        int[] CarIdxClassPosition { get; set; }
        float[] CarIdxEstTime { get; set; }
        float[] CarIdxF2Time { get; set; }
        int[] CarIdxGear { get; set; }
        int[] CarIdxLap { get; set; }
        float[] CarIdxLapDistPct { get; set; }
        bool[] CarIdxOnPitRoad { get; set; }
        int[] CarIdxPosition { get; set; }
        float[] CarIdxRPM { get; set; }
        float[] CarIdxSteer { get; set; }
        TrackLocation[] CarIdxTrackSurface { get; set; }
        float Clutch { get; set; }
        float CpuUsageBG { get; set; }
        float dcBrakeBias { get; set; }
        int DCDriversSoFar { get; set; }
        int DCLapStatus { get; set; }
        int DisplayUnits { get; set; }
        float dpQtape { get; set; }
        bool DriverMarker { get; set; }
        int EngineWarnings { get; set; }
        int EnterExitReset { get; set; }
        float FogLevel { get; set; }
        float FrameRate { get; set; }
        float FuelLevel { get; set; }
        float FuelLevelPct { get; set; }
        float FuelPress { get; set; }
        int Gear { get; set; }
        bool IsDiskLoggingActive { get; set; }
        bool IsDiskLoggingEnabled { get; set; }
        bool IsInGarage { get; set; }
        bool IsOnTrack { get; set; }
        bool IsOnTrackCar { get; set; }
        bool IsReplayPlaying { get; set; }
        int Lap { get; set; }
        int LapBestLap { get; set; }
        float LapBestLapTime { get; set; }
        int LapBestNLapLap { get; set; }
        float LapBestNLapTime { get; set; }
        float LapCurrentLapTime { get; set; }
        float LapDeltaToBestLap { get; set; }
        float LapDeltaToBestLap_DD { get; set; }
        bool LapDeltaToBestLap_OK { get; set; }
        float LapDeltaToOptimalLap { get; set; }
        float LapDeltaToOptimalLap_DD { get; set; }
        bool LapDeltaToOptimalLap_OK { get; set; }
        float LapDeltaToSessionBestLap { get; set; }
        float LapDeltaToSessionBestLap_DD { get; set; }
        bool LapDeltaToSessionBestLap_OK { get; set; }
        float LapDeltaToSessionLastlLap { get; set; }
        float LapDeltaToSessionLastlLap_DD { get; set; }
        bool LapDeltaToSessionLastlLap_OK { get; set; }
        float LapDeltaToSessionOptimalLap { get; set; }
        float LapDeltaToSessionOptimalLap_DD { get; set; }
        bool LapDeltaToSessionOptimalLap_OK { get; set; }
        float LapDist { get; set; }
        float LapDistPct { get; set; }
        int LapLasNLapSeq { get; set; }
        float LapLastLapTime { get; set; }
        float LapLastNLapTime { get; set; }
        float LatAccel { get; set; }
        float LFbrakeLinePress { get; set; }
        float LFcoldPressure { get; set; }
        float LFshockDefl { get; set; }
        float LFshockVel { get; set; }
        float LFtempCL { get; set; }
        float LFtempCM { get; set; }
        float LFtempCR { get; set; }
        float LFwearL { get; set; }
        float LFwearM { get; set; }
        float LFwearR { get; set; }
        float LongAccel { get; set; }
        float LRbrakeLinePress { get; set; }
        float LRcoldPressure { get; set; }
        float LRshockDefl { get; set; }
        float LRshockVel { get; set; }
        float LRtempCL { get; set; }
        float LRtempCM { get; set; }
        float LRtempCR { get; set; }
        float LRwearL { get; set; }
        float LRwearM { get; set; }
        float LRwearR { get; set; }
        float ManifoldPress { get; set; }
        float OilLevel { get; set; }
        float OilPress { get; set; }
        float OilTemp { get; set; }
        bool OnPitRoad { get; set; }
        float Pitch { get; set; }
        float PitchRate { get; set; }
        float PitOptRepairLeft { get; set; }
        float PitRepairLeft { get; set; }
        int PitSvFlags { get; set; }
        float PitSvFuel { get; set; }
        float PitSvLFP { get; set; }
        float PitSvLRP { get; set; }
        float PitSvRFP { get; set; }
        float PitSvRRP { get; set; }
        int PlayerCarClassPosition { get; set; }
        int PlayerCarPosition { get; set; }
        int RaceLaps { get; set; }
        int RadioTransmitCarIdx { get; set; }
        int RadioTransmitFrequencyIdx { get; set; }
        int RadioTransmitRadioIdx { get; set; }
        float RelativeHumidity { get; set; }
        int ReplayFrameNum { get; set; }
        int ReplayFrameNumEnd { get; set; }
        bool ReplayPlaySlowMotion { get; set; }
        int ReplayPlaySpeed { get; set; }
        int ReplaySessionNum { get; set; }
        double ReplaySessionTime { get; set; }
        float RFbrakeLinePress { get; set; }
        float RFcoldPressure { get; set; }
        float RFshockDefl { get; set; }
        float RFshockVel { get; set; }
        float RFtempCL { get; set; }
        float RFtempCM { get; set; }
        float RFtempCR { get; set; }
        float RFwearL { get; set; }
        float RFwearM { get; set; }
        float RFwearR { get; set; }
        float Roll { get; set; }
        float RollRate { get; set; }
        float RPM { get; set; }
        float RRbrakeLinePress { get; set; }
        float RRcoldPressure { get; set; }
        float RRshockDefl { get; set; }
        float RRshockVel { get; set; }
        float RRtempCL { get; set; }
        float RRtempCM { get; set; }
        float RRtempCR { get; set; }
        float RRwearL { get; set; }
        float RRwearM { get; set; }
        float RRwearR { get; set; }
        SessionData SessionData { get; set; }
        SessionFlags SessionFlags { get; set; }
        int SessionLapsRemain { get; set; }
        int SessionNum { get; set; }
        SessionState SessionState { get; set; }
        double SessionTime { get; set; }
        double SessionTimeRemain { get; set; }
        int SessionUniqueID { get; set; }
        float ShiftGrindRPM { get; set; }
        float ShiftIndicatorPct { get; set; }
        float ShiftPowerPct { get; set; }
        int Skies { get; set; }
        float Speed { get; set; }
        float SteeringWheelAngle { get; set; }
        float SteeringWheelAngleMax { get; set; }
        float SteeringWheelPctDamper { get; set; }
        float SteeringWheelPctTorque { get; set; }
        float SteeringWheelPctTorqueSign { get; set; }
        float SteeringWheelPctTorqueSignStops { get; set; }
        float SteeringWheelPeakForceNm { get; set; }
        float SteeringWheelTorque { get; set; }
        float Throttle { get; set; }
        float ThrottleRaw { get; set; }
        int TickCount { get; set; }
        float TrackTemp { get; set; }
        float VelocityX { get; set; }
        float VelocityY { get; set; }
        float VelocityZ { get; set; }
        float VertAccel { get; set; }
        float Voltage { get; set; }
        float WaterLevel { get; set; }
        float WaterTemp { get; set; }
        int WeatherType { get; set; }
        float WindDir { get; set; }
        float WindVel { get; set; }
        float Yaw { get; set; }
        float YawRate { get; set; }
    }
}
