using System;

namespace TicketSystemMod
{
    public class Defect : Ticket
    {
        public string severity {get;set;}

        public override string Display()
        {
            return $"Id: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submit}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSeverity: {severity}";
        }
    }
}