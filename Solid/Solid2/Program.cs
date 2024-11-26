using System;

//Який принцип S.O.L.I.D. порушено? Виправте!

/* Тут порушено принципи S та О, тобто принцип Принцип єдиного обов’язку(The Single Responsibility Principle) 
 * та принцип відкритості/закритості (The Open Closed Principle). З першим ми вже стикались в 1 завданні,
 * а другий принцип каже: Класи потрібно проєктувати так, щоб згодом мати можливість змінювати поведінку класу, 
 * не змінюючи його код. Тут щоб змінити логування треба буде випавляти Send у EmailSender. Це ще й створює залежність.
 * Для виправлення ситуації будемо використовувати інверсію залежностей (він каже: Абстракції не повинні залежати
 * від деталей, а деталі повинні залежати від абстракцій.). Мусимо передати логування через інтерфейс.
 */
namespace Solid2
{
    class Email
    {
        public string Theme { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    // Інтерфейс для логування
    interface ILogger
    {
        void Log(string message);
    }

    // Реалізація логування через консоль
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    // для відправлення повідомлень
    class EmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(Email email)
        {
            _logger.Log($"Email from '{email.From}' to '{email.To}' was sent. Theme: {email.Theme}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
            Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };

            ILogger logger = new ConsoleLogger();
            EmailSender emailSender = new EmailSender(logger);

            emailSender.Send(e1);
            emailSender.Send(e2);

            Console.ReadKey();
        }
    }
}