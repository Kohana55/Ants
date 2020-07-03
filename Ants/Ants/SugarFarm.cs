using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KonsoleGameEngine;

namespace Ants
{
    class SugarFarm : GameEntity , IAntStructure
    {
        public Cell[] Model =
        {
            new Cell(0,0, "\\") { IsWalkable = false },
            new Cell(1,0, "_") { IsWalkable = false },
            new Cell(2,0, "/") { IsWalkable = false },
        };

        public Cell[] DeploySpot =
{
            new Cell(0,0),
            new Cell(1,0),
            new Cell(2,0),
        };

        List<Worker> _workers;
        public AntEums ID { get { return AntEums.SugarFarm; } }

        public SugarFarm(int x, int y)
        {
            foreach (Cell cell in Model)
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
    }
}
