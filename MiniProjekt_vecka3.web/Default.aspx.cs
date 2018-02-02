using Miniprojekt_v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniProjekt_vecka3.web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataManager manager = new DataManager();
            List<Player> leagueTable = manager.GetLeagueTable();
            leagueRepeater.DataSource = leagueTable;
            leagueRepeater.DataBind();

            List<Match> matchTable = manager.GetMatchTable();
            matchRepeater.DataSource = matchTable;
            matchRepeater.DataBind();

            List<String> playerName = new List<string>();
            foreach (var item in leagueTable)
            {
                playerName.Add(item.Id.ToString());
            }

            //List<Match> matchPlayer = manager.GetMatchTable();
            //playerRepeater.DataSource = matchPlayer;
            //playerRepeater.DataBind();

            List<Player> dropDownPlayers = manager.GetLeagueTable();

            foreach (var item in dropDownPlayers)
            {

                ListItem listItem = new ListItem(item.Name, item.Id.ToString());
                DropDownListPlayer.Items.Add(listItem);
                DropDownListPlayer2.Items.Add(listItem);
            }


            btnMatch.Click += BtnMatch_Click;

			btnAddPlayer.Click += BtnAddPlayer_Click;

		}

		private void BtnAddPlayer_Click(object sender, EventArgs e)
		{
			DataManager dataManager = new DataManager();
			dataManager.AddNewPlayer(newPlayerName.Text);
			Response.Redirect("Default.Aspx");
		}

		private void BtnMatch_Click(object sender, EventArgs e)
        {
            int player1 = int.Parse(DropDownListPlayer.SelectedValue);
            int player2 = int.Parse(DropDownListPlayer2.SelectedValue);
            int sets1 = int.Parse(DropDownListP1Sets.SelectedValue);
            int sets2 = int.Parse(DropDownListP2Sets.SelectedValue);
            if (sets1 != sets2 && (sets1 == 2 || sets2 == 2) && player1 != player2)
            {
                DataManager datamanager = new DataManager();
                datamanager.AddMatch(player1, player2, sets1, sets2);
                datamanager.UppdatePlayer(player1, player2, sets1, sets2);
                Response.Redirect("Default.aspx");
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FEELL!')", true);
                //System.Threading.Thread.Sleep(2000);
                Response.Redirect("Default.aspx");
            }
        }

    }
}