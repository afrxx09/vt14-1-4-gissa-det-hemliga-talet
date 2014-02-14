using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecretNumber.Model;
using System.Collections.ObjectModel;

namespace SecretNumber
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNum SN {
            get { return Session["sn"] as SecretNum ?? (SecretNum)(Session["sn"] = new SecretNum()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMakeGuess_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    int guess = int.Parse(txtGuess.Text);
                    Outcome o = SN.MakeGuess(guess);
                    RenderResponseText(o);
                    RenderGuesses(SN.PreviousGuesses);
                    if (!SN.CanMakeGuess) { EndGame(); }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Obs! Något gick fel.");
                }
                lblResponse.Visible = true;
                lblGuesses.Visible = true;
            }
        }

        private void EndGame()
        {
            phGameOver.Visible = true;
            txtGuess.Enabled = false;
            btnMakeGuess.Enabled = false;
            SN.Initialize();
        }

        private void RenderGuesses(ReadOnlyCollection<int> pg)
        {
            string g = string.Format("{0} Gissningar: {1}", pg.Count, String.Join<int>(", ", pg));
            lblGuesses.Text = g;
        }

        private void RenderResponseText(Outcome o)
        {
            string r;
            switch (o)
            {
                case Outcome.Correct:
                    r = String.Format("Grattis du gissade rätt på {0} försök.", SN.Count);
                    break;
                case Outcome.High:
                    r = "Du gissade för högt.";
                    break;
                case Outcome.Low:
                    r = "Du gissade för lågt.";
                    break;
                case Outcome.NoMoreGuesses:
                    r = String.Format("Slut på gissningar. Det hemliga talet var: {0}", SN.Number);
                    break;
                case Outcome.PreviousGuess:
                    r= String.Format("Du har redan gissat på {0}.", txtGuess.Text);
                    break;
                default:
                    r = "Något gick knas...";
                    break;
            }
            lblResponse.Text = r;
        }
    }
}