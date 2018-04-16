using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace AutomatedUIFramework.Configuration
{
    public class ConfigurationElementCollection<T> : ConfigurationElementCollection
        where T : ConfigurationElement
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { }) as ConfigurationElement;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            PropertyInfo keyProperty = null;
            foreach (PropertyInfo property in properties)
            {
                if (property.IsDefined(typeof(ConfigurationPropertyAttribute), true))
                {
                    ConfigurationPropertyAttribute attribute = property.GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true)[0] as ConfigurationPropertyAttribute;
                    if (attribute.IsKey)
                    {
                        keyProperty = property;
                        break;
                    }
                }
            }
            object key = null;
            if (keyProperty != null)
            {
                key = keyProperty.GetValue(element, null);
            }
            return key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public T this[int index]
        {
            get { return (T)BaseGet(index); }
            set 
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public T this[object key]
        {
            get { return (T)BaseGet(key); }
        }

        public int IndexOf(T element)
        {
            return BaseIndexOf(element);
        }

        public void Add(T element)
        {
            BaseAdd(element);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, true);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
