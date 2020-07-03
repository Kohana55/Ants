using KonsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ants
{
    class Terrain : GameEntity
    {

        private Cell[] EnclosureModel =
        {
            // West Wall
            new Cell(0,0, "█") { IsWalkable = false },
            new Cell(0,1, "█") { IsWalkable = false },
            new Cell(0,2, "█") { IsWalkable = false },
            new Cell(0,3, "█") { IsWalkable = false },
            new Cell(0,4, "█") { IsWalkable = false },
            new Cell(0,5, "█") { IsWalkable = false },
            new Cell(0,6, "█") { IsWalkable = false },
            new Cell(0,7, "█") { IsWalkable = false },

            // South Wall
            new Cell(1,7, "█") { IsWalkable = false },
            new Cell(2,7, "█") { IsWalkable = false },
            new Cell(3,7, "█") { IsWalkable = false },
            new Cell(4,7, "█") { IsWalkable = false },
            new Cell(5,7, "█") { IsWalkable = false },
            new Cell(6,7, "█") { IsWalkable = false },
            new Cell(7,7, "█") { IsWalkable = false },
            new Cell(8,7, "█") { IsWalkable = false },
            new Cell(9,7, "█") { IsWalkable = false },
            new Cell(10,7, "█") { IsWalkable = false },

            // East Wall
            new Cell(11,0, "█") { IsWalkable = false },
            new Cell(11,1, "█") { IsWalkable = false },
            new Cell(11,2, "█") { IsWalkable = false },
            new Cell(11,3, "█") { IsWalkable = false },
            new Cell(11,4, "█") { IsWalkable = false },
            new Cell(11,6, "█") { IsWalkable = false },
            new Cell(11,7, "█") { IsWalkable = false },
        };



        public override List<Cell> GetCells()
        {
            return EnclosureModel.OfType<Cell>().ToList();
        }

        public override void Start()
        {
            
        }
    }
}
