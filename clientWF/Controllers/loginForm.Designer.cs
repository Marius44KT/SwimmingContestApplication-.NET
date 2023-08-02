using System.ComponentModel;

namespace concursInot;

partial class loginForm
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
        this.emailLabel = new System.Windows.Forms.Label();
        this.parolaLabel = new System.Windows.Forms.Label();
        this.textFieldEmail = new System.Windows.Forms.TextBox();
        this.textFieldParola = new System.Windows.Forms.TextBox();
        this.loginButton = new System.Windows.Forms.Button();
        this.warningLabel = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // emailLabel
        // 
        this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.emailLabel.Location = new System.Drawing.Point(140, 69);
        this.emailLabel.Name = "emailLabel";
        this.emailLabel.Size = new System.Drawing.Size(61, 23);
        this.emailLabel.TabIndex = 0;
        this.emailLabel.Text = "email";
        this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // parolaLabel
        // 
        this.parolaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.parolaLabel.Location = new System.Drawing.Point(140, 118);
        this.parolaLabel.Name = "parolaLabel";
        this.parolaLabel.Size = new System.Drawing.Size(61, 23);
        this.parolaLabel.TabIndex = 1;
        this.parolaLabel.Text = "parola";
        this.parolaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textFieldEmail
        // 
        this.textFieldEmail.Location = new System.Drawing.Point(224, 70);
        this.textFieldEmail.Name = "textFieldEmail";
        this.textFieldEmail.Size = new System.Drawing.Size(215, 22);
        this.textFieldEmail.TabIndex = 2;
        // 
        // textFieldParola
        // 
        this.textFieldParola.Location = new System.Drawing.Point(224, 119);
        this.textFieldParola.Name = "textFieldParola";
        this.textFieldParola.Size = new System.Drawing.Size(215, 22);
        this.textFieldParola.TabIndex = 3;
        // 
        // loginButton
        // 
        this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.loginButton.Location = new System.Drawing.Point(140, 193);
        this.loginButton.Name = "loginButton";
        this.loginButton.Size = new System.Drawing.Size(299, 38);
        this.loginButton.TabIndex = 4;
        this.loginButton.Text = "Login";
        this.loginButton.UseVisualStyleBackColor = true;
        this.loginButton.Click += new System.EventHandler(this.handleLoginButton);
        // 
        // warningLabel
        // 
        this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.warningLabel.ForeColor = System.Drawing.Color.Red;
        this.warningLabel.Location = new System.Drawing.Point(-2, 158);
        this.warningLabel.Name = "warningLabel";
        this.warningLabel.Size = new System.Drawing.Size(622, 32);
        this.warningLabel.TabIndex = 5;
        this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // loginForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(620, 284);
        this.Controls.Add(this.warningLabel);
        this.Controls.Add(this.loginButton);
        this.Controls.Add(this.textFieldParola);
        this.Controls.Add(this.textFieldEmail);
        this.Controls.Add(this.parolaLabel);
        this.Controls.Add(this.emailLabel);
        this.Name = "loginForm";
        this.Text = "loginForm";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label warningLabel;

    private System.Windows.Forms.TextBox textFieldEmail;
    private System.Windows.Forms.TextBox textFieldParola;
    private System.Windows.Forms.Button loginButton;

    private System.Windows.Forms.Label emailLabel;
    private System.Windows.Forms.Label parolaLabel;

    #endregion
}