using Common;

namespace Telephone_UI
{
    partial class Telephone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Telephone));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelBell = new System.Windows.Forms.Label();
            this.labelBellValue = new System.Windows.Forms.Label();
            this.labelLineValue = new System.Windows.Forms.Label();
            this.labelLine = new System.Windows.Forms.Label();
            this.bttn_Receiver = new System.Windows.Forms.Button();
            this.bttn_Call = new System.Windows.Forms.Button();
            this.label_CurViewState = new System.Windows.Forms.Label();
            this.label_CurViewStateValue = new System.Windows.Forms.Label();
            this.bttn_ReceiverLift = new System.Windows.Forms.Button();
            this.labelReceiverValue = new System.Windows.Forms.Label();
            this.labelReceiver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(67, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelBell
            // 
            this.labelBell.AutoSize = true;
            this.labelBell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBell.Location = new System.Drawing.Point(284, 29);
            this.labelBell.Name = "labelBell";
            this.labelBell.Size = new System.Drawing.Size(39, 20);
            this.labelBell.TabIndex = 1;
            this.labelBell.Text = "Bell";
            // 
            // labelBellValue
            // 
            this.labelBellValue.AutoSize = true;
            this.labelBellValue.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.labelBellValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBellValue.Location = new System.Drawing.Point(329, 29);
            this.labelBellValue.Name = "labelBellValue";
            this.labelBellValue.Size = new System.Drawing.Size(55, 20);
            this.labelBellValue.TabIndex = 2;
            this.labelBellValue.Text = "Silent";
            // 
            // labelLineValue
            // 
            this.labelLineValue.AutoSize = true;
            this.labelLineValue.BackColor = System.Drawing.Color.Tomato;
            this.labelLineValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLineValue.Location = new System.Drawing.Point(329, 93);
            this.labelLineValue.Name = "labelLineValue";
            this.labelLineValue.Size = new System.Drawing.Size(34, 20);
            this.labelLineValue.TabIndex = 4;
            this.labelLineValue.Text = "Off";
            // 
            // labelLine
            // 
            this.labelLine.AutoSize = true;
            this.labelLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLine.Location = new System.Drawing.Point(284, 93);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(43, 20);
            this.labelLine.TabIndex = 3;
            this.labelLine.Text = "Line";
            // 
            // bttn_Receiver
            // 
            this.bttn_Receiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_Receiver.Location = new System.Drawing.Point(46, 214);
            this.bttn_Receiver.Name = "bttn_Receiver";
            this.bttn_Receiver.Size = new System.Drawing.Size(111, 50);
            this.bttn_Receiver.TabIndex = 5;
            this.bttn_Receiver.Text = "Receiver\r Down";
            this.bttn_Receiver.UseVisualStyleBackColor = true;
            this.bttn_Receiver.Click += new System.EventHandler(this.bttn_ReceiverDown_Click);
            // 
            // bttn_Call
            // 
            this.bttn_Call.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_Call.Location = new System.Drawing.Point(330, 299);
            this.bttn_Call.Name = "bttn_Call";
            this.bttn_Call.Size = new System.Drawing.Size(108, 35);
            this.bttn_Call.TabIndex = 6;
            this.bttn_Call.Text = "Initiate Call";
            this.bttn_Call.UseVisualStyleBackColor = true;
            this.bttn_Call.Click += new System.EventHandler(this.bttn_Call_Click);
            // 
            // label_CurViewState
            // 
            this.label_CurViewState.AutoSize = true;
            this.label_CurViewState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurViewState.Location = new System.Drawing.Point(19, 319);
            this.label_CurViewState.Name = "label_CurViewState";
            this.label_CurViewState.Size = new System.Drawing.Size(138, 16);
            this.label_CurViewState.TabIndex = 7;
            this.label_CurViewState.Text = "Current view state: ";
            // 
            // label_CurViewStateValue
            // 
            this.label_CurViewStateValue.AutoSize = true;
            this.label_CurViewStateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurViewStateValue.Location = new System.Drawing.Point(163, 319);
            this.label_CurViewStateValue.Name = "label_CurViewStateValue";
            this.label_CurViewStateValue.Size = new System.Drawing.Size(45, 16);
            this.label_CurViewStateValue.TabIndex = 8;
            this.label_CurViewStateValue.Text = "None";
            // 
            // bttn_ReceiverLift
            // 
            this.bttn_ReceiverLift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_ReceiverLift.Location = new System.Drawing.Point(166, 214);
            this.bttn_ReceiverLift.Name = "bttn_ReceiverLift";
            this.bttn_ReceiverLift.Size = new System.Drawing.Size(111, 50);
            this.bttn_ReceiverLift.TabIndex = 9;
            this.bttn_ReceiverLift.Text = "Receiver\r\nLifted";
            this.bttn_ReceiverLift.UseVisualStyleBackColor = true;
            this.bttn_ReceiverLift.Click += new System.EventHandler(this.bttn_ReceiverLift_Click);
            // 
            // labelReceiverValue
            // 
            this.labelReceiverValue.AutoSize = true;
            this.labelReceiverValue.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.labelReceiverValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiverValue.Location = new System.Drawing.Point(369, 154);
            this.labelReceiverValue.Name = "labelReceiverValue";
            this.labelReceiverValue.Size = new System.Drawing.Size(54, 20);
            this.labelReceiverValue.TabIndex = 11;
            this.labelReceiverValue.Text = "Down";
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiver.Location = new System.Drawing.Point(284, 154);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(79, 20);
            this.labelReceiver.TabIndex = 10;
            this.labelReceiver.Text = "Receiver";
            // 
            // Telephone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 346);
            this.Controls.Add(this.labelReceiverValue);
            this.Controls.Add(this.labelReceiver);
            this.Controls.Add(this.bttn_ReceiverLift);
            this.Controls.Add(this.label_CurViewStateValue);
            this.Controls.Add(this.label_CurViewState);
            this.Controls.Add(this.bttn_Call);
            this.Controls.Add(this.bttn_Receiver);
            this.Controls.Add(this.labelLineValue);
            this.Controls.Add(this.labelLine);
            this.Controls.Add(this.labelBellValue);
            this.Controls.Add(this.labelBell);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Telephone";
            this.Text = "Telephone UI";
            this.Load += new System.EventHandler(this.Telephone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelBell;
        private System.Windows.Forms.Label labelBellValue;
        private System.Windows.Forms.Label labelLineValue;
        private System.Windows.Forms.Label labelLine;
        private System.Windows.Forms.Button bttn_Receiver;
        private System.Windows.Forms.Button bttn_Call;
        private System.Windows.Forms.Label label_CurViewState;
        private System.Windows.Forms.Label label_CurViewStateValue;
        private System.Windows.Forms.Button bttn_ReceiverLift;
        private System.Windows.Forms.Label labelReceiverValue;
        private System.Windows.Forms.Label labelReceiver;
    }
}

