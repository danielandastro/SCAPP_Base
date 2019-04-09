using System;

namespace Base_Data_Classes
{
    public struct ConfigFileItem
    {
        public int itemNumber;
        public string title;
        public string description;
        public string value;
        public bool flag;
        public bool enforced;
        public bool required;
    }
}
