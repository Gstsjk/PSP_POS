﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.Tax
{
    public class TaxDto
    {
        public string Name { get; set; }

        public int Rate { get; set; }
    }
}

