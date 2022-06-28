using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileSharing.Common.Entities
{
    public class ShFile
    {
        public ShFile(int id, string name, string ext)
        {
            ID = id;
            Name = name;
            Extension = ext;
            CreationDate = DateTime.Now;

        }
        public ShFile(int id, string name)
        {
            ID = id;
            Name = name;
            Extension = "";
            CreationDate = DateTime.Now;

        }

        public ShFile(int id, string name, string ext,  DateTime date)
        {
            ID = id;
            Name = name;
            Extension = ext;
            CreationDate = date;

        }
        public ShFile(int id, string name,  DateTime date)
        {
            ID = id;
            Name = name;
            Extension = "";
            CreationDate = date;

        }

        public ShFile(string name)
        {
            ID = -1;
            Name = name;
            Extension = "";
            CreationDate = DateTime.Now;

        }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public string Extension { get;  }

        public DateTime CreationDate { get; private set; }

        public void EditName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name", "Name cannot be null!");
            Name = name;
        }

        public override string ToString() =>
             JsonConvert.SerializeObject(this);
        
    }
}
