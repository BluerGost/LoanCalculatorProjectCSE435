using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoanCalculatorProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textNewBalance.Text = "";
            labelErrorMsg.Visible = false;
        }
        
        public void btnDeposit_Click(object sender, EventArgs e)
        {
            string strBalance = textBalance.Text;
            string strDepositAmount = textDepositAmount.Text;

           textNewBalance.Text =  save(strBalance, strDepositAmount);
            
        }

        public string save(string strBalance, string strDepositAmount)
        {
            if (strBalance == "" || strDepositAmount == "")//Empty Field
            {
                return "Balance or Deposit Amount Can't Be Empty";
            }
            else
            {
                double balance = Convert.ToDouble(strBalance);
                double depositAmount = Convert.ToDouble(strDepositAmount);
                if (balance < 0 || depositAmount < 0)//Negative Deposit Value
                {
                    return "Balance or Deposit Amount Can't Be Negative";
                }
                else
                {
                    double newBalance = balance + depositAmount;
                    return Convert.ToString(newBalance);
                }
            }
        }
    }
}