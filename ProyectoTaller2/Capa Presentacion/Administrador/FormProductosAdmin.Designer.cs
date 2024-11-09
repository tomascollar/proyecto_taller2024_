namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    partial class FormProductosAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.btnAgregarProd = new FontAwesome.Sharp.IconButton();
            this.btnEditarProd = new FontAwesome.Sharp.IconButton();
            this.btnEliminarProd = new FontAwesome.Sharp.IconButton();
            this.txtPrecioProd = new System.Windows.Forms.TextBox();
            this.txtNombreProd = new System.Windows.Forms.TextBox();
            this.txtStockProd = new System.Windows.Forms.TextBox();
            this.txtDescripProd = new System.Windows.Forms.TextBox();
            this.comboCategoriaProd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCateg = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBuscarProd = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarFiltro = new FontAwesome.Sharp.IconButton();
            this.btnReactivar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProductos.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridProductos.EnableHeadersVisualStyles = false;
            this.dataGridProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridProductos.Location = new System.Drawing.Point(12, 226);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.ReadOnly = true;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridProductos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridProductos.RowTemplate.Height = 28;
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(753, 218);
            this.dataGridProductos.TabIndex = 1;
            this.dataGridProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProductos_CellClick);
            this.dataGridProductos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridProductos_DataBindingComplete);
            this.dataGridProductos.SelectionChanged += new System.EventHandler(this.dataGridProductos_SelectionChanged);
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProd.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProd.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarProd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgregarProd.IconColor = System.Drawing.Color.Green;
            this.btnAgregarProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarProd.IconSize = 30;
            this.btnAgregarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarProd.Location = new System.Drawing.Point(644, 21);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(105, 39);
            this.btnAgregarProd.TabIndex = 2;
            this.btnAgregarProd.Text = "Agregar";
            this.btnAgregarProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarProd.UseVisualStyleBackColor = false;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // btnEditarProd
            // 
            this.btnEditarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEditarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarProd.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProd.ForeColor = System.Drawing.Color.Black;
            this.btnEditarProd.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnEditarProd.IconColor = System.Drawing.Color.Navy;
            this.btnEditarProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditarProd.IconSize = 30;
            this.btnEditarProd.Location = new System.Drawing.Point(644, 77);
            this.btnEditarProd.Name = "btnEditarProd";
            this.btnEditarProd.Size = new System.Drawing.Size(105, 38);
            this.btnEditarProd.TabIndex = 3;
            this.btnEditarProd.Text = "Editar";
            this.btnEditarProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarProd.UseVisualStyleBackColor = false;
            this.btnEditarProd.Click += new System.EventHandler(this.btnEditarProd_Click);
            // 
            // btnEliminarProd
            // 
            this.btnEliminarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarProd.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProd.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnEliminarProd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarProd.IconSize = 30;
            this.btnEliminarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarProd.Location = new System.Drawing.Point(644, 133);
            this.btnEliminarProd.Name = "btnEliminarProd";
            this.btnEliminarProd.Size = new System.Drawing.Size(105, 37);
            this.btnEliminarProd.TabIndex = 4;
            this.btnEliminarProd.Text = "Eliminar";
            this.btnEliminarProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarProd.UseVisualStyleBackColor = false;
            this.btnEliminarProd.Click += new System.EventHandler(this.btnEliminarProd_Click);
            // 
            // txtPrecioProd
            // 
            this.txtPrecioProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioProd.Location = new System.Drawing.Point(435, 38);
            this.txtPrecioProd.Name = "txtPrecioProd";
            this.txtPrecioProd.Size = new System.Drawing.Size(147, 22);
            this.txtPrecioProd.TabIndex = 5;
            this.txtPrecioProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioProd_KeyPress);
            // 
            // txtNombreProd
            // 
            this.txtNombreProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProd.Location = new System.Drawing.Point(161, 38);
            this.txtNombreProd.Name = "txtNombreProd";
            this.txtNombreProd.Size = new System.Drawing.Size(141, 22);
            this.txtNombreProd.TabIndex = 6;
            // 
            // txtStockProd
            // 
            this.txtStockProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockProd.Location = new System.Drawing.Point(161, 126);
            this.txtStockProd.Name = "txtStockProd";
            this.txtStockProd.Size = new System.Drawing.Size(141, 22);
            this.txtStockProd.TabIndex = 8;
            this.txtStockProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockProd_KeyPress);
            // 
            // txtDescripProd
            // 
            this.txtDescripProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripProd.Location = new System.Drawing.Point(435, 81);
            this.txtDescripProd.Name = "txtDescripProd";
            this.txtDescripProd.Size = new System.Drawing.Size(147, 22);
            this.txtDescripProd.TabIndex = 9;
            // 
            // comboCategoriaProd
            // 
            this.comboCategoriaProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategoriaProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategoriaProd.FormattingEnabled = true;
            this.comboCategoriaProd.Location = new System.Drawing.Point(435, 127);
            this.comboCategoriaProd.Name = "comboCategoriaProd";
            this.comboCategoriaProd.Size = new System.Drawing.Size(147, 24);
            this.comboCategoriaProd.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre";
            // 
            // lblCateg
            // 
            this.lblCateg.AutoSize = true;
            this.lblCateg.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCateg.ForeColor = System.Drawing.Color.White;
            this.lblCateg.Location = new System.Drawing.Point(334, 125);
            this.lblCateg.Name = "lblCateg";
            this.lblCateg.Size = new System.Drawing.Size(96, 25);
            this.lblCateg.TabIndex = 12;
            this.lblCateg.Text = "Categoria";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.White;
            this.lblDesc.Location = new System.Drawing.Point(320, 78);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(112, 25);
            this.lblDesc.TabIndex = 13;
            this.lblDesc.Text = "Descripcion";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecio.ForeColor = System.Drawing.Color.White;
            this.labelPrecio.Location = new System.Drawing.Point(364, 35);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(65, 25);
            this.labelPrecio.TabIndex = 14;
            this.labelPrecio.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(92, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(85, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Marca";
            // 
            // comboMarca
            // 
            this.comboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(161, 81);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(141, 24);
            this.comboMarca.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Buscar por:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 199);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(240, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 20);
            this.textBox1.TabIndex = 20;
            // 
            // btnBuscarProd
            // 
            this.btnBuscarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProd.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProd.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarProd.IconColor = System.Drawing.Color.White;
            this.btnBuscarProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProd.IconSize = 20;
            this.btnBuscarProd.Location = new System.Drawing.Point(409, 193);
            this.btnBuscarProd.Name = "btnBuscarProd";
            this.btnBuscarProd.Size = new System.Drawing.Size(35, 31);
            this.btnBuscarProd.TabIndex = 21;
            this.btnBuscarProd.UseVisualStyleBackColor = true;
            this.btnBuscarProd.Click += new System.EventHandler(this.btnBuscarProd_Click);
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltro.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarFiltro.IconColor = System.Drawing.Color.White;
            this.btnLimpiarFiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarFiltro.IconSize = 20;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(450, 193);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(35, 31);
            this.btnLimpiarFiltro.TabIndex = 24;
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // btnReactivar
            // 
            this.btnReactivar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnReactivar.IconColor = System.Drawing.Color.Black;
            this.btnReactivar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReactivar.Location = new System.Drawing.Point(656, 176);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(75, 41);
            this.btnReactivar.TabIndex = 25;
            this.btnReactivar.Text = "Reactivar Producto";
            this.btnReactivar.UseVisualStyleBackColor = true;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);
            // 
            // FormProductosAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(777, 456);
            this.Controls.Add(this.btnReactivar);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.btnBuscarProd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblCateg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCategoriaProd);
            this.Controls.Add(this.txtDescripProd);
            this.Controls.Add(this.txtStockProd);
            this.Controls.Add(this.txtNombreProd);
            this.Controls.Add(this.txtPrecioProd);
            this.Controls.Add(this.btnEliminarProd);
            this.Controls.Add(this.btnEditarProd);
            this.Controls.Add(this.btnAgregarProd);
            this.Controls.Add(this.dataGridProductos);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormProductosAdmin";
            this.Text = "FormProductosAdmin";
            this.Load += new System.EventHandler(this.FormProductosAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProductos;
        private FontAwesome.Sharp.IconButton btnAgregarProd;
        private FontAwesome.Sharp.IconButton btnEditarProd;
        private FontAwesome.Sharp.IconButton btnEliminarProd;
        private System.Windows.Forms.TextBox txtPrecioProd;
        private System.Windows.Forms.TextBox txtNombreProd;
        private System.Windows.Forms.TextBox txtStockProd;
        private System.Windows.Forms.TextBox txtDescripProd;
        private System.Windows.Forms.ComboBox comboCategoriaProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCateg;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnBuscarProd;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltro;
        private FontAwesome.Sharp.IconButton btnReactivar;
    }
}