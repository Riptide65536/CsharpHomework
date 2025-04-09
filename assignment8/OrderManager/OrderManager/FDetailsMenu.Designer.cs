namespace OrderManager
{
    partial class DetailsMenu
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
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            orderDetailsBindingSource = new BindingSource(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            CustomerComboBox = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            BackButton = new Button();
            addDetailButton = new Button();
            deleteDetailButton = new Button();
            GoodsName = new DataGridViewTextBoxColumn();
            GoodsPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            totalPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(935, 581);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { GoodsName, GoodsPrice, Quantity, totalPriceDataGridViewTextBoxColumn });
            dataGridView1.DataSource = orderDetailsBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 143);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(929, 435);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // orderDetailsBindingSource
            // 
            orderDetailsBindingSource.DataSource = typeof(OrderDetail);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.4545441F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.5454559F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(label4, 3, 0);
            tableLayoutPanel2.Controls.Add(dateTimePicker1, 4, 0);
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(CustomerComboBox, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(929, 74);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(448, 25);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 7;
            label4.Text = "创建日期";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Left;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Location = new Point(536, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(211, 30);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(53, 25);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 6;
            label3.Text = "用户名";
            // 
            // CustomerComboBox
            // 
            CustomerComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CustomerComboBox.FormattingEnabled = true;
            CustomerComboBox.Location = new Point(123, 21);
            CustomerComboBox.Name = "CustomerComboBox";
            CustomerComboBox.Size = new Size(307, 32);
            CustomerComboBox.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 8;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(BackButton, 6, 0);
            tableLayoutPanel3.Controls.Add(addDetailButton, 1, 0);
            tableLayoutPanel3.Controls.Add(deleteDetailButton, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 83);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(929, 54);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // BackButton
            // 
            BackButton.Dock = DockStyle.Fill;
            BackButton.Location = new Point(763, 3);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(142, 48);
            BackButton.TabIndex = 0;
            BackButton.Text = "保存并返回";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // addDetailButton
            // 
            addDetailButton.Dock = DockStyle.Fill;
            addDetailButton.Location = new Point(23, 3);
            addDetailButton.Name = "addDetailButton";
            addDetailButton.Size = new Size(142, 48);
            addDetailButton.TabIndex = 1;
            addDetailButton.Text = "添加项目";
            addDetailButton.UseVisualStyleBackColor = true;
            addDetailButton.Click += addDetailButton_Click;
            // 
            // deleteDetailButton
            // 
            deleteDetailButton.Dock = DockStyle.Fill;
            deleteDetailButton.Location = new Point(171, 3);
            deleteDetailButton.Name = "deleteDetailButton";
            deleteDetailButton.Size = new Size(142, 48);
            deleteDetailButton.TabIndex = 2;
            deleteDetailButton.Text = "删除项目";
            deleteDetailButton.UseVisualStyleBackColor = true;
            deleteDetailButton.Click += deleteDetailButton_Click;
            // 
            // GoodsName
            // 
            GoodsName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GoodsName.DataPropertyName = "GoodsName";
            GoodsName.HeaderText = "商品名";
            GoodsName.MinimumWidth = 8;
            GoodsName.Name = "GoodsName";
            GoodsName.ReadOnly = true;
            // 
            // GoodsPrice
            // 
            GoodsPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GoodsPrice.DataPropertyName = "GoodsPrice";
            GoodsPrice.FillWeight = 80F;
            GoodsPrice.HeaderText = "商品单价";
            GoodsPrice.MinimumWidth = 8;
            GoodsPrice.Name = "GoodsPrice";
            GoodsPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Quantity.DataPropertyName = "Quantity";
            Quantity.FillWeight = 30F;
            Quantity.HeaderText = "数量";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            totalPriceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn.FillWeight = 30F;
            totalPriceDataGridViewTextBoxColumn.HeaderText = "小记";
            totalPriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DetailsMenu
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 581);
            Controls.Add(tableLayoutPanel1);
            Name = "DetailsMenu";
            Text = "DetailsMenu";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BackButton;
        private Button addDetailButton;
        private Button deleteDetailButton;
        private BindingSource orderDetailsBindingSource;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox CustomerComboBox;
        private DataGridViewTextBoxColumn GoodsName;
        private DataGridViewTextBoxColumn GoodsPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
    }
}