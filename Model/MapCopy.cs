﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.Model
{
    class MapCopy
    {
        public int Sum { get; private set; }
        public int [,] Map { get; private set; }

        public MapCopy(int sum, int[,] map)
        {
            Sum = sum;
            Map = map;
        }
    }
}
