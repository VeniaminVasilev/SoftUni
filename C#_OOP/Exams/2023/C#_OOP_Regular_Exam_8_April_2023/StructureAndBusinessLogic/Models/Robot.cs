using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string _model;
        private int _batteryCapacity;
        private int _batteryLevel;
        private int _convertionCapacityIndex;
        private List<int> _interfaceStandards;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.BatteryLevel = batteryCapacity;
            this.ConvertionCapacityIndex = conversionCapacityIndex;
            this._interfaceStandards = new List<int>();
        }

        public string Model
        {
            get { return this._model; }
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                this._model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return this._batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                this._batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get { return this._batteryLevel; }
            private set { this._batteryLevel = value; }
        }

        public int ConvertionCapacityIndex
        {
            get { return this._convertionCapacityIndex; }
            private set { this._convertionCapacityIndex = value; }
        }

        public IReadOnlyCollection<int> InterfaceStandards
        {
            get { return this._interfaceStandards.AsReadOnly(); }
        }

        public void Eating(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                this.BatteryLevel += this.ConvertionCapacityIndex;

                if (this.BatteryLevel == this.BatteryCapacity)
                {
                    break;
                }
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                this.BatteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this._interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {this.Model}");
            sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {this.BatteryLevel}");

            if (this.InterfaceStandards.Count == 0)
            {
                sb.AppendLine($"--Supplements installed: none");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: {string.Join(", ", this.InterfaceStandards)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}