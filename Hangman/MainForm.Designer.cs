namespace Hangman
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureStep = new System.Windows.Forms.PictureBox();
            this.labelWord = new System.Windows.Forms.Label();
            this.panelKeys = new System.Windows.Forms.Panel();
            this.textList = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStep)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureStep
            // 
            this.pictureStep.BackColor = System.Drawing.Color.White;
            this.pictureStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureStep.Image = global::Hangman.Properties.Resources.step0;
            this.pictureStep.Location = new System.Drawing.Point(3, 9);
            this.pictureStep.Name = "pictureStep";
            this.pictureStep.Size = new System.Drawing.Size(247, 240);
            this.pictureStep.TabIndex = 0;
            this.pictureStep.TabStop = false;
            // 
            // labelWord
            // 
            this.labelWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWord.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWord.Location = new System.Drawing.Point(256, 9);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(424, 74);
            this.labelWord.TabIndex = 1;
            this.labelWord.Text = "*****";
            this.labelWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWord.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelWord_MouseDoubleClick);
            // 
            // panelKeys
            // 
            this.panelKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKeys.Location = new System.Drawing.Point(256, 86);
            this.panelKeys.Name = "panelKeys";
            this.panelKeys.Size = new System.Drawing.Size(424, 163);
            this.panelKeys.TabIndex = 2;
            // 
            // textList
            // 
            this.textList.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textList.Location = new System.Drawing.Point(3, 9);
            this.textList.Multiline = true;
            this.textList.Name = "textList";
            this.textList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textList.Size = new System.Drawing.Size(247, 240);
            this.textList.TabIndex = 3;
            this.textList.Visible = false;
            // 
            // FormHangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 254);
            this.Controls.Add(this.textList);
            this.Controls.Add(this.panelKeys);
            this.Controls.Add(this.labelWord);
            this.Controls.Add(this.pictureStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "FormHangman";
            this.Text = "Игра Виселка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureStep;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.Panel panelKeys;
        private System.Windows.Forms.TextBox textList;
    }
}

