using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int _interfaceStandard;
        private int _batteryUsage;

        public Supplement(int interfaceStandard, int batteryUsage)
        {
            this.InterfaceStandard = interfaceStandard;
            this.BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard
        {
            get { return this._interfaceStandard; }
            private set { this._interfaceStandard = value; }
        }

        public int BatteryUsage
        {
            get { return this._batteryUsage; }
            private set { this._batteryUsage = value; }
        }
    }
}