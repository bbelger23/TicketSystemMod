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
            //string enhanceFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
            //string taskFilePath = Directory.GetCurrentDirectory() + "\\tasks.csv";

            logger.Info("Program Started");

            DefectFile defectFile = new DefectFile(defectFilePath);
            //EnhanceFile enhanceFile = new EnhanceFile(enhanceFilePath);
            //TaskFile taskFile = new TaskFile(taskFilePath);
            
            string option = "";
            string addChoice = "";
            //string displayChoice = "";

            // user options
            do{
                Console.WriteLine("Select option");
                Console.WriteLine("1. Add Tickets");
                Console.WriteLine("2. Display Tickets");
                Console.WriteLine("Press any key to quit");

                option = Console.ReadLine();

                if (option == "1")
                {
                    do{
                        Console.WriteLine("Select choice");
                        Console.WriteLine("1. Add Bug/Defect Ticket");
                        Console.WriteLine("2. Add Enhancement Ticket");
                        Console.WriteLine("3. Add Task Ticket");
                        Console.WriteLine("Press any key to return to option");

                        addChoice = Console.ReadLine();

                        if (addChoice == "1")
                        {
                            // add ticket
                            Defect defect = new Defect();
                            // user adds summary
                            Console.WriteLine("Enter ticket summary");
                            defect.summary = Console.ReadLine();
                            // user adds status of ticket
                            Console.WriteLine("Enter ticket status");
                            defect.status = Console.ReadLine();
                            // user adds priority of ticket
                            Console.WriteLine("Enter ticket priority");
                            defect.priority = Console.ReadLine();
                            // user adds who submitted the ticket
                            Console.WriteLine("Enter ticket submitter");
                            defect.submit = Console.ReadLine();
                            // user adds who the ticket is assigned to
                            Console.WriteLine("Enter who ticket is assigned to");
                            defect.assigned = Console.ReadLine();
                            // user adds who is watching the ticket
                            string input;
                            do
                            {
                                Console.WriteLine("Enter who is watching ticket (or done to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    defect.watching.Add(input);
                                }
                            } while (input != "done");
                            if (defect.watching.Count == 0)
                            {
                                defect.watching.Add("(No one is watching the ticket)");
                            }
                            // user adds the severity of ticket
                            Console.WriteLine("Enter ticket severity");
                            defect.severity = Console.ReadLine();

                            defectFile.AddDefect(defect);

                        }
                        
                    } while (addChoice == "1" || addChoice == "2" || addChoice == "3");

                    logger.Info("Ticket Added");
                    
                }
            } while (option == "1" || option == "2"); 

            logger.Info("Program Ended");    
        }
    }
}
