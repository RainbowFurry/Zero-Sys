using System;

namespace ZeroSys.Manager.RunExeCode
{
    /// <summary>
    /// AssemblyObject
    /// </summary>
    public class AssemblyObject
    {

        /// <summary>
        /// Assembly Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Assembly Description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Assembly Company
        /// </summary>
        public string Company { get; }
        /// <summary>
        /// Assembly CopyRight
        /// </summary>
        public string Copyright { get; }
        /// <summary>
        /// Assembly Trademark
        /// </summary>
        public string Trademark { get; }
        /// <summary>
        /// Assembly Type
        /// </summary>
        public Type Type { get; }
        /// <summary>
        /// Assembly Loaded State
        /// </summary>
        public bool Loaded { get; set; }

        /// <summary>
        /// Initialize new Assembly Object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="company"></param>
        /// <param name="copyright"></param>
        /// <param name="trademark"></param>
        /// <param name="type"></param>
        /// <param name="loaded"></param>
        public AssemblyObject(string name, string description, string company, string copyright, string trademark, Type type, bool loaded)
        {
            Name = name;
            Description = description;
            Company = company;
            Copyright = copyright;
            Trademark = trademark;
            Type = type;
            Loaded = loaded;
        }

    }
}
