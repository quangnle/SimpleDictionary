using Dictionary.Properties;
using KbHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    class Processor : IDisposable
    {   
        private NotifyIcon _nIcon;
        private ContextMenuStrip _menu;
        private Hook _listener;
        private Dict _dict;

        public Processor()
        {
            _dict = new Dict();
            _dict.Load("ev.dat");

            _nIcon = new NotifyIcon();

            _menu = CreateMenu();
            _nIcon.ContextMenuStrip = _menu;

            _nIcon.Icon = Resources.TrayIcon;

            _nIcon.Text = "My Simple dictionary";
            _nIcon.Visible = true;

            _nIcon.MouseClick += _nIcon_MouseClick;
        }

        private void _nIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowMenu();
        }

        private ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();
            
            var item = new ToolStripMenuItem();
            item.Text = "Start";
            item.Click += new EventHandler(Start_Click);
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Stop";
            item.Click += new EventHandler(Stop_Click);
            menu.Items.Add(item);

            // add the splitter
            menu.Items.Add(new ToolStripSeparator());

            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new EventHandler(Exit_Click);
            menu.Items.Add(item);

            return menu;
        }

        private void Exit_Click(object sender, EventArgs e)
        {   
            if (_listener == null)
            {
                _listener.UnHookKeyboard();
                _listener = null;
            }
                
            Application.Exit();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (_listener == null)
            {
                _listener.UnHookKeyboard();
                _listener = null;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            _listener = new Hook();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
        }

        private void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            var key = e.KeyPressed;
            var ctrlPressed = (e.Modifiers & (int)Modifiers.Control) == (int)Modifiers.Control;
            if (key == Keys.T && ctrlPressed)
            {
                var st = Clipboard.GetText(TextDataFormat.Text);

                var result = _dict.Lookup(st);
                var f = new FrmMain(result.Source, result.Phonetic, result.Meaning);
                
                f.Show();
            }
        }

        public void ShowMenu()
        {
            var x = Screen.PrimaryScreen.Bounds.Width - 50;
            var y = Screen.PrimaryScreen.Bounds.Height - 50;
            _menu.Show(x, y);
        }

        public void Dispose()
        {
            _nIcon.Dispose();
        }
    }
}
