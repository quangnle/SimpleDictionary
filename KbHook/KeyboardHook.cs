using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace KbHook
{
    public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

    public struct KBDLLHOOKSTRUCT
    {
        public int vkCode;
        int scanCode;
        public int flags;
        int time;
        int dwExtraInfo;
    }

    public enum Modifiers
    {
        Null = 0,
        Capslock = 1,
        Shift = 2,
        Control = 4,
        Alternate = 8
    }

    public class Hook
    {
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        // modifier key constants
        private const int VK_SHIFT = 0x10;
        private const int VK_CONTROL = 0x11;
        private const int VK_MENU = 0x12;
        private const int VK_CAPITAL = 0x14;

        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);
        

        public event EventHandler<KeyPressedArgs> OnKeyPressed;
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public Hook()
        {                        
            _proc = HookCallback;
        }

        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookKeyboard()
        {            
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {                
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {            
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
               var modifier = (int)Modifiers.Null;
                if (!(lParam.vkCode >= 160 && lParam.vkCode <= 164))
                {
                    if ((GetKeyState(VK_CAPITAL) & 0x1000) != 0)
                        modifier = modifier | (int)Modifiers.Capslock;
                    if ((GetKeyState(VK_SHIFT) & 0x8000) != 0)
                        modifier = modifier | (int)Modifiers.Shift;
                    if ((GetKeyState(VK_CONTROL) & 0x8000) != 0)
                       modifier = modifier | (int)Modifiers.Control;
                    if ((GetKeyState(VK_MENU) & 0x8000) != 0)
                        modifier = modifier | (int)Modifiers.Alternate;

                }

                if (OnKeyPressed != null)
                    OnKeyPressed(this, new KeyPressedArgs((Keys)lParam.vkCode, modifier));
            }

            return CallNextHookEx(_hookID, nCode, wParam, ref lParam);
        }

    }
}
