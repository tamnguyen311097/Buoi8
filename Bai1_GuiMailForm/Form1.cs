using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Bai1_GuiMailForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {             
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("nguyenthanhtam311097s2qm@gmail.com", txtPassword.Text);//txtSender.Text

                MailMessage message = new MailMessage("nguyenthanhtam311097s2qm@gmail.com", "nguyenthanhtam311097s2qm@gmail.com");// txtTo.Text
                message.Subject = txtSubject.Text;
                message.Body = txtBody.Text;
                
                if(listBox1.Items.Count > 0)
                {
                    foreach (var filename in listBox1.Items)
                    {
                        if (File.Exists(filename.ToString()))
                        {
                            message.Attachments.Add(new Attachment(filename.ToString()));
                        }
                    }
                }
                mailclient.Send(message);
                MessageBox.Show("Mail sent successfully!");

                /*
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(txtSender.Text);
                mail.To.Add(txtTo.Text);
                mail.Subject = "Test";
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(txtSender.Text, txtPassword.Text);
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                MessageBox.Show("Mail sent successfully!");*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(),"Error");
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtAttach.Text = open.FileName;
            }

            MailMessage message = new MailMessage();
            Attachment file = new Attachment(open.FileName);
            message.Attachments.Add(file);*/

            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var filename in openFileDialog1.FileName)
                {
                    listBox1.Items.Add(filename.ToString());
                }
            }
        }
    }
}
