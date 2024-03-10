using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Get_Facebook_UDID_by_Anh2Ten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string apiUrl = "https://api.dailythuonghien.com/fb/api.php";
            string username = textBox1.Text;

            using (HttpClient client = new HttpClient())
            {
                var parameters = new System.Collections.Generic.Dictionary<string, string>
                {
                    { "username", username }
                };

                var content = new FormUrlEncodedContent(parameters);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(requestUri: apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        richTextBox1.Text = result;
                        Clipboard.SetText(result);
                    }
                    else
                    {
                        richTextBox1.Text = "Error: " + response.StatusCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    richTextBox1.Text = "Error: " + ex.Message;
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
