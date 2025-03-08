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
    public abstract class SingleTon<_T> : IDisposable where _T : class, new()
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

        protected abstract void Dispose(bool bisDisposing);
    }

    public abstract class SingleTonForGameObject<_T> : MonoBehaviour, IDisposable where _T : class
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
                        throw new Exception("Must call SetInstance method, before use Instance");
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
                    //DontDestroyOnLoad((m_instance as MonoBehaviour).gameObject);
                }
            }
        }

        public bool BIsInstanceNull
        {
            get
            {
                return m_instance == null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected abstract void Dispose(bool bisDisposing);
    }
}