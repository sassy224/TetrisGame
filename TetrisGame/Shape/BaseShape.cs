using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class BaseShape : ITetrisShape
    {
        /// <summary>
        /// The sheetview object that represents a sheet of the spread
        /// </summary>
        protected SheetView _sheet = null;

        /// <summary>
        /// The nine cells that represents a shape
        /// </summary>
        protected Cell _center = null;
        protected int _centerRowIdx = -1;
        protected int _centerColIdx = -1;

        protected Cell _left = null;
        protected int _leftRowIdx = -1;
        protected int _leftColIdx = -1;

        protected Cell _right = null;
        protected int _rightRowIdx = -1;
        protected int _rightColIdx = -1;

        protected Cell _top = null;
        protected int _topRowIdx = -1;
        protected int _topColIdx = -1;

        protected Cell _bottom = null;
        protected int _bottomRowIdx = -1;
        protected int _bottomColIdx = -1;

        protected Cell _topLeft = null;
        protected int _topLeftRowIdx = -1;
        protected int _topLeftColIdx = -1;

        protected Cell _topRight = null;
        protected int _topRightRowIdx = -1;
        protected int _topRightColIdx = -1;

        protected Cell _bottomLeft = null;
        protected int _bottomLeftRowIdx = -1;
        protected int _bottomLeftColIdx = -1;

        protected Cell _bottomRight = null;
        protected int _bottomRightRowIdx = -1;
        protected int _bottomRightColIdx = -1;

        /// <summary>
        /// The init location of the shape
        /// </summary>
        protected int _initRowIdx = -1;
        protected int _initColIdx = -1;

        /// <summary>
        /// The current direction of the shape
        /// </summary>
        protected ShapeDirections _currentShapeDirection = ShapeDirections.FaceUp;

        /// <summary>
        /// Borders' location
        /// </summary>
        protected int BORDER_LEFT = Constants.BASE_WIDTH_OFFSET;
        protected int BORDER_RIGHT = Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET;
        protected int BORDER_BOTTOM = Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="sheet">The sheetview object</param>
        /// <param name="rowIdx">The init row index</param>
        /// <param name="colIdx">The init col index</param>
        public BaseShape(SheetView sheet, int rowIdx, int colIdx)
        {
            _sheet = sheet;
            _initRowIdx = rowIdx;
            _initColIdx = colIdx;
        }

        /// <summary>
        /// Base draw function, only draw cells that have positive coordinate
        /// </summary>
        public virtual void Draw()
        {
            if (_centerRowIdx != -1 && _centerColIdx != -1)
            {
                _center = _sheet.Cells[_centerRowIdx, _centerColIdx];
                _center.CellType = new ButtonCellType();
            }

            if (_leftRowIdx != -1 && _leftColIdx != -1)
            {
                _left = _sheet.Cells[_leftRowIdx, _leftColIdx];
                _left.CellType = new ButtonCellType();
            }

            if (_rightRowIdx != -1 && _rightColIdx != -1)
            {
                _right = _sheet.Cells[_rightRowIdx, _rightColIdx];
                _right.CellType = new ButtonCellType();
            }

            if (_bottomRowIdx != -1 && _bottomColIdx != -1)
            {
                _bottom = _sheet.Cells[_bottomRowIdx, _bottomColIdx];
                _bottom.CellType = new ButtonCellType();
            }

            if (_topRowIdx != -1 && _topColIdx != -1)
            {
                _top = _sheet.Cells[_topRowIdx, _topColIdx];
                _top.CellType = new ButtonCellType();
            }

            if (_topLeftRowIdx != -1 && _topLeftColIdx != -1)
            {
                _topLeft = _sheet.Cells[_topLeftRowIdx, _topLeftColIdx];
                _topLeft.CellType = new ButtonCellType();
            }

            if (_bottomLeftRowIdx != -1 && _bottomLeftColIdx != -1)
            {
                _bottomLeft = _sheet.Cells[_bottomLeftRowIdx, _bottomLeftColIdx];
                _bottomLeft.CellType = new ButtonCellType();
            }

            if (_topRightRowIdx != -1 && _topRightColIdx != -1)
            {
                _topRight = _sheet.Cells[_topRightRowIdx, _topRightColIdx];
                _topRight.CellType = new ButtonCellType();
            }

            if (_bottomRightRowIdx != -1 && _bottomRightColIdx != -1)
            {
                _bottomRight = _sheet.Cells[_bottomRightRowIdx, _bottomRightColIdx];
                _bottomRight.CellType = new ButtonCellType();
            }
        }

        /// <summary>
        /// Base rotate function, do nothing
        /// </summary>
        public virtual void Rotate()
        {
        }

        /// <summary>
        /// Base move left function, move all cells coordinates to the left
        /// </summary>
        public virtual void Move(MovingDirections direction)
        {
            switch (direction)
            {
                case MovingDirections.Left:
                    if (_center != null) _centerColIdx -= 1;
                    if (_top != null) _topColIdx -= 1;
                    if (_bottom != null) _bottomColIdx -= 1;
                    if (_left != null) _leftColIdx -= 1;
                    if (_right != null) _rightColIdx -= 1;
                    if (_topLeft != null) _topLeftColIdx -= 1;
                    if (_bottomLeft != null) _bottomLeftColIdx -= 1;
                    if (_topRight != null) _topRightColIdx -= 1;
                    if (_bottomRight != null) _bottomRightColIdx -= 1;
                    break;

                case MovingDirections.Right:
                    if (_center != null) _centerColIdx += 1;
                    if (_top != null) _topColIdx += 1;
                    if (_bottom != null) _bottomColIdx += 1;
                    if (_left != null) _leftColIdx += 1;
                    if (_right != null) _rightColIdx += 1;
                    if (_topLeft != null) _topLeftColIdx += 1;
                    if (_bottomLeft != null) _bottomLeftColIdx += 1;
                    if (_topRight != null) _topRightColIdx += 1;
                    if (_bottomRight != null) _bottomRightColIdx += 1;
                    break;

                case MovingDirections.Down:
                    if (_center != null) _centerRowIdx += 1;
                    if (_top != null) _topRowIdx += 1;
                    if (_bottom != null) _bottomRowIdx += 1;
                    if (_left != null) _leftRowIdx += 1;
                    if (_right != null) _rightRowIdx += 1;
                    if (_topLeft != null) _topLeftRowIdx += 1;
                    if (_bottomLeft != null) _bottomLeftRowIdx += 1;
                    if (_topRight != null) _topRightRowIdx += 1;
                    if (_bottomRight != null) _bottomRightRowIdx += 1;
                    break;
            }

            ResetCells();
            Draw();
        }

        /// <summary>
        /// Base function to check whether the shape can be rotated. Default is return true
        /// </summary>
        /// <param name="nextDirection"></param>
        /// <returns></returns>
        public virtual bool CanRotate(ShapeDirections nextDirection)
        {
            return true;
        }

        /// <summary>
        /// Base function to check whether the shape can move. Default is return true
        /// </summary>
        /// <param name="nextDirection"></param>
        /// <returns></returns>
        public virtual bool CanMove(MovingDirections nextDirection)
        {
            return true;
        }

        /// <summary>
        /// Base function to return array of all initialized cells
        /// </summary>
        /// <returns></returns>
        public virtual Cell[] GetCells()
        {
            List<Cell> cells = new List<Cell>(9);

            if (_center != null) cells.Add(_center);
            if (_left != null) cells.Add(_left);
            if (_right != null) cells.Add(_right);
            if (_top != null) cells.Add(_top);
            if (_bottom != null) cells.Add(_bottom);
            if (_topLeft != null) cells.Add(_topLeft);
            if (_bottomLeft != null) cells.Add(_bottomLeft);
            if (_topRight != null) cells.Add(_topRight);
            if (_bottomRight != null) cells.Add(_bottomRight);

            return cells.ToArray();
        }

        /// <summary>
        /// Base function to set SheetView object
        /// </summary>
        /// <param name="sheet"></param>
        public virtual void SetSheetView(SheetView sheet)
        {
            _sheet = sheet;
        }

        /// <summary>
        /// Base function to reset all cells
        /// </summary>
        public virtual void ResetCells()
        {
            if (_center != null)
            {
                _center.ResetCellType();
                _center = null;
            }
            if (_top != null)
            {
                _top.ResetCellType();
                _top = null;
            }
            if (_bottom != null)
            {
                _bottom.ResetCellType();
                _bottom = null;
            }
            if (_left != null)
            {
                _left.ResetCellType();
                _left = null;
            }
            if (_right != null)
            {
                _right.ResetCellType();
                _right = null;
            }
            if (_topLeft != null)
            {
                _topLeft.ResetCellType();
                _topLeft = null;
            }
            if (_bottomLeft != null)
            {
                _bottomLeft.ResetCellType();
                _bottomLeft = null;
            };
            if (_topRight != null)
            {
                _topRight.ResetCellType();
                _topRight = null;
            }
            if (_bottomRight != null)
            {
                _bottomRight.ResetCellType();
                _bottomRight = null;
            }
        }

        /// <summary>
        /// Base function to reset all location variables except the center one
        /// </summary>
        public virtual void ResetLocations()
        {
            _leftColIdx = -1;
            _leftRowIdx = -1;

            _rightColIdx = -1;
            _rightRowIdx = -1;

            _topColIdx = -1;
            _topRowIdx = -1;

            _bottomColIdx = -1;
            _bottomRowIdx = -1;

            _topLeftColIdx = -1;
            _topLeftRowIdx = -1;

            _bottomLeftColIdx = -1;
            _bottomLeftRowIdx = -1;

            _topRightColIdx = -1;
            _topRightRowIdx = -1;

            _bottomRightColIdx = -1;
            _bottomRightRowIdx = -1;
        }

        /// <summary>
        /// Base function to save locations of cells to variables
        /// </summary>
        protected virtual void SaveLocations()
        {
            if (_center != null)
            {
                _centerColIdx = _center.Column.Index;
                _centerRowIdx = _center.Row.Index;
            }

            if (_left != null)
            {
                _leftColIdx = _left.Column.Index;
                _leftRowIdx = _left.Row.Index;
            }

            if (_top != null)
            {
                _topColIdx = _top.Column.Index;
                _topRowIdx = _top.Row.Index;
            }

            if (_right != null)
            {
                _rightColIdx = _right.Column.Index;
                _rightRowIdx = _right.Row.Index;
            }

            if (_bottom != null)
            {
                _bottomColIdx = _bottom.Column.Index;
                _bottomRowIdx = _bottom.Row.Index;
            }

            if (_topLeft != null)
            {
                _topLeftColIdx = _topLeft.Column.Index;
                _topLeftRowIdx = _topLeft.Row.Index;
            }

            if (_bottomLeft != null)
            {
                _bottomLeftColIdx = _bottomLeft.Column.Index;
                _bottomLeftRowIdx = _bottomLeft.Row.Index;
            }

            if (_topRight != null)
            {
                _topRightColIdx = _topRight.Column.Index;
                _topRightRowIdx = _topRight.Row.Index;
            }

            if (_bottomRight != null)
            {
                _bottomRightColIdx = _bottomRight.Column.Index;
                _bottomRightRowIdx = _bottomRight.Row.Index;
            }
        }

        /// <summary>
        /// Get the minimum column index based on the current shape
        /// </summary>
        /// <returns>Min column index</returns>
        protected virtual int GetCurrentMinColIdx()
        {
            int min = _centerColIdx;

            if (_topLeft != null) min = Math.Min(_topLeftColIdx, min);
            if (_bottomLeft != null) min = Math.Min(_bottomLeftColIdx, min);
            if (_left != null) min = Math.Min(_leftColIdx, min);

            return min;
        }

        /// <summary>
        /// Get the maximum column index based on the current shape
        /// </summary>
        /// <returns></returns>
        protected virtual int GetCurrentMaxColIdx()
        {
            int max = _centerColIdx;

            if (_topRight != null) max = Math.Min(_topRightColIdx, max);
            if (_bottomRight != null) max = Math.Min(_bottomRightColIdx, max);
            if (_right != null) max = Math.Min(_rightColIdx, max);

            return max;
        }

        /// <summary>
        /// Get the maximum row index based on the current shape
        /// </summary>
        /// <returns></returns>
        protected virtual int GetCurrentMaxRowIdx()
        {
            int max = _centerRowIdx;

            if (_bottomLeft != null) max = Math.Max(_bottomLeftRowIdx, max);
            if (_bottomRight != null) max = Math.Max(_bottomRightRowIdx, max);
            if (_bottom != null) max = Math.Max(_bottomRowIdx, max);

            return max;
        }

        public virtual ShapeDirections GetShapeDirection()
        {
            return _currentShapeDirection;
        }
    }
}