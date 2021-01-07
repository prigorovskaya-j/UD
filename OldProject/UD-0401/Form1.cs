using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UD_0401
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        SqlCommandBuilder sqlBuilder = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataSet dataSet = null;

        public Form1()
        {
            InitializeComponent();

            tabPage2.AutoScroll = true;
            tabPage3.AutoScroll = true;
            tabPage4.AutoScroll = true;
            tabPage5.AutoScroll = true;
            tabPage6.AutoScroll = true;
        }

        /*private void LoadData() {
            try {
                      
            } catch (Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            finally { 
                            
            }
        }
       */

        private async void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection =
                new SqlConnection(
                    @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\razumovskiy\RiderProjects\UD\UD-0401\DatabaseUD.mdf; Integrated Security = True; Connect Timeout = 30");
            await sqlConnection.OpenAsync();


            //LoadData();

            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Auditoriya". При необходимости она может быть перемещена или удалена.
            this.auditoriyaTableAdapter.Fill(this.databaseUDDataSet.Auditoriya);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Remont". При необходимости она может быть перемещена или удалена.
            this.remontTableAdapter.Fill(this.databaseUDDataSet.Remont);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Spisok". При необходимости она может быть перемещена или удалена.
            this.spisokTableAdapter.Fill(this.databaseUDDataSet.Spisok);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Document". При необходимости она может быть перемещена или удалена.
            this.documentTableAdapter.Fill(this.databaseUDDataSet.Document);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Inventar". При необходимости она может быть перемещена или удалена.
            this.inventarTableAdapter.Fill(this.databaseUDDataSet.Inventar);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Otvet". При необходимости она может быть перемещена или удалена.
            this.otvetTableAdapter.Fill(this.databaseUDDataSet.Otvet);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Prover". При необходимости она может быть перемещена или удалена.
            this.proverTableAdapter.Fill(this.databaseUDDataSet.Prover);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Inventarisation". При необходимости она может быть перемещена или удалена.
            this.inventarisationTableAdapter.Fill(this.databaseUDDataSet.Inventarisation);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseUDDataSet.Auditoriya". При необходимости она может быть перемещена или удалена.
            this.auditoriyaTableAdapter.Fill(this.databaseUDDataSet.Auditoriya);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("save new auditories");
            SqlCommand command =
                new SqlCommand(
                    "INSERT into [Auditoriya]('[№ аудитории]','[тип аудитории]','[id ответственного]')values([№ аудитории],[тип аудитории],[id ответственного])",
                    sqlConnection);
            command.Parameters.AddWithValue("[№ аудитории]", num_аудиторииTextBox.Text);
            command.Parameters.AddWithValue("[тип аудитории]", тип_аудиторииTextBox.Text);
            command.Parameters.AddWithValue("[id ответственного]", id_ответственногоComboBox.Text);
            command.ExecuteNonQuery();
            this.auditoriyaBindingSource.EndEdit();
        }

        private void EndEditOnAllBindingSources()
        {
            var BindingSourcesQuery =
                from Component bindingSources in this.components.Components
                where bindingSources is BindingSource
                select bindingSources;

            foreach (BindingSource bindingSource in BindingSourcesQuery)
            {
                bindingSource.EndEdit();
            }
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            EndEditOnAllBindingSources();

            this.inventarTableAdapter.Update(this.databaseUDDataSet.Inventar);
            this.auditoriyaTableAdapter.Update(this.databaseUDDataSet.Auditoriya);
            this.documentTableAdapter.Update(this.databaseUDDataSet.Document);
            this.otvetTableAdapter.Update(this.databaseUDDataSet.Otvet);
            this.proverTableAdapter.Update(this.databaseUDDataSet.Prover);
            this.inventarisationTableAdapter.Update(this.databaseUDDataSet.Inventarisation);
            this.remontTableAdapter.Update(this.databaseUDDataSet.Remont);
            this.spisokTableAdapter.Update(this.databaseUDDataSet.Spisok);

            this.auditoriyaBindingSource.EndEdit();
            this.inventarBindingSource.EndEdit();
            this.documentBindingSource.EndEdit();
            this.otvetBindingSource.EndEdit();
            this.proverBindingSource.EndEdit();
            this.inventarisationBindingSource.EndEdit();
            this.remontBindingSource.EndEdit();
            this.spisokBindingSource.EndEdit();
        }
    }
}