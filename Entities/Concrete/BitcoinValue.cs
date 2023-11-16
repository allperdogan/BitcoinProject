using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BitcoinValue :IEntity
    {
        public int id { get; set; }
        public DateTime timestamp { get; set; }
        public decimal value { get; set; }
    }
}
