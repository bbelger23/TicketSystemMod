using System;

namespace TicketSystemMod
{
    public class Enhancement : Ticket
    {
        public string software {get;set;}
        public string cost {get;set;}
        public string reason {get;set;}
        public string estimate {get;set;}
        public override string Display()
        {
            return $"Id: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submit}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}";
        }
    }
}