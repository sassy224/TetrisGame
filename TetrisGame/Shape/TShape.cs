using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class TShape : ITetrisShape
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

        private Cell _left = null;
        private int _leftRowIdx = 0;
        private int _leftColIdx = 0;

        private Cell _right = null;
        private int _rightRowIdx = 0;
        private int _rightColIdx = 0;

        private Cell _top = null;
        private int _topRowIdx = 0;
        private int _topColIdx = 0;

        /// <summary>
        /// The init location of the shape
        /// </summary>
        private int _initRowIdx = 0;
        private int _initColIdx = 0;

        /// <summary>
        /// The current direction of the shape
        /// </summary>
        private ShapeDirections _currentShapeDirection = ShapeDirections.FaceUp;

        private int BORDER_LEFT = Constants.BASE_WIDTH_OFFSET;
        private int BORDER_RIGHT = Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET;
        private int BORDER_BOTTOM = Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET;

        public TShape(SheetView sheet, int rowIdx, int colIdx, ShapeDirections direction)
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

            //Compute locations for other cells
            if (_currentShapeDirection == ShapeDirections.FaceUp)
            {
                _leftColIdx = _centerColIdx - 1;
                _leftRowIdx = _centerRowIdx;

                _topColIdx = _centerColIdx;
                _topRowIdx = _centerRowIdx - 1;

                _rightColIdx = _centerColIdx + 1;
                _rightRowIdx = _centerRowIdx;
            }
            else if (_currentShapeDirection == ShapeDirections.FaceRight)
            {
                _leftColIdx = _centerColIdx;
                _leftRowIdx = _centerRowIdx - 1;

                _topColIdx = _centerColIdx + 1;
                _topRowIdx = _centerRowIdx;

                _rightColIdx = _centerColIdx;
                _rightRowIdx = _centerRowIdx + 1;
            }
            else if (_currentShapeDirection == ShapeDirections.FaceDown)
            {
                _leftColIdx = _centerColIdx + 1;
                _leftRowIdx = _centerRowIdx;

                _topColIdx = _centerColIdx;
                _topRowIdx = _centerRowIdx + 1;

                _rightColIdx = _centerColIdx - 1;
                _rightRowIdx = _centerRowIdx;
            }
            else //Face left
            {
                _leftColIdx = _centerColIdx;
                _leftRowIdx = _centerRowIdx + 1;

                _topColIdx = _centerColIdx - 1;
                _topRowIdx = _centerRowIdx;

                _rightColIdx = _centerColIdx;
                _rightRowIdx = _centerRowIdx - 1;
            }

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

            _left = _sheet.Cells[_leftRowIdx, _leftColIdx];
            _left.CellType = new ButtonCellType();

            _right = _sheet.Cells[_rightRowIdx, _rightColIdx];
            _right.CellType = new ButtonCellType();

            _top = _sheet.Cells[_topRowIdx, _topColIdx];
            _top.CellType = new ButtonCellType();
        }

        /// <summary>
        /// Rotate the shape, in order from up -> right -> down -> left -> up
        /// </summary>
        public void Rotate()
        {
            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceUp:
                    if (CanRotate(ShapeDirections.FaceRight))
                    {
                        //Shape is facing up, rotate to face right
                        //Switch left and top
                        _left.ResetCellType();
                        _left = _top;
                        //Switch top and right
                        _top = _right;
                        //Move right to new position
                        _right = _sheet.Cells[_center.Row.Index + 1, _center.Column.Index];
                        _right.CellType = new ButtonCellType();
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceRight;
                    }
                    break;

                case ShapeDirections.FaceRight:
                    if (CanRotate(ShapeDirections.FaceDown))
                    {
                        //Shape is facing right, rotate to face down
                        //Switch left and top
                        _left.ResetCellType();
                        _left = _top;
                        //Switch top and right
                        _top = _right;
                        //Move right to new position
                        _right = _sheet.Cells[_center.Row.Index, _center.Column.Index - 1];
                        _right.CellType = new ButtonCellType();
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceDown;
                    }
                    break;

                case ShapeDirections.FaceDown:
                    if (CanRotate(ShapeDirections.FaceLeft))
                    {
                        //Shape is facing down, rotate to face left
                        //Switch left and top
                        _left.ResetCellType();
                        _left = _top;
                        //Switch top and right
                        _top = _right;
                        //Move right to new position
                        _right = _sheet.Cells[_center.Row.Index - 1, _center.Column.Index];
                        _right.CellType = new ButtonCellType();
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceLeft;
                    }
                    break;

                case ShapeDirections.FaceLeft:
                    if (CanRotate(ShapeDirections.FaceUp))
                    {
                        //Shape is facing left, rotate to face up
                        //Switch left and top
                        _left.ResetCellType();
                        _left = _top;
                        //Switch top and right
                        _top = _right;
                        //Move right to new position
                        _right = _sheet.Cells[_center.Row.Index, _center.Column.Index + 1];
                        _right.CellType = new ButtonCellType();
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceUp;
                    }
                    break;
            }
            //Save new locations of cell
            SaveLocations();
        }

        /// <summary>
        /// Move the shape to the left
        /// </summary>
        public void MoveLeft()
        {
            //Move all cells to the left
            _centerColIdx -= 1;
            _leftColIdx -= 1;
            _topColIdx -= 1;
            _rightColIdx -= 1;

            _center.ResetCellType();
            _left.ResetCellType();
            _top.ResetCellType();
            _right.ResetCellType();

            Draw();
        }

        /// <summary>
        /// Move the shape to the right
        /// </summary>
        public void MoveRight()
        {
            //Move all cells to the right
            _centerColIdx += 1;
            _leftColIdx += 1;
            _topColIdx += 1;
            _rightColIdx += 1;

            _center.ResetCellType();
            _left.ResetCellType();
            _top.ResetCellType();
            _right.ResetCellType();

            Draw();
        }

        /// <summary>
        /// Move the shape down
        /// </summary>
        public void MoveDown()
        {
            //Move all cells down
            _centerRowIdx += 1;
            _leftRowIdx += 1;
            _topRowIdx += 1;
            _rightRowIdx += 1;

            _center.ResetCellType();
            _left.ResetCellType();
            _top.ResetCellType();
            _right.ResetCellType();

            Draw();
        }

        /// <summary>
        /// Check if the shape can be rotated to the next direction
        /// </summary>
        /// <param name="nextShape">The next shape after the rotation</param>
        /// <returns>true if can rotate, false otherwise</returns>
        public bool CanRotate(ShapeDirections nextShape)
        {
            //The shape can be rotated if there's no ButtonCellType in its current left corner, current right corner,
            //the next right corner and the next right cell
            int curRightCornerRowIdx = 0;
            int curRightCornerColIdx = 0;
            int curLeftCornerRowIdx = 0;
            int curLeftCornerColIdx = 0;
            int nextRightCornerRowIdx = 0;
            int nextRightCornerColIdx = 0;
            int nextRightRowIdx = 0;
            int nextRightColIdx = 0;

            ICellType nextRightCornerCellType = null;
            ICellType nextRightCellType = null;
            ICellType curRightCornerCellType = null;
            ICellType curLeftCornerCellType = null;

            switch (nextShape)
            {
                case ShapeDirections.FaceDown:
                    //Current is FaceRight
                    curRightCornerColIdx = _topColIdx;
                    curRightCornerRowIdx = _rightRowIdx;

                    curLeftCornerColIdx = _topColIdx;
                    curLeftCornerRowIdx = _leftRowIdx;

                    nextRightCornerColIdx = _rightColIdx - 1;
                    nextRightCornerRowIdx = _rightRowIdx;

                    nextRightColIdx = _rightColIdx - 1;
                    nextRightRowIdx = _rightRowIdx - 1;

                    break;

                case ShapeDirections.FaceLeft:
                    //Current is FaceDown
                    curRightCornerColIdx = _rightColIdx;
                    curRightCornerRowIdx = _topRowIdx;

                    curLeftCornerColIdx = _leftColIdx;
                    curLeftCornerRowIdx = _topRowIdx;

                    nextRightCornerColIdx = _rightColIdx;
                    nextRightCornerRowIdx = _rightRowIdx - 1;

                    nextRightColIdx = _rightColIdx + 1;
                    nextRightRowIdx = _rightRowIdx - 1;

                    break;

                case ShapeDirections.FaceUp:
                    //Current is FaceLeft
                    curRightCornerColIdx = _topColIdx;
                    curRightCornerRowIdx = _rightRowIdx;

                    curLeftCornerColIdx = _topColIdx;
                    curLeftCornerRowIdx = _leftRowIdx;

                    nextRightCornerColIdx = _rightColIdx + 1;
                    nextRightCornerRowIdx = _rightRowIdx;

                    nextRightColIdx = _rightColIdx + 1;
                    nextRightRowIdx = _rightRowIdx + 1;

                    break;

                case ShapeDirections.FaceRight:
                    //Current is FaceUp
                    curRightCornerColIdx = _rightColIdx;
                    curRightCornerRowIdx = _topRowIdx;

                    curLeftCornerColIdx = _leftColIdx;
                    curLeftCornerRowIdx = _topRowIdx;

                    nextRightCornerColIdx = _rightColIdx;
                    nextRightCornerRowIdx = _rightRowIdx - 1;

                    nextRightColIdx = _rightColIdx - 1;
                    nextRightRowIdx = _rightRowIdx + 1;

                    break;
            }

            //When the center cell reaches borders, can't rotate
            if (_centerColIdx == BORDER_LEFT || _centerColIdx == BORDER_RIGHT - 1 || _centerRowIdx == BORDER_BOTTOM - 1)
                return false;

            //The shape can be rotated if there's no ButtonCellType in its current left corner, current right corner,
            //the next right corner and the next right cell
            curRightCornerCellType = _sheet.Cells[curRightCornerRowIdx, curRightCornerColIdx].CellType;
            curLeftCornerCellType = _sheet.Cells[curLeftCornerRowIdx, curLeftCornerColIdx].CellType;
            nextRightCornerCellType = _sheet.Cells[nextRightCornerRowIdx, nextRightCornerColIdx].CellType;
            nextRightCellType = _sheet.Cells[nextRightRowIdx, nextRightColIdx].CellType;

            if (nextRightCornerCellType != null || nextRightCellType != null
                || curLeftCornerCellType != null || curRightCornerCellType != null)
                return false;

            return true;
        }

        /// <summary>
        /// Check if the shape can move in the desinated direction
        /// </summary>
        /// <param name="nextDirection">The direction the shape is going to be moved</param>
        /// <returns>true if it can move, false otherwise</returns>
        public bool CanMove(MovingDirections nextDirection)
        {
            //The shape can be moved if the cells at the next location are not ButtonCellType
            int nextLeftRowIdx = 0;
            int nextLeftColIdx = 0;
            int nextCenterRowIdx = 0;
            int nextCenterColIdx = 0;
            int nextTopRowIdx = 0;
            int nextTopColIdx = 0;
            int nextRightRowIdx = 0;
            int nextRightColIdx = 0;

            ICellType nextLeftCellType = null;
            ICellType nextTopCellType = null;
            ICellType nextRightCellType = null;
            ICellType nextCenterCellType = null;

            bool canMove = true;

            switch (nextDirection)
            {
                case MovingDirections.Right:
                    nextLeftRowIdx = _leftRowIdx;
                    nextCenterRowIdx = _centerRowIdx;
                    nextTopRowIdx = _topRowIdx;
                    nextRightRowIdx = _rightRowIdx;

                    nextLeftColIdx = _leftColIdx + 1;
                    nextRightColIdx = _rightColIdx + 1;
                    nextTopColIdx = _topColIdx + 1;
                    nextCenterColIdx = _centerColIdx + 1;
                    break;

                case MovingDirections.Left:
                    nextLeftRowIdx = _leftRowIdx;
                    nextCenterRowIdx = _centerRowIdx;
                    nextTopRowIdx = _topRowIdx;
                    nextRightRowIdx = _rightRowIdx;

                    nextLeftColIdx = _leftColIdx - 1;
                    nextRightColIdx = _rightColIdx - 1;
                    nextTopColIdx = _topColIdx - 1;
                    nextCenterColIdx = _centerColIdx - 1;
                    break;

                case MovingDirections.Down:
                    nextLeftRowIdx = _leftRowIdx + 1;
                    nextCenterRowIdx = _centerRowIdx + 1;
                    nextTopRowIdx = _topRowIdx + 1;
                    nextRightRowIdx = _rightRowIdx + 1;

                    nextLeftColIdx = _leftColIdx;
                    nextRightColIdx = _rightColIdx;
                    nextTopColIdx = _topColIdx;
                    nextCenterColIdx = _centerColIdx;
                    break;
            }

            //If any row or col idx of the new locations go over the border, stops
            if (nextCenterRowIdx >= BORDER_BOTTOM || nextLeftRowIdx >= BORDER_BOTTOM
                || nextRightRowIdx >= BORDER_BOTTOM || nextTopRowIdx >= BORDER_BOTTOM
                || nextCenterColIdx >= BORDER_RIGHT || nextLeftColIdx >= BORDER_RIGHT
                || nextRightColIdx >= BORDER_RIGHT || nextTopColIdx >= BORDER_RIGHT
                || nextCenterColIdx < BORDER_LEFT || nextLeftColIdx < BORDER_LEFT
                || nextRightColIdx < BORDER_LEFT || nextTopColIdx < BORDER_LEFT)
                return false;

            //The shape can be moved if the cells at the next location are not ButtonCellType
            nextLeftCellType = _sheet.Cells[nextLeftRowIdx, nextLeftColIdx].CellType;
            nextTopCellType = _sheet.Cells[nextTopRowIdx, nextTopColIdx].CellType;
            nextRightCellType = _sheet.Cells[nextRightRowIdx, nextRightColIdx].CellType;
            nextCenterCellType = _sheet.Cells[nextCenterRowIdx, nextCenterColIdx].CellType;

            //Check the new locations based on the moving direction and the current shape direction
            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceUp:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            if (nextLeftCellType != null || nextCenterCellType != null || nextRightCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Left:
                            if (nextLeftCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Right:
                            if (nextRightCellType != null)
                            {
                                canMove = false;
                            }
                            break;
                    }
                    break;

                case ShapeDirections.FaceRight:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            if (nextTopCellType != null || nextRightCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Left:
                            if (nextLeftCellType != null || nextRightCellType != null || nextCenterCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Right:
                            if (nextLeftCellType != null || nextRightCellType != null || nextTopCellType != null)
                            {
                                canMove = false;
                            }
                            break;
                    }
                    break;

                case ShapeDirections.FaceDown:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            if (nextLeftCellType != null || nextTopCellType != null || nextRightCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Left:
                            if (nextRightCellType != null || nextTopCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Right:
                            if (nextLeftCellType != null || nextTopCellType != null)
                            {
                                canMove = false;
                            }
                            break;
                    }
                    break;

                case ShapeDirections.FaceLeft:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            if (nextTopCellType != null || nextLeftCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Left:
                            if (nextLeftCellType != null || nextRightCellType != null || nextTopCellType != null)
                            {
                                canMove = false;
                            }
                            break;

                        case MovingDirections.Right:
                            if (nextLeftCellType != null || nextRightCellType != null || nextCenterCellType != null)
                            {
                                canMove = false;
                            }
                            break;
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
            return new Cell[4] { _center, _left, _right, _top };
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
            _top.ResetCellType();
            _center.ResetCellType();
            _left.ResetCellType();
            _right.ResetCellType();
        }

        /// <summary>
        /// Save locations of the cells to variables
        /// </summary>
        private void SaveLocations()
        {
            _centerColIdx = _center.Column.Index;
            _centerRowIdx = _center.Row.Index;

            _leftColIdx = _left.Column.Index;
            _leftRowIdx = _left.Row.Index;

            _topColIdx = _top.Column.Index;
            _topRowIdx = _top.Row.Index;

            _rightColIdx = _right.Column.Index;
            _rightRowIdx = _right.Row.Index;
        }
    }
}