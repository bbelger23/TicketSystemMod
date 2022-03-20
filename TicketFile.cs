using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketSystemMod
{
    
    
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
        public string enhancePath {get;set;}
        public List<Enhancement> Enhancements {get;set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public EnhanceFile (string enhanceFilePath)
        {
            enhancePath = enhanceFilePath;
            Enhancements = new List<Enhancement>();

            try
            {
                StreamReader sr = new StreamReader(enhancePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Enhancement enhancement = new Enhancement();
                    string line = sr.ReadLine();

                    string[] enhanceDetails = line.Split(',');
                    enhancement.ticketID = UInt64.Parse(enhanceDetails[0]);
                    enhancement.summary = enhanceDetails[1];
                    enhancement.status = enhanceDetails[2];
                    enhancement.priority = enhanceDetails[3];
                    enhancement.submit = enhanceDetails[4];
                    enhancement.assigned = enhanceDetails[5];
                    enhancement.watching = enhanceDetails[6].Split('|').ToList();
                    enhancement.software = enhanceDetails[7];
                    enhancement.cost = enhanceDetails[8];
                    enhancement.reason = enhanceDetails[9];
                    enhancement.estimate = DateTime.Parse(enhanceDetails[10]);

                    Enhancements.Add(enhancement);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddEnhancement(Enhancement enhancement)
        {
            try
            {
                enhancement.ticketID = Enhancements.Max(t => t.ticketID) + 1;
                StreamWriter sw = new StreamWriter(enhancePath, true);
                sw.WriteLine($"{enhancement.ticketID},{enhancement.summary},{enhancement.status},{enhancement.priority},{enhancement.submit},{enhancement.assigned},{string.Join("|", enhancement.watching)},{enhancement.software},{enhancement.cost},{enhancement.reason},{enhancement.estimate}");
                sw.Close();

                Enhancements.Add(enhancement);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }

    public class TaskFile
    {
        public string taskPath {get;set;}
        public List<Task> Tasks {get;set;}
         private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public TaskFile (string taskFilePath)
        {
            taskPath = taskFilePath;
            Tasks = new List<Task>();

            try
            {
                StreamReader sr = new StreamReader(taskPath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    string line = sr.ReadLine();

                    string[] taskDetails = line.Split(',');
                    task.ticketID = UInt64.Parse(taskDetails[0]);
                    task.summary = taskDetails[1];
                    task.status = taskDetails[2];
                    task.priority = taskDetails[3];
                    task.submit = taskDetails[4];
                    task.assigned = taskDetails[5];
                    task.watching = taskDetails[6].Split('|').ToList();
                    task.projectName = taskDetails[7];
                    task.dueDate = DateTime.Parse(taskDetails[8]);

                    Tasks.Add(task);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }
        public void AddTask(Task task)
        {
            try
            {
                task.ticketID = Tasks.Max(t => t.ticketID) + 1;
                StreamWriter sw = new StreamWriter(taskPath, true);
                sw.WriteLine($"{task.ticketID},{task.summary},{task.status},{task.priority},{task.submit},{task.assigned},{string.Join("|", task.watching)},{task.projectName},{task.dueDate}");
                sw.Close();

                Tasks.Add(task);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}