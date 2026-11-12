using System;
using System.Collections.Generic;
using System.Text;

namespace TIC_IPG203_F25_JOB.Static_Class
{
    internal static class ApplianceValidator
    {




       
            internal static int TotalCheckedAppliances = 0;//دالة الأجهزة التي تم فحصها

            internal static void IncrementCheckedCount()//زيادة العداد للأجهزة المفحوصة
            {
                TotalCheckedAppliances++;
            }


            internal static bool IsValidSerialNumber(string serialNumber)//دالة التحقق من الرقم التسلسلي
            {
                return !string.IsNullOrEmpty(serialNumber);// طباعةالعدد الاجمالي للأجهزة المفحوصة
            }
        }
    }
}
