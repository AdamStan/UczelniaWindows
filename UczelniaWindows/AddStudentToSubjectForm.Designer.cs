﻿namespace UczelniaWindows
{
    partial class AddStudentToSubjectForm
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
            this.textBoxStudentId = new System.Windows.Forms.TextBox();
            this.textBoxSubjectId = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelStudentId = new System.Windows.Forms.Label();
            this.labelSubjectId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxStudentId
            // 
            this.textBoxStudentId.Location = new System.Drawing.Point(148, 56);
            this.textBoxStudentId.Name = "textBoxStudentId";
            this.textBoxStudentId.Size = new System.Drawing.Size(100, 20);
            this.textBoxStudentId.TabIndex = 0;
            // 
            // textBoxSubjectId
            // 
            this.textBoxSubjectId.Location = new System.Drawing.Point(148, 105);
            this.textBoxSubjectId.Name = "textBoxSubjectId";
            this.textBoxSubjectId.Size = new System.Drawing.Size(100, 20);
            this.textBoxSubjectId.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(43, 174);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(159, 174);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStudentId
            // 
            this.labelStudentId.AutoSize = true;
            this.labelStudentId.Location = new System.Drawing.Point(40, 59);
            this.labelStudentId.Name = "labelStudentId";
            this.labelStudentId.Size = new System.Drawing.Size(53, 13);
            this.labelStudentId.TabIndex = 4;
            this.labelStudentId.Text = "student id";
            // 
            // labelSubjectId
            // 
            this.labelSubjectId.AutoSize = true;
            this.labelSubjectId.Location = new System.Drawing.Point(40, 108);
            this.labelSubjectId.Name = "labelSubjectId";
            this.labelSubjectId.Size = new System.Drawing.Size(52, 13);
            this.labelSubjectId.TabIndex = 5;
            this.labelSubjectId.Text = "subject id";
            // 
            // AddStudentToSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 231);
            this.Controls.Add(this.labelSubjectId);
            this.Controls.Add(this.labelStudentId);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSubjectId);
            this.Controls.Add(this.textBoxStudentId);
            this.Name = "AddStudentToSubjectForm";
            this.Text = "AddStudentToSubjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStudentId;
        private System.Windows.Forms.TextBox textBoxSubjectId;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelStudentId;
        private System.Windows.Forms.Label labelSubjectId;
    }
}