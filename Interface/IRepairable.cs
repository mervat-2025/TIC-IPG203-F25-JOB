using System;
using System.Collections.Generic;
using System.Text;

namespace TIC_IPG203_F25_JOB.Interface
{
    internal interface IRepairable
    {
        public interface IRepairable
        {
            // Start maintenance
            void StartMaintenance();  //بدء صيانة الجهاز//

            // Mark the repair as complete
            void CompleteRepair(); //تسجيل اكتمال الاصلاح//

            // Return the current appliance status
            string GetStatus(); //ارجاع حالة الجهاز الحالية //
        }
    }
}
