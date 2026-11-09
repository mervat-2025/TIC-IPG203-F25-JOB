using System;
using System.Collections.Generic;
using System.Text;
using TIC_IPG203_F25_JOB.Interface;

namespace TIC_IPG203_F25_JOB.AbstractClsses
{
    public abstract class Appliance : IRepairable
    {
        private readonly string _serialNumber;
        private string _model;
        private string _brand;
        private bool _isUnderWarranty;
        private string _status;
        private DateTime _entryDate;

        protected Appliance(string serialNumber, string model, string brand, bool isUnderWarranty)
        {
            _serialNumber = serialNumber;
            _model = model;
            _brand = brand;
            _isUnderWarranty = isUnderWarranty;
            _status = "Waiting for Maintenance";
            _entryDate = DateTime.Now;
        }

        public string SerialNumber => _serialNumber;
        public string Status
        {
            get => _status;
            protected set => _status = value;
        }

        public void StartMaintenance()
        {
            _status = "Under Maintenance";
        }

        public void CompleteRepair()
        {
            _status = "Repaired";
        }
    }
}
