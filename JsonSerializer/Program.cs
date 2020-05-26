//  Created by Javier Alejandro Domínguez Falcón on 21/05/2020.
//  Copyright © 2020 Javier Alejandro Domínguez Falcón. All rights reserved.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomJsonSerializer
{
    class Program
    {
        public string name;

        static void Main(string[] args)
        {
            // Serialize our settings object from a JSON string
            Settings settings = new Settings();

            Console.WriteLine("Settings Values before Serialize \n");
            Console.WriteLine("   The property value Enabled        is :   {0}", settings.enabled);
            Console.WriteLine("   The property value MyProperty     is :   {0}", settings.MyProperty);
            Console.WriteLine("   The property value NameProperty   is :   {0}", settings.NameProperty);
            Console.WriteLine("   The property value points         is :   {0}", settings.points);
            Console.WriteLine("   The property value Summary        is :   {0}", settings.Summary);
            Console.WriteLine("\n");

            var result = GenericValidator.TryValidate(settings);

            Console.WriteLine("Are the data valid? : {0} \n", result);

            //If the data are valid then it is serialized
            if (result)
            {
                string jsonString;
                jsonString = settings.Serialize();

                Console.WriteLine("Result Serialized : {0} \n", jsonString);

                settings.Deserialize(jsonString);
            }

        }
    }

    public class JSONSerializable
    {
        [JSONField("points", 100)]
        public int points { get; set; }

        [JSONField("Summary", "Another Value")]
        public string Summary { get; set; }

        public JSONSerializable()
        {
            
        }

        public virtual void Deserialize(string jsonString)
        {
            var tempValue = JsonSerializer.Deserialize<JSONSerializable>(jsonString);
        }

        public virtual string Serialize()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(this);

            var result = GenericValidator.TryValidate(this);

            return jsonString;
        }
    }

    public class Settings : JSONSerializable
    {
        [JSONField("enabled", false, "Enabled")]
        public bool enabled { get; set; }

        [JSONField("MyProperty", 500)]
        public int MyProperty { get; set; }

        [JSONField("NameProperty", "testProperty")]
        public string NameProperty { get; set; }

        public override string Serialize()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(this);

            return jsonString;
        }

        public override void Deserialize(string jsonString)
        {
            var tempValue = JsonSerializer.Deserialize<Settings>(jsonString);

            this.enabled        =   tempValue.enabled;
            this.MyProperty     =   tempValue.MyProperty;
            this.NameProperty   =   tempValue.NameProperty;
            this.points         =   tempValue.points;
            this.Summary        =   tempValue.Summary;

            Console.WriteLine("Settings Values Deserialized \n");
            Console.WriteLine("   The property value Enabled        is :   {0}", enabled);
            Console.WriteLine("   The property value MyProperty     is :   {0}", MyProperty);
            Console.WriteLine("   The property value NameProperty   is :   {0}", NameProperty);
            Console.WriteLine("   The property value points         is :   {0}", points);
            Console.WriteLine("   The property value Summary        is :   {0}", Summary);
        }
    }

    public class GenericValidator
    {
        public static bool TryValidate(object obj)
        {
            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                {
                    var customAttribute = attribute as CustomAttribute;
                    if (customAttribute != null)
                    {
                        var result = propertyInfo.GetValue(obj);
                        //Validate by Types
                        if (customAttribute.IsValidAttribute(propertyInfo.PropertyType))
                        {
                            //Set Default Value
                            if (result == null)
                            {
                                //If the value is null then it'll be assigned set default value of the property
                                var attributeDefaultValue = ((JSONFieldAttribute)customAttribute).DefaultValue;
                                propertyInfo.SetValue(obj, attributeDefaultValue);
                            }

                            if (result is int && (int)result == 0)
                            {
                                //If the value is null then it'll be assigned set default value of the property
                                var attributeDefaultValue = ((JSONFieldAttribute)customAttribute).DefaultValue;
                                propertyInfo.SetValue(obj, attributeDefaultValue);
                            }
                        }
                        else
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
