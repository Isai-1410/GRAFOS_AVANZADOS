namespace EditordeGrafos
{
    partial class AtributosGrafo
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
            this.grpBoxAtriNodo = new System.Windows.Forms.GroupBox();
            this.lblNodos = new System.Windows.Forms.Label();
            this.grpBoxAtriArista = new System.Windows.Forms.GroupBox();
            this.lblAristas = new System.Windows.Forms.Label();
            this.grpBoxDegree = new System.Windows.Forms.GroupBox();
            this.GradoInterno = new System.Windows.Forms.Label();
            this.GradoExterno = new System.Windows.Forms.Label();
            this.grpBoxAtriNodo.SuspendLayout();
            this.grpBoxAtriArista.SuspendLayout();
            this.grpBoxDegree.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxAtriNodo
            // 
            this.grpBoxAtriNodo.Controls.Add(this.lblNodos);
            this.grpBoxAtriNodo.Location = new System.Drawing.Point(12, 12);
            this.grpBoxAtriNodo.Name = "grpBoxAtriNodo";
            this.grpBoxAtriNodo.Size = new System.Drawing.Size(237, 317);
            this.grpBoxAtriNodo.TabIndex = 1;
            this.grpBoxAtriNodo.TabStop = false;
            this.grpBoxAtriNodo.Text = "Nodos";
            // 
            // lblNodos
            // 
            this.lblNodos.Location = new System.Drawing.Point(6, 16);
            this.lblNodos.Name = "lblNodos";
            this.lblNodos.Size = new System.Drawing.Size(225, 298);
            this.lblNodos.TabIndex = 0;
            // 
            // grpBoxAtriArista
            // 
            this.grpBoxAtriArista.Controls.Add(this.lblAristas);
            this.grpBoxAtriArista.Location = new System.Drawing.Point(255, 12);
            this.grpBoxAtriArista.Name = "grpBoxAtriArista";
            this.grpBoxAtriArista.Size = new System.Drawing.Size(237, 317);
            this.grpBoxAtriArista.TabIndex = 2;
            this.grpBoxAtriArista.TabStop = false;
            this.grpBoxAtriArista.Text = "Aristas";
            // 
            // lblAristas
            // 
            this.lblAristas.Location = new System.Drawing.Point(6, 16);
            this.lblAristas.Name = "lblAristas";
            this.lblAristas.Size = new System.Drawing.Size(225, 298);
            this.lblAristas.TabIndex = 0;
            // 
            // grpBoxDegree
            // 
            this.grpBoxDegree.Controls.Add(this.GradoInterno);
            this.grpBoxDegree.Controls.Add(this.GradoExterno);
            this.grpBoxDegree.Location = new System.Drawing.Point(12, 335);
            this.grpBoxDegree.Name = "grpBoxDegree";
            this.grpBoxDegree.Size = new System.Drawing.Size(480, 185);
            this.grpBoxDegree.TabIndex = 3;
            this.grpBoxDegree.TabStop = false;
            this.grpBoxDegree.Text = "Grados";
            // 
            // GradoInterno
            // 
            this.GradoInterno.Location = new System.Drawing.Point(230, 16);
            this.GradoInterno.Name = "GradoInterno";
            this.GradoInterno.Size = new System.Drawing.Size(231, 166);
            this.GradoInterno.TabIndex = 3;
            // 
            // GradoExterno
            // 
            this.GradoExterno.Location = new System.Drawing.Point(6, 16);
            this.GradoExterno.Name = "GradoExterno";
            this.GradoExterno.Size = new System.Drawing.Size(218, 166);
            this.GradoExterno.TabIndex = 2;
            // 
            // AtributosGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 532);
            this.Controls.Add(this.grpBoxDegree);
            this.Controls.Add(this.grpBoxAtriArista);
            this.Controls.Add(this.grpBoxAtriNodo);
            this.Name = "AtributosGrafo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atributos";
            this.grpBoxAtriNodo.ResumeLayout(false);
            this.grpBoxAtriArista.ResumeLayout(false);
            this.grpBoxDegree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBoxAtriNodo;
        private System.Windows.Forms.GroupBox grpBoxAtriArista;
        private System.Windows.Forms.Label lblAristas;
        private System.Windows.Forms.Label lblNodos;
        private System.Windows.Forms.GroupBox grpBoxDegree;
        private System.Windows.Forms.Label GradoInterno;
        private System.Windows.Forms.Label GradoExterno;
    }
}