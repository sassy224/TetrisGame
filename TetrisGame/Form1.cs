using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
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
    public partial class Form1 : Form
    {
        private ITetrisShape _pendingShape = null;
        private ITetrisShape _currentShape = null;
        private Random _random = new Random();
        private bool _gameOver = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindLevels();
        }

        /// <summary>
        /// Bind list of levels to Combobox
        /// </summary>
        private void BindLevels()
        {
            List<LevelItem> items = new List<LevelItem>();

            items.Add(new LevelItem()
            {
                Level = GameLevels.Slow,
                LevelName = GameLevels.Slow.ToString()
            });

            items.Add(new LevelItem()
            {
                Level = GameLevels.Normal,
                LevelName = GameLevels.Normal.ToString()
            });

            items.Add(new LevelItem()
            {
                Level = GameLevels.Fast,
                LevelName = GameLevels.Fast.ToString()
            });

            cboLevel.DataSource = items;
            cboLevel.DisplayMember = "LevelName";

            cboLevel.SelectedItem = items[1]; //Default to normal
        }

        /// <summary>
        /// Reset the board and start the game
        /// </summary>
        private void GameStart()
        {
            //Stop ticking
            tmTick.Stop();
            pnlGameOver.Visible = false;

            //Clear controls
            sheetMain.Rows.Clear();
            sheetMain.Columns.Clear();

            sheetMain.RowCount = 26;
            sheetMain.ColumnCount = 26;
            //Create random shapes
            _currentShape = GenerateRandomShape(false);

            _pendingShape = GenerateRandomShape(true);
            lblPointsValue.Text = "0";
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
            pnlGameOver.Visible = true;
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
            if (minRowIdx == 0) //cells reach top of the border
            {
                GameOver();
                return;
            }

            List<int> lstClearedRowIdxes = new List<int>();

            for (int row = sheetMain.RowCount - 1; row >= minRowIdx; row--)
            {
                bool cleared = true;
                for (int col = 0; col < sheetMain.ColumnCount; col++)
                {
                    //If there's any row that is not of ButtonCellType, skip it
                    if (!(sheetMain.Cells[row, col].CellType is ButtonCellType))
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

            foreach (int rowIdx in lstClearedRowIdxes)
            {
                //Change color
                sheetMain.Rows.Get(rowIdx).ForeColor = Color.Blue;
                //Remove the row
                sheetMain.Rows.Get(rowIdx).Remove();
                //Add a new one at the top
                sheetMain.Rows.Add(0, 1);
                //Update score
                lblPointsValue.Text = (Int32.Parse(lblPointsValue.Text) + 100).ToString();
            }
        }

        private ITetrisShape GenerateRandomShape(bool forPreview)
        {
            ITetrisShape shape = null;

            //Create a random direction
            ShapeDirections direction = (ShapeDirections)_random.Next(1, 4);

            //Init location
            int colIdx = 1;
            int rowIdx = 1;

            if (!forPreview)
            {
                colIdx = _random.Next(2, Constants.MAX_WIDTH - 2);
            }

            //Create a random shape
            TetrisShapes model = (TetrisShapes)_random.Next(1, 2);

            switch (model)
            {
                case TetrisShapes.TShape:
                    shape = new TShape(forPreview ? sheetPreview : sheetMain, rowIdx, colIdx, direction);
                    break;

                case TetrisShapes.SShape:
                    shape = new SShape(forPreview ? sheetPreview : sheetMain, rowIdx, colIdx);
                    break;

                case TetrisShapes.LShape:
                    shape = new LShape(forPreview ? sheetPreview : sheetMain, rowIdx, colIdx, direction);
                    break;
            }

            return shape;
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
                _currentShape = _pendingShape;
                _currentShape.SetSheetView(sheetMain);

                //Create new pending shape
                _pendingShape.Reset();
                _pendingShape = GenerateRandomShape(true);
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //Start the game
            GameStart();
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
                if (!_gameOver && _currentShape.CanMove(MovingDirections.Down))
                    _currentShape.MoveDown();
                return true;
            }
            //Capture left arrow key
            if (keyData == Keys.Left)
            {
                if (!_gameOver && _currentShape.CanMove(MovingDirections.Left))
                    _currentShape.MoveLeft();
                return true;
            }
            //Capture right arrow key
            if (keyData == Keys.Right)
            {
                if (!_gameOver && _currentShape.CanMove(MovingDirections.Right))
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

        private void cboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLevel.SelectedIndex != -1)
            {
                //Change speed of the game by changing the tick interval
                LevelItem selectedLevel = (LevelItem)cboLevel.SelectedValue;
                tmTick.Interval = (int)selectedLevel.Level;
            }
        }
    }
}

class LevelItem
{
    public GameLevels Level { get; set; }
    public string LevelName { get; set; }
}