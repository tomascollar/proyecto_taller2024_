namespace ProyectoTaller2.Capa_Presentacion.SuperAdmin
{
    partial class Restaurar_Backup
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDialog = new System.Windows.Forms.Button();
            this.btnAbrir = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(160, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Archivo:";
            // 
            // btnDialog
            // 
            this.btnDialog.BackColor = System.Drawing.Color.White;
            this.btnDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDialog.Location = new System.Drawing.Point(476, 175);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(26, 23);
            this.btnDialog.TabIndex = 1;
            this.btnDialog.Text = "...";
            this.btnDialog.UseVisualStyleBackColor = false;
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.White;
            this.btnAbrir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAbrir.FlatAppearance.BorderSize = 2;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnAbrir.IconColor = System.Drawing.Color.Black;
            this.btnAbrir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAbrir.IconSize = 25;
            this.btnAbrir.Location = new System.Drawing.Point(338, 233);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(111, 42);
            this.btnAbrir.TabIndex = 2;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrir.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(310, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 26);
            this.textBox1.TabIndex = 3;
            // 
            // Restaurar_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.label1);
            this.Name = "Restaurar_Backup";
            this.Text = "Restaurar_Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDialog;
        private FontAwesome.Sharp.IconButton btnAbrir;
        private System.Windows.Forms.TextBox textBox1;
    }
}