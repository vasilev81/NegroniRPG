﻿namespace NegroniGame.Items.Armor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public struct DragonRobe : Interfaces.IGloves
    {
        public string Name { get; private set; }
        public int Defence { get; private set; }
    }
}