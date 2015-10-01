using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class DotShape : BaseShape
    {
        public DotShape(SheetView sheet, int rowIdx, int colIdx)
            : base(sheet, rowIdx, colIdx)
        {
            Initialize();
        }

        private void Initialize()
        {
            //Center cell
            _centerColIdx = _initColIdx;
            _centerRowIdx = _initRowIdx;

            //Draw the shape
            Draw();
        }

        /// <summary>
        /// Check if the shape can be rotated to the next direction
        /// </summary>
        /// <param name="nextShape">The next shape after the rotation</param>
        /// <returns>true if can rotate, false otherwise</returns>
        public override bool CanRotate(ShapeDirections nextShape)
        {
            //This shape doesn't support rotation
            return false;
        }

        /// <summary>
        /// Check if the shape can move in the desinated direction
        /// </summary>
        /// <param name="nextDirection">The direction the shape is going to be moved</param>
        /// <returns>true if it can move, false otherwise</returns>
        public override bool CanMove(MovingDirections nextDirection)
        {
            //The shape can be moved if the cells at the next location are not ButtonCellType
            int nextCenterRowIdx = 0;
            int nextCenterColIdx = 0;

            ICellType nextCenterCellType = null;

            bool canMove = true;

            switch (nextDirection)
            {
                case MovingDirections.Right:
                    nextCenterRowIdx = _centerRowIdx;
                    nextCenterColIdx = _centerColIdx + 1;
                    break;

                case MovingDirections.Left:
                    nextCenterRowIdx = _centerRowIdx;
                    nextCenterColIdx = _centerColIdx - 1;
                    break;

                case MovingDirections.Down:
                    nextCenterRowIdx = _centerRowIdx + 1;
                    nextCenterColIdx = _centerColIdx;
                    break;
            }

            //If any row or col idx of the new locations go over the border, stops
            if (nextCenterRowIdx >= BORDER_BOTTOM || nextCenterColIdx < BORDER_LEFT || nextCenterColIdx >= BORDER_RIGHT)
                return false;

            //The shape can be moved if the cells at the next location are not ButtonCellType
            nextCenterCellType = _sheet.Cells[nextCenterRowIdx, nextCenterColIdx].CellType;

            //Check the new locations based on the moving direction and the current shape direction
            if (nextCenterCellType != null)
                return false;

            return canMove;
        }
    }
}