﻿namespace TetrisGame
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tmTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.AllowUndo = false;
            this.fpSpread1.AllowUserZoom = false;
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.AutoClipboard = false;
            this.fpSpread1.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse;
            this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fpSpread1.CellNoteIndicatorVisible = false;
            this.fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpSpread1.EnableCrossSheetReference = false;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Margin = new System.Windows.Forms.Padding(0);
            this.fpSpread1.MoveActiveOnFocus = false;
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RetainSelectionBlock = false;
            this.fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(399, 499);
            this.fpSpread1.TabIndex = 0;
            this.fpSpread1.TabStrip.ButtonPolicy = FarPoint.Win.Spread.TabStripButtonPolicy.Never;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ButtonClicked);
            this.fpSpread1.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ComboCloseUp);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            fpSpread1_Sheet1.ColumnCount = 20;
            fpSpread1_Sheet1.RowCount = 25;
            this.fpSpread1_Sheet1.AllowNoteEdit = false;
            this.fpSpread1_Sheet1.AutoCalculation = false;
            this.fpSpread1_Sheet1.AutoGenerateColumns = false;
            this.fpSpread1_Sheet1.AutoUpdateNotes = false;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 1).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 1).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 1).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 2).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 2).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 2).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 3).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 3).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 3).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 4).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 4).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 4).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 5).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 5).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 5).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 6).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 6).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 6).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 7).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 7).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 7).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 8).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 8).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 8).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 9).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 9).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 9).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 10).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 10).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 10).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 11).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 11).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 11).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 12).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 12).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 12).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 13).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 13).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 13).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 14).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 14).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 14).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 15).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 15).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 15).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 16).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 16).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 16).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 17).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 17).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 17).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 18).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 18).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 18).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(0, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(0, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(0, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 1).BackColor = System.Drawing.SystemColors.ControlLight;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            buttonCellType4.Text = "&New Game";
            this.fpSpread1_Sheet1.Cells.Get(1, 1).CellType = buttonCellType4;
            this.fpSpread1_Sheet1.Cells.Get(1, 1).ColumnSpan = 3;
            this.fpSpread1_Sheet1.Cells.Get(1, 1).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 1).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 2).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 2).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 2).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 3).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 3).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 3).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 4).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 4).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 4).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 5).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 5).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 5).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 6).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 6).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 6).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 7).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 7).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 7).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 8).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 8).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 8).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 9).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 9).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 9).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 10).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 10).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 10).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 11).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 11).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 11).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 12).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 12).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 12).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 13).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 13).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 13).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 14).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 14).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 14).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 15).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 15).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 15).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(1, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(1, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(1, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 1).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 1).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 1).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 2).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 2).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 2).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 3).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 3).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 3).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 4).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 4).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 4).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 5).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 5).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 5).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 6).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 6).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 6).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 7).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 7).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 7).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 8).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 8).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 8).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 9).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 9).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 9).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 10).BackColor = System.Drawing.SystemColors.ControlLight;
            textCellType10.ReadOnly = true;
            this.fpSpread1_Sheet1.Cells.Get(2, 10).CellType = textCellType10;
            this.fpSpread1_Sheet1.Cells.Get(2, 10).ColumnSpan = 2;
            this.fpSpread1_Sheet1.Cells.Get(2, 10).ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.Cells.Get(2, 10).Value = "Score:";
            this.fpSpread1_Sheet1.Cells.Get(2, 10).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 11).BackColor = System.Drawing.SystemColors.ControlLight;
            textCellType11.ReadOnly = true;
            this.fpSpread1_Sheet1.Cells.Get(2, 11).CellType = textCellType11;
            this.fpSpread1_Sheet1.Cells.Get(2, 11).ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.Cells.Get(2, 11).Value = "Score:";
            this.fpSpread1_Sheet1.Cells.Get(2, 11).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 12).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 12).ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.Cells.Get(2, 12).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 13).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 13).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 13).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 14).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 14).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 14).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 15).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 15).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 15).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(2, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(2, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(2, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 1).BackColor = System.Drawing.SystemColors.ControlLight;
            textCellType12.ReadOnly = true;
            this.fpSpread1_Sheet1.Cells.Get(3, 1).CellType = textCellType12;
            this.fpSpread1_Sheet1.Cells.Get(3, 1).ColumnSpan = 2;
            this.fpSpread1_Sheet1.Cells.Get(3, 1).ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.Cells.Get(3, 1).Value = "Level";
            this.fpSpread1_Sheet1.Cells.Get(3, 1).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 2).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 2).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 2).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 3).BackColor = System.Drawing.Color.White;
            comboBoxCellType4.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType4.ItemData = new string[] {
        "1",
        "2",
        "3"};
            comboBoxCellType4.Items = new string[] {
        "Slow",
        "Normal",
        "Fast"};
            this.fpSpread1_Sheet1.Cells.Get(3, 3).CellType = comboBoxCellType4;
            this.fpSpread1_Sheet1.Cells.Get(3, 3).ColumnSpan = 3;
            this.fpSpread1_Sheet1.Cells.Get(3, 3).ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.Cells.Get(3, 3).Value = "Normal";
            this.fpSpread1_Sheet1.Cells.Get(3, 3).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 4).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 4).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 4).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 5).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 5).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 5).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 6).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 6).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 6).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 7).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 7).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 7).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 8).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 8).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 8).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 9).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 9).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 9).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 10).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 10).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 10).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 11).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 11).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 11).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 12).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 12).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 12).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 13).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 13).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 13).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 14).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 14).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 14).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 15).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 15).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 15).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(3, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(3, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(3, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 1).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 1).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 1).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 2).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 2).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 2).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 3).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 3).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 3).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 4).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 4).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 4).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 5).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 5).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 5).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 6).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 6).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 6).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 7).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 7).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 7).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 8).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 8).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 8).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 9).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 9).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 9).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 10).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 10).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 10).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 11).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 11).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 11).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 12).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 12).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 12).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 13).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 13).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 13).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 14).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 14).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 14).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 15).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 15).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 15).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 16).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 16).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 16).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 17).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 17).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 17).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 18).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(4, 18).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(4, 18).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(4, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(5, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(5, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(5, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(5, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(5, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(6, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(6, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(6, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(6, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(6, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(6, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(7, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(7, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(7, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(7, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(7, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(7, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(8, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(8, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(9, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(9, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(9, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(9, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(9, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(9, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(10, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(10, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(10, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(10, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(10, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(10, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(11, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(11, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(11, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(11, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(11, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(11, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(12, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(12, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(12, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(12, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(12, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(12, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(13, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(13, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(14, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(14, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(14, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(14, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(14, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(14, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(15, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(15, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(15, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(15, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(15, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(15, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(16, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(16, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(16, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(16, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(16, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(16, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(17, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(17, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(17, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(17, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(17, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(17, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(18, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(18, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(19, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(19, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(19, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(19, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(19, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(19, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(20, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(20, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(20, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(20, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(20, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(20, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(21, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(21, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(21, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(21, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(21, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(21, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(22, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(22, 0).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(22, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(22, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(22, 19).ForeColor = System.Drawing.Color.Silver;
            this.fpSpread1_Sheet1.Cells.Get(22, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.Cells.Get(23, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(23, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(24, 0).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(24, 1).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.Cells.Get(24, 1).ColumnSpan = 18;
            this.fpSpread1_Sheet1.Cells.Get(24, 19).BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpSpread1_Sheet1.ColumnHeader.Visible = false;
            this.fpSpread1_Sheet1.Columns.Default.Width = 20F;
            this.fpSpread1_Sheet1.DataAutoCellTypes = false;
            this.fpSpread1_Sheet1.DataAutoHeadings = false;
            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
            this.fpSpread1_Sheet1.DrawingContainer.ContainedObjects.AddRange(new object[] {
            ((object)(resources.GetObject("resource.ContainedObjects")))});
            this.fpSpread1_Sheet1.DrawingContainer.FlipHorizontal = false;
            this.fpSpread1_Sheet1.DrawingContainer.FlipVertical = false;
            this.fpSpread1_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.SystemColors.ControlLight);
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.None;
            this.fpSpread1_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight);
            this.fpSpread1_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight);
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tmTick
            // 
            this.tmTick.Interval = 1000;
            this.tmTick.Tick += new System.EventHandler(this.tmTick_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(398, 499);
            this.Controls.Add(this.fpSpread1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Timer tmTick;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
    }
}