using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["constr"].ToString());
    SqlDataAdapter da;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogin.Attributes.Add("OnClick", "javascript:return validate();");
        txtPassword.Attributes.Add("onkeypress", "return clickbutton(event,'" + btnLogin.ClientID + "')");
        //SetFocus(txtUserName);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    con.Open();
                    cmd = new SqlCommand("select Count(*) from User_Master where username=@uname and password=@password", con);
                    cmd.Parameters.AddWithValue("@uname", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    int x = (int)(cmd.ExecuteScalar());
                    if (x > 0)
                    {
                        Session["username"] = txtUserName.Text;
                        Response.Redirect("SendNotice.aspx");
                    }
                    else
                    {
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        SetFocus(btnLogin);
                        SetFocus(txtUserName);
                        SetFocus(txtPassword);
                        SetFocus(btnLogin);
                        Session["username"] = null;
                        lblmsg.Text = "Wrong Username or Password";                        
                        return;
                    }
                }
                else
                {
                    SetFocus(txtPassword);
                    SetFocus(lblmsg);
                    lblmsg.Text = "Please Enter Password";                    
                    return;
                }
            }
            else
            {
                SetFocus(txtUserName);                
                SetFocus(lblmsg);
                lblmsg.Text = "Please Enter Username";                
                return;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return;
        }
        finally
        {
            cmd.Dispose();
            con.Close();            
        }
    }
}