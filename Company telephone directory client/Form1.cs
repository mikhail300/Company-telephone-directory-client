using System.Text.Json;

namespace Company_telephone_directory_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:49153/api/Divisions/");
                //HTTP GET
                var responseTask = client.GetAsync("All");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Division[]>();
                    readTask.Wait();

                    var divisions = readTask.Result;
                    textBox1.Text = textBox1.Text + JsonSerializer.Serialize(divisions);

                    //foreach (var division in divisions)
                 //   {
                    //    textBox1.Text = textBox1.Text + JsonSerializer.Serialize( division).;
                        //textBox1.Text = textBox1.Text + division.title;
                        //textBox1.Text = textBox1.Text + division.parent_id;
                  //  }
                }
            }
        }
    }
}