using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


namespace CommonUtilLib.ThreadSafe
{
    /// <summary>
    /// General thread safe singleton class
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    public class SingleTon<_T> : IDisposable where _T : class, IDisposable, new()
    {
        private static _T m_instance = null;
        private static readonly object m_lock = new object();


        ~SingleTon()
        {
            Dispose(false);
        }

        /// <summary>
        /// Get the instance of the singleton class
        /// </summary>
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

        /// <summary>
        /// Dispose the instance of the singleton class
        /// </summary>
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

    public class SingleTonForGameObject<_T> : MonoBehaviour where _T : class
    {
        private static _T m_instance = null;
        private static readonly object m_lock = new object();


        public static _T Instance
        {
            get
            {
                lock (m_lock)
                {
                    if (m_instance == null)
                    {
                        throw new Exception("The instance is null");
                    }
                    return m_instance;
                }
            }
        }

        public static void SetInstance(in _T instance)
        {
            lock (m_lock)
            {
                if (m_instance == null)
                {
                    m_instance = instance;
                }
            }
        }
    }
}