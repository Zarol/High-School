using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursiveMazeGeneration
{
    class MazeCellStack
    {
        private List<MazeCell> listCells;

        public MazeCellStack()
        {
            this.listCells = new List<MazeCell>();
        }

        public void pushCell(MazeCell newCell)
        {
            listCells.Insert(0, newCell);
        }

        public MazeCell popCell()
        {
            MazeCell poppedCell = listCells[0];
            listCells.RemoveAt(0);
            return poppedCell;
        }
    }
}
