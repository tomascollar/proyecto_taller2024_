namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    partial class Reporte_ventas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label3 = new System.Windows.Forms.Label();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCategorias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(303, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reportes Graficos";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chartVentas
            // 
            this.chartVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chartVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartVentas.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Shingle;
            this.chartVentas.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea5.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartVentas.Legends.Add(legend5);
            this.chartVentas.Location = new System.Drawing.Point(66, 34);
            this.chartVentas.Name = "chartVentas";
            this.chartVentas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Ventas";
            this.chartVentas.Series.Add(series5);
            this.chartVentas.Size = new System.Drawing.Size(343, 168);
            this.chartVentas.TabIndex = 5;
            this.chartVentas.Text = "Ventas por mes";
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(448, 34);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(304, 168);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "Productos mas vendidos";
            // 
            // chartBarras
            // 
            chartArea7.Name = "ChartArea1";
            this.chartBarras.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartBarras.Legends.Add(legend7);
            this.chartBarras.Location = new System.Drawing.Point(66, 208);
            this.chartBarras.Name = "chartBarras";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartBarras.Series.Add(series7);
            this.chartBarras.Size = new System.Drawing.Size(343, 184);
            this.chartBarras.TabIndex = 7;
            this.chartBarras.Text = "chart2";
            // 
            // chartCategorias
            // 
            chartArea8.Name = "ChartArea1";
            this.chartCategorias.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartCategorias.Legends.Add(legend8);
            this.chartCategorias.Location = new System.Drawing.Point(448, 208);
            this.chartCategorias.Name = "chartCategorias";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartCategorias.Series.Add(series8);
            this.chartCategorias.Size = new System.Drawing.Size(304, 184);
            this.chartCategorias.TabIndex = 8;
            this.chartCategorias.Text = "chart3";
            // 
            // Reporte_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 417);
            this.Controls.Add(this.chartCategorias);
            this.Controls.Add(this.chartBarras);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.label3);
            this.Name = "Reporte_ventas";
            this.Text = "Reporte_ventas";
            this.Load += new System.EventHandler(this.Reporte_ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarras;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategorias;
    }
}