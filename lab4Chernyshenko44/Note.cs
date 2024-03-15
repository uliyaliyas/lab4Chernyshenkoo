using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4Chernyshenko44
{
    public class Note<T> : ICloneable, IComparable
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public object Phone { get; set; }
        public int[] Birth { get; set; }
        public static int Count { get; internal set; }

        public Note(string fName, string lName, object phone, int[] birth)
        {
            FName = fName;
            LName = lName;
            Phone = phone;
            Birth = birth;
        }

        public override string ToString()
        {
            return $"{FName} {LName}, номер телефона: {Phone}, дата рождения: {string.Join(".", Birth)}";
        }

        public object Clone()
        {
            return new Note<T>(FName, LName, Phone, Birth);
        }
        int IComparable.CompareTo(object? obj)
        {
            if (obj is Note<T> other)
            {
                for (int i = 0; i < Birth.Length; i++)
                {
                    if (Birth[i] != other.Birth[i])
                    {
                        return Birth[i].CompareTo(other.Birth[i]);
                    }
                }
                return 0;
            }
            throw new ArgumentException("bye");
        }
    }
}
