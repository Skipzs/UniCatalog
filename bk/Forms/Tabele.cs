using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace Login
{
    public partial class Tabele : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "https://localhost:7063/api/";
        private string _query;
        private string _semestruId;

        public Tabele(string query, string semestruId)
        {
            InitializeComponent();
            _query = query;
            _semestruId = semestruId;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Load user data
                var response = await _httpClient.GetAsync(_baseAddress + _query);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(responseBody);

                // Load discipline data
                var semestruResponse = await _httpClient.GetAsync($"{_baseAddress}Semestru/{_semestruId}");
                semestruResponse.EnsureSuccessStatusCode();
                var semestruResponseBody = await semestruResponse.Content.ReadAsStringAsync();
                var semestruData = JsonConvert.DeserializeObject<SemestruResponse>(semestruResponseBody);

                // Setup DataGridView columns
                SetupDataGridView(users, semestruData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SetupDataGridView(List<User> users, SemestruResponse semestruData)
        {
            TabeleStudenti.AutoGenerateColumns = false;

            // Add user detail columns (read-only)
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("ProgramStudiu", "Program Studii", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("CicluInvatamant", "Ciclu Invatamant", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("AnStudiu", "An Studii", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("Semestru", "Semestru", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("Id", "ID", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("Email", "Email", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("FirstName", "First Name", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("LastName", "Last Name", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("Age", "Age", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("Cnp", "CNP", true));
            TabeleStudenti.Columns.Add(CreateTextBoxColumn("PhoneNumber", "Phone Number", true));

            // Add discipline columns (editable)
            foreach (var disciplina in semestruData.Discipline)
            {
                TabeleStudenti.Columns.Add(CreateTextBoxColumn(disciplina.NumeDisciplina, disciplina.NumeDisciplina, false));
            }

            // Bind the users to the DataGridView
            TabeleStudenti.DataSource = new BindingList<User>(users);
        }

        private DataGridViewTextBoxColumn CreateTextBoxColumn(string dataPropertyName, string headerText, bool readOnly)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                ReadOnly = readOnly,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Open file dialog for saving Excel file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    // Create a new Excel package
                    using (var excelPackage = new OfficeOpenXml.ExcelPackage())
                    {
                        // Add a worksheet
                        var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                        // Add column headers
                        for (int i = 0; i < TabeleStudenti.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = TabeleStudenti.Columns[i].HeaderText;
                        }

                        // Add data rows
                        for (int i = 0; i < TabeleStudenti.Rows.Count; i++)
                        {
                            for (int j = 0; j < TabeleStudenti.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = TabeleStudenti.Rows[i].Cells[j].Value;
                            }
                        }

                        // Save the Excel package to the selected file
                        excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                    }

                    MessageBox.Show("Datele au fost exportate într-un fișier Excel cu succes.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare în timpul exportului datelor în fișier Excel: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class User
    {
        public string ProgramStudiu { get; set; }
        public string CicluInvatamant { get; set; }
        public string AnStudiu { get; set; }
        public string Semestru { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Cnp { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Disciplina
    {
        public string Id { get; set; }
        public string NumeDisciplina { get; set; }
        public int NumarCredite { get; set; }
        public string CodDisciplina { get; set; }
        public string AcronimDisciplina { get; set; }
    }

    public class SemestruResponse
    {
        public string NumeSemestru { get; set; }
        public List<Disciplina> Discipline { get; set; }
    }
}
