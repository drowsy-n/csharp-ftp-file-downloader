using System.IO;
using System.Net;

class FtpFileDownloader {

    private void FtpFileDownload()
    {
        try
        {
            const string url = "ftp://yourFTP";
            NetworkCredential credentials = new NetworkCredential("userName", "password");

            // Download the file
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = credentials;
            request.EnableSsl = true; // SSL 여부- 명시적 FTP(FTPES)이면 true
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            using (Stream ftpStream = request.GetResponse().GetResponseStream())
            using (Stream fileStream = File.Create(@"C:\test\test.jpg")) // 파일 다운 받을 경로 입력하세요.
            {
                byte[] buffer = new byte[10240];
                int read;
                while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, read);
                    int position = (int)fileStream.Position;
                }
            }
        }
        catch
        {
        }
    }
}
