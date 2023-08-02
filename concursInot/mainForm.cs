using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace concursInot;

public partial class mainForm : Form
{
    private Service service;
    public mainForm(Service srv)
    {
        service=srv;
        InitializeComponent();
        initialiseGUI();
    }
    
    
    public void createAndFillTable(ArrayList participanti)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Nume", typeof(string));
        table.Columns.Add("Varsta", typeof(int));
        table.Columns.Add("Stil", typeof(string));
        table.Columns.Add("Distanta", typeof(string));
        foreach (ParticipantDTO p in participanti)
        {
            DataRow row = table.NewRow();
            row["Nume"] = p.getNume();
            row["Varsta"] = p.getVarsta();
            row["Stil"] = p.getStil();
            row["Distanta"] = p.getDistanta();
            table.Rows.Add(row);
        }
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.DataSource = table;
    }
    
    
    public void initialiseGUI()
    {
        stilInscriere.Items.Add("liber");
        stilInscriere.Items.Add("flutur");
        stilInscriere.Items.Add("spate");
        stilInscriere.Items.Add("mixt");
        distantaInscriere.Items.Add("dist50m");
        distantaInscriere.Items.Add("dist200m");
        distantaInscriere.Items.Add("dist800m");
        distantaInscriere.Items.Add("dist1500m");
        
        stilCautare.Items.Add("liber");
        stilCautare.Items.Add("spate");
        stilCautare.Items.Add("flutur");
        stilCautare.Items.Add("mixt");
        distantaCautare.Items.Add("dist50m");
        distantaCautare.Items.Add("dist200m");
        distantaCautare.Items.Add("dist800m");
        distantaCautare.Items.Add("dist1500m");
        
        refreshStatistics();
        refreshTable(service.getParticipanti());
    }


    public void refreshTable(ArrayList participanti)
    {
        createAndFillTable(participanti);
    }


    public void refreshStatistics()
    {
        label13.Text = service.getNumarParticipantiDupaProba("liber", "dist50m").ToString();
        label14.Text = service.getNumarParticipantiDupaProba("liber", "dist200m").ToString();
        label15.Text = service.getNumarParticipantiDupaProba("liber", "dist800m").ToString();
        label16.Text = service.getNumarParticipantiDupaProba("liber", "dist1500m").ToString();
        
        label18.Text = service.getNumarParticipantiDupaProba("spate", "dist50m").ToString();
        label19.Text = service.getNumarParticipantiDupaProba("spate", "dist200m").ToString();
        label20.Text = service.getNumarParticipantiDupaProba("spate", "dist800m").ToString();
        label21.Text = service.getNumarParticipantiDupaProba("spate", "dist1500m").ToString();
        
        label23.Text = service.getNumarParticipantiDupaProba("flutur", "dist50m").ToString();
        label24.Text = service.getNumarParticipantiDupaProba("flutur", "dist200m").ToString();
        label25.Text = service.getNumarParticipantiDupaProba("flutur", "dist800m").ToString();
        label26.Text = service.getNumarParticipantiDupaProba("flutur", "dist1500m").ToString();
        
        label33.Text = service.getNumarParticipantiDupaProba("mixt", "dist50m").ToString();
        label34.Text = service.getNumarParticipantiDupaProba("mixt", "dist200m").ToString();
        label35.Text = service.getNumarParticipantiDupaProba("mixt", "dist800m").ToString();
        label36.Text = service.getNumarParticipantiDupaProba("", "dist1500m").ToString();
    }
    
    
    
    public void handleInscriereParticipant(object sender, EventArgs e)
    {
        string nume = textFieldNume.Text;
        int varsta = Int32.Parse(textFieldVarsta.Text);
        string stil = stilInscriere.Text;
        string distanta = distantaInscriere.Text;
        if (service.inscriereParticipant(nume, varsta, stil, distanta) == false)
            MessageBox.Show("Participantul este deja inscris la proba dorita.");
        else
        {
            MessageBox.Show("Participantul a fost inscris cu succes!");
            refreshTable(service.getParticipanti());
            refreshStatistics();
        }
    }

    
    public void handleCautaParticipanti(object sender, EventArgs e)
    {
        string stil = stilCautare.Text;
        string distanta = distantaCautare.Text;
        refreshTable(service.getSearchedParticipanti(stil,distanta));
    }

    
    public void handleAnuleazaCautarea(object sender, EventArgs e)
    {
        refreshTable(service.getParticipanti());
    }
    
    
    public void handleLogoutButton(object sender, EventArgs e)
    {
        this.Hide();
        loginForm loginForm = new loginForm(service);
        loginForm.Closed += (s, args) => this.Close();
        loginForm.Show();
    }
}