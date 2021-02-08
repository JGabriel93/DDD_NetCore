using System;

namespace Api.Domain.Mappings
{
    public class MapConverter
    {
        public Type Type { get; set; }

        public MapConverter(Type type)
        {
            Type = type;
        }

        public bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public string KeyToDescription(object value)
        {
            foreach (var item in Type.GetFields())
            {
                var map = item.GetValue(null);
                if (((MapperCharacter)map).Key == value.ToString())
                {
                    return (((MapperCharacter)map).Description);
                }
            }
            return "";
        }        

        public string DescriptionToKey(object value)
        {
            foreach (var item in Type.GetFields())
            {
                var map = item.GetValue(null);
                if (((MapperCharacter)map).Description == value.ToString())
                {
                    return (((MapperCharacter)map).Key);
                }
            }
            return "";
        }    
    }
}
