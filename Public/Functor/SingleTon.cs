using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonUtilLib.ThreadSafe
{
    public class SingleTon<_T> : IDisposable where _T : class, IDisposable, new()
    {
        private static _T m_instance = null;
        private static readonly object m_lock = new object();


        ~SingleTon()
        {
            Dispose(false);
        }

        public static _T Instance
        {
            get
            {
                lock (m_lock)
                {
                    if (m_instance == null)
                    {
                        m_instance = new _T();
                    }
                    return m_instance;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool bisDisposing)
        {
            if (bisDisposing)
            {
                if (m_instance != null)
                {
                    m_instance.Dispose();
                    m_instance = null;
                }
            }
        }
    }
}