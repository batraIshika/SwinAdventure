using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
   public abstract  class GameObject :IdentifiableObject
    {
        private string _description;
        private string _name;

    public GameObject(string[] ids, string name, string desc) :base(ids)
        {
            _name = name;
            _description = desc;
        }
    public string Name{
            get
            {
                return _name;
            }
    }
    public string Shortdescription
        {
            get
            {
                return $"{_name}({base.FirstId})";
            }
        }
    public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}
