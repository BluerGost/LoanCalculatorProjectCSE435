using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoanCalculatorProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelErrorMsg.Visible = false;
        }

        protected void btnInterestCal_Click(object sender, EventArgs e)
        {
            string strLoanAmount = textLoanAmount.Text;
            string strNumberOfInstallment = textNumberOfInstallment.Text;
            string strInterestRate = textInterestRate.Text;
            textTotalInterest.Text = save(strLoanAmount, strNumberOfInstallment, strInterestRate);
        }

        public string save(string strLoanAmount,string strNumberOfInstallment,string strInterestRate)
        {

            if (strLoanAmount == "" || strNumberOfInstallment == "" || strInterestRate == "")//Empty Field
            {
                //labelErrorMsg.Visible = true;
                return "Loan Amount or Installment Number or Interest Rate Can't Be Empty";
            }
            else
            {
                double loanAmount = Convert.ToDouble(strLoanAmount);

                //installment cant be in float
                int numberOfInstallment = Convert.ToInt32(strNumberOfInstallment);
                double interestRate = Convert.ToDouble(strInterestRate) / 100;


                if (loanAmount < 0 || numberOfInstallment < 0 || interestRate < 0)//Negative Value
                {
                    //labelErrorMsg.Visible = true;
                    return "Loan Amount or Installment Number or Interest Rate Can't Be Negative";
                }
                else
                {
                    double totalInterest = loanAmount * numberOfInstallment * interestRate;
                    return Convert.ToString(totalInterest);
                }
            }
        }
    }
}