using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models
{
    public class TicketGenerator
    {
        int ticketnum { get; set; }

        public static int Ticket()
        {
            int count = 0;
            int ticketnum;
            count++;
            
            //creates a list of all tickets and cycles through checking if a ticker of that type has been used inorder to remove redundant tickets
            List<int> ticketchecker = new List<int>();
            ticketchecker.Add(count);
            foreach (int i in ticketchecker)
            {
                if (ticketchecker.Contains(count) == true)
                {
                    count++;
                }
            }


            //sets a limitation of the tickets so that it avoids redundant or a long backlog on tickets in the list
            //once Tickets have reached 3000, the cycle will be reset to 1
            // this would be eventually set so once the day has been completed ie time hits closing time the system would reset ticket system to 1 automatically
            if (count == 3000)
            {
                count = 1;
                ticketchecker.Clear();
            }

            ticketnum = count;

            return ticketnum;
        }
    }
}
