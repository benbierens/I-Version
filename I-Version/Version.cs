using System.Reflection;

namespace IVersion
{
    public interface IVersion
    {
        VersionInfo GetVersionInfo(Assembly assembly);
    }

    public class Version : IVersion
    {
        public VersionInfo GetVersionInfo(Assembly assembly)
        {
            var version = GetVersion(assembly);
            var runtimeVersion = GetRuntimeVersion(assembly);

            var versionInfo = new VersionInfo
            {
                Version = version,
                RuntimeVersion = runtimeVersion,
                Git = new GitInfo
                {
                    Commit = new CommitInfo
                    {
                        id = runtimeVersion.Split('-').Length > 1 ? runtimeVersion.Split('-')[1] : runtimeVersion
                    }
                }
            };

            return versionInfo;
        }
        
        private static string GetVersion(Assembly assembly)
        {
            var version = assembly.GetName().Version;
            if (version == null) return "Unknown";
            return version.ToString();
        }

        private static string GetRuntimeVersion(Assembly assembly)
        {
            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute == null) return "Unknown";
            return attribute.InformationalVersion;
        }
    }

    [Serializable]
    public class VersionInfo
    {
        public string Version { get; set; } = "";
        public string RuntimeVersion { get; set; } = "";
        public GitInfo Git { get; set; } = new GitInfo();
    }

    [Serializable]
    public class GitInfo
    {
        public CommitInfo Commit { get; set; } = new CommitInfo();
    }

    [Serializable]
    public class CommitInfo
    {
        public string id { get; set; } = "";
    }
}
