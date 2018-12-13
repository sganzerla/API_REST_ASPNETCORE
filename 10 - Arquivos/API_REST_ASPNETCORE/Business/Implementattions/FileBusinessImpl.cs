using System.IO;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class FileBusinessImpl : IFileBusiness
    {

        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fulPath = path + "\\Billing Management Console - Novembro.pdf";
            return File.ReadAllBytes(fulPath);
        }
    }
}
