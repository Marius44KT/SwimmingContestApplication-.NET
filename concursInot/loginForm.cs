using System;
using System.Windows.Forms;

namespace concursInot;

public partial class loginForm : Form
{
    private Service service;
    public loginForm(Service srv)
    {
        InitializeComponent();
        service = srv;
    }

    private void handleLoginButton(object sender, EventArgs e)
    {
        string email = textFieldEmail.Text;
        string parola = textFieldParola.Text;
        if (service.getAngajatByEmailAndPassword(email, parola) != null)
        {
            this.Hide();
            mainForm mainForm = new mainForm(service);
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();
        }
        else if (service.getAngajatByEmail(email) != null)
        {
            warningLabel.Text="Parola introdusa gresit. Incercati din nou!";
        }
        else
        {
            warningLabel.Text="Utilizator inexistent.";
        }
    }
    
}