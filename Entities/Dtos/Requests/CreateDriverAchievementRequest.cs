﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests
{
    public class CreateDriverAchievementRequest
    {
        public Guid DriverId { get; set; }
        public int WorldChampionship { get; set; }
        public int FastestLap { get; set; }
        public int PolePosition { get; set; }
        public int Wins { get; set; }


    }
}
