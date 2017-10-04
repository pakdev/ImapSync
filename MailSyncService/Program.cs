using MailSync;
using Topshelf;

namespace MailSyncService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(service =>
            {
                service.Service<ImapSync>(s =>
                {
                    s.ConstructUsing(name => new ImapSync());
                    s.WhenStarted(i => i.Start());
                    s.WhenStopped(i => i.Stop());
                });

                service.RunAsLocalSystem();

                service.SetDescription("MailSync");
                service.SetDisplayName("MailSync");
                service.SetServiceName("MailSync");
            });
        }
    }
}
