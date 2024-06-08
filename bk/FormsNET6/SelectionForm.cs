using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsNET6;
using Newtonsoft.Json;

namespace FormsNET6
{
    public partial class SelectionForm : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "https://localhost:7063/api/"; // Adresa de bază a API-ului

        private string semestruId;

        private LoginForm loginForm;
        private List<CicluInvatamant> cicluriInvatamant; // Variabila globala pentru a stoca ciclurile de invatamant
        CicluInvatamant cicluSelectat;
        private AnStudiuResponse anStudiuResponse;

        public SelectionForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            LoadCicluriInvatamantAsync(); // Încarcă ciclurile de învățământ când formularul este inițializat
        }

        public SelectionForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            LoadCicluriInvatamantAsync(); // Încarcă ciclurile de învățământ când formularul este inițializat
        }

        private async Task LoadCicluriInvatamantAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("CicluInvatamant"); // Endpoint-ul pentru cicluri de învățământ
                response.EnsureSuccessStatusCode(); // Aruncă o excepție dacă cererea nu este de succes

                var responseData = await response.Content.ReadAsStringAsync();
                cicluriInvatamant = JsonConvert.DeserializeObject<List<CicluInvatamant>>(responseData);

                // Adaugă numele ciclurilor de învățământ în ComboBox
                foreach (var ciclu in cicluriInvatamant)
                {
                    CicluriDeInvDropDown.Items.Add(ciclu.Nume);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Dacă ai un formular de login, poți să-l arăți din nou
            // De exemplu, dacă avem un formular de login numit loginForm
            loginForm.Show();
        }


        private void CicluriDeInvDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obține ciclul de învățământ selectat din combobox
            cicluSelectat = cicluriInvatamant[CicluriDeInvDropDown.SelectedIndex];

            // Șterge programele de studiu existente din alt combobox sau de altfel de afișare
            ProgrameStudiiDropDown.Items.Clear();

            // Adaugă programele de studiu asociate ciclului de învățământ selectat în alt combobox sau de altfel de afișare
            foreach (var programStudiu in cicluSelectat.ProgramStudiuIds)
            {
                ProgrameStudiiDropDown.Items.Add(programStudiu.Name);
            }
        }


        private async Task<AnStudiuResponse> LoadAnStudiuAsync(string anStudiuId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"AnStudiu/id?id={anStudiuId}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                var anStudiuResponse = JsonConvert.DeserializeObject<AnStudiuResponse>(responseData);
                return anStudiuResponse;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async Task LoadAniStudiuAsync(List<string> anStudiuIds)
        {
            try
            {
                AniiDeStudiuDropDown.Items.Clear();

                foreach (var anStudiuId in anStudiuIds)
                {
                    var anStudiuResponse = await LoadAnStudiuAsync(anStudiuId);
                    if (anStudiuResponse != null)
                    {
                        AniiDeStudiuDropDown.Items.Add(anStudiuResponse.AnStudiuName);
                        // Stocăm informațiile despre semestre pentru utilizare ulterioară
                        foreach (var semestru in anStudiuResponse.Semestre)
                        {
                            // Aici poți face ce dorești cu informațiile despre semestre
                            // De exemplu, le poți stoca într-o listă sau în altă structură de date
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProgrameStudiiDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProgrameStudiiDropDown.SelectedIndex >= 0)
            {
                ProgramStudiu programSelectat = cicluSelectat.ProgramStudiuIds[ProgrameStudiiDropDown.SelectedIndex];
                AniiDeStudiuDropDown.Items.Clear();
                LoadAniStudiuAsync(programSelectat.AnStudii);
            }
        }

        private async void AniiDeStudiuDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AniiDeStudiuDropDown.SelectedIndex >= 0)
            {
                string anStudiuId = cicluSelectat.ProgramStudiuIds[ProgrameStudiiDropDown.SelectedIndex].AnStudii[AniiDeStudiuDropDown.SelectedIndex];

                // Încarcă semestrele corespunzătoare anului de studiu selectat
                await LoadSemestreAsync(anStudiuId);
            }
        }

        private async Task LoadSemestreAsync(string anStudiuId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"AnStudiu/id?id={anStudiuId}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                anStudiuResponse = JsonConvert.DeserializeObject<AnStudiuResponse>(responseData);

                // Șterge semestrele existente din combobox
                SemestruDropDown.Items.Clear();

                // Adaugă numele semestrelor în combobox
                foreach (var semestru in anStudiuResponse.Semestre)
                {
                    SemestruDropDown.Items.Add(semestru.NumeSemestru);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (CicluriDeInvDropDown.Text == "" || ProgrameStudiiDropDown.Text == ""
                || AniiDeStudiuDropDown.Text == "" || SemestruDropDown.Text == "")
            {
                MessageBox.Show("Toate campurile trebuiesc selectate", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Tabele t = new Tabele(CicluriDeInvDropDown.Text, ProgrameStudiiDropDown.Text, AniiDeStudiuDropDown.Text
                                      , SemestruDropDown.Text, semestruId);
                t.Show();
            }

        }

        private void SemestruDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            semestruId = anStudiuResponse.Semestre[SemestruDropDown.SelectedIndex].Id;
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }

    public class ProgramStudiu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> AnStudii { get; set; }
    }

    public class CicluInvatamant
    {
        public string Id { get; set; }
        public string Nume { get; set; }
        public List<ProgramStudiu> ProgramStudiuIds { get; set; }
    }

    public class AnStudiuResponse
    {
        public string AnStudiuName { get; set; } = string.Empty;
        public List<Semestru> Semestre { get; set; } = new List<Semestru>();
    }

    public class Semestru
    {
        public string Id { get; set; }
        public string NumeSemestru { get; set; }
        public List<string> Discipline { get; set; } = new List<string>();
    }




}
