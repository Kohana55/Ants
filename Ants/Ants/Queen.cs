using KonsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ants
{
    class Queen : GameEntity
    {
        private Colony _colony;
        public int Protein { get; set; } = 0;

        public override List<Cell> GetCells()
        {
            return new List<Cell>();
        }

        public override void Start()
        {
            
        }

        public void RegisterColony(Colony colony)
        {
            _colony = colony;
        }

        public void ConsumeProtein()
        {
            Random rng = new Random();

            Protein++;

            if(Protein >= 50)
            {
                Protein -= 50;
                Cell deploySpot = _colony._deploySpots[rng.Next(_colony._deploySpots.Length)];
                Worker worker = new Worker(deploySpot.X, deploySpot.Y);
                _colony.RegisterWorker(worker);
                _gameWorld.RegisterAndStartEntity(worker);
            }
        }
    }
}
