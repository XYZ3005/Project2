using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Project_2
{
    public partial class Tenant : Form
    {
        public Tenant()
        {
            InitializeComponent();
        }
        BuisnessLogicLayer bll = new BuisnessLogicLayer();
        DataAccessLayer dal = new DataAccessLayer();
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Tenants tenant = new Tenants(txtName.Text,txtSurName.Text,txtEmail.Text,txtPassword.Text,txtPhone.Text,cmbxStatus.Text,int.Parse(txtID.Text));
            int x = bll.InsertTenant(tenant);
            if (x > 0)
            {
                MessageBox.Show(x + "Agents Added");

            }
            else
            {
                MessageBox.Show("Nothing Added");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tenants tenant = new Tenants(txtName.Text, txtSurName.Text, txtEmail.Text, txtPassword.Text, txtPhone.Text, cmbxStatus.Text, int.Parse(txtID.Text));
            dgvOutput.DataSource = bll.UpdateTenant(tenant);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Tenants tenant = new Tenants(txtName.Text, txtSurName.Text, txtEmail.Text, txtPassword.Text, txtPhone.Text, cmbxStatus.Text, int.Parse(txtID.Text));
            dgvOutput.DataSource = bll.TenantDisplay(tenant);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Tenants tenant = new Tenants(txtName.Text, txtSurName.Text, txtEmail.Text, txtPassword.Text, txtPhone.Text, cmbxStatus.Text, int.Parse(txtID.Text));
            dgvOutput.DataSource = bll.DeleteTenant(tenant);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //frmMenu form = new frmMenu();
            //form.Show();
            //this.Hide();
        }

        private void Tenant_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            cmbxStatus.Items.Add("Available");
            cmbxStatus.Items.Add("Unavailable");
        } 

        private void dgvOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOutput.SelectedRows.Count > 0)
            {

                txtName.Text = dgvOutput.SelectedRows[0].Cells["Name"].Value.ToString();
                txtSurName.Text = dgvOutput.SelectedRows[0].Cells["SurName"].Value.ToString();
                txtEmail.Text = dgvOutput.SelectedRows[0].Cells["Email"].Value.ToString();
                txtPassword.Text = dgvOutput.SelectedRows[0].Cells["Password"].Value.ToString();
                txtPhone.Text = dgvOutput.SelectedRows[0].Cells["Phone"].Value.ToString();
                cmbxStatus.Text = dgvOutput.SelectedRows[0].Cells["Status"].Value.ToString();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[A-Z][a-zA-Z]+$");
            bool result = reg.IsMatch(txtName.Text);
            if (result == false)
            {
                txtName.Clear();
                txtName.Focus();
            }
        }

        private void txtSurName_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[A-Z][a-zA-Z]+$");
            bool result = reg.IsMatch(txtSurName.Text);
            if (result == false)
            {
                txtSurName.Clear();
                txtSurName.Focus();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*\r\n@[a-zA-Z] (-?[a-zA-Z0-9])*(\\.[a-zA-Z] (-?[a-zA-Z0-9])*)+$");
            bool result = reg.IsMatch(txtEmail.Text);
            if (result == false)
            {
                txtEmail.Clear();
                txtEmail.Focus();
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^\\(?([0-9]{3})\\)?[-.\\s]?([0-9]{3})[-.\\s]?([0-9]{4})$");
            bool result = reg.IsMatch(txtEmail.Text);
            if (result == false)
            {
                txtPhone.Clear();
                txtPhone.Focus();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^(?=.{ 8,32}$)(?=.*[a - z]).*\\d / i");// regex for password containing at least 8 characters, 1 number, 1 upper and 1 lowercase [duplicate]
            bool result = reg.IsMatch(txtEmail.Text);
            if (result == false)
            {
                txtPhone.Clear();
                txtPhone.Focus();
            }
        }
    }
}
