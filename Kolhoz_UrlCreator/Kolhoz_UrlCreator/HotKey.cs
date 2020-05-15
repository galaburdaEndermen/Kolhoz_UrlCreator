using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolhoz_UrlCreator
{
    public sealed class HotKey : IMessageFilter, IDisposable
    {
        public event KeyEventHandler HotKeyPressed;
        public event EventHandler KeyChanged;
        public event EventHandler KeyModifierChanged;

        private readonly int _id;

        #region Native win32 API

        private const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [Flags]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        #endregion

        public IntPtr Handle { get; set; }

        private Keys _key = Keys.None;
        private KeyModifiers _keyModifier;
        public bool isKeyRegistered = false;

        public HotKey(IntPtr handle)
        {
            Handle = handle;
            _id = GetHashCode();
            Application.AddMessageFilter(this);
        }

        public void Dispose()
        {
            Application.RemoveMessageFilter(this);
            if (isKeyRegistered && !UnregisterHotKey(Handle, _id))
                throw new ApplicationException("Failed to unregister hotkey");
            isKeyRegistered = false;
        }

        public void RegisterHotKey()
        {
            if (_key == Keys.None || _keyModifier == KeyModifiers.None)
            {
                return;
            }
            if (isKeyRegistered && !UnregisterHotKey(Handle, _id))
                throw new ApplicationException("Failed to unregister hotkey");
            if (!RegisterHotKey(Handle, _id, _keyModifier, _key))
                throw new ApplicationException("Failed to register hotkey");
            isKeyRegistered = true;
        }

        [Bindable(true), Category("HotKey")]
        public Keys Key
        {
            get { return _key; }
            set
            {
                if (_key != value)
                {
                    _key = value;
                    OnKeyChanged(new EventArgs());
                }
            }
        }

        [Bindable(true), Category("HotKey")]
        public KeyModifiers KeyModifier
        {
            get { return _keyModifier; }

            set
            {
                if (_keyModifier != value)
                {
                    _keyModifier = value;
                    OnKeyModifierChanged(new EventArgs());
                }
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    if ((int)m.WParam == _id)
                    {
                        KeyEventArgs args = new KeyEventArgs((IsButtonDown(m.LParam, KeyModifiers.Alt) ? Keys.Alt : Keys.None)
                                | (IsButtonDown(m.LParam, KeyModifiers.Control) ? Keys.Control : Keys.None)
                                | (IsButtonDown(m.LParam, KeyModifiers.Shift) ? Keys.Shift : Keys.None) | Key);

                        OnHotKeyPressed(args);
                        return true;
                    }
                    break;
            }
            return false;
        }

        private static bool IsButtonDown(IntPtr ptr, KeyModifiers keyModifiers)
        {
            return Convert.ToBoolean(((long)ptr) & (long)keyModifiers);
        }

        private void OnHotKeyPressed(KeyEventArgs e)
        {
            HotKeyPressed?.Invoke(this, e);
        }

        private void OnKeyChanged(EventArgs e)
        {
            RegisterHotKey();
            KeyChanged?.Invoke(this, e);
        }

        private void OnKeyModifierChanged(EventArgs e)
        {
            RegisterHotKey();
            KeyModifierChanged?.Invoke(this, e);
        }
    }
}
