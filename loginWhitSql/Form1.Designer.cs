namespace loginWhitSql
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStock = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnDpto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnStock.Image = global::loginWhitSql.Properties.Resources._79732_paste_stock_icon__1_;
            this.btnStock.Location = new System.Drawing.Point(249, 82);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(112, 97);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock";
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEmpleados.Image = global::loginWhitSql.Properties.Resources._285641_id_user_icon;
            this.btnEmpleados.Location = new System.Drawing.Point(439, 82);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(122, 97);
            this.btnEmpleados.TabIndex = 1;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnDpto
            // 
            this.btnDpto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDpto.Image = global::loginWhitSql.Properties.Resources._299100_screwdriver_wrench_icon;
            this.btnDpto.Location = new System.Drawing.Point(61, 82);
            this.btnDpto.Name = "btnDpto";
            this.btnDpto.Size = new System.Drawing.Size(112, 97);
            this.btnDpto.TabIndex = 0;
            this.btnDpto.Text = "Departamentos ";
            this.btnDpto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDpto.UseVisualStyleBackColor = false;
            this.btnDpto.Click += new System.EventHandler(this.btnDpto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 57);
            this.label1.TabIndex = 3;
            this.label1.Text = "BIENVENDIDO";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::loginWhitSql.Properties.Resources._299045_sign_error_icon__1___1_;
            this.btnSalir.Location = new System.Drawing.Point(525, 320);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 34);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::loginWhitSql.Properties.Resources.fondoForms;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(612, 366);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnDpto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDpto;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
    }
}

