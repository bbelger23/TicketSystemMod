using System;
using System.Collections.Generic;

namespace TicketSystemClass
{
    public class Ticket
    {
        public UInt64 ticketID {get;set;}
        public string summary {get;set;}
        public string status {get;set;}
        public string priority {get;set;}
        public string submit {get;set;}
        public string assigned {get;set;}
        public List<string> watching {get;set;}

        public Ticket()
        {
            watching = new List<string>();
        }

        public string Show()
        {
            return $"Id: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submit}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\n";
        }
    }
}