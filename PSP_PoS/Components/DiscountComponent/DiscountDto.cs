﻿using PSP_PoS.Enums;

namespace PSP_PoS.Components.DiscountComponent
{
    public class DiscountDto
    {
        public DiscountType DiscountType { get; set; }
        public int Percentage { get; set; } // 0 - 100 %
    }
}
