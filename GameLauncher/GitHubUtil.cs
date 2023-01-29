using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Octokit;
using System.Threading.Tasks;

namespace GameLauncher
{
    internal class GitHubUtil
    {
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("AltronixEngineLauncher"));

        public static string getLastReleaseAssetUrl()
        {
            var release = client.Repository.Release.GetLatest("Altronix-Team", "FNF-AltronixEngine").GetAwaiter().GetResult(); 
            var enumerator = release.Assets.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var cur = enumerator.Current;
                if (cur.Name.Contains("Engine"))
                {
                    return cur.BrowserDownloadUrl;
                }
            }
            return null;
        }

        public static string getLastReleaseVersion()
        {
            var release = client.Repository.Release.GetLatest("Altronix-Team", "FNF-AltronixEngine").GetAwaiter().GetResult();
            return release.Name;
        }

        public async Task getAllReleases()
        {
            var releases = await client.Repository.Release.GetAll("Altronix-Team", "FNF-AltronixEngine");
        }
    }
}
