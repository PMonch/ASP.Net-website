using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class Customerscard
    {
        public int ID { get; set; }
        public int Points { get; set; }
        public DateTime DueDatePoints { get; set; }

        public Customerscard()
        {

        }

        public int GetPoints(int id)
        {
            return 0;
        }
    }
}