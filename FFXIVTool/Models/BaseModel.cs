using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text;

namespace FFXIVTool.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67
    }

    public class Address<T> : INotifyPropertyChanged
    {
        //public string offset { get; set; }
        public T value { get; set; }
        [JsonIgnore] public bool freeze { get; set; }
        [JsonIgnore] public bool Activated { get; set; }
        [JsonIgnore] public bool Cantbeused { get; set; }
        [JsonIgnore] public bool Checker { get; set; }
        [JsonIgnore] public bool Checked { get; set; }
        [JsonIgnore] public bool SpecialActivate { get; set; }
        [JsonIgnore] public int Selected { get; set; }
        [JsonIgnore] public bool freezetest { get; set; }
        /// <summary>
        /// Get a byte array of this address
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            var type = typeof(T);
            if (type == typeof(byte) || type.IsEnum)
                return new byte[] { Convert.ToByte(value) };
            else if (type == typeof(string))
                return Encoding.UTF8.GetBytes((dynamic)value);
            return BitConverter.GetBytes((dynamic)value);
        }

#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67
    }
}