
namespace EditordeGrafos
{
    partial class Floyd
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
            this.comboInicio = new System.Windows.Forms.ComboBox();
            this.comboFinal = new System.Windows.Forms.ComboBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelNodIni = new System.Windows.Forms.Label();
            this.labelNodDest = new System.Windows.Forms.Label();
            this.buttonCalcular = new System.Windows.Forms.Button();
            this.labelCamino = new System.Windows.Forms.Label();
            this.labelPeso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboInicio
            // 
            this.comboInicio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboInicio.FormattingEnabled = true;
            this.comboInicio.Location = new System.Drawing.Point(171, 62);
            this.comboInicio.Name = "comboInicio";
            this.comboInicio.Size = new System.Drawing.Size(121, 20);
            this.comboInicio.TabIndex = 0;
            this.comboInicio.SelectedIndexChanged += new System.EventHandler(this.comboInicio_SelectedIndexChanged);
            // 
            // comboFinal
            // 
            this.comboFinal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFinal.FormattingEnabled = true;
            this.comboFinal.Location = new System.Drawing.Point(329, 63);
            this.comboFinal.Name = "comboFinal";
            this.comboFinal.Size = new System.Drawing.Size(121, 20);
            this.comboFinal.TabIndex = 1;
            this.comboFinal.SelectedIndexChanged += new System.EventHandler(this.comboFinal_SelectedIndexChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(98, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(482, 24);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Indique el nodo de partida y el nodo de destino";
            // 
            // labelNodIni
            // 
            this.labelNodIni.AutoSize = true;
            this.labelNodIni.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNodIni.Location = new System.Drawing.Point(189, 44);
            this.labelNodIni.Name = "labelNodIni";
            this.labelNodIni.Size = new System.Drawing.Size(90, 16);
            this.labelNodIni.TabIndex = 3;
            this.labelNodIni.Text = "Nodo de inicio";
            // 
            // labelNodDest
            // 
            this.labelNodDest.AutoSize = true;
            this.labelNodDest.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNodDest.Location = new System.Drawing.Point(348, 44);
            this.labelNodDest.Name = "labelNodDest";
            this.labelNodDest.Size = new System.Drawing.Size(102, 16);
            this.labelNodDest.TabIndex = 4;
            this.labelNodDest.Text = "Nodo de destino";
            // 
            // buttonCalcular
            // 
            this.buttonCalcular.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonCalcular.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcular.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCalcular.Location = new System.Drawing.Point(456, 36);
            this.buttonCalcular.Name = "buttonCalcular";
            this.buttonCalcular.Size = new System.Drawing.Size(165, 56);
            this.buttonCalcular.TabIndex = 5;
            this.buttonCalcular.Text = "Calcular Camino Mas Corto";
            this.buttonCalcular.UseVisualStyleBackColor = false;
            this.buttonCalcular.Click += new System.EventHandler(this.buttonCalcular_Click);
            // 
            // labelCamino
            // 
            this.labelCamino.AutoSize = true;
            this.labelCamino.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCamino.Location = new System.Drawing.Point(111, 457);
            this.labelCamino.Name = "labelCamino";
            this.labelCamino.Size = new System.Drawing.Size(0, 19);
            this.labelCamino.TabIndex = 6;
            // 
            // labelPeso
            // 
            this.labelPeso.AutoSize = true;
            this.labelPeso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeso.Location = new System.Drawing.Point(111, 63);
            this.labelPeso.Name = "labelPeso";
            this.labelPeso.Size = new System.Drawing.Size(54, 16);
            this.labelPeso.TabIndex = 7;
            this.labelPeso.Text = "Peso = ";
            this.labelPeso.Visible = false;
            // 
            // Floyd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(668, 530);
            this.Controls.Add(this.labelPeso);
            this.Controls.Add(this.labelCamino);
            this.Controls.Add(this.buttonCalcular);
            this.Controls.Add(this.labelNodDest);
            this.Controls.Add(this.labelNodIni);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.comboFinal);
            this.Controls.Add(this.comboInicio);
            this.Name = "Floyd";
            this.Text = "Floyd";
            this.Load += new System.EventHandler(this.Floyd_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Floyd_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboInicio;
        private System.Windows.Forms.ComboBox comboFinal;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelNodIni;
        private System.Windows.Forms.Label labelNodDest;
        private System.Windows.Forms.Button buttonCalcular;
        private System.Windows.Forms.Label labelCamino;
        private System.Windows.Forms.Label labelPeso;
    }
}