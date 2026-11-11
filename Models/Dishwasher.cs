using System;
using System.Collections.Generic;
using System.Text;
using TIC_IPG203_F25_JOB.AbstractClsses;

namespace TIC_IPG203_F25_JOB.Models
{

    public class Dishwasher : Appliance // فئة تمثل الجلاية من الكلاس الاساسي
    {
        // الباني يمرر كافة البيانات (الرقم التسلسلي، الموديل، الماركة، وحالة الكفالة) إلى الكلاس الأساسي
        public Dishwasher(string serialNumber, string model, string brand, bool isUnderWarranty)
            : base(serialNumber, model, brand, isUnderWarranty)
        {
        }

        public override decimal CalculateRepairCost() // دالة حساب تكلفة الاصلاح الخاصة بشالجلاية
        {
            return 150m; // تكلفة إصلاح الجلاية
        }
    }
}
