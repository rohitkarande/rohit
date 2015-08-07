using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendNotice : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["constr"].ToString());
    SqlDataAdapter da;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    btnSend.Attributes.Add("onclick", "return ConfirmSend();");
                    FillDDLTownship();
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx", true);
            }
        }
        catch
        {
            Response.Redirect("LoginPage.aspx", true);
        }
    }

    protected void FillDDLTownship()
    {
        try
        {
            DataSet _ds =new DataSet();
            da = new SqlDataAdapter("select Township,SrNo_TownshipMaster from Township_Master where SrNo_TownshipMaster IN(select SrNo_TownshipMaster from Admin_ForTownship where SrNo_UserMaster=(select SrNo_UserMaster from User_Master where username='" + Session["username"] + "'))", con);
            da.Fill(_ds);           
            if (_ds.Tables[0].Rows.Count > 0)
            {
                int k = 1;
                ddlTownship.Items.Clear();
                ddlTownship.Items.Insert(0, "---Select Township---");
                for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                {
                    ddlTownship.Items.Insert(k, _ds.Tables[0].Rows[i][0].ToString());
                    ddlTownship.DataValueField=  _ds.Tables[0].Rows[i][1].ToString();
                    k++;
                }
            }
            else
            {
                lblmsg.Text = "No Township Found for user: "+ Session["username"];
                return;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return;
        }
    }

    protected void chkAllFLats_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAllFLats.Checked == true)
            {
                for (int i = 0; i < chkFlats.Items.Count; i++)
                {
                    chkFlats.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < chkFlats.Items.Count; i++)
                {
                    chkFlats.Items[i].Selected = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return;
        }
    }
    protected void chkFlats_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < chkFlats.Items.Count; i++)
            {
                if (chkFlats.Items[i].Selected == false)
                {
                    chkAllFLats.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return;
        }
    }
    protected void ddlTownship_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
            {
                if (ddlTownship.SelectedIndex != 0)
                {
                    DataSet _ds = new DataSet();
                    da = new SqlDataAdapter("select Sector,SrNo_Sector from Sector_Master where SrNo_TownshipMaster IN(select SrNo_TownshipMaster from Township_Master where Township='" + ddlTownship.SelectedValue + "')", con);
                    da.Fill(_ds);
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        int k = 1;
                        ddlSector.Items.Clear();
                        ddlBuilding.Items.Clear();
                        chkAllFLats.Checked = false;
                        chkFlats.Items.Clear();
                        ddlSector.Items.Insert(0, "---Select Sector---");
                        for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                        {
                            ddlSector.Items.Insert(k, _ds.Tables[0].Rows[i][0].ToString());
                            ddlSector.DataValueField = _ds.Tables[0].Rows[i][1].ToString();
                            k++;
                        }
                    }
                    else
                    {
                        lblmsg.Text = "No Sector Found for this Township: " + ddlTownship.SelectedValue;
                        ddlSector.Items.Clear();
                        ddlBuilding.Items.Clear();
                        chkAllFLats.Checked = false;
                        chkFlats.Items.Clear();
                        SetFocus(ddlTownship);
                        return;
                    }
                }
                else
                {
                    // lblmsg.Text = "Please";
                    ddlSector.Items.Clear();
                    ddlBuilding.Items.Clear();
                    chkAllFLats.Checked = false;
                    chkFlats.Items.Clear();
                    SetFocus(ddlTownship);
                    return;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                return;
            }
    }

    protected void ddlBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTownship.SelectedIndex != 0)
            {
                if (ddlSector.SelectedIndex != 0)
                {
                    if (ddlBuilding.SelectedIndex != 0)
                    {
                        string qry = "SELECT FlatNo,SrNo_GUID from ControllerInfo where SrNo_BuildingMaster IN(select SrNo_BuildingMaster from Building_Master where Building='"+ddlBuilding.SelectedValue+"' ";
                        qry += "and SrNo_Sector IN(select SrNo_Sector from Sector_Master where Sector='"+ddlSector.SelectedValue+"' and ";
                        qry += "SrNo_TownshipMaster IN (Select SrNo_TownshipMaster from Township_Master where Township='"+ddlTownship.SelectedValue+"')))";

                        DataSet _ds = new DataSet();
                        da = new SqlDataAdapter(qry, con);
                        da.Fill(_ds);

                        if (_ds.Tables[0].Rows.Count > 0)
                        {
                            chkAllFLats.Visible = true;
                            chkAllFLats.Checked = false;
                            chkFlats.Items.Clear();

                            for (int k = 0; k < _ds.Tables[0].Rows.Count; k++)
                            {
                                chkFlats.Items.Insert(k, _ds.Tables[0].Rows[k][0].ToString());
                                chkFlats.DataValueField = _ds.Tables[0].Rows[k][1].ToString();
                            }
                        }
                        else
                        {
                            chkAllFLats.Visible = false;
                            chkAllFLats.Checked = false;
                            chkFlats.Items.Clear();
                            lblmsg.Text = "No Falts Found";
                             return;
                        }
                    }
                    else
                    {
                        chkAllFLats.Checked = false;
                        chkFlats.Items.Clear();
                        SetFocus(ddlBuilding);
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return;
        }
    }
    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTownship.SelectedIndex != 0)
            {
                if (ddlSector.SelectedIndex != 0)
                {
                    DataSet _ds = new DataSet();
                    da = new SqlDataAdapter("select Building,SrNo_BuildingMaster from Building_Master where SrNo_Sector IN(Select SrNo_Sector from Sector_Master where Sector='"+ddlSector.SelectedValue+"' and SrNo_TownshipMaster IN(select SrNo_TownshipMaster from Township_Master where Township='"+ddlTownship.SelectedValue+"'))", con);
                    da.Fill(_ds);
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        int k = 1;                        
                        ddlBuilding.Items.Clear();
                        chkAllFLats.Checked = false;
                        chkFlats.Items.Clear();
                        ddlBuilding.Items.Insert(0, "---Select Building---");
                        for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                        {
                            ddlBuilding.Items.Insert(k, _ds.Tables[0].Rows[i][0].ToString());
                            ddlBuilding.DataValueField = _ds.Tables[0].Rows[i][1].ToString();
                            k++;
                        }
                    }
                    else
                    {
                        lblmsg.Text = "No Building Found for Sector: " + ddlSector.SelectedValue;
                        ddlBuilding.Items.Clear();
                        chkAllFLats.Checked = false;
                        chkAllFLats.Visible = false;
                        chkFlats.Items.Clear();
                        return;
                    }
                }
                else
                {                    
                    ddlBuilding.Items.Clear();
                    chkAllFLats.Checked = false;
                    chkAllFLats.Visible = false;
                    chkFlats.Items.Clear();
                    SetFocus(ddlSector);
                }
            }
            else
            {
                // lblmsg.Text = "Please";
                ddlSector.Items.Clear();
                ddlBuilding.Items.Clear();
                chkAllFLats.Checked = false;
                chkAllFLats.Visible = false;
                chkFlats.Items.Clear();
                return;
            }
        }
        catch (Exception ex)
        {
             lblmsg.Text = ex.Message;
            return;
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            CallAPI _ObjCall = new CallAPI(); int z = 0;
            string[] _SrNoGUID;
            if (ddlTownship.SelectedIndex != 0)
            {
                if (ddlSector.SelectedIndex != 0)
                {
                    if (ddlBuilding.SelectedIndex != 0)
                    {
                        if (txtTitle.Text != "")
                        {
                            if (txtMessage.Text != "")
                            {
                                for (int j = 0; j < chkFlats.Items.Count; j++)
                                {
                                    if (chkFlats.Items[j].Selected == false)
                                    {
                                        z++;
                                    }
                                }
                                if (z == chkFlats.Items.Count)
                                {
                                    lblmsg.Text = "Please Select Flat No";
                                    return;
                                }
                                else
                                {
                                    for (int j = 0; j < chkFlats.Items.Count; j++)
                                    {
                                        if (chkFlats.Items[j].Selected == true)
                                        {
                                            _SrNoGUID[j] = chkFlats.DataValueField;

                                            
                                        }
                                    }

                                    if (_SrNoGUID.Length > 0)
                                    {
                                        var _result = _ObjCall.call(txtTitle.Text, txtMessage.Text, _SrNoGUID, ddlBuilding.DataValueField, ddlSector.DataValueField, ddlTownship.DataValueField);                                       
                                    }
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Please enter Title";
                                SetFocus(txtTitle);
                                return;
                            }
                        }
                        else
                        {
                            lblmsg.Text = "Please enter Message";
                            SetFocus(txtMessage);
                            return;
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Please select Building";
                        chkAllFLats.Checked = false;
                        chkAllFLats.Visible = false;
                        chkFlats.Items.Clear();
                        return;
                    }
                }
                else
                {
                    lblmsg.Text = "Please select Sector";
                    ddlBuilding.Items.Clear();
                    chkAllFLats.Checked = false;
                    chkAllFLats.Visible = false;
                    chkFlats.Items.Clear();
                    SetFocus(ddlSector);
                }
            }
            else
            {
                lblmsg.Text = "Please select Township";
                ddlSector.Items.Clear();
                ddlBuilding.Items.Clear();
                chkAllFLats.Checked = false;
                chkAllFLats.Visible = false;
                chkFlats.Items.Clear();
                SetFocus(ddlTownship);
                return;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return;
        }

    }
}