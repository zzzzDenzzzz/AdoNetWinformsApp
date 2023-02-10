namespace AdoNetWinformsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTab = new System.Windows.Forms.TabControl();
            this.goodsTab = new System.Windows.Forms.TabPage();
            this.gridGoods = new System.Windows.Forms.DataGridView();
            this.goodsTypeTab = new System.Windows.Forms.TabPage();
            this.btnAddGoodType = new System.Windows.Forms.Button();
            this.gridGoodsType = new System.Windows.Forms.DataGridView();
            this.btnDeleteGoodType = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.goodsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGoods)).BeginInit();
            this.goodsTypeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGoodsType)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Controls.Add(this.goodsTab);
            this.mainTab.Controls.Add(this.goodsTypeTab);
            this.mainTab.Location = new System.Drawing.Point(12, 12);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(1188, 598);
            this.mainTab.TabIndex = 0;
            this.mainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            // 
            // goodsTab
            // 
            this.goodsTab.Controls.Add(this.gridGoods);
            this.goodsTab.Location = new System.Drawing.Point(4, 24);
            this.goodsTab.Name = "goodsTab";
            this.goodsTab.Padding = new System.Windows.Forms.Padding(3);
            this.goodsTab.Size = new System.Drawing.Size(1180, 570);
            this.goodsTab.TabIndex = 0;
            this.goodsTab.Text = "Goods";
            this.goodsTab.UseVisualStyleBackColor = true;
            // 
            // gridGoods
            // 
            this.gridGoods.AllowUserToAddRows = false;
            this.gridGoods.AllowUserToResizeColumns = false;
            this.gridGoods.AllowUserToResizeRows = false;
            this.gridGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGoods.Location = new System.Drawing.Point(6, 6);
            this.gridGoods.Name = "gridGoods";
            this.gridGoods.RowHeadersVisible = false;
            this.gridGoods.RowTemplate.Height = 25;
            this.gridGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGoods.Size = new System.Drawing.Size(925, 558);
            this.gridGoods.TabIndex = 0;
            // 
            // goodsTypeTab
            // 
            this.goodsTypeTab.Controls.Add(this.btnDeleteGoodType);
            this.goodsTypeTab.Controls.Add(this.btnAddGoodType);
            this.goodsTypeTab.Controls.Add(this.gridGoodsType);
            this.goodsTypeTab.Location = new System.Drawing.Point(4, 24);
            this.goodsTypeTab.Name = "goodsTypeTab";
            this.goodsTypeTab.Padding = new System.Windows.Forms.Padding(3);
            this.goodsTypeTab.Size = new System.Drawing.Size(1180, 570);
            this.goodsTypeTab.TabIndex = 1;
            this.goodsTypeTab.Text = "GoodsType";
            this.goodsTypeTab.UseVisualStyleBackColor = true;
            // 
            // btnAddGoodType
            // 
            this.btnAddGoodType.Location = new System.Drawing.Point(937, 6);
            this.btnAddGoodType.Name = "btnAddGoodType";
            this.btnAddGoodType.Size = new System.Drawing.Size(237, 23);
            this.btnAddGoodType.TabIndex = 2;
            this.btnAddGoodType.Text = "Добавить тип товара";
            this.btnAddGoodType.UseVisualStyleBackColor = true;
            this.btnAddGoodType.Click += new System.EventHandler(this.BtnAddGoodType_Click);
            // 
            // gridGoodsType
            // 
            this.gridGoodsType.AllowUserToAddRows = false;
            this.gridGoodsType.AllowUserToResizeColumns = false;
            this.gridGoodsType.AllowUserToResizeRows = false;
            this.gridGoodsType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridGoodsType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGoodsType.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridGoodsType.Location = new System.Drawing.Point(6, 6);
            this.gridGoodsType.Name = "gridGoodsType";
            this.gridGoodsType.RowHeadersVisible = false;
            this.gridGoodsType.RowTemplate.Height = 25;
            this.gridGoodsType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGoodsType.Size = new System.Drawing.Size(925, 558);
            this.gridGoodsType.TabIndex = 1;
            // 
            // btnDeleteGoodType
            // 
            this.btnDeleteGoodType.Location = new System.Drawing.Point(937, 35);
            this.btnDeleteGoodType.Name = "btnDeleteGoodType";
            this.btnDeleteGoodType.Size = new System.Drawing.Size(237, 23);
            this.btnDeleteGoodType.TabIndex = 3;
            this.btnDeleteGoodType.Text = "Удалить тип товара";
            this.btnDeleteGoodType.UseVisualStyleBackColor = true;
            this.btnDeleteGoodType.Click += new System.EventHandler(this.btnDeleteGoodType_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 622);
            this.Controls.Add(this.mainTab);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainTab.ResumeLayout(false);
            this.goodsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGoods)).EndInit();
            this.goodsTypeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGoodsType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl mainTab;
        private TabPage goodsTab;
        private DataGridView gridGoods;
        private TabPage goodsTypeTab;
        private DataGridView gridGoodsType;
        private Button btnAddGoodType;
        private Button btnDeleteGoodType;
    }
}