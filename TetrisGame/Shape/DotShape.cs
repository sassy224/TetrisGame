using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class DotShape : ITetrisShape
    {
        /// <summary>
        /// The sheetview object that represents a sheet of the spread
        /// </summary>
        private SheetView _sheet = null;

        /// <summary>
        /// The four cells that represents a shape
        /// </summary>
        private Cell _center = null;
        private int _centerRowIdx = 0;
        private int _centerColIdx = 0;

        /// <summary>
        /// The init location of the shape
        /// </summary>
        private int _initRowIdx = 0;
        private int _initColIdx = 0;

        /// <summary>
        /// The current direction of the shape
        /// </summary>
        private ShapeDirections _currentShapeDirection = ShapeDirections.FaceUp;

        /// <summary>
        /// Borders' location
        /// </summary>
        private int BORDER_LEFT = Constants.BASE_WIDTH_OFFSET;
        private int BORDER_RIGHT = Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET;
        private int BORDER_BOTTOM = Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET;

        public DotShape(SheetView sheet, int rowIdx, int colIdx, ShapeDirections direction)
        {
            _sheet = sheet;
            _initColIdx = colIdx;
            _initRowIdx = rowIdx;
            _currentShapeDirection = direction;

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
        /// Draw the shape by filling the cells with ButtonCellType to make it look different
        /// </summary>
        public void Draw()
        {
            _center = _sheet.Cells[_centerRowIdx, _centerColIdx];
            _center.CellType = new ButtonCellType();
        }

        /// <summary>
        /// Rotate the shape, in order from up -> right -> down -> left -> up
        /// </summary>
        public void Rotate()
        {
            //This shape doesn't support rotation
        }

        /// <summary>
        /// Move the shape to the left
        /// </summary>
        public void MoveLeft()
        {
            //Move all cells to the left
            _centerColIdx -= 1;

            Reset();

            Draw();
        }

        /// <summary>
        /// Move the shape to the right
        /// </summary>
        public void MoveRight()
        {
            //Move all cells to the right
            _centerColIdx += 1;

            Reset();

            Draw();
        }

        /// <summary>
        /// Move the shape down
        /// </summary>
        public void MoveDown()
        {
            //Move all cells down
            _centerRowIdx += 1;

            Reset();

            Draw();
        }

        /// <summary>
        /// Check if the shape can be rotated to the next direction
        /// </summary>
        /// <param name="nextShape">The next shape after the rotation</param>
        /// <returns>true if can rotate, false otherwise</returns>
        public bool CanRotate(ShapeDirections nextShape)
        {
            //This shape doesn't support rotation
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
            int nextCenterRowIdx = 0;
            int nextCenterColIdx = 0;

            ICellType nextLeftCellType = null;
            ICellType nextTopCellType = null;
            ICellType nextRightCellType = null;
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

        /// <summary>
        /// Get all the cells that built up the shape
        /// </summary>
        /// <returns></returns>
        public Cell[] GetCells()
        {
            return new Cell[4] { _center, _center, _center, _center };
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
            _center.ResetCellType();
        }

        /// <summary>
        /// Save locations of the cells to variables
        /// </summary>
        private void SaveLocations()
        {
            _centerColIdx = _center.Column.Index;
            _centerRowIdx = _center.Row.Index;
        }
    }
}