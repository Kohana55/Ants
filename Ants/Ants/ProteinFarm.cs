using Ants;
using KonsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Ants
{
    class ProteinFarm : GameEntity, IAntStructure
    {
        public Cell[] Model =
        {
            new Cell(0,0, "\\") { IsWalkable = false },
            new Cell(1,0, "v") { IsWalkable = false },
            new Cell(2,0, "/") { IsWalkable = false },
        };

        public Cell[] DeploySpot =
        {
            new Cell(0,0),
            new Cell(1,0),
            new Cell(2,0),
        };

        List<Worker> _workers;
        public AntEums ID { get { return AntEums.ProteinFarm; } }

        public ProteinFarm(int x, int y)
        {
            foreach(Cell cell in Model)
            {
                cell.X += x;
                cell.Y += y;
            }
            foreach (Cell cell in DeploySpot)
            {
                cell.X += x;
                cell.Y += y+1;                
            }
        }

        public override List<Cell> GetCells()
        {
            return Model.OfType<Cell>().ToList();
        }

        public override void Start()
        {
        }

        private Worker SpawnWorker()
        {
            return null;
        }
    }
}
