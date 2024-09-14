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
    public partial class frmMain : Form
    {
        IContactRepository contactRepository;
        public frmMain()
        {
            InitializeComponent();
            contactRepository = new ContactRepository();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void dgvContact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void BindGrid()
        {
            dgvContact.AutoGenerateColumns = false;
            dgvContact.DataSource = contactRepository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            AddOrEditFrm frm= new AddOrEditFrm();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ConTactiD = int.Parse(dgvContact.CurrentRow.Cells[0].Value.ToString());
            string naMe = dgvContact.CurrentRow.Cells[1].Value.ToString();
            string faMily = dgvContact.CurrentRow.Cells[2].Value.ToString();
            string FullName = naMe + " " + faMily;


            if (dgvContact.CurrentRow != null)
            {
                if (MessageBox.Show($"آیا مایل به حذف {FullName} میباشید؟", "توجه", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    contactRepository.Delete(ConTactiD);
                    BindGrid();
                }
            

        }
            else
            {
                MessageBox.Show("لطفا شخص مورد نظر حود را برای حذف انتخاب نمایید");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvContact.CurrentRow != null)
            {
                int ContactId = Convert.ToInt32(dgvContact.CurrentRow.Cells[0].Value.ToString());
                AddOrEditFrm frm = new AddOrEditFrm();
                frm.ContactID = ContactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص یزای ویرایش انتخاب نمایید", "توجه", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvContact.DataSource = contactRepository.Search(txtSearch.Text);
        }
    }
}
