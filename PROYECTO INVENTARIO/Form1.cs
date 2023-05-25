using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PROYECTO_INVENTARIO
{
    public partial class Form1 : Form
    {
        DataGridViewRow row;
        public Form1()
        {
            InitializeComponent();
        }
        public void save()
        {
            ProductDetails product = new ProductDetails();
            product.Name = txtname.Text.ToUpper();
            product.Code = txtcode.Text.ToUpper();
            product.Entry_date = dateTimePicker1.Value;
            product.Purchase_price = double.Parse(txtpurchase_price.Text);
            product.Sale_price = double.Parse(txtsale_price.Text);
            product.Amount = int.Parse(txtamount.Text);

            fill_DGV(product);
        }
        private void save(string code, int exit)
        {
            int rowIndex = 0;
            foreach (DataGridViewRow row in dgvBoard.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    { continue; }

                    if (cell.Value.ToString() == code)
                    { rowIndex = row.Index; break; }
                }
                if (rowIndex != 0) { break; }
            }
            dgvBoard.Rows[rowIndex].Cells[6].Value = exit;
            int stock = int.Parse(dgvBoard.Rows[rowIndex].Cells[3].Value.ToString()) - exit;
            dgvBoard.Rows[rowIndex].Cells[7].Value = stock;

        }
        private void fill_DGV(ProductDetails product)
        {
            row = new DataGridViewRow();
            row.CreateCells(dgvBoard);
            try
            {
                row = new DataGridViewRow();
                row.CreateCells(dgvBoard);
                row.Cells[0].Value = product.Code;
                row.Cells[1].Value = dateTimePicker1.Text;
                row.Cells[2].Value = product.Name;
                row.Cells[3].Value = product.Amount;
                row.Cells[4].Value = product.Purchase_price;
                row.Cells[5].Value = product.Sale_price;

                StreamWriter sw = new StreamWriter("PROYECT.txt", true, Encoding.ASCII);

                sw.WriteLine(txtcode.Text.ToUpper() + "," + dateTimePicker1.Text + "," + txtname.Text.ToUpper() + "," + txtpurchase_price.Text + "," + txtamount.Text + "," + txtsale_price.Text + "," + txtexit.Text);
                sw.Close();

                dgvBoard.Rows.Add(row);
                txtcode.Text = " ";
                dateTimePicker1.Text = null;
                txtname.Text = " ";
                txtpurchase_price.Text = " ";
                txtamount.Text = " ";
                txtsale_price.Text = " ";
            }
            catch
            {
                MessageBox.Show("IT SEEMS SOMETHING WENT WRONG..., PLEASE REVIEW AND FILL IN EACH FIELD CORRECTLY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvBoard.Rows.Remove(dgvBoard.CurrentRow);
        }
        private void dgvBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcode.Text = dgvBoard.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = dgvBoard.CurrentRow.Cells[1].Value.ToString();
            txtname.Text = dgvBoard.CurrentRow.Cells[2].Value.ToString();
            txtpurchase_price.Text = dgvBoard.CurrentRow.Cells[3].Value.ToString();
            txtamount.Text = dgvBoard.CurrentRow.Cells[4].Value.ToString();
            txtsale_price.Text = dgvBoard.CurrentRow.Cells[5].Value.ToString();
        }
        private void btnmost_Click(object sender, EventArgs e)
        {
            double totalA, totalB, totalC;
            totalA = 0; totalB = 0; totalC = 0;
            foreach (DataGridViewRow row in dgvBoard.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    double value = 0;
                    if (double.TryParse(row.Cells[3].Value.ToString(), out value))
                    { totalA += value; }
                    txtentries.Text = totalA.ToString();
                }
                if (row.Cells[4].Value != null)
                {
                    double value1 = 0;
                    if (double.TryParse(row.Cells[4].Value.ToString(), out value1))
                    { totalB += value1; }
                    txttotal1.Text = totalB.ToString("C");
                }
                if (row.Cells[5].Value != null)
                {
                    double value2 = 0;
                    if (double.TryParse(row.Cells[5].Value.ToString(), out value2))
                    { totalC += value2; }
                    txttotal2.Text = totalC.ToString("C");
                }
            }
        }
        private void btnSave2_Click(object sender, EventArgs e)
        {
            save(txtCodeStock.Text, int.Parse(txtexit.Text));
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            save();
        }
        private void btnStreamReader_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("PROYECT.txt");
            rtxtboxmost.Text = sr.ReadToEnd();
        }
    }
}