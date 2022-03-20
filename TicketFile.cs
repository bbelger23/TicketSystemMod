using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketSystemMod
{
    //public string enhancePath {get;set;}
    //public string taskPath {get;set;}
    public class DefectFile
    {
        public string defectPath {get;set;}
        public List<Defect> Defects {get;set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public DefectFile(string defectFilePath)
        {
            defectPath = defectFilePath;
            Defects = new List<Defect>();

            try
            {
                StreamReader sr = new StreamReader(defectPath);

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Defect defect = new Defect();
                    string line = sr.ReadLine();

                    string[] defectDetails = line.Split(',');
                    defect.ticketID = UInt64.Parse(defectDetails[0]);
                    defect.summary = defectDetails[1];
                    defect.status = defectDetails[2];
                    defect.priority = defectDetails[3];
                    defect.submit = defectDetails[4];
                    defect.assigned = defectDetails[5];
                    defect.watching = defectDetails[6].Split('|').ToList();
                    defect.severity = defectDetails[7];

                   Defects.Add(defect); 
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddDefect(Defect defect)
        {
            try
            {
                defect.ticketID = Defects.Max(t => t.ticketID) + 1;
                StreamWriter sw = new StreamWriter(defectPath, true);
                sw.WriteLine($"{defect.ticketID},{defect.summary},{defect.status},{defect.priority},{defect.submit},{defect.assigned},{string.Join("|", defect.watching)},{defect.severity}");
                sw.Close();

                Defects.Add(defect);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }

    public class EnhanceFile
    {
        public EnhanceFile (string enhanceFilePath)
        {

        }
    }

    public class TaskFile
    {
        public TaskFile (string taskFilePath)
        {

        }
    }
}