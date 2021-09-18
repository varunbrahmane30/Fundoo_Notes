using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace CommonLayer.MSMQ
{
    public class MsmqOperation
    {
        //private IConfiguration _config;
        //public MsmqOperation(IConfiguration config)
        //{
        //    _config = config;
        //}

        MessageQueue msmq = new MessageQueue();
        

        public void sendingData(string token)
        {
            msmq.Path = @".\private$\tokenQueue";
            if (!MessageQueue.Exists(msmq.Path))
            { 
                //if not Exists
                MessageQueue.Create(msmq.Path);
            }

            sendtoken(token);
        }

        public void sendtoken(string token)
        {
            //for adding XML formatter to msg
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;
            //for sending token to the queue 
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();
        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                //getting token from receiver
                var msg = msmq.EndReceive(e.AsyncResult);

                string token = msg.Body.ToString();
                //sending a mail via SMTP
                mailSending(token);
                msmq.BeginReceive();
            }

            catch (MessageQueueException)
            { 
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

        private void mailSending(string token)
        {
            MailMessage mailmsg = new MailMessage("sendertohost@gmail.com", "sendertohost@gmail.com");
            mailmsg.Subject = "Reset password link mail";
            mailmsg.Body = "https://localhost:44365/api/User/forgotPassword"+token;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                //_config["UserName"]
                //_config["login:Password"]

                UserName = "sendertohost@gmail.com",
                Password = "Test@123"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailmsg);
        }
    }

}
