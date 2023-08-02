using System;
using System.Windows.Forms;
using services;

namespace concursInot;

public partial class loginForm : Form
{
    private IServices service;
    public loginForm(IServices srv)
    {
        InitializeComponent();
        service = srv;
    }

    private void handleLoginButton(object sender, EventArgs e)
    {
        string email = textFieldEmail.Text;
        string parola = textFieldParola.Text;
        mainForm mainForm = new mainForm(email);
        bool ok = service.login(email, parola, mainForm);
        if (ok)
        {
            mainForm.setService(service);
            this.Hide();
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();
        }
        else
        {
            warningLabel.Text="Parola incorecta sau utilizator neinregistrat.";
        }
    }
}