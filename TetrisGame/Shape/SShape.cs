using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class SShape : ITetrisShape
    {
        /// <summary>
        /// The sheetview object that represents a sheet of the spread
        /// </summary>
        private SheetView _sheet = null;

        /// <summary>
        /// The four cells that represents a shape
        /// </summary>
        private Cell _topLeft = null;
        private int _topLeftRowIdx = 0;
        private int _topLeftColIdx = 0;

        private Cell _bottomLeft = null;
        private int _bottomLeftRowIdx = 0;
        private int _bottomLeftColIdx = 0;

        private Cell _topRight = null;
        private int _topRightRowIdx = 0;
        private int _topRightColIdx = 0;

        private Cell _bottomRight = null;
        private int _bottomRightRowIdx = 0;
        private int _bottomRightColIdx = 0;

        /// <summary>
        /// The init location of the shape
        /// </summary>
        private int _initRowIdx = 0;
        private int _initColIdx = 0;

        public SShape(SheetView sheet, int rowIdx, int colIdx)
        {
            _sheet = sheet;
            _initColIdx = colIdx;
            _initRowIdx = rowIdx;

            Initialize();
        }

        private void Initialize()
        {
            //Create random location for top left cell
            int colIdx = new Random().Next(1, Constants.MAX_WIDTH - 2);

            _topLeftRowIdx = colIdx;
            _topLeftColIdx = 0;

            _bottomLeftColIdx = colIdx;
            _bottomLeftRowIdx = 1;

            _topRightColIdx = colIdx + 1;
            _topRightRowIdx = 0;

            _bottomRightColIdx = colIdx + 1;
            _bottomRightRowIdx = 1;

            //Draw the shape
            Draw();
        }

        /// <summary>
        /// Draw the shape by filling the cells with ButtonCellType to make it look different
        /// </summary>
        public void Draw()
        {
            _topLeft = _sheet.Cells[_topLeftRowIdx, _topLeftColIdx];
            _topLeft.CellType = new ButtonCellType();

            _bottomLeft = _sheet.Cells[_bottomLeftRowIdx, _bottomLeftColIdx];
            _bottomLeft.CellType = new ButtonCellType();

            _topRight = _sheet.Cells[_topRightRowIdx, _topRightColIdx];
            _topRight.CellType = new ButtonCellType();

            _bottomRight = _sheet.Cells[_bottomRightRowIdx, _bottomRightColIdx];
            _bottomRight.CellType = new ButtonCellType();
        }

        /// <summary>
        /// Rotate the shape, in order from up -> right -> down -> left -> up
        /// </summary>
        public void Rotate()
        {
            //Do nothing, because this shape can't be rotated
        }

        /// <summary>
        /// Move the shape to the left
        /// </summary>
        public void MoveLeft()
        {
            //Move all cells to the left
            _topLeftColIdx -= 1;
            _bottomLeftColIdx -= 1;
            _topRightColIdx -= 1;
            _bottomRightColIdx -= 1;

            _topLeft.ResetCellType();
            _bottomLeft.ResetCellType();
            _bottomRight.ResetCellType();
            _topRight.ResetCellType();

            Draw();
        }

        /// <summary>
        /// Move the shape to the right
        /// </summary>
        public void MoveRight()
        {
            //Move all cells to the right
            _topLeftColIdx += 1;
            _bottomLeftColIdx += 1;
            _topRightColIdx += 1;
            _bottomRightColIdx += 1;

            _topLeft.ResetCellType();
            _bottomLeft.ResetCellType();
            _bottomRight.ResetCellType();
            _topRight.ResetCellType();

            Draw();
        }

        /// <summary>
        /// Move the shape down
        /// </summary>
        public void MoveDown()
        {
            //Move all cells down
            _topLeftRowIdx += 1;
            _bottomLeftRowIdx += 1;
            _topRightRowIdx += 1;
            _bottomRightRowIdx += 1;

            _topLeft.ResetCellType();
            _bottomLeft.ResetCellType();
            _bottomRight.ResetCellType();
            _topRight.ResetCellType();

            Draw();
        }

        /// <summary>
        /// Check if the shape can be rotated to the next direction
        /// </summary>
        /// <param name="nextShape">The next shape after the rotation</param>
        /// <returns>true if can rotate, false otherwise</returns>
        public bool CanRotate(ShapeDirections nextShape)
        {
            //This shape can't be rotated
            return false;
        }

        /// <summary>
        /// Check if the shape can move in the desinated direction
        /// </summary>
        /// <param name="nextDirection">The direction the shape is going to be moved</param>
        /// <returns>true if it can move, false otherwise</returns>
        public bool CanMove(MovingDirections nextDirection)
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
                    nextTopLeftRowIdx = _topLeftRowIdx;
                    nextBottomLeftRowIdx = _bottomLeftRowIdx;
                    nextTopRightRowIdx = _topRightRowIdx;
                    nextBottomRightRowIdx = _bottomRightRowIdx;

                    nextTopLeftColIdx = _topLeftColIdx + 1;
                    nextBottomLeftColIdx = _bottomRightColIdx + 1;
                    nextTopRightColIdx = _topRightColIdx + 1;
                    nextBottomRightColIdx = _bottomRightColIdx + 1;
                    break;

                case MovingDirections.Left:
                    nextTopLeftRowIdx = _topLeftRowIdx;
                    nextBottomLeftRowIdx = _bottomLeftRowIdx;
                    nextTopRightRowIdx = _topRightRowIdx;
                    nextBottomRightRowIdx = _bottomRightRowIdx;

                    nextTopLeftColIdx = _topLeftColIdx - 1;
                    nextBottomLeftColIdx = _bottomRightColIdx - 1;
                    nextTopRightColIdx = _topRightColIdx - 1;
                    nextBottomRightColIdx = _bottomRightColIdx - 1;
                    break;

                case MovingDirections.Down:
                    nextTopLeftRowIdx = _topLeftRowIdx + 1;
                    nextBottomLeftRowIdx = _bottomLeftRowIdx + 1;
                    nextTopRightRowIdx = _topRightRowIdx + 1;
                    nextBottomRightRowIdx = _bottomRightRowIdx + 1;

                    nextTopLeftColIdx = _topLeftColIdx;
                    nextBottomLeftColIdx = _bottomRightColIdx;
                    nextTopRightColIdx = _topRightColIdx;
                    nextBottomRightColIdx = _bottomRightColIdx;
                    break;
            }

            //If any row or col idx of the new locations go over the border, stops
            if (nextBottomLeftColIdx < 0 || nextBottomLeftRowIdx >= Constants.MAX_HEIGHT
                || nextBottomRightColIdx >= Constants.MAX_WIDTH
                || nextBottomRightRowIdx >= Constants.MAX_HEIGHT)
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
                    if (nextBottomLeftCellType is ButtonCellType || nextBottomRightCellType is ButtonCellType)
                    {
                        canMove = false;
                    }
                    break;

                case MovingDirections.Left:
                    if (nextBottomLeftCellType is ButtonCellType || nextTopLeftCellType is ButtonCellType)
                    {
                        canMove = false;
                    }
                    break;

                case MovingDirections.Right:
                    if (nextTopRightCellType is ButtonCellType || nextBottomRightCellType is ButtonCellType)
                    {
                        canMove = false;
                    }
                    break;
            }

            return canMove;
        }

        /// <summary>
        /// Get all the cells that built up the shape
        /// </summary>
        /// <returns></returns>
        public Cell[] GetCells()
        {
            return new Cell[4] { _topLeft, _bottomLeft, _topRight, _bottomRight };
        }

        /// <summary>
        /// Set SheetView object to contain this shape
        /// </summary>
        /// <param name="sheet">SheetView object</param>
        public void SetSheetView(SheetView sheet)
        {
            _sheet = sheet;
        }

        /// <summary>
        /// Reset all cells that forms the shape
        /// </summary>
        public void Reset()
        {
            _topLeft.ResetCellType();
            _bottomLeft.ResetCellType();
            _topRight.ResetCellType();
            _bottomRight.ResetCellType();
        }

        /// <summary>
        /// Save locations of the cells to variables
        /// </summary>
        private void SaveLocations()
        {
            _topLeftColIdx = _topLeft.Column.Index;
            _topLeftRowIdx = _topLeft.Row.Index;

            _bottomLeftColIdx = _bottomLeft.Column.Index;
            _bottomLeftRowIdx = _bottomLeft.Row.Index;

            _bottomRightColIdx = _bottomRight.Column.Index;
            _bottomRightRowIdx = _bottomRight.Row.Index;

            _topRightColIdx = _topRight.Column.Index;
            _topRightRowIdx = _topRight.Row.Index;
        }
    }
}