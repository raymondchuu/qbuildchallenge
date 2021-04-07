
namespace qbuild_coding_challenge
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.popTreeDataBtn = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.exitBtn = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.partPathLabel = new System.Windows.Forms.Label();
            this.currPartLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // popTreeDataBtn
            // 
            this.popTreeDataBtn.Location = new System.Drawing.Point(416, 151);
            this.popTreeDataBtn.Name = "popTreeDataBtn";
            this.popTreeDataBtn.Size = new System.Drawing.Size(142, 23);
            this.popTreeDataBtn.TabIndex = 0;
            this.popTreeDataBtn.Text = "Populate Data In Tree";
            this.popTreeDataBtn.UseVisualStyleBackColor = true;
            this.popTreeDataBtn.Click += new System.EventHandler(this.popTreeDataBtn_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(149, 77);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(233, 148);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(416, 194);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(142, 23);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Exit From Application";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(149, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(422, 33);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Testing Functionality for Tree and Datagrid";
            // 
            // partPathLabel
            // 
            this.partPathLabel.AutoSize = true;
            this.partPathLabel.ForeColor = System.Drawing.Color.Red;
            this.partPathLabel.Location = new System.Drawing.Point(416, 77);
            this.partPathLabel.Name = "partPathLabel";
            this.partPathLabel.Size = new System.Drawing.Size(99, 15);
            this.partPathLabel.TabIndex = 4;
            this.partPathLabel.Text = "Parent Child Part:";
            // 
            // currPartLabel
            // 
            this.currPartLabel.AutoSize = true;
            this.currPartLabel.ForeColor = System.Drawing.Color.Green;
            this.currPartLabel.Location = new System.Drawing.Point(416, 107);
            this.currPartLabel.Name = "currPartLabel";
            this.currPartLabel.Size = new System.Drawing.Size(74, 15);
            this.currPartLabel.TabIndex = 5;
            this.currPartLabel.Text = "Current Part:";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 267);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(639, 198);
            this.dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 510);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.currPartLabel);
            this.Controls.Add(this.partPathLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.popTreeDataBtn);
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Testing Functionality for Tree and Datagrid";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button popTreeDataBtn;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label partPathLabel;
        private System.Windows.Forms.Label currPartLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

