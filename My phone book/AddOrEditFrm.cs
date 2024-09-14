using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using My_phone_book.Repository;
using My_phone_book.Services;

namespace My_phone_book
{
    public partial class AddOrEditFrm : Form
    {
        public int ContactID=0;
        IContactRepository contactRepository;
        public AddOrEditFrm()
        {
            InitializeComponent();
            contactRepository = new ContactRepository();
        }

        private void AddOrEditFrm_Load(object sender, EventArgs e)
        {
            
            if (ContactID==0)
            {
                this.Text = "افزودن";
            }
            else
            {
                
                this.Text = "ویرایش";
                DataTable dt = new DataTable();
                dt=contactRepository.SelectRow(ContactID);
                txtName.Text= dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtAge.Value =int.Parse(dt.Rows[0][3].ToString());
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtEmail.Text= dt.Rows[0][5].ToString();
                txtAddress.Text= dt.Rows[0][6].ToString();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (IsValidate())
            {
                bool isSuccess;
                if (ContactID == 0)
                {
                    
                    isSuccess = contactRepository.Insert(txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);



                }
                else
                {
                    
                    isSuccess = contactRepository.Update(ContactID, txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);

                }
                ;
                if (isSuccess == true)
                {

                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                ;
            }
        }


        bool IsValidate()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام شخص مورد نظر را وارد نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی شخص مورد نظر را وارد نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا مویایل شخص مورد نظر را وارد نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن شخص مورد نظر را وارد نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل شخص مورد نظر را وارد نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
    }
}
