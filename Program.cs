using System.Net;
using System.Net.Mail;
using System;

namespace EnvioEmailComAnexo
{
    class Program
    {
        static void Main(string[] args)
        {
            string from = "E-mail de quem está enviando";
            string fromName = "Nome";

            string to = "Para quem irá ser enviado";

            string smtpUserName = "E-mail de quem está enviando";
            string smtpPassWord = "Senha do e-mail";
            string configSet= "ConfigSet";
            string host = "Insira o host padrão do email utilizado";

            int port = 587;

            string subject = "Teste envio de email utilizando C#";

            string body = "Corpo da mensagem";


            MailMessage mensagem = new MailMessage();
            mensagem.IsBodyHtml = true;
            mensagem.From = new MailAddress(from, fromName);
            mensagem.To.Add(new MailAddress(to));
            mensagem.Subject = subject;
            mensagem.Body = body;

            mensagem.Attachments.Add(new Attachment(@"C:\caminho do repositorio no qual oarquivo se encontra"));

            mensagem.Headers.Add("X-SES-CONFIGURATION-SET", configSet);

            using (var client = new System.Net.Mail.SmtpClient(host, port))
            {
                client.Credentials = new NetworkCredential(smtpUserName, smtpPassWord);
                client.EnableSsl = true;

                try
                {
                    Console.WriteLine("Enviando E-mail...");
                    client.Send(mensagem);
                    Console.WriteLine("E-mail enviado");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("O E-mail não foi enviado");
                    Console.WriteLine("Mensagem de Erro " + ex.Message);
                }
            }
        }
    }
}
