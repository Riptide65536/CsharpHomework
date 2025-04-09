namespace OrderManager
{
    partial class StockMenu
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            AddStockButton = new Button();
            ReduceStockButton = new Button();
            ChangeStockButton = new Button();
            CreateStockButton = new Button();
            ClearStockButton = new Button();
            BackButton = new Button();
            StockGridView = new DataGridView();
            goodsIdColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockQuantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockBinding = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StockGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stockBinding).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(StockGridView);
            splitContainer1.Size = new Size(802, 475);
            splitContainer1.SplitterDistance = 124;
            splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(AddStockButton, 0, 1);
            tableLayoutPanel1.Controls.Add(ReduceStockButton, 1, 1);
            tableLayoutPanel1.Controls.Add(ChangeStockButton, 2, 1);
            tableLayoutPanel1.Controls.Add(CreateStockButton, 0, 0);
            tableLayoutPanel1.Controls.Add(ClearStockButton, 1, 0);
            tableLayoutPanel1.Controls.Add(BackButton, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(802, 124);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AddStockButton
            // 
            AddStockButton.Dock = DockStyle.Fill;
            AddStockButton.Location = new Point(10, 72);
            AddStockButton.Margin = new Padding(10);
            AddStockButton.Name = "AddStockButton";
            AddStockButton.Size = new Size(180, 42);
            AddStockButton.TabIndex = 0;
            AddStockButton.Text = "进货";
            AddStockButton.UseVisualStyleBackColor = true;
            AddStockButton.Click += AddStockButton_Click;
            // 
            // ReduceStockButton
            // 
            ReduceStockButton.Dock = DockStyle.Fill;
            ReduceStockButton.Location = new Point(210, 72);
            ReduceStockButton.Margin = new Padding(10);
            ReduceStockButton.Name = "ReduceStockButton";
            ReduceStockButton.Size = new Size(180, 42);
            ReduceStockButton.TabIndex = 1;
            ReduceStockButton.Text = "出货";
            ReduceStockButton.UseVisualStyleBackColor = true;
            ReduceStockButton.Click += ReduceStockButton_Click;
            // 
            // ChangeStockButton
            // 
            ChangeStockButton.Dock = DockStyle.Fill;
            ChangeStockButton.Location = new Point(410, 72);
            ChangeStockButton.Margin = new Padding(10);
            ChangeStockButton.Name = "ChangeStockButton";
            ChangeStockButton.Size = new Size(180, 42);
            ChangeStockButton.TabIndex = 2;
            ChangeStockButton.Text = "修改信息";
            ChangeStockButton.UseVisualStyleBackColor = true;
            ChangeStockButton.Click += ChangeStockButton_Click;
            // 
            // CreateStockButton
            // 
            CreateStockButton.Dock = DockStyle.Fill;
            CreateStockButton.Location = new Point(10, 10);
            CreateStockButton.Margin = new Padding(10);
            CreateStockButton.Name = "CreateStockButton";
            CreateStockButton.Size = new Size(180, 42);
            CreateStockButton.TabIndex = 3;
            CreateStockButton.Text = "创建新货";
            CreateStockButton.UseVisualStyleBackColor = true;
            CreateStockButton.Click += CreateStockButton_Click;
            // 
            // ClearStockButton
            // 
            ClearStockButton.Dock = DockStyle.Fill;
            ClearStockButton.Location = new Point(210, 10);
            ClearStockButton.Margin = new Padding(10);
            ClearStockButton.Name = "ClearStockButton";
            ClearStockButton.Size = new Size(180, 42);
            ClearStockButton.TabIndex = 4;
            ClearStockButton.Text = "清除货物";
            ClearStockButton.UseVisualStyleBackColor = true;
            ClearStockButton.Click += ClearStockButton_Click;
            // 
            // BackButton
            // 
            BackButton.Dock = DockStyle.Fill;
            BackButton.Location = new Point(610, 72);
            BackButton.Margin = new Padding(10);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(182, 42);
            BackButton.TabIndex = 6;
            BackButton.Text = "保存并返回上级";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // StockGridView
            // 
            StockGridView.AllowUserToAddRows = false;
            StockGridView.AllowUserToDeleteRows = false;
            StockGridView.AutoGenerateColumns = false;
            StockGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StockGridView.Columns.AddRange(new DataGridViewColumn[] { goodsIdColumn, nameDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn, stockQuantityDataGridViewTextBoxColumn });
            StockGridView.DataSource = stockBinding;
            StockGridView.Dock = DockStyle.Fill;
            StockGridView.Location = new Point(0, 0);
            StockGridView.Name = "StockGridView";
            StockGridView.ReadOnly = true;
            StockGridView.RowHeadersWidth = 62;
            StockGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            StockGridView.Size = new Size(802, 347);
            StockGridView.TabIndex = 0;
            // 
            // goodsIdColumn
            // 
            goodsIdColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            goodsIdColumn.DataPropertyName = "GoodsId";
            goodsIdColumn.HeaderText = "货物编号";
            goodsIdColumn.MinimumWidth = 8;
            goodsIdColumn.Name = "goodsIdColumn";
            goodsIdColumn.ReadOnly = true;
            goodsIdColumn.Width = 118;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "货物名";
            nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            priceDataGridViewTextBoxColumn.HeaderText = "价格";
            priceDataGridViewTextBoxColumn.MinimumWidth = 8;
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockQuantityDataGridViewTextBoxColumn
            // 
            stockQuantityDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            stockQuantityDataGridViewTextBoxColumn.DataPropertyName = "StockQuantity";
            stockQuantityDataGridViewTextBoxColumn.HeaderText = "存量";
            stockQuantityDataGridViewTextBoxColumn.MinimumWidth = 8;
            stockQuantityDataGridViewTextBoxColumn.Name = "stockQuantityDataGridViewTextBoxColumn";
            stockQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockBinding
            // 
            stockBinding.DataSource = typeof(Goods);
            // 
            // StockMenu
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 475);
            Controls.Add(splitContainer1);
            Name = "StockMenu";
            Text = "StockMenu";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StockGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)stockBinding).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button AddStockButton;
        private Button ReduceStockButton;
        private Button ChangeStockButton;
        private Button CreateStockButton;
        private Button ClearStockButton;
        private Button BackButton;
        private DataGridView StockGridView;
        private BindingSource stockBinding;
        private DataGridViewTextBoxColumn goodsIdColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stockQuantityDataGridViewTextBoxColumn;
    }
}