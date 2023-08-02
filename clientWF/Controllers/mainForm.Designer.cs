using System.ComponentModel;

namespace concursInot;

partial class mainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.textFieldNume = new System.Windows.Forms.TextBox();
        this.textFieldVarsta = new System.Windows.Forms.TextBox();
        this.stilInscriere = new System.Windows.Forms.ComboBox();
        this.distantaInscriere = new System.Windows.Forms.ComboBox();
        this.stilCautare = new System.Windows.Forms.ComboBox();
        this.distantaCautare = new System.Windows.Forms.ComboBox();
        this.butonCautare = new System.Windows.Forms.Button();
        this.butonAnuleazaCautarea = new System.Windows.Forms.Button();
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
        this.butonInscriere = new System.Windows.Forms.Button();
        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        this.labelTitle = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        this.label12 = new System.Windows.Forms.Label();
        this.label13 = new System.Windows.Forms.Label();
        this.label14 = new System.Windows.Forms.Label();
        this.label15 = new System.Windows.Forms.Label();
        this.label16 = new System.Windows.Forms.Label();
        this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        this.label17 = new System.Windows.Forms.Label();
        this.label18 = new System.Windows.Forms.Label();
        this.label19 = new System.Windows.Forms.Label();
        this.label20 = new System.Windows.Forms.Label();
        this.label21 = new System.Windows.Forms.Label();
        this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        this.label22 = new System.Windows.Forms.Label();
        this.label23 = new System.Windows.Forms.Label();
        this.label24 = new System.Windows.Forms.Label();
        this.label25 = new System.Windows.Forms.Label();
        this.label26 = new System.Windows.Forms.Label();
        this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
        this.label32 = new System.Windows.Forms.Label();
        this.label33 = new System.Windows.Forms.Label();
        this.label34 = new System.Windows.Forms.Label();
        this.label35 = new System.Windows.Forms.Label();
        this.label36 = new System.Windows.Forms.Label();
        this.butonLogout = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.flowLayoutPanel1.SuspendLayout();
        this.flowLayoutPanel2.SuspendLayout();
        this.flowLayoutPanel3.SuspendLayout();
        this.flowLayoutPanel4.SuspendLayout();
        this.flowLayoutPanel5.SuspendLayout();
        this.flowLayoutPanel7.SuspendLayout();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(70, 32);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(264, 27);
        this.label1.TabIndex = 0;
        this.label1.Text = "Inscriere persoana";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label2
        // 
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new System.Drawing.Point(395, 32);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(635, 27);
        this.label2.TabIndex = 1;
        this.label2.Text = "Cautare participanti dupa o anumita proba (stil, distanta)";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label3.Location = new System.Drawing.Point(1, 569);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(1083, 27);
        this.label3.TabIndex = 2;
        this.label3.Text = "Statistici inscriere";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label4
        // 
        this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label4.Location = new System.Drawing.Point(28, 85);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(100, 23);
        this.label4.TabIndex = 3;
        this.label4.Text = "Nume";
        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label5
        // 
        this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label5.Location = new System.Drawing.Point(28, 129);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(100, 23);
        this.label5.TabIndex = 4;
        this.label5.Text = "Varsta";
        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label6
        // 
        this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label6.Location = new System.Drawing.Point(28, 175);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(100, 23);
        this.label6.TabIndex = 5;
        this.label6.Text = "Stilul";
        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label7
        // 
        this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label7.Location = new System.Drawing.Point(28, 224);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(100, 23);
        this.label7.TabIndex = 6;
        this.label7.Text = "Distanta";
        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textFieldNume
        // 
        this.textFieldNume.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.textFieldNume.Location = new System.Drawing.Point(134, 86);
        this.textFieldNume.Name = "textFieldNume";
        this.textFieldNume.Size = new System.Drawing.Size(200, 22);
        this.textFieldNume.TabIndex = 7;
        // 
        // textFieldVarsta
        // 
        this.textFieldVarsta.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.textFieldVarsta.Location = new System.Drawing.Point(134, 130);
        this.textFieldVarsta.Name = "textFieldVarsta";
        this.textFieldVarsta.Size = new System.Drawing.Size(200, 22);
        this.textFieldVarsta.TabIndex = 8;
        // 
        // stilInscriere
        // 
        this.stilInscriere.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.stilInscriere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.stilInscriere.FormattingEnabled = true;
        this.stilInscriere.Location = new System.Drawing.Point(134, 174);
        this.stilInscriere.Name = "stilInscriere";
        this.stilInscriere.Size = new System.Drawing.Size(200, 24);
        this.stilInscriere.TabIndex = 9;
        // 
        // distantaInscriere
        // 
        this.distantaInscriere.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.distantaInscriere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.distantaInscriere.FormattingEnabled = true;
        this.distantaInscriere.Location = new System.Drawing.Point(134, 223);
        this.distantaInscriere.Name = "distantaInscriere";
        this.distantaInscriere.Size = new System.Drawing.Size(200, 24);
        this.distantaInscriere.TabIndex = 10;
        // 
        // stilCautare
        // 
        this.stilCautare.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.stilCautare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.stilCautare.FormattingEnabled = true;
        this.stilCautare.Location = new System.Drawing.Point(421, 84);
        this.stilCautare.Name = "stilCautare";
        this.stilCautare.Size = new System.Drawing.Size(274, 24);
        this.stilCautare.TabIndex = 11;
        // 
        // distantaCautare
        // 
        this.distantaCautare.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.distantaCautare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.distantaCautare.FormattingEnabled = true;
        this.distantaCautare.Location = new System.Drawing.Point(756, 84);
        this.distantaCautare.Name = "distantaCautare";
        this.distantaCautare.Size = new System.Drawing.Size(274, 24);
        this.distantaCautare.TabIndex = 12;
        // 
        // butonCautare
        // 
        this.butonCautare.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.butonCautare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.butonCautare.Location = new System.Drawing.Point(421, 123);
        this.butonCautare.Name = "butonCautare";
        this.butonCautare.Size = new System.Drawing.Size(274, 37);
        this.butonCautare.TabIndex = 13;
        this.butonCautare.Text = "Cauta";
        this.butonCautare.UseVisualStyleBackColor = true;
        this.butonCautare.Click += new System.EventHandler(this.handleCautaParticipanti);
        // 
        // butonAnuleazaCautarea
        // 
        this.butonAnuleazaCautarea.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.butonAnuleazaCautarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.butonAnuleazaCautarea.Location = new System.Drawing.Point(756, 123);
        this.butonAnuleazaCautarea.Name = "butonAnuleazaCautarea";
        this.butonAnuleazaCautarea.Size = new System.Drawing.Size(274, 37);
        this.butonAnuleazaCautarea.TabIndex = 14;
        this.butonAnuleazaCautarea.Text = "Anuleaza cautarea";
        this.butonAnuleazaCautarea.UseVisualStyleBackColor = true;
        this.butonAnuleazaCautarea.Click += new System.EventHandler(this.handleAnuleazaCautarea);
        // 
        // dataGridView1
        // 
        this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Location = new System.Drawing.Point(421, 175);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.RowTemplate.Height = 24;
        this.dataGridView1.Size = new System.Drawing.Size(609, 369);
        this.dataGridView1.TabIndex = 15;
        // 
        // butonInscriere
        // 
        this.butonInscriere.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.butonInscriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.butonInscriere.Location = new System.Drawing.Point(28, 265);
        this.butonInscriere.Name = "butonInscriere";
        this.butonInscriere.Size = new System.Drawing.Size(311, 52);
        this.butonInscriere.TabIndex = 16;
        this.butonInscriere.Text = "Trimite inscrierea";
        this.butonInscriere.UseVisualStyleBackColor = true;
        this.butonInscriere.Click += new System.EventHandler(this.handleInscriereParticipant);
        
        // 
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.Controls.Add(this.labelTitle);
        this.flowLayoutPanel1.Controls.Add(this.label8);
        this.flowLayoutPanel1.Controls.Add(this.label9);
        this.flowLayoutPanel1.Controls.Add(this.label10);
        this.flowLayoutPanel1.Controls.Add(this.label11);
        this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new System.Drawing.Size(1083, 34);
        this.flowLayoutPanel1.TabIndex = 17;
        this.flowLayoutPanel1.WrapContents = false;
        // 
        // labelTitle
        // 
        this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.labelTitle.Location = new System.Drawing.Point(3, 0);
        this.labelTitle.Name = "labelTitle";
        this.labelTitle.Size = new System.Drawing.Size(204, 34);
        this.labelTitle.TabIndex = 18;
        this.labelTitle.Text = "Stilul/Distanta";
        this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label8
        // 
        this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label8.Location = new System.Drawing.Point(213, 0);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(204, 34);
        this.label8.TabIndex = 19;
        this.label8.Text = "50metri";
        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label9
        // 
        this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label9.Location = new System.Drawing.Point(423, 0);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(204, 34);
        this.label9.TabIndex = 20;
        this.label9.Text = "200metri";
        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label10
        // 
        this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label10.Location = new System.Drawing.Point(633, 0);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(204, 34);
        this.label10.TabIndex = 21;
        this.label10.Text = "800metri";
        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label11
        // 
        this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label11.Location = new System.Drawing.Point(843, 0);
        this.label11.Name = "label11";
        this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label11.Size = new System.Drawing.Size(204, 34);
        this.label11.TabIndex = 22;
        this.label11.Text = "1500metri";
        this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanel2
        // 
        this.flowLayoutPanel2.Controls.Add(this.label12);
        this.flowLayoutPanel2.Controls.Add(this.label13);
        this.flowLayoutPanel2.Controls.Add(this.label14);
        this.flowLayoutPanel2.Controls.Add(this.label15);
        this.flowLayoutPanel2.Controls.Add(this.label16);
        this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 43);
        this.flowLayoutPanel2.Name = "flowLayoutPanel2";
        this.flowLayoutPanel2.Size = new System.Drawing.Size(1083, 34);
        this.flowLayoutPanel2.TabIndex = 18;
        this.flowLayoutPanel2.WrapContents = false;
        // 
        // label12
        // 
        this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label12.Location = new System.Drawing.Point(3, 0);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(204, 34);
        this.label12.TabIndex = 18;
        this.label12.Text = "Liber";
        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label13
        // 
        this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label13.Location = new System.Drawing.Point(213, 0);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(204, 34);
        this.label13.TabIndex = 19;
        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label14
        // 
        this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label14.Location = new System.Drawing.Point(423, 0);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(204, 34);
        this.label14.TabIndex = 20;
        this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label15
        // 
        this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label15.Location = new System.Drawing.Point(633, 0);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(204, 34);
        this.label15.TabIndex = 21;
        this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label16
        // 
        this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label16.Location = new System.Drawing.Point(843, 0);
        this.label16.Name = "label16";
        this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label16.Size = new System.Drawing.Size(204, 34);
        this.label16.TabIndex = 22;
        this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanel3
        // 
        this.flowLayoutPanel3.Controls.Add(this.label17);
        this.flowLayoutPanel3.Controls.Add(this.label18);
        this.flowLayoutPanel3.Controls.Add(this.label19);
        this.flowLayoutPanel3.Controls.Add(this.label20);
        this.flowLayoutPanel3.Controls.Add(this.label21);
        this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 83);
        this.flowLayoutPanel3.Name = "flowLayoutPanel3";
        this.flowLayoutPanel3.Size = new System.Drawing.Size(1083, 34);
        this.flowLayoutPanel3.TabIndex = 19;
        this.flowLayoutPanel3.WrapContents = false;
        // 
        // label17
        // 
        this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label17.Location = new System.Drawing.Point(3, 0);
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.Size(204, 34);
        this.label17.TabIndex = 18;
        this.label17.Text = "Spate";
        this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label18
        // 
        this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label18.Location = new System.Drawing.Point(213, 0);
        this.label18.Name = "label18";
        this.label18.Size = new System.Drawing.Size(204, 34);
        this.label18.TabIndex = 19;
        this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label19
        // 
        this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label19.Location = new System.Drawing.Point(423, 0);
        this.label19.Name = "label19";
        this.label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label19.Size = new System.Drawing.Size(204, 34);
        this.label19.TabIndex = 20;
        this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label20
        // 
        this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label20.Location = new System.Drawing.Point(633, 0);
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.Size(204, 34);
        this.label20.TabIndex = 21;
        this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label21
        // 
        this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label21.Location = new System.Drawing.Point(843, 0);
        this.label21.Name = "label21";
        this.label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label21.Size = new System.Drawing.Size(204, 34);
        this.label21.TabIndex = 22;
        this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanel4
        // 
        this.flowLayoutPanel4.Controls.Add(this.label22);
        this.flowLayoutPanel4.Controls.Add(this.label23);
        this.flowLayoutPanel4.Controls.Add(this.label24);
        this.flowLayoutPanel4.Controls.Add(this.label25);
        this.flowLayoutPanel4.Controls.Add(this.label26);
        this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 123);
        this.flowLayoutPanel4.Name = "flowLayoutPanel4";
        this.flowLayoutPanel4.Size = new System.Drawing.Size(1083, 34);
        this.flowLayoutPanel4.TabIndex = 20;
        this.flowLayoutPanel4.WrapContents = false;
        // 
        // label22
        // 
        this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label22.Location = new System.Drawing.Point(3, 0);
        this.label22.Name = "label22";
        this.label22.Size = new System.Drawing.Size(204, 34);
        this.label22.TabIndex = 18;
        this.label22.Text = "Flutur";
        this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label23
        // 
        this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label23.Location = new System.Drawing.Point(213, 0);
        this.label23.Name = "label23";
        this.label23.Size = new System.Drawing.Size(204, 34);
        this.label23.TabIndex = 19;
        this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label24
        // 
        this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label24.Location = new System.Drawing.Point(423, 0);
        this.label24.Name = "label24";
        this.label24.Size = new System.Drawing.Size(204, 34);
        this.label24.TabIndex = 20;
        this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label25
        // 
        this.label25.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label25.Location = new System.Drawing.Point(633, 0);
        this.label25.Name = "label25";
        this.label25.Size = new System.Drawing.Size(204, 34);
        this.label25.TabIndex = 21;
        this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label26
        // 
        this.label26.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label26.Location = new System.Drawing.Point(843, 0);
        this.label26.Name = "label26";
        this.label26.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label26.Size = new System.Drawing.Size(204, 34);
        this.label26.TabIndex = 22;
        this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanel5
        // 
        this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel1);
        this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel2);
        this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel3);
        this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel4);
        this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel7);
        this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel5.Location = new System.Drawing.Point(12, 616);
        this.flowLayoutPanel5.Name = "flowLayoutPanel5";
        this.flowLayoutPanel5.Size = new System.Drawing.Size(1039, 204);
        this.flowLayoutPanel5.TabIndex = 21;
        // 
        // flowLayoutPanel7
        // 
        this.flowLayoutPanel7.Controls.Add(this.label32);
        this.flowLayoutPanel7.Controls.Add(this.label33);
        this.flowLayoutPanel7.Controls.Add(this.label34);
        this.flowLayoutPanel7.Controls.Add(this.label35);
        this.flowLayoutPanel7.Controls.Add(this.label36);
        this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 163);
        this.flowLayoutPanel7.Name = "flowLayoutPanel7";
        this.flowLayoutPanel7.Size = new System.Drawing.Size(1083, 34);
        this.flowLayoutPanel7.TabIndex = 23;
        this.flowLayoutPanel7.WrapContents = false;
        // 
        // label32
        // 
        this.label32.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label32.Location = new System.Drawing.Point(3, 0);
        this.label32.Name = "label32";
        this.label32.Size = new System.Drawing.Size(204, 34);
        this.label32.TabIndex = 18;
        this.label32.Text = "Mixt";
        this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label33
        // 
        this.label33.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label33.Location = new System.Drawing.Point(213, 0);
        this.label33.Name = "label33";
        this.label33.Size = new System.Drawing.Size(204, 34);
        this.label33.TabIndex = 19;
        this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label34
        // 
        this.label34.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label34.Location = new System.Drawing.Point(423, 0);
        this.label34.Name = "label34";
        this.label34.Size = new System.Drawing.Size(204, 34);
        this.label34.TabIndex = 20;
        this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label35
        // 
        this.label35.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label35.Location = new System.Drawing.Point(633, 0);
        this.label35.Name = "label35";
        this.label35.Size = new System.Drawing.Size(204, 34);
        this.label35.TabIndex = 21;
        this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label36
        // 
        this.label36.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label36.Location = new System.Drawing.Point(843, 0);
        this.label36.Name = "label36";
        this.label36.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label36.Size = new System.Drawing.Size(204, 34);
        this.label36.TabIndex = 22;
        this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // butonLogout
        // 
        this.butonLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.butonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.butonLogout.Location = new System.Drawing.Point(433, 842);
        this.butonLogout.Name = "butonLogout";
        this.butonLogout.Size = new System.Drawing.Size(204, 37);
        this.butonLogout.TabIndex = 23;
        this.butonLogout.Text = "Logout";
        this.butonLogout.UseVisualStyleBackColor = true;
        this.butonLogout.Click += new System.EventHandler(this.handleLogoutButton);
        // 
        // mainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1082, 903);
        this.Controls.Add(this.butonLogout);
        this.Controls.Add(this.flowLayoutPanel5);
        this.Controls.Add(this.butonInscriere);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.butonAnuleazaCautarea);
        this.Controls.Add(this.butonCautare);
        this.Controls.Add(this.distantaCautare);
        this.Controls.Add(this.stilCautare);
        this.Controls.Add(this.distantaInscriere);
        this.Controls.Add(this.stilInscriere);
        this.Controls.Add(this.textFieldVarsta);
        this.Controls.Add(this.textFieldNume);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "mainForm";
        this.Text = "mainForm";
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.flowLayoutPanel1.ResumeLayout(false);
        this.flowLayoutPanel2.ResumeLayout(false);
        this.flowLayoutPanel3.ResumeLayout(false);
        this.flowLayoutPanel4.ResumeLayout(false);
        this.flowLayoutPanel5.ResumeLayout(false);
        this.flowLayoutPanel7.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button butonLogout;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.Label label36;
    

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label26;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label21;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;

    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;

    private System.Windows.Forms.Label labelTitle;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.Button butonInscriere;

    private System.Windows.Forms.TextBox textFieldNume;
    private System.Windows.Forms.TextBox textFieldVarsta;
    private System.Windows.Forms.ComboBox stilInscriere;
    private System.Windows.Forms.ComboBox distantaInscriere;
    private System.Windows.Forms.ComboBox stilCautare;
    private System.Windows.Forms.ComboBox distantaCautare;
    private System.Windows.Forms.Button butonCautare;
    private System.Windows.Forms.Button butonAnuleazaCautarea;
    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}