using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using services;

namespace concursInot;

public partial class mainForm : Form,IObserver
{
    private IServices service;
    private string emailAngajat;
    public mainForm(string email)
    {
        emailAngajat = email;
        InitializeComponent();
    }

    
    public void setService(IServices srv)
    {
        service=srv;
        initialiseGUI();
    }
    
    
    public void createAndFillTable(List<ParticipantDTO> participanti)
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
        refreshTable();
    }

    

    public void refreshTable()
    {
        List<ParticipantDTO> participanti = service.getParticipanti();
        createAndFillTable(participanti);
    }
    
    
    
    public void refreshTableFilter(string stil,string distanta)
    {
        List<ParticipantDTO> participanti = service.getSearchedParticipanti(stil, distanta);
        createAndFillTable(participanti);
        string message = "Simple MessageBox";  
        MessageBox.Show(message); 
    }


    public void refreshStatistics()
    {
        List<int> nrParticipanti = service.getNumarParticipantiDupaProba();
        label13.Text = nrParticipanti[0].ToString();
        label14.Text = nrParticipanti[1].ToString();
        label15.Text = nrParticipanti[2].ToString();
        label16.Text = nrParticipanti[3].ToString();
        
        label18.Text = nrParticipanti[4].ToString();
        label19.Text = nrParticipanti[5].ToString();
        label20.Text = nrParticipanti[6].ToString();
        label21.Text = nrParticipanti[7].ToString();
        
        label23.Text = nrParticipanti[8].ToString();
        label24.Text = nrParticipanti[9].ToString();
        label25.Text = nrParticipanti[10].ToString();
        label26.Text = nrParticipanti[11].ToString();
        
        label33.Text = nrParticipanti[12].ToString();
        label34.Text = nrParticipanti[13].ToString();
        label35.Text = nrParticipanti[14].ToString();
        label36.Text = nrParticipanti[15].ToString();
    }
    
    
    
    public void handleInscriereParticipant(object sender, EventArgs e)
    {
        string nume = textFieldNume.Text;
        int varsta = Int32.Parse(textFieldVarsta.Text);
        string stil = stilInscriere.Text;
        string distanta = distantaInscriere.Text;
        service.inscriereParticipant(nume, varsta, stil, distanta);
        // MessageBox.Show("Participantul este deja inscris la proba dorita.");
        stilInscriere.SelectedItem = null;
        distantaInscriere.SelectedItem = null;
    }

    
    public void handleCautaParticipanti(object sender, EventArgs e)
    {
        string stil = stilCautare.Text;
        string distanta = distantaCautare.Text;
        refreshTableFilter(stil,distanta);
    }

    
    public void handleAnuleazaCautarea(object sender, EventArgs e)
    {
        refreshTable();
    }
    
    
    public void handleLogoutButton(object sender, EventArgs e)
    {
        this.Hide();
        service.logout(emailAngajat);
        loginForm loginForm = new loginForm(service);
        loginForm.Closed += (s, args) => this.Close();
        loginForm.Show();
    }

    
    public void participantInscris()
    {
        dataGridView1.BeginInvoke((Action) delegate { refreshTable();
            refreshStatistics();
        });
    }
}