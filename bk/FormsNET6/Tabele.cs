using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace FormsNET6
{
    public partial class Tabele : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "https://localhost:7063/api/";
        private string _query;
        private string _semestruId;
        private bool _columnsSetup = false;

        private string _programStudiu;
        private string _cicluInvatamant;
        private string _anStudiu;
        private string _semestru;

        public Tabele(string _cicluInvatamant, string _programStudiu, string _anStudiu, string _semestru, string semestruId)
        {
            InitializeComponent();
            _query = $"User/{_cicluInvatamant}/{_programStudiu}/{_anStudiu}/{_semestru}";
            _semestruId = semestruId;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            this._programStudiu = _programStudiu;
            this._cicluInvatamant = _cicluInvatamant;
            this._anStudiu = _anStudiu;
            this._semestru = _semestru;
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

                // Set the pre-filled values
                if (users.Any())
                {
                    var firstUser = users.First();
                    _programStudiu = firstUser.ProgramStudiu;
                    _cicluInvatamant = firstUser.CicluInvatamant;
                    _anStudiu = firstUser.AnStudiu;
                    _semestru = firstUser.Semestru;
                }

                // Setup DataGridView columns if not already set up
                if (!_columnsSetup)
                {
                    SetupDataGridView(semestruData);
                    _columnsSetup = true;
                }

                // Bind the users to the DataGridView
                TabeleStudenti.DataSource = new BindingList<User>(users);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SetupDataGridView(SemestruResponse semestruData)
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

        private async void AddUserButton_Click(object sender, EventArgs e)
        {
            using (var addUserForm = new AddUserForm(_programStudiu, _cicluInvatamant, _anStudiu, _semestru))
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    var newUser = addUserForm.NewUser;
                    try
                    {
                        var jsonContent = JsonConvert.SerializeObject(newUser);
                        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        var response = await _httpClient.PostAsync($"{_baseAddress}User/", httpContent);
                        response.EnsureSuccessStatusCode();

                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Add new user to the existing DataGridView's data source
                        var users = (BindingList<User>)TabeleStudenti.DataSource;
                        users.Add(newUser);
                        LoadDataAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

        private async void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    using (var excelPackage = new ExcelPackage(new System.IO.FileInfo(openFileDialog.FileName)))
                    {
                        var worksheet = excelPackage.Workbook.Worksheets[0];
                        var rows = worksheet.Dimension.Rows;
                        var columns = worksheet.Dimension.Columns;

                        // Get the list of disciplines from the semester
                        var response = await _httpClient.GetAsync($"{_baseAddress}Semestru/{_semestruId}");
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var semestruData = JsonConvert.DeserializeObject<SemestruResponse>(responseBody);

                        // Configure DataGridView columns
                        TabeleStudenti.Rows.Clear();
                        TabeleStudenti.Columns.Clear();

                        // Add columns for user details
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

                        // Add columns for disciplines
                        foreach (var disciplina in semestruData.Discipline)
                        {
                            TabeleStudenti.Columns.Add(CreateTextBoxColumn(disciplina.NumeDisciplina, disciplina.NumeDisciplina, false));
                        }

                        // Create a list to store imported users
                        List<User> importedUsers = new List<User>();

                        // Import data from Excel
                        for (int i = 2; i <= rows; i++) // Start from row 2 because row 1 contains column titles
                        {
                            var user = new User
                            {
                                ProgramStudiu = worksheet.Cells[i, 1].Text,
                                CicluInvatamant = worksheet.Cells[i, 2].Text,
                                AnStudiu = worksheet.Cells[i, 3].Text,
                                Semestru = worksheet.Cells[i, 4].Text,
                                Id = worksheet.Cells[i, 5].Text,
                                Email = worksheet.Cells[i, 6].Text,
                                FirstName = worksheet.Cells[i, 7].Text,
                                LastName = worksheet.Cells[i, 8].Text,
                                Age = int.TryParse(worksheet.Cells[i, 9].Text, out var age) ? age : 0,
                                Cnp = worksheet.Cells[i, 10].Text,
                                PhoneNumber = worksheet.Cells[i, 11].Text,
                                Discipline = new Dictionary<string, string>()
                            };

                            // Add disciplines
                            for (int j = 12; j <= Math.Min(columns, 11 + semestruData.Discipline.Count); j++)
                            {
                                string disciplineName = TabeleStudenti.Columns[j - 1].HeaderText;
                                string grade = worksheet.Cells[i, j].Text;
                                user.Discipline[disciplineName] = grade;
                            }

                            importedUsers.Add(user);
                        }

                        // Bind the imported users to the DataGridView
                        TabeleStudenti.DataSource = new BindingList<User>(importedUsers);

                        MessageBox.Show("Datele au fost importate cu succes.", "Import Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare în timpul importului datelor din fișierul Excel: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public Dictionary<string, string> Discipline { get; set; } = new Dictionary<string, string>();
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
