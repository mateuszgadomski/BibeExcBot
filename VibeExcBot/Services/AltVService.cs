using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using VibeExcBot.Interfaces;

namespace VibeExcBot.Services
{
    internal class AltVService : IAltVService
    {
        private const int SW_RESTORE = 9;
        private const int SW_MINIMIZE = 6;
        private readonly string _windowName = "alt:V Multiplayer";

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        [DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO fwInfo);

        public void RestoreAltVWindow(string? message = default)
        {
            IntPtr hWnd = FindWindow(null, _windowName);

            if (hWnd != IntPtr.Zero)
            {
                RestoreAndFocusWindow(hWnd);

                if (!string.IsNullOrEmpty(message))
                {
                    SendMessage(message);
                }
                else
                {
                    SendKeys.SendWait("{ESCAPE}");
                }

                ShowWindow(hWnd, SW_MINIMIZE);
            }
            else
            {
                MessageBox.Show($"Nie znaleziono okna {_windowName}. Wejdź na serwer i zaloguj się na postać.");
            }
        }

        public void NotifyUser()
        {
            SystemSounds.Beep.Play();
            FlashWindow();
        }

        private static void RestoreAndFocusWindow(IntPtr hWnd)
        {
            ShowWindow(hWnd, SW_RESTORE);
            Thread.Sleep(2000);
            SetForegroundWindow(hWnd);
            Thread.Sleep(1000);
            SendKeys.SendWait("t");
            Thread.Sleep(1000);
            SendKeys.SendWait("{BACKSPACE}");
        }

        private static void SendMessage(string message)
        {
            Thread.Sleep(1000);
            foreach (char c in message)
            {
                SendKeys.SendWait(c.ToString());
                Thread.Sleep(50);
            }
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
        }

        private static void FlashWindow()
        {
            IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;

            FLASHWINFO fwInfo = new()
            {
                cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd = hWnd,
                dwFlags = 0x00000001 | 0x00000004,
                uCount = 5,
                dwTimeout = 1
            };

            FlashWindowEx(ref fwInfo);
        }
    }
}
