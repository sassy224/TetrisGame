using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class SShape : BaseShape
    {
        public SShape(SheetView sheet, int rowIdx, int colIdx)
            : base(sheet, rowIdx, colIdx)
        {
            Initialize();
        }

        private void Initialize()
        {
            _centerColIdx = _initColIdx;
            _centerRowIdx = _initRowIdx;

            _bottomColIdx = _centerColIdx;
            _bottomRowIdx = _centerRowIdx + 1;

            _rightColIdx = _centerColIdx + 1;
            _rightRowIdx = _centerRowIdx;

            _bottomRightColIdx = _centerColIdx + 1;
            _bottomRightRowIdx = _centerRowIdx + 1;

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
            //This shape can't be rotated
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
            int nextTopLeftRowIdx = 0;
            int nextTopLeftColIdx = 0;
            int nextBottomLeftRowIdx = 0;
            int nextBottomLeftColIdx = 0;
            int nextTopRightRowIdx = 0;
            int nextTopRightColIdx = 0;
            int nextBottomRightRowIdx = 0;
            int nextBottomRightColIdx = 0;

            ICellType nextTopLeftCellType = null;
            ICellType nextTopRightCellType = null;
            ICellType nextBottomLeftCellType = null;
            ICellType nextBottomRightCellType = null;

            bool canMove = true;

            switch (nextDirection)
            {
                case MovingDirections.Right:
                    nextTopLeftRowIdx = _centerRowIdx;
                    nextBottomLeftRowIdx = _bottomRowIdx;
                    nextTopRightRowIdx = _rightRowIdx;
                    nextBottomRightRowIdx = _bottomRightRowIdx;

                    nextTopLeftColIdx = _centerColIdx + 1;
                    nextBottomLeftColIdx = _bottomColIdx + 1;
                    nextTopRightColIdx = _rightColIdx + 1;
                    nextBottomRightColIdx = _bottomRightColIdx + 1;
                    break;

                case MovingDirections.Left:
                    nextTopLeftRowIdx = _centerRowIdx;
                    nextBottomLeftRowIdx = _bottomRowIdx;
                    nextTopRightRowIdx = _rightRowIdx;
                    nextBottomRightRowIdx = _bottomRightRowIdx;

                    nextTopLeftColIdx = _centerColIdx - 1;
                    nextBottomLeftColIdx = _bottomColIdx - 1;
                    nextTopRightColIdx = _rightColIdx - 1;
                    nextBottomRightColIdx = _bottomRightColIdx - 1;
                    break;

                case MovingDirections.Down:
                    nextTopLeftRowIdx = _centerRowIdx + 1;
                    nextBottomLeftRowIdx = _bottomRowIdx + 1;
                    nextTopRightRowIdx = _rightRowIdx + 1;
                    nextBottomRightRowIdx = _bottomRightRowIdx + 1;

                    nextTopLeftColIdx = _centerColIdx;
                    nextBottomLeftColIdx = _bottomColIdx;
                    nextTopRightColIdx = _rightColIdx;
                    nextBottomRightColIdx = _bottomRightColIdx;
                    break;
            }

            //If any row or col idx of the new locations go over the border, stops
            if (nextBottomLeftColIdx < BORDER_LEFT || nextBottomLeftRowIdx >= BORDER_BOTTOM
                || nextBottomRightColIdx >= BORDER_RIGHT
                || nextBottomRightRowIdx >= BORDER_BOTTOM)
                return false;

            //The shape can be moved if the cells at the next location are not ButtonCellType
            nextTopLeftCellType = _sheet.Cells[nextTopLeftRowIdx, nextTopLeftColIdx].CellType;
            nextTopRightCellType = _sheet.Cells[nextTopRightRowIdx, nextTopRightColIdx].CellType;
            nextBottomRightCellType = _sheet.Cells[nextBottomRightRowIdx, nextBottomRightColIdx].CellType;
            nextBottomLeftCellType = _sheet.Cells[nextBottomLeftRowIdx, nextBottomLeftColIdx].CellType;

            //Check the new locations based on the moving direction and the current shape direction
            switch (nextDirection)
            {
                case MovingDirections.Down:
                    if (nextBottomLeftCellType != null || nextBottomRightCellType != null)
                    {
                        canMove = false;
                    }
                    break;

                case MovingDirections.Left:
                    if (nextBottomLeftCellType != null || nextTopLeftCellType != null)
                    {
                        canMove = false;
                    }
                    break;

                case MovingDirections.Right:
                    if (nextTopRightCellType != null || nextBottomRightCellType != null)
                    {
                        canMove = false;
                    }
                    break;
            }

            return canMove;
        }
    }
}