using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaAdmin
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connessione = ConfigurationManager.ConnectionStrings["DBconnection"].ToString();
            SqlConnection conn = new SqlConnection(connessione);

            try
            {
                conn.Open();
                SqlCommand getTickets = new SqlCommand("SELECT (SELECT COUNT(*) FROM Biglietto WHERE Sala = 'nord') AS totNord, (SELECT COUNT(*) FROM Biglietto WHERE Sala = 'nord' AND TipoBiglietto = 'Ridotto') AS totKidsNord, (SELECT COUNT(*) FROM Biglietto WHERE Sala = 'est') AS totEst, (SELECT COUNT(*) FROM Biglietto WHERE Sala = 'est' AND TipoBiglietto = 'Ridotto') AS totKidsEst, (SELECT COUNT(*) FROM Biglietto WHERE Sala = 'sud') AS totSud, (SELECT COUNT(*) FROM Biglietto WHERE Sala = 'sud' AND TipoBiglietto = 'Ridotto') AS totKidsSud", conn);
                SqlDataReader sqlTickets = getTickets.ExecuteReader();
                if (sqlTickets.HasRows)
                {
                    while (sqlTickets.Read())
                    {
                        int totTicketsNord = sqlTickets.GetInt32(0);
                        LabelNord.Text = $"Biglietti venduti: {totTicketsNord.ToString()}";
                        int totKidsNord = sqlTickets.GetInt32(1);
                        LabelRidottiNord.Text = $"Biglietti ridotti venduti: {totKidsNord.ToString()}";
                        int totTicketsEst = sqlTickets.GetInt32(2);
                        LabelEst.Text = $"Biglietti venduti: {totTicketsEst.ToString()}";
                        int totKidsEst = sqlTickets.GetInt32(3);
                        LabelRidottiEst.Text = $"Biglietti ridotti venduti: {totKidsEst.ToString()}";
                        int totTicketsSud = sqlTickets.GetInt32(4);
                        LabelSud.Text = $"Biglietti venduti: {totTicketsSud.ToString()}";
                        int totKidsSud = sqlTickets.GetInt32(5);
                        LabelRidottiSud.Text = $"Biglietti ridotti venduti: {totKidsSud.ToString()}";
                    }
                }
                else
                {
                    LabelNord.Text = "0";
                }
                sqlTickets.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"{ex}");
            }
            finally
            {
                conn.Close();
            }
        }
        protected void PrenotaBtn_Click(object sender, EventArgs e)
        {
            string connessione = ConfigurationManager.ConnectionStrings["DBconnection"].ToString();
            SqlConnection conn = new SqlConnection(connessione);

            try
            {
                conn.Open();
                string selectedRadio = (RadioButtonList1.SelectedValue).ToString();
                string isRidotto;
                if (CheckBoxRidotto.Checked)
                {
                    isRidotto = "Ridotto";
                }
                else
                {
                    isRidotto = "Intero";
                }
                if (TextBoxNome.Text != "" && TextBoxCognome.Text != "" && selectedRadio != "")
                {
                    SqlCommand addTicket = new SqlCommand($"INSERT into Biglietto (Nome, Cognome, Sala, TipoBiglietto) VALUES ('{TextBoxNome.Text}', '{TextBoxCognome.Text}', '{selectedRadio}', '{isRidotto}')", conn);
                    int affectedRow = addTicket.ExecuteNonQuery();
                    if (affectedRow > 0)
                    {
                        Response.Write("Biglietto registrato con successo");
                        TextBoxNome.Text = "";
                        TextBoxCognome.Text = "";
                        RadioButtonList1.ClearSelection();
                        CheckBoxRidotto.Checked = false;
                    }
                    else
                    {
                        Response.Write("Compila tutti i campi!");
                    }


                }

            }
            catch
            {
                Response.Write("Connessione chiusa");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}     