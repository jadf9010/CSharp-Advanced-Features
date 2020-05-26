//  Created by Javier Alejandro Domínguez Falcón on 21/05/2020.
//  Copyright © 2020 Javier Alejandro Domínguez Falcón. All rights reserved.

using System;

namespace CustomJsonSerializer
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class JSONFieldAttribute : CustomAttribute
    {
        public JSONFieldAttribute(string key, object defaultObject, string name = null)
        {
            this.Key = key;
            this.DefaultValue = defaultObject;
            this.Name = name;
        }

        public string Key { get; private set; }
        public object DefaultValue { get; private set; }
        public string Name { get; private set; }

        public void HashableFieldAttribute(string key, string name = null)
        {
            Key = key;
            DefaultValue = null;
            Name = string.IsNullOrEmpty(name) ? key : name.ToLowerInvariant();
        }

        public void HashableFieldAttribute(string key, object defaultValue, string name = null)  
        {
            Key = key;
            DefaultValue = defaultValue;
            Name = string.IsNullOrEmpty(name) ? key : name.ToLowerInvariant();
        }

        /// <summary>
        /// Compare with the attribute by type
        /// </summary>
        /// <param name="value"></param>
        /// <returns> The result is true if the value of the property o field is the same type of the attribute </returns>
        public override bool IsValidAttribute(Type valueType)
        {
            var attributeType = DefaultValue.GetType();

            if (attributeType == valueType)
            {
                return true;
            }
            else
                return false;
        }
    }

    public abstract class CustomAttribute : Attribute 
    {
        public abstract bool IsValidAttribute(Type value);
    }
}
