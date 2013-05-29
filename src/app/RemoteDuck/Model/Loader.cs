using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RemoteDuck.Model
{
    public class Loader
    {
        public static bool Load(string tempPath)
        {
            var app = new FileInfo(Application.ExecutablePath);

            if (Application.StartupPath == tempPath)
                return true;

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            DeleteAllOldInstances(tempPath, app);

            var sourceFileName = Path.Combine(Application.StartupPath, app.Name);
            var destFileName = GetDestFileName(app.Name, tempPath);

            File.Copy(sourceFileName, destFileName, false);
            Process.Start(destFileName);
            return false;
        }

        static void DeleteAllOldInstances(string tempPath, FileInfo app)
        {
            foreach (var file in Directory.GetFiles(tempPath).Where(x => x.Contains(app.Name)))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                }
            }
        }

        static string GetDestFileName(string appName, string tempPath)
        {
            var i = 0;
            var destFileName = Path.Combine(tempPath, appName);
            while (File.Exists(destFileName))
                destFileName = Path.Combine(tempPath, "_" + i++ + appName);

            return destFileName;
        }
    }
}