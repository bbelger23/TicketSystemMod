using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace TicketSystemMod
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string defectFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            string enhanceFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
            string taskFilePath = Directory.GetCurrentDirectory() + "\\tasks.csv";

            logger.Info("Program Started");

            DefectFile defectFile = new DefectFile(defectFilePath);
            EnhanceFile enhanceFile = new EnhanceFile(enhanceFilePath);
            TaskFile taskFile = new TaskFile(taskFilePath);
            
             
        }
    }
}
