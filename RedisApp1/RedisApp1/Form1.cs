using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using ServiceStack.Redis;

namespace RedisApp1
{
    public partial class Form1 : Form
    {
        private string host;
        private int port;
        private RedisEndpoint redisEndpoint;

        public Form1()
        {
            InitializeComponent();

            host = ConfigurationManager.AppSettings.Get("host");
            port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("port"));
            redisEndpoint = new RedisEndpoint(host, port);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            string value = textBox2.Text;
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
                return;
            
            using (var client = new RedisClient(redisEndpoint))
            {
                //client.Set(key, value);
                client.SetValue(key, value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string key = textBox3.Text;

            using (var client = new RedisClient(redisEndpoint))
            {
                var value = client.GetValue(key);
                textBox4.Text = value;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
