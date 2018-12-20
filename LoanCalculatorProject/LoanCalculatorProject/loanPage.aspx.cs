using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoanCalculatorProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textNumberOfPayment.Text = "";
            labelErrorMsg.Visible = false;
        }

        protected void btnNumOfPayment_Click(object sender, EventArgs e)
        {
            string strLoanAmount = textLoanAmount.Text;
            string strPaymentPerInstallment = textPaymentPerInstallment.Text;
            textNumberOfPayment.Text =  save(strLoanAmount, strPaymentPerInstallment);
        }

        public string save(string strLoanAmount,string strPaymentPerInstallment)
        {

            if (strLoanAmount == "" || strPaymentPerInstallment == "")//Empty Field
            {
                //labelErrorMsg.Visible = true;
                return "Loan Amount or Payment Per Installment Can't Be Empty";
            }
            else
            {
                double loanAmount = Convert.ToDouble(strLoanAmount);
                double paymentPerInstallment = Convert.ToDouble(strPaymentPerInstallment);
                if (loanAmount <= 0 || paymentPerInstallment <= 0)//Negative Deposit Value
                {
                    //labelErrorMsg.Visible = true;
                    return "Loan Amount or Payment Per Installment Can't Be Negative or Zero";
                }
                else if (loanAmount < paymentPerInstallment)
                {
                    //labelErrorMsg.Visible = true;
                    return "Loan Amount Must Be  More than Per Installment Payment Amount";
                }
                else
                {
                    double numberOfPayment = loanAmount / paymentPerInstallment;
                    return Convert.ToString(numberOfPayment);
                }
            }
        }
    }
}