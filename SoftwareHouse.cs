﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_houses")]
    public class SoftwareHouse
    {
        [Key]
        public long SoftwareHouseId { get; set; }

        public string Name { get; set; }


        public List<Videogame> videogames { get; set; }
    }
}
