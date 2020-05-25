using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.ViewModel
{
    public class Cell : PropertyChangedClass
    {
        static List<Tuple<string, string>> Dict;
        public Cell()
        {
            Dict = new List<Tuple<string, string>>();
            InitStyles();
        }
        

        int _value;
        public int Value { get { return _value; }
            set
            {
                _value = value;
                if (value == 0)
                {
                    Background = "#cdc1b4";
                    Foreground = "#cdc1b4";
                }
                else if (value >= 8192)
                {
                    Background = "#ff1d1e";
                    Foreground = "White";
                }
                else
                {
                    Background = Dict[(int)Math.Log(_value, 2)].Item1;
                    Foreground = Dict[(int)Math.Log(_value, 2)].Item2;
                }
                OnPropertyChanged();
            } }

        string back;
        public string Background { get { return Value == 0 ? "#cdc1b4" : (Value >= 8192) ? "#ff1d1e": Dict[(int)Math.Log(Value, 2)].Item1; } private set { back = value; OnPropertyChanged(); } }

        string fore;
        public string Foreground { get { return Value == 0 ? "#cdc1b4" : (Value >= 8192) ? "White" : Dict[(int)Math.Log(Value, 2)].Item2; } private set { fore = value; OnPropertyChanged(); } }


        void InitStyles()
        {
            string path = Environment.CurrentDirectory + "\\styles.txt";
            using (StreamReader st = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = st.ReadLine()) != null)
                {
                    var items = line.Split(';');
                    Dict.Add(new Tuple<string, string>(items[1], items[2]));
                }
            }
        }
    }
}
