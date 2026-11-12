using System;
using System.Collections.Generic;
using System.Text;
using TIC_IPG203_F25_JOB.AbstractClsses;
using TIC_IPG203_F25_JOB.Static_Class;

namespace TIC_IPG203_F25_JOB.Models
{
    public class ApplianceManager  //كلاس ادارة الاجهزة
    {
        private List<Appliance> appliances = new List<Appliance>();  // تخزن القيم المقبولة

        public void AddAppliance(Appliance appliance)  // تضيف الجهاز بعد الفحص
        {
            if (ApplianceValidator.IsValidSerialNumber(appliance.SerialNumber))  // شرط التأكد
            {
                if (appliances.Exists(a => a.SerialNumber == appliance.SerialNumber)) //شرط لمنع التكرار
                {
                    Console.WriteLine("Serial number already exists:" + appliance.SerialNumber);
                    return;
                }
                //...................
                appliances.Add(appliance); // الاضافة ع قائمة
                ApplianceValidator.IncrementCheckedCount();  // زيادة عدد الاجهزة المصلحة
                Console.WriteLine("Appliance added successfully: " + appliance.Brand);  // طباعة الزيادة
            }
            else   // اذا كان الرقم اقصر من المطلوب يتم الرفض
            {
                Console.WriteLine("Serial number is too short: " + appliance.SerialNumber);  //طباعة الرفض
            }
        }

        public void DisplayRepairCosts()  //دالةعرض تكاليف الاصلاح
        {
            Console.WriteLine("\n--- Repair Costs ---");   //طباعة عنوان القائمة

            foreach (Appliance appliance in appliances)  // تكرار لكل الاجهزة المضافة
            {
                Console.WriteLine("Serial Number: " + appliance.SerialNumber);  //طباعة الرقم التسلسلي
                Console.WriteLine("Brand: " + appliance.Brand);  // طباعة البراند
                Console.WriteLine("Repair Cost: " + appliance.CalculateRepairCost()); //طباعة الحساب
                Console.WriteLine("---");   //فاصل بين الاجهزة
            }

            Console.WriteLine("Total Checked Appliances: " + ApplianceValidator.TotalCheckedAppliances);  //طباعة العدد الاجمالي لعدد الاجهزة التي قام بفحصها
        }
    }
}



