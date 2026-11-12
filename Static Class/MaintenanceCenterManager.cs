using System;
using System.Collections.Generic;
using System.Text;

namespace TIC_IPG203_F25_JOB.Static_Class
{
    
        public static class MaintenanceCenterManager//كلاس ثابت مستقل لتتبع الإحصائيات العامة للمركز
        {
            public static int TotalAppliancesCount { get; set; } = 0;//خاصية ثابتة لعد الأجهزة التي تمت معالجتها

            public static decimal TotalRevenue { get; set; } = 0.0m;// خاصية ثابتة لحساب إجمالي تكاليف الإصلاح في المركز

        }

    }

