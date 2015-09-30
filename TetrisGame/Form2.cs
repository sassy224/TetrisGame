using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.DrawingSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TetrisGame.Enums;
using TetrisGame.Shape;

namespace TetrisGame
{
    public partial class Form2 : Form
    {
        private ITetrisShape _pendingShape = null;
        private ITetrisShape _currentShape = null;
        private Random _random = new Random();
        private bool _gameOver = false;
        private ShapeDirections _currentDirection = ShapeDirections.FaceDown;
        private TetrisShapes _currentShapeModel = TetrisShapes.TShape;
        PSShape rectGameOver;
        Cell previewRange = null;
        Cell gameRange = null;

        public Form2()
        {
            InitializeComponent();
            rectGameOver = fpSpread1_Sheet1.GetShape("rectGameOver");
            fpSpread1_Sheet1.RemoveShape("rectGameOver");

            previewRange = fpSpread1_Sheet1.Cells[1, 16, 3, 19];
            gameRange = fpSpread1_Sheet1.Cells[5, 1, Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET, Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET];
        }

        private void fpSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 1 && e.Row == 1)
            {
                GameStart();
            }
        }

        private void tmTick_Tick(object sender, EventArgs e)
        {
            if (_currentShape.CanMove(MovingDirections.Down))
            {
                //Move the shape down
                _currentShape.MoveDown();
            }
            else
            {
                //Shape can't be moved down, check for cleared rows
                CheckRows();
                //Assign pending shape to current shape
                _currentShape = GenerateRandomShape(false);

                //Create new pending shape
                _pendingShape.Reset();
                _pendingShape = GenerateRandomShape(true);
            }
        }

        private void fpSpread1_ComboSelChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Row == 3 && e.Column == 3)
            {
                string selectedLevel = fpSpread1_Sheet1.Cells[3, 3].Text;
                if (selectedLevel.Equals(GameLevels.Slow.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    tmTick.Interval = (int)GameLevels.Slow;
                }
                else if (selectedLevel.Equals(GameLevels.Normal.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    tmTick.Interval = (int)GameLevels.Normal;
                }
                else
                {
                    tmTick.Interval = (int)GameLevels.Fast;
                }
            }
        }

        /// <summary>
        /// Reset the board and start the game
        /// </summary>
        private void GameStart()
        {
            //Stop ticking
            tmTick.Stop();

            //Remove shape
            fpSpread1_Sheet1.RemoveShape("rectGameOver");
            //Clear ranges
            previewRange.ResetCellType();
            gameRange.ResetCellType();

            //Create random shapes
            _currentShape = GenerateRandomShape(false);

            _pendingShape = GenerateRandomShape(true);
            fpSpread1_Sheet1.Cells[2, 12].Text = "0";
            _gameOver = false;

            //Start ticking
            tmTick.Start();
        }

        /// <summary>
        /// Stop everything, show Game Over
        /// </summary>
        private void GameOver()
        {
            tmTick.Stop();
            fpSpread1_Sheet1.AddShape(rectGameOver);
            _gameOver = true;
        }

        /// <summary>
        /// Check for cleared rows
        /// </summary>
        private void CheckRows()
        {
            //Get cells from shape
            Cell[] cells = _currentShape.GetCells();
            //A shape is built by 4 cells, find the lowest row index of the 4 cells
            int minRowIdx = Math.Min(Math.Min(cells[0].Row.Index, cells[1].Row.Index), Math.Min(cells[2].Row.Index, cells[3].Row.Index));

            //check minRowIdx
            if (minRowIdx == Constants.BASE_HEIGHT_OFFSET) //cells reach top of the border
            {
                GameOver();
                return;
            }

            List<int> lstClearedRowIdxes = new List<int>();

            for (int row = fpSpread1_Sheet1.RowCount - 1; row >= minRowIdx; row--)
            {
                bool cleared = true;
                for (int col = Constants.BASE_WIDTH_OFFSET; col < Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET; col++)
                {
                    //If there's any row that is not of ButtonCellType, skip it
                    if ((fpSpread1_Sheet1.Cells[row, col].CellType == null))
                    {
                        cleared = false;
                        break;
                    }
                }

                if (cleared)
                {
                    lstClearedRowIdxes.Add(row);
                }
            }

            int removedCount = 0;

            foreach (int rowIdx in lstClearedRowIdxes)
            {
                //Remove the row
                fpSpread1_Sheet1.Rows.Get(rowIdx + removedCount).Remove();
                //Add a new one at the top
                fpSpread1_Sheet1.Rows.Add(Constants.BASE_HEIGHT_OFFSET, 1);

                //Update color for newly created cells
                this.fpSpread1_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.SystemColors.ControlLight;
                this.fpSpread1_Sheet1.Cells.Get(5, 0).ForeColor = System.Drawing.Color.Silver;
                this.fpSpread1_Sheet1.Cells.Get(5, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
                this.fpSpread1_Sheet1.Cells.Get(5, 19).BackColor = System.Drawing.SystemColors.ControlLight;
                this.fpSpread1_Sheet1.Cells.Get(5, 19).ForeColor = System.Drawing.Color.Silver;
                this.fpSpread1_Sheet1.Cells.Get(5, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;

                //Update score
                fpSpread1_Sheet1.Cells[2, 12].Text = (Int32.Parse(fpSpread1_Sheet1.Cells[2, 12].Text) + 100).ToString();

                //Increase the count so next row will be removed correctly
                removedCount++;
            }
        }

        private ITetrisShape GenerateRandomShape(bool forPreview)
        {
            ITetrisShape shape = null;

            if (forPreview)
            {
                //Create a random direction
                _currentDirection = (ShapeDirections)_random.Next(1, 4);
            }

            //Init location
            int colIdx = 17;
            int rowIdx = 2;

            if (!forPreview)
            {
                colIdx = _random.Next(2, Constants.MAX_WIDTH - 2);
                rowIdx = 6;
            }

            if (forPreview)
            {
                //Create a random shape
                _currentShapeModel = (TetrisShapes)_random.Next(1, 3);
            }

            switch (_currentShapeModel)
            {
                case TetrisShapes.TShape:
                    shape = new TShape(fpSpread1_Sheet1, rowIdx, colIdx, _currentDirection);
                    break;

                case TetrisShapes.SShape:
                    shape = new SShape(fpSpread1_Sheet1, rowIdx, colIdx);
                    break;

                case TetrisShapes.LShape:
                    shape = new LShape(fpSpread1_Sheet1, rowIdx, colIdx, _currentDirection);
                    break;
            }

            return shape;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Capture up arrow key
            if (keyData == Keys.Up)
            {
                //Do nothing
                return true;
            }
            //Capture down arrow key
            if (keyData == Keys.Down)
            {
                if (!_gameOver && _currentShape != null && _currentShape.CanMove(MovingDirections.Down))
                    _currentShape.MoveDown();
                return true;
            }
            //Capture left arrow key
            if (keyData == Keys.Left)
            {
                if (!_gameOver && _currentShape != null && _currentShape.CanMove(MovingDirections.Left))
                    _currentShape.MoveLeft();
                return true;
            }
            //Capture right arrow key
            if (keyData == Keys.Right)
            {
                if (!_gameOver && _currentShape != null && _currentShape.CanMove(MovingDirections.Right))
                    _currentShape.MoveRight();
                return true;
            }

            //Capture Esc key
            if (keyData == Keys.Space)
            {
                if (!_gameOver)
                {
                    if (_currentShape == null)
                    {
                        //Game hasn't been started yet, start it
                        GameStart();
                    }
                    else
                    {
                        _currentShape.Rotate();
                    }
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}