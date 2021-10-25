using Microsoft.AspNetCore.Mvc;
using relicarioApi.Data;
using relicarioApi.Repositories.System.Parameter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IParametersRepository _parameterRepository;

        public EmailController(IParametersRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        [HttpPost]
        public bool SendEmail(string message, string name, string email, string phone, string page, string subject)
        {
            try
            {
                var fromAddress = new MailAddress(_parameterRepository.GetByParam("Email_Send")?.Value, "Relicário Email Contato");
                var toAddress = new MailAddress(_parameterRepository.GetByParam("Email_Receive")?.Value, "Relicário Recebido");
                var fromPassword = _parameterRepository.GetByParam("Email_Send_Password").Value;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                var body = @"
                           <section>
                             <div>
                               <div>
                                 <h2>Nome: " + name + "</h2>" +
                               " <h3>Email: " + email + "</h3> " +
                               " <h3>Telefone: " + phone + "</h3> " +
                               " <h4>Página: " + page + "</h4> " +
                               " <p>" + message + "</p> " +
                               "</div> " +
                             "</div> " +
                           "</section> ";
                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(mailMessage);
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
