namespace MenuApplication
{
    partial class AddIngredientDialog
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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtpRecord = new System.Windows.Forms.DateTimePicker();
            this.nudProtein = new System.Windows.Forms.NumericUpDown();
            this.nudFat = new System.Windows.Forms.NumericUpDown();
            this.nudCarbohydrate = new System.Windows.Forms.NumericUpDown();
            this.nudMass = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTypeIngredient = new System.Windows.Forms.ComboBox();
            this.TypeIngredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudProtein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCarbohydrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeIngredientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(263, 237);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancle
            // 
            this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancle.Location = new System.Drawing.Point(115, 237);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 23);
            this.btCancle.TabIndex = 1;
            this.btCancle.Text = "Отмена";
            this.btCancle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя ингредиента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Упаковочная масса продукта в кг";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Упаковочная цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Дата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Белок в 100 г продукта";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Жир в 100 г продукта";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Углевод в 100 г продукта";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(218, 9);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(120, 20);
            this.tbName.TabIndex = 9;
            // 
            // dtpRecord
            // 
            this.dtpRecord.Location = new System.Drawing.Point(218, 89);
            this.dtpRecord.Name = "dtpRecord";
            this.dtpRecord.Size = new System.Drawing.Size(120, 20);
            this.dtpRecord.TabIndex = 12;
            this.dtpRecord.ValueChanged += new System.EventHandler(this.dtpRecord_ValueChanged);
            // 
            // nudProtein
            // 
            this.nudProtein.DecimalPlaces = 1;
            this.nudProtein.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudProtein.Location = new System.Drawing.Point(218, 153);
            this.nudProtein.Name = "nudProtein";
            this.nudProtein.Size = new System.Drawing.Size(66, 20);
            this.nudProtein.TabIndex = 13;
            // 
            // nudFat
            // 
            this.nudFat.DecimalPlaces = 1;
            this.nudFat.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudFat.Location = new System.Drawing.Point(218, 174);
            this.nudFat.Name = "nudFat";
            this.nudFat.Size = new System.Drawing.Size(66, 20);
            this.nudFat.TabIndex = 14;
            // 
            // nudCarbohydrate
            // 
            this.nudCarbohydrate.DecimalPlaces = 1;
            this.nudCarbohydrate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudCarbohydrate.Location = new System.Drawing.Point(218, 198);
            this.nudCarbohydrate.Name = "nudCarbohydrate";
            this.nudCarbohydrate.Size = new System.Drawing.Size(66, 20);
            this.nudCarbohydrate.TabIndex = 15;
            // 
            // nudMass
            // 
            this.nudMass.DecimalPlaces = 3;
            this.nudMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudMass.Location = new System.Drawing.Point(218, 32);
            this.nudMass.Name = "nudMass";
            this.nudMass.Size = new System.Drawing.Size(83, 20);
            this.nudMass.TabIndex = 16;
            this.nudMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(218, 59);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 20);
            this.nudPrice.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Тип ингредиента";
            // 
            // cbTypeIngredient
            // 
            this.cbTypeIngredient.DataSource = this.TypeIngredientsBindingSource;
            this.cbTypeIngredient.DisplayMember = "NameTypeIngredient";
            this.cbTypeIngredient.FormattingEnabled = true;
            this.cbTypeIngredient.Location = new System.Drawing.Point(218, 126);
            this.cbTypeIngredient.Name = "cbTypeIngredient";
            this.cbTypeIngredient.Size = new System.Drawing.Size(121, 21);
            this.cbTypeIngredient.TabIndex = 19;
            this.cbTypeIngredient.ValueMember = "NameTypeIngredient";
            // 
            // TypeIngredientsBindingSource
            // 
            this.TypeIngredientsBindingSource.DataSource = typeof(MenuApplication.ModelDB.TypeIngredient);
            // 
            // AddIngredientDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 273);
            this.Controls.Add(this.cbTypeIngredient);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudMass);
            this.Controls.Add(this.nudCarbohydrate);
            this.Controls.Add(this.nudFat);
            this.Controls.Add(this.nudProtein);
            this.Controls.Add(this.dtpRecord);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btOK);
            this.Name = "AddIngredientDialog";
            this.Text = "Добавление ингредиента";
            this.Load += new System.EventHandler(this.AddIngredientDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudProtein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCarbohydrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeIngredientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox tbName;
        internal System.Windows.Forms.DateTimePicker dtpRecord;
        internal System.Windows.Forms.NumericUpDown nudProtein;
        internal System.Windows.Forms.NumericUpDown nudFat;
        internal System.Windows.Forms.NumericUpDown nudCarbohydrate;
        internal System.Windows.Forms.NumericUpDown nudMass;
        internal System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTypeIngredient;
        public System.Windows.Forms.BindingSource TypeIngredientsBindingSource;
    }
}