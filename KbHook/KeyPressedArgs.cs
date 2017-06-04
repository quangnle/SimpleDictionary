using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace KbHook
{
    public class KeyPressedArgs : EventArgs
    {
        public int Modifiers { get; private set; }
        public Keys KeyPressed { get; private set; }

        public KeyPressedArgs(Keys key, int modifiers)
        {
            KeyPressed = key;
            Modifiers = modifiers;
        }
    }

}
