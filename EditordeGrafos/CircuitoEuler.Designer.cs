
namespace EditordeGrafos
{
    partial class CircuitoEuleriano
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
            this.groupBoxEu = new System.Windows.Forms.GroupBox();
            this.labelCaE = new System.Windows.Forms.Label();
            this.labelCE = new System.Windows.Forms.Label();
            this.labelCam = new System.Windows.Forms.Label();
            this.labelCir = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.labelNone = new System.Windows.Forms.Label();
            this.groupBoxEu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEu
            // 
            this.groupBoxEu.Controls.Add(this.labelNone);
            this.groupBoxEu.Controls.Add(this.labelCaE);
            this.groupBoxEu.Controls.Add(this.labelCE);
            this.groupBoxEu.Controls.Add(this.labelCam);
            this.groupBoxEu.Controls.Add(this.labelCir);
            this.groupBoxEu.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEu.Name = "groupBoxEu";
            this.groupBoxEu.Size = new System.Drawing.Size(776, 72);
            this.groupBoxEu.TabIndex = 0;
            this.groupBoxEu.TabStop = false;
            this.groupBoxEu.Text = "Camino y circuito";
            this.groupBoxEu.Enter += new System.EventHandler(this.groupBoxEu_Enter);
            // 
            // labelCaE
            // 
            this.labelCaE.AutoSize = true;
            this.labelCaE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaE.Location = new System.Drawing.Point(190, 48);
            this.labelCaE.Name = "labelCaE";
            this.labelCaE.Size = new System.Drawing.Size(0, 15);
            this.labelCaE.TabIndex = 3;
            // 
            // labelCE
            // 
            this.labelCE.AutoSize = true;
            this.labelCE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCE.Location = new System.Drawing.Point(190, 20);
            this.labelCE.Name = "labelCE";
            this.labelCE.Size = new System.Drawing.Size(0, 15);
            this.labelCE.TabIndex = 2;
            // 
            // labelCam
            // 
            this.labelCam.AutoSize = true;
            this.labelCam.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCam.Location = new System.Drawing.Point(5, 45);
            this.labelCam.Name = "labelCam";
            this.labelCam.Size = new System.Drawing.Size(125, 18);
            this.labelCam.TabIndex = 1;
            this.labelCam.Text = "Camino de Euler";
            // 
            // labelCir
            // 
            this.labelCir.AutoSize = true;
            this.labelCir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCir.Location = new System.Drawing.Point(6, 16);
            this.labelCir.Name = "labelCir";
            this.labelCir.Size = new System.Drawing.Size(124, 18);
            this.labelCir.TabIndex = 0;
            this.labelCir.Text = "Circuito de Euler";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.Location = new System.Drawing.Point(179, 87);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(423, 15);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "El orden de la arista visitada es indicada con el numero que tiene sobre ella";
            this.labelText.Visible = false;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR.Location = new System.Drawing.Point(27, 104);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(74, 15);
            this.labelR.TabIndex = 2;
            this.labelR.Text = "Recorrido = ";
            this.labelR.Visible = false;
            // 
            // labelNone
            // 
            this.labelNone.AutoSize = true;
            this.labelNone.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNone.Location = new System.Drawing.Point(512, 30);
            this.labelNone.Name = "labelNone";
            this.labelNone.Size = new System.Drawing.Size(0, 15);
            this.labelNone.TabIndex = 3;
            // 
            // CircuitoEuleriano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 523);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.groupBoxEu);
            this.Name = "CircuitoEuleriano";
            this.Text = "CircuitoEuler";
            this.Load += new System.EventHandler(this.CircuitoEuleriano_Load);
            this.groupBoxEu.ResumeLayout(false);
            this.groupBoxEu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEu;
        private System.Windows.Forms.Label labelCam;
        private System.Windows.Forms.Label labelCir;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelCaE;
        private System.Windows.Forms.Label labelCE;
        private System.Windows.Forms.Label labelNone;
    }
}