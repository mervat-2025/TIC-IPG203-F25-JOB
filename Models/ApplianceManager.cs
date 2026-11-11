using System;
using System.Collections.Generic;
using System.Text;
using TIC_IPG203_F25_JOB.AbstractClsses;

namespace TIC_IPG203_F25_JOB.Models
{
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
        

