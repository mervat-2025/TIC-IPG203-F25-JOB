using System;
using System.Collections.Generic;
using System.Text;
using TIC_IPG203_F25_JOB.Interface;

namespace TIC_IPG203_F25_JOB.AbstractClsses
{
    public abstract class Appliance : IRepairable
    {

        // 1. حقول خاصة وقراءة فقط (Private Readonly Fields) للبيانات الثابتة والحساسة التي يجب ألا تتغير أبداً بعد الإنشاء
        private readonly string _model;        // موديل الجهاز

        private readonly DateTime _entryDate;  // تاريخ دخول الجهاز للصيانة

        private bool _isUnderWarranty;         // هل الجهاز تحت الكفالة؟

        // 3. خصائص للقراءة فقط (Read-only Properties) لضمان حماية الموديل والتاريخ من أي تعديل خارجي
        public string Model => _model;

        public DateTime EntryDate => _entryDate;
        private readonly string _serialNumber; // الرقم التسلسلي غير قابل للتعديل
        private string _brand;  // العلامة التجارية
        private string _status;  // حالة الصيانة

        public string SerialNumber
        {
            get { return _serialNumber; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Status
        {
            get { return _status; }
            protected set { _status = value; }
        }

        protected Appliance(string serialNumber, string model, string brand, bool isUnderWarranty)// الباني لتهيئة كائن الجهاز بالحالة الابتدائية
        {
            _serialNumber = serialNumber;
            _model = model;
            _brand = brand;
            _isUnderWarranty = isUnderWarranty;
            _status = "Waiting for Maintenance";
            _entryDate = DateTime.Now;

        }

        public void StartMaintenance()
        {
            Status = "Under Maintenance";
        }

        public void CompleteRepair()
        {
            Status = "Repaired";
        }

        public string GetStatus()
        {
            return Status;
        }

        // الدالة المجردة لحساب التكلفة التي ستطبّقها الفئات الفرعية

        public abstract decimal CalculateRepairCost();



    }
}