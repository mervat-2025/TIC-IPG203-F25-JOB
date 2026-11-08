using System;
using System.Collections.Generic;
using System.Text;
using TIC_IPG203_F25_JOB.Interface;

namespace TIC_IPG203_F25_JOB.AbstractClsses
{
    internal class Appliance
    {


        public abstract class Appliance : IRepairable
        {
            private readonly string _serialNumber; // الرقم التسلسلي غير قابل للتعديل
            private string _brand;  // العلامة التجارية
            private string _status;  // حالة الصيانة

            public string SerialNumber
            {
                get { return _serialNumber; }
            }

        }
    }
}
