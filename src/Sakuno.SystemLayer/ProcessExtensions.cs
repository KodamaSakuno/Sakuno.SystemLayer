using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sakuno.SystemLayer
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ProcessExtensions
    {
        public static Task<int> WaitForExitAsync(this Process process)
        {
            if (process == null)
                throw new ArgumentNullException(nameof(process));

            if (process.HasExited)
                return Task.FromResult(process.ExitCode);

            var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

            process.Exited += OnProcessExited;
            process.EnableRaisingEvents = true;

            if (process.HasExited)
                tcs.TrySetResult(process.ExitCode);

            return tcs.Task;

            void OnProcessExited(object sender, EventArgs e)
            {
                process.Exited -= OnProcessExited;

                tcs.TrySetResult(process.ExitCode);
            }
        }
    }
}
