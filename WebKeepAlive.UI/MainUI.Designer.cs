namespace WebKeepAlive.UI;

partial class MainUI
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
            this.url_txt_box = new System.Windows.Forms.TextBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.data_grid = new System.Windows.Forms.DataGridView();
            this.btn_delete = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.state_lbl = new System.Windows.Forms.Label();
            this.refresh_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // url_txt_box
            // 
            this.url_txt_box.Location = new System.Drawing.Point(12, 411);
            this.url_txt_box.Name = "url_txt_box";
            this.url_txt_box.Size = new System.Drawing.Size(414, 27);
            this.url_txt_box.TabIndex = 0;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(448, 411);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(94, 29);
            this.add_btn.TabIndex = 1;
            this.add_btn.Text = "Add URL";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_ClickAsync);
            // 
            // data_grid
            // 
            this.data_grid.AllowUserToAddRows = false;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Location = new System.Drawing.Point(12, 12);
            this.data_grid.Name = "data_grid";
            this.data_grid.ReadOnly = true;
            this.data_grid.RowHeadersWidth = 51;
            this.data_grid.RowTemplate.Height = 29;
            this.data_grid.Size = new System.Drawing.Size(530, 393);
            this.data_grid.TabIndex = 2;
            this.data_grid.SelectionChanged += new System.EventHandler(this.data_grid_SelectionChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_delete.Location = new System.Drawing.Point(548, 411);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(94, 29);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_ClickAsync);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(604, 199);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(94, 29);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(725, 199);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(94, 29);
            this.stop_btn.TabIndex = 5;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(633, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Service State";
            // 
            // state_lbl
            // 
            this.state_lbl.AutoSize = true;
            this.state_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.state_lbl.ForeColor = System.Drawing.Color.ForestGreen;
            this.state_lbl.Location = new System.Drawing.Point(665, 119);
            this.state_lbl.Name = "state_lbl";
            this.state_lbl.Size = new System.Drawing.Size(92, 28);
            this.state_lbl.TabIndex = 7;
            this.state_lbl.Text = "running...";
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(477, 356);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(65, 29);
            this.refresh_btn.TabIndex = 8;
            this.refresh_btn.Text = "refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_ClickAsync);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 450);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.state_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.data_grid);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.url_txt_box);
            this.Name = "MainUI";
            this.Text = "MainUI";
            this.Load += new System.EventHandler(this.MainUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBox url_txt_box;
    private Button add_btn;
    private DataGridView data_grid;
    private Button btn_delete;
    private Button start_btn;
    private Button stop_btn;
    private Label label1;
    private Label state_lbl;
    private Button refresh_btn;
}