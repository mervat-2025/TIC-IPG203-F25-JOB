using System;
using System.Collections.Generic;
using System.Text;

namespace TIC_IPG203_F25_JOB.Services
{
    public class RepairNotifier// كلاس مستقل للتفويض والأحداث
    {

        public delegate void RepairStatusHandler(string message); //     هذا التفويض يحدد شكل الدالة التي ستستقبل الرسالة
    }     



}

