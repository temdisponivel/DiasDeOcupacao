using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Work around to handle dictionary-like data struct in Unity inspector.
    /// </summary>
    /// <typeparam name="Type">Type of the entity to use as key for dictionary.</typeparam>
    /// <typeparam name="Entity">Type of the entity identified by the key.</typeparam>
    [Serializable]
    public class TypeEntityDictionary<Type, Entity>
    {
        public Type _type;
        public Entity _entity;
    }
}