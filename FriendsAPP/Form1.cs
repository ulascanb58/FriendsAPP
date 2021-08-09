using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using EntityLayer;

namespace FriendsAPP
{
    public partial class Form1 : Form
    {
        
        public string _gender;
   


        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Enabled = true;
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAge.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedBirthDate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.Equals("Female"))
                radioButtonFemale.Checked = true;
            else
                RadioButtonMale.Checked = true;
            

            txtCity.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            mskPhone.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtID.Enabled = false;
            List<Friend> FriendList = FriendLogic.LLFriendList();
            dataGridView1.DataSource = FriendList;
            MessageBox.Show("Listed!", "Friend List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            txtID.Enabled = false;
            List<Friend> FriendList = FriendLogic.LLFriendList();
            dataGridView1.DataSource = FriendList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtFirstName.Focus();
                txtID.Enabled = false;
                Friend fr = new Friend();
                fr.FirstName = txtFirstName.Text;
                fr.LastName = txtLastName.Text;
                fr.Age = Convert.ToInt32(txtAge.Text);
                fr.BirthDate = maskedBirthDate.Text;
                fr.Email = txtMail.Text;
                fr.Gender = _gender;
                fr.City = txtCity.Text;
                fr.PhoneNumber = mskPhone.Text;
                FriendLogic.LLRegisterFriend(fr);
                MessageBox.Show("Registration is Successful !", "Success!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception Error)
            {
                MessageBox.Show("Some values are wrong please check your values.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void RadioButtonMale_CheckedChanged(object sender, EventArgs e)
        {

            _gender = "Male";
            
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            _gender = "Female";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                txtFirstName.Focus();
                txtID.Enabled = false;
                Friend fr = new Friend();
                fr.FriendID = Convert.ToInt32(txtID.Text);
                FriendLogic.LLDeleteFriend(fr.FriendID);
                MessageBox.Show("Do you really want to delete it?", "Delete a Friend", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }
            catch (Exception Error)
            {
                MessageBox.Show("Some values are wrong please check your values.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            try
            {
                txtFirstName.Focus();
                Friend fr = new Friend();
                fr.FriendID = Convert.ToInt32(txtID.Text);
                fr.FirstName = txtFirstName.Text;
                fr.LastName = txtLastName.Text;
                fr.Age = Convert.ToInt32(txtAge.Text);
                fr.BirthDate = maskedBirthDate.Text;
                fr.Email = txtMail.Text;
                fr.Gender = _gender;
                fr.City = txtCity.Text;
                fr.PhoneNumber = mskPhone.Text;
                FriendLogic.LLUpdateFriend(fr);
                MessageBox.Show("Updated!","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            catch (Exception Error)
            {
                MessageBox.Show("Some values are wrong please check your values.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            List<Friend> FriendSearch = FriendLogic.LLFriendSearch(txtSearch.Text);
            dataGridView1.DataSource = FriendSearch;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            List<Friend> FriendSearch = FriendLogic.LLFriendSearch2(txtSearch.Text);
            dataGridView1.DataSource = FriendSearch;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            List<Friend> FriendSearch = FriendLogic.LLFriendSearch3(txtSearch.Text);
            dataGridView1.DataSource = FriendSearch;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Clear(groupBox1);
            Clear(groupBox2);
            maskedBirthDate.Text = "";
            mskPhone.Text = "";



        }

        public void Clear(GroupBox group)
        {
            foreach (var item in group.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Clear();
                }

               

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
