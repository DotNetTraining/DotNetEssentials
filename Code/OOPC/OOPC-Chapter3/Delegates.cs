using System;
namespace OOPCChapter3
{
    public enum VehicleState
    {
        EngineOff = 0,
        EngineOn = 1,
        Stopped = 2,
        Moving = 3,
    }

    public class SpeedChangeEventArgs:EventArgs
    {
        public int Speed { get; set; }
        public string VehicleECUMessage { get; set; }
        public bool IsSpeedOverLimit => Speed >= 80;
    }

    public delegate void VehicleStateChangeAction();
    public class Vehicle
    {
        private int speed = 0;
        private VehicleState state = VehicleState.EngineOff;
        //Delegates
        public VehicleStateChangeAction OnVehicleEngineOn { get; set; }
        public VehicleStateChangeAction OnVehicleEngineOff { get; set; }
        public VehicleStateChangeAction OnVehicleStartMoving { get; set; }
        public VehicleStateChangeAction OnVehicleStopped { get; set; }

        //events
        public event EventHandler<SpeedChangeEventArgs> VehicleSpeedChanged;

        public void EngineOn()
        {
            if (state == VehicleState.EngineOff)
            {
                state = VehicleState.EngineOn;
                OnVehicleEngineOn?.Invoke();
            }
            else
                throw new InvalidOperationException("Not allowed!");
        }

        public void EngineOff()
        {
            if (state == VehicleState.EngineOn || state == VehicleState.Stopped)
            {
                state = VehicleState.EngineOff;
                OnVehicleEngineOff?.Invoke();
            }
            else
                throw new InvalidOperationException("Not Allowed!");
        }

        public void Accelerate()
        {
            if (state == VehicleState.EngineOff)
                throw new InvalidOperationException("Not Allowed!");
            if(state==VehicleState.EngineOn||state==VehicleState.Stopped)
            {
                state = VehicleState.Moving;
                OnVehicleStartMoving();
            }
            speed += 1;
            SpeedChangeEventArgs speedChanged = new SpeedChangeEventArgs()
            {
                Speed = speed,
                VehicleECUMessage = speed > 80 ? "You are overspeeding!" : (speed < 10 ? "You are about to stop!" : "All is well!")
            };
            VehicleSpeedChanged?.Invoke(this, speedChanged);
        }

        public void DeAccelerate()
        {
            if (state == VehicleState.EngineOff || state == VehicleState.Stopped || state==VehicleState.EngineOn)
                throw new InvalidOperationException("Not Allowed!");
            
            speed -= 1;
            if(speed==0)
            {
                state = VehicleState.Stopped;
                OnVehicleStopped();
                state = VehicleState.EngineOn;
                return;
            }
            SpeedChangeEventArgs speedChanged = new SpeedChangeEventArgs()
            {
                Speed = speed,
                VehicleECUMessage = speed > 80 ? "You are overspeeding!" : (speed < 10 ? "You are about to stop!" : "All is well!")
            };
            VehicleSpeedChanged?.Invoke(this, speedChanged);

        }
    }
}