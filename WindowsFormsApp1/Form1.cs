using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string ips = "1"; // unico ip ou uma lista 
       
        public Form1()
        {
            InitializeComponent();
        }


        public static void SendWebhook(string url, string msg, string usename)
        {



        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var ip = await httpClient.GetStringAsync("https://api.ipify.org"); /// api ip
            if (ip.Equals(ips)) // se o ip que a api requisitou foi igual o mostrado na string entao 
            {
                MessageBox.Show($"meu ip {ip}");
            }
            else // se nao ele gera uma mensagem no discord que informa o ip de quem apertou o botao 
            {
                string web = ""; //link webhook discord 
                WebRequest wr = (HttpWebRequest)WebRequest.Create(web);
                wr.ContentType = "application/json";
                wr.Method = "POST";
                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        username = "Log App",
                        embeds = new[]
                        {
                        new
                        {
                            desccription = "Test desk",
                            title = $"Um Usuario Sem registro esta tentando usar o App : ||{ip}||",
                            color = "6464385"
                        }
                    }
                    });
                    sw.Write(json);
                }
                var response = (HttpWebResponse)wr.GetResponse();

            }

        }
    }
}

