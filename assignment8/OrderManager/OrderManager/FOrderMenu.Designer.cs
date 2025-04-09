namespace OrderManager
{
    partial class OrderMenu
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
            AddOrderButton = new Button();
            DeleteOrderButton = new Button();
            EditOrderButton = new Button();
            label1 = new Label();
            searchButton = new Button();
            label2 = new Label();
            sortSelect1 = new ComboBox();
            sortSelect2 = new ComboBox();
            filterInput = new TextBox();
            filterSelect = new ComboBox();
            BackButton = new Button();
            dataGridViewOrders = new DataGridView();
            orderBinding = new BindingSource(components);
            OrderId = new DataGridViewTextBoxColumn();
            customerName = new DataGridViewTextBoxColumn();
            createTime = new DataGridViewTextBoxColumn();
            TotalPriceColumn = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBinding).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857132F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857132F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(AddOrderButton, 2, 1);
            tableLayoutPanel1.Controls.Add(DeleteOrderButton, 3, 1);
            tableLayoutPanel1.Controls.Add(EditOrderButton, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(searchButton, 7, 0);
            tableLayoutPanel1.Controls.Add(label2, 4, 0);
            tableLayoutPanel1.Controls.Add(sortSelect1, 5, 0);
            tableLayoutPanel1.Controls.Add(sortSelect2, 6, 0);
            tableLayoutPanel1.Controls.Add(filterInput, 3, 0);
            tableLayoutPanel1.Controls.Add(filterSelect, 2, 0);
            tableLayoutPanel1.Controls.Add(BackButton, 7, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1052, 115);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AddOrderButton
            // 
            AddOrderButton.Dock = DockStyle.Fill;
            AddOrderButton.Location = new Point(174, 67);
            AddOrderButton.Margin = new Padding(10);
            AddOrderButton.Name = "AddOrderButton";
            AddOrderButton.Size = new Size(124, 38);
            AddOrderButton.TabIndex = 3;
            AddOrderButton.Text = "添加订单";
            AddOrderButton.UseVisualStyleBackColor = true;
            AddOrderButton.Click += AddOrderButton_Click;
            // 
            // DeleteOrderButton
            // 
            DeleteOrderButton.Dock = DockStyle.Fill;
            DeleteOrderButton.Location = new Point(318, 67);
            DeleteOrderButton.Margin = new Padding(10);
            DeleteOrderButton.Name = "DeleteOrderButton";
            DeleteOrderButton.Size = new Size(124, 38);
            DeleteOrderButton.TabIndex = 4;
            DeleteOrderButton.Text = "删除订单";
            DeleteOrderButton.UseVisualStyleBackColor = true;
            DeleteOrderButton.Click += DeleteOrderButton_Click;
            // 
            // EditOrderButton
            // 
            EditOrderButton.Dock = DockStyle.Fill;
            EditOrderButton.Location = new Point(30, 67);
            EditOrderButton.Margin = new Padding(10);
            EditOrderButton.Name = "EditOrderButton";
            EditOrderButton.Size = new Size(124, 38);
            EditOrderButton.TabIndex = 5;
            EditOrderButton.Text = "编辑订单";
            EditOrderButton.UseVisualStyleBackColor = true;
            EditOrderButton.Click += EditOrderButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(79, 16);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 7;
            label1.Text = "筛选条件";
            // 
            // searchButton
            // 
            searchButton.Dock = DockStyle.Fill;
            searchButton.Location = new Point(894, 10);
            searchButton.Margin = new Padding(10);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(124, 37);
            searchButton.TabIndex = 6;
            searchButton.Text = "查询";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(511, 16);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 8;
            label2.Text = "排序方式";
            // 
            // sortSelect1
            // 
            sortSelect1.Anchor = AnchorStyles.Left;
            sortSelect1.DropDownStyle = ComboBoxStyle.DropDownList;
            sortSelect1.FormattingEnabled = true;
            sortSelect1.Items.AddRange(new object[] { "订单编号", "用户名", "用户编号", "时间", "总金额" });
            sortSelect1.Location = new Point(599, 12);
            sortSelect1.Name = "sortSelect1";
            sortSelect1.Size = new Size(138, 32);
            sortSelect1.TabIndex = 10;
            // 
            // sortSelect2
            // 
            sortSelect2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sortSelect2.DropDownStyle = ComboBoxStyle.DropDownList;
            sortSelect2.FormattingEnabled = true;
            sortSelect2.Items.AddRange(new object[] { "升序", "降序" });
            sortSelect2.Location = new Point(743, 12);
            sortSelect2.Name = "sortSelect2";
            sortSelect2.Size = new Size(138, 32);
            sortSelect2.TabIndex = 11;
            // 
            // filterInput
            // 
            filterInput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            filterInput.Location = new Point(311, 13);
            filterInput.Name = "filterInput";
            filterInput.Size = new Size(138, 30);
            filterInput.TabIndex = 9;
            // 
            // filterSelect
            // 
            filterSelect.Anchor = AnchorStyles.Left;
            filterSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            filterSelect.FormattingEnabled = true;
            filterSelect.Items.AddRange(new object[] { "（无）", "订单编号", "姓名", "货物名" });
            filterSelect.Location = new Point(167, 12);
            filterSelect.Name = "filterSelect";
            filterSelect.Size = new Size(138, 32);
            filterSelect.TabIndex = 12;
            filterSelect.SelectedIndexChanged += filterSelect_SelectedIndexChanged;
            // 
            // BackButton
            // 
            BackButton.Dock = DockStyle.Fill;
            BackButton.Location = new Point(894, 67);
            BackButton.Margin = new Padding(10);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(124, 38);
            BackButton.TabIndex = 2;
            BackButton.Text = "返回上级";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] { OrderId, customerName, createTime, TotalPriceColumn });
            dataGridViewOrders.DataSource = orderBinding;
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(0, 115);
            dataGridViewOrders.Margin = new Padding(10);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersWidth = 62;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(1052, 449);
            dataGridViewOrders.TabIndex = 1;
            // 
            // orderBinding
            // 
            orderBinding.DataSource = typeof(Order);
            // 
            // OrderId
            // 
            OrderId.DataPropertyName = "OrderId";
            OrderId.HeaderText = "订单号";
            OrderId.MinimumWidth = 8;
            OrderId.Name = "OrderId";
            OrderId.ReadOnly = true;
            OrderId.Width = 150;
            // 
            // customerName
            // 
            customerName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            customerName.DataPropertyName = "CustomerName";
            customerName.HeaderText = "用户名";
            customerName.MinimumWidth = 8;
            customerName.Name = "customerName";
            customerName.ReadOnly = true;
            // 
            // createTime
            // 
            createTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            createTime.DataPropertyName = "CreateTime";
            createTime.HeaderText = "创建时间";
            createTime.MinimumWidth = 8;
            createTime.Name = "createTime";
            createTime.ReadOnly = true;
            // 
            // TotalPriceColumn
            // 
            TotalPriceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalPriceColumn.DataPropertyName = "TotalPrice";
            TotalPriceColumn.FillWeight = 30F;
            TotalPriceColumn.HeaderText = "总价";
            TotalPriceColumn.MinimumWidth = 8;
            TotalPriceColumn.Name = "TotalPriceColumn";
            TotalPriceColumn.ReadOnly = true;
            // 
            // OrderMenu
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 564);
            Controls.Add(dataGridViewOrders);
            Controls.Add(tableLayoutPanel1);
            Name = "OrderMenu";
            Text = "OrderMenu";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBinding).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridViewOrders;
        private Button BackButton;
        private BindingSource orderBinding;
        private Button AddOrderButton;
        private Button DeleteOrderButton;
        private Button EditOrderButton;
        private Button searchButton;
        private Label label1;
        private Label label2;
        private TextBox filterInput;
        private ComboBox sortSelect1;
        private ComboBox sortSelect2;
        private ComboBox filterSelect;
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn customerName;
        private DataGridViewTextBoxColumn createTime;
        private DataGridViewTextBoxColumn TotalPriceColumn;
    }
}