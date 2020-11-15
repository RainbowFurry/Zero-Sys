using System;

namespace ZeroSys.Manager
{
    /// <summary>
    /// ExeptionManager
    /// </summary>
    public class ExeptionManager
    {
        /// <summary>
        /// Create new Custom Exeption
        /// </summary>
        /// <param name="exeption"></param>
        public static void CreateCustomExeption(string exeption)
        {
            throw new Exception(exeption);
        }

    }
}
