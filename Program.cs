using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            VoiceMessage mess1 = new VoiceMessage();
            mess1.Send();
          
            EmailMessage mess2 = new EmailMessage();
            mess2.Send();
            Console.ReadLine();
        }

        interface IMessage
        {
            void Send();
            string ToAddress { get; set; }
            string FromAddress { get; set; }
        }
        interface IVoiceMessage : IMessage
        {
            byte[] Voice { get; set; }
        }
        interface ITextMessage : IMessage
        {
            string Text { get; set; }
        }

        interface IEmailMessage : ITextMessage
        {
            string Subject { get; set; }
        }

        class VoiceMessage : IVoiceMessage
        {
            public string ToAddress { get; set; }
            public string FromAddress { get; set; }

            public byte[] Voice { get; set; }
            public void Send()
            {
                Console.WriteLine("Передача голосовой почты");
            }
        }
        class EmailMessage : IEmailMessage
        {
            public string Text { get; set; }
            public string Subject { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }

            public void Send()
            {
                Console.WriteLine("Отправляем по Email сообщение: {0}", Text);
            }
        }

        class SmsMessage : ITextMessage
        {
            public string Text { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }
            public void Send()
            {
                Console.WriteLine("Отправляем по Sms сообщение: {0}", Text);
            }
        }
    }
}
