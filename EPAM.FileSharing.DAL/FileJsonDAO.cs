using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.FileSharing.Common.Entities;
using System.IO;
using Newtonsoft.Json;
using EPAM.FileSharing.DAL.Interfaces;

namespace EPAM.FileSharing.DAL.DAL
{
    public class FileJsonDAO : IFileShareDAO
    {
        public const string _JSON_FILES_PATH = @"C:\Users\Nuuskamuikkunen\source\repos\FileSharing\Files";
        public void AddFile(ShFile fileshare)
        {
            string json = JsonConvert.SerializeObject(fileshare);

            File.WriteAllText(GetFilePathById(fileshare.ID), json);
        }

        public void RemoveFile(int id)
        {
            if (File.Exists(GetFilePathById(id)))
            {
                File.Delete(GetFilePathById(id));
            }
            else throw new FileNotFoundException(
                string.Format("File with name {0} at path {1} isn't created!", id, _JSON_FILES_PATH));
            
        }

        public void EditFile(int id, string newName)
        {
            if (!File.Exists(GetFilePathById(id)))
                throw new FileNotFoundException(
                string.Format("File with name {0} at path {1} isn't created!",
                id, _JSON_FILES_PATH));

            ShFile fileshare = JsonConvert.DeserializeObject<ShFile>(File.ReadAllText(GetFilePathById(id)));

            fileshare.EditName(newName);

            File.WriteAllText(GetFilePathById(fileshare.ID), JsonConvert.SerializeObject(fileshare));
        
        }

        public string GetFilePathById(int id) => _JSON_FILES_PATH + id + ".json";

    }
}
