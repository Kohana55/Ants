using KonsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ants
{
    class AntsCursor : KonsoleCursor
    {

        public AntEums _activeStructure;

        /// <summary>
        /// Controls the Cursor
        /// WASD    - movement
        /// SPACE   - select
        /// </summary>
        protected override void Controller()
        {
            ConsoleKeyInfo keypress;
            Cell currentCell;

            while (true)
            {

                keypress = Console.ReadKey(true);

                if (keypress.KeyChar == 'a' && Model.X != 0)
                    Model.X -= 1;

                if (keypress.KeyChar == 'd' && Model.X != _gameWorld.X - 1)
                    Model.X += 1;

                if (keypress.KeyChar == 'w' && Model.Y != 0)
                    Model.Y -= 1;

                if (keypress.KeyChar == 's' && Model.Y != _gameWorld.Y - 1)
                    Model.Y += 1;

                if (_activeStructure == AntEums.Colony)
                {

                }

                if (keypress.KeyChar == ' ')
                {
                    currentCell = _gameWorld.GetCell(Model);
                    IAntStructure antStructure = _gameWorld.GetEntity(Model) as IAntStructure;

                    if (antStructure != null)
                    {
                        _activeStructure = antStructure.ID;
                    }
                }
            }
        }
    }
}
