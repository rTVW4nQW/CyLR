using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace CyLR.Sftp
{
    internal static class Sftp
    {
        public static void SendUsingSftp(Stream archiveStream, string sftpServer, int port, string userName, string userPassword, string destinationPath)
        {
            var SftpKey = new PrivateKeyFile(userPassword);
            var client = new SftpClient(sftpServer, port, userName, SftpKey);
            client.Connect();
            client.UploadFile(archiveStream, destinationPath);
            client.Disconnect();
        }
    }
}
