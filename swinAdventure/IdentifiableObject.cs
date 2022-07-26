using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public class IdentifiableObject 
    {
        private List<string> _identifiers = new List<string>();
     

        public IdentifiableObject(string[] idents)
        {

            foreach (string s in idents)
            {

                _identifiers.Add(s.ToLower());
            }
        }
        public bool AreYou(string id)
        {
            foreach (string s in _identifiers)
            {
                if (id.ToLower() == s)
                    return true;
                }

            return false;
        }
        public string  FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                }
            }
        }
        public void AddIdentifier(string id)
        {
            string a = id;
            a = a.ToLower();
            _identifiers.Add(a);
        }

    }
}