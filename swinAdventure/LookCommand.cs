using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() :base(new string[] {"look"})
        {

        }
        public override string Execute(Player p, string[] text)
        {
          
            if(text.Length!=3 && text.Length!=5)
            {
                return"I don't know how to look like that";
            }
             if(text[0]!="Look"&& text[0]!="look")
             {
                return "Error in look input";
             }
             if(text[1]!="at")
             {
                return "What do you want to look at";
             }
             if(text.Length==5)
             {
                if (text[3] != "in")
                    return "What do you want to look in?"; 
               
             }
             if(text.Length==3)
             {
                if (LookAtIn(text[2], p as IHaveInventory) == null)
                {
                    return LookAtIn(text[2], p.Location);
                }
                
                return LookAtIn(text[2], p as IHaveInventory);
             }
             if(text.Length==5)
             {
                IHaveInventory container;
                container=FetchContainer(p, text[4]);
               
              
                if (container is null)
                {
                    return "I cannot find the " + text[4];
                }
                return LookAtIn(text[2], container); 
            }

            return "pass";


        }
        private IHaveInventory FetchContainer(Player p, string containerid)
        {
            return p.Locate(containerid) as IHaveInventory;
        }

        private string LookAtIn(string thingid, IHaveInventory container)
        {
            
                 
                if (container.Locate(thingid) != null)
                {
                    return container.Locate(thingid).FullDescription;
                }
              
                return "I cannot find the " + thingid;
                

                 

   
        }

     }
}

