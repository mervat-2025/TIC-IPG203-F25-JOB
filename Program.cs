using TIC_IPG203_F25_JOB.AbstractClsses;
using TIC_IPG203_F25_JOB.Interface;
using TIC_IPG203_F25_JOB.Models;
using TIC_IPG203_F25_JOB.Services;
using TIC_IPG203_F25_JOB.Static_Class;

namespace TIC_IPG203_F25_JOB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Home Appliance Repair System");
          
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("====Packaging test====");
            Appliance device = new Dishwasher("SN-98765", "EcoBubble-X", "Samsung", true);

            // . القراءة فقط (Read-Only Properties): نصل لقيمة الحقول الخاصة بأمان دون القدرة على تعديلها
            Console.WriteLine($"Serial Number: {device.SerialNumber}"); // قراءة الرقم التسلسلي المحمي  private readonly
            Console.WriteLine($"Model: {device.Model}");               // قراءة الموديل المحمي  private readonly
            Console.WriteLine($"Entry Date: {device.EntryDate}");     // قراءة تاريخ الدخول المحمي private readonly


            Console.WriteLine($"Under Warranty: {device.IsUnderWarranty}"); // قراءة حالة الكفالة (Get)
            device.IsUnderWarranty = false;                                 // تعديل حالة الكفالة بأمان عبر (Set)
            device.Brand = "LG";                                            // تعديل العلامة التجارية عبر خاصية Brand

            Console.WriteLine($"Initial Status: {device.GetStatus()}"); // قراءة الحالة عبر دالة مخصصة

            //  (device.Status = "Repaired";) مباشرة من هنا سيعطي خطأ لأن التعديل محمي (protected set)
            device.StartMaintenance(); // تغيير الحالة بطريقة آمنة ومنضبطة إلى "Under Maintenance"
            Console.WriteLine($"Updated Status: {device.Status}");

            device.CompleteRepair();   // تغيير الحالة بطريقة آمنة إلى "Repaired"
            Console.WriteLine($"Final Status: {device.Status}");


            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("---Testing Manager & Polymorphism)-----");

            // 1. إنشاء كائن (Instance) من كلاس مدير الأجهزة
            ApplianceManager manager = new ApplianceManager();

            // 2. إنشاء كائن جهاز جديد (تأكدي أن كلاس Appliance أو الكلاس الفرعي الخاص به جاهز لديكِ)
            // (مثال على إنشاء جهاز وإضافة أبعاده أو بياناته حسب ما تم تصميمه في مشروعكم)
            Appliance myAppliance = new Dishwasher("SN-12345", "DW60M6050", "Samsung", true);

            // 3. إضافة الجهاز للنظام (سيقوم بفحص الرقم التسلسلي، منع التكرار، زيادة العداد وطباعة رسالة النجاح)
            manager.AddAppliance(myAppliance);
            
            // 4. استدعاء دالة عرض التكاليف (ستطبع تفاصيل الأجهزة المضافة والعدد الإجمالي للأجهزة المفحوصة)
            manager.DisplayRepairCosts();


            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();


            Console.WriteLine("===Subgroup inheritance testing===");


             manager = new ApplianceManager();  //تعريف متغير من نوع ApplianceManager 


            manager.AddAppliance(new WashingMachine("WV5149S2W", "WM-2025", "LG", true)); //اضافة الاجهزة وارقامها
            manager.AddAppliance(new Refrigerator("HL4DRF600SS", "RF-300", "Hi-Life", true));
            manager.AddAppliance(new AirConditioner("AS-18TF4RBTCA00", "AC-18K", "Hisense", false));
            manager.AddAppliance(new Dishwasher("DW8SS", "DW-400", "Samsung", true));
            manager.AddAppliance(new WashingMachine("WV5149S2W", "WM-2025", "LG", true)); //اضافي لتاكد من شرط منع التكرار




            manager.DisplayRepairCosts(); // استدعاء الدالة لعرض تكاليف الإصلاح للأجهزة المضافة


            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();  // الانتظار حتى يقوم المستخدم بالضغط على


            Console.WriteLine("===Authorization test===");

            RepairNotifier notifier = new RepairNotifier();

            notifier.OnRepairStatusChanged += (message) =>
            {
                Console.WriteLine(message);
            };

            Refrigerator fridge =
                new Refrigerator("SN123456789", "LG100", "LG", true);

            fridge.StartMaintenance();

            notifier.Notify(
                fridge.SerialNumber,
                fridge.GetStatus());

            fridge.CompleteRepair();

            notifier.Notify(
                fridge.SerialNumber,
                fridge.GetStatus());

            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("-----\"===== Test Requirement ======\"---");

            // / 1.التحقق من الرقم التسلسلي لجهاز معين قبل إضافته
            string serial = "12345";
            if (ApplianceValidator.IsValidSerialNumber(serial))
            {
                Console.WriteLine("الرقم التسلسلي صحيح ومقبول.");

                // 2. زيادة العداد عند فحص الجهاز وإضافته بنجاح
                ApplianceValidator.IncrementCheckedCount();
            }
            else
            {
                Console.WriteLine("الرقم التسلسلي غير صالح.");
            }

            // 3. طباعة وعرض العدد الإجمالي للأجهزة المفحوصة
            Console.WriteLine("Total Checked Appliances: " + ApplianceValidator.TotalCheckedAppliances);// 1.التحقق من الرقم التسلسلي لجهاز معين قبل إضافته
            if (ApplianceValidator.IsValidSerialNumber(serial))
            {
                Console.WriteLine("الرقم التسلسلي صحيح ومقبول.");

                // 2. زيادة العداد عند فحص الجهاز وإضافته بنجاح
                ApplianceValidator.IncrementCheckedCount();
            }
            else
            {
                Console.WriteLine("الرقم التسلسلي غير صالح.");
            }

            // 3. طباعة وعرض العدد الإجمالي للأجهزة المفحوصة
            Console.WriteLine("Total Checked Appliances: " + ApplianceValidator.TotalCheckedAppliances);

            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine("----- Testing Static Class (MaintenanceCenterManager) -----");

            // 1. تحديث إحصائيات المركز (إضافة جهاز وتكلفة إصلاحه)
            MaintenanceCenterManager.TotalAppliancesCount++;
            MaintenanceCenterManager.TotalRevenue += myAppliance.CalculateRepairCost();

            // 2. طباعة الإحصائيات العامة للمركز
            Console.WriteLine($"Total Processed Appliances: {MaintenanceCenterManager.TotalAppliancesCount}");
            Console.WriteLine($"Total Center Revenue: {MaintenanceCenterManager.TotalRevenue}");

            Console.WriteLine("-----------------------------------------------------------");
        }




    }
}
