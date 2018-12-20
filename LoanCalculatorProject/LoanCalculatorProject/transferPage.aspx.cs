using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoanCalculatorProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textNewBalance.Text = "";
            labelErrorMsg.Visible = false;
        }

        protected void btnTrnasfer_Click(object sender, EventArgs e)
        {

            string strBalance = textBalance.Text;
            string strTransferAmount = textTransferAmount.Text;

            textNewBalance.Text = save(strBalance, strTransferAmount);

        }

        public string save(string strBalance,string strTransferAmount)
        {

            if (strBalance == "" || strTransferAmount == "")//Empty Field
            {
                return "Balance or Transfer Amount Can't Be Empty";
            }
            else
            {
                double balance = Convert.ToDouble(strBalance);
                double transferAmount = Convert.ToDouble(strTransferAmount);
                if (balance < 0 || transferAmount < 0)//Negative Deposit Value
                {
                    //labelErrorMsg.Visible = true;
                    return "Balance or Transfer Amount Can't Be Negative";
                }
                else if (balance < transferAmount)
                {
                    //labelErrorMsg.Visible = true;
                    return "Not Enough Balance";
                }
                else
                {
                    double newBalance = balance - transferAmount;
                    return Convert.ToString(newBalance);
                }
            }
        }
    }
}