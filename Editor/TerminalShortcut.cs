using System.Diagnostics;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace QOL.Editor
{
    public static class TerminalShortcut
    {
        [MenuItem("QOL/Open Terminal At Project ^`")]
        public static void OpenTerminalAtRoot()
        {
            string path = GetProjectPath();
            
            ProcessStartInfo startInfo = new()
            {
                FileName = "wt",
                Arguments = $"-d {path}",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }

        [MenuItem("QOL/Open Explorer at root ^#&f")]
        public static void OpenTerminalAtDirectory()
        {
            string path = GetProjectPath();
            ProcessStartInfo psi = new()
            {
                FileName = "explorer.exe",
                Arguments = $"-select,{path}",
                UseShellExecute = false,
            };
            Process.Start(psi);
        }
        
        private static string GetProjectPath()
        {
            var path = Application.dataPath;
            var sagments = path.Split('/')[..^1];
            path = string.Join('/', sagments);
            return path;
        }
    }
}