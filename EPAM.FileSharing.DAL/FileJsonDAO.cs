using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.FileSharing.Common.Entities;
using System.IO;
using Newtonsoft.Json;
using EPAM.FileSharing.DAL.Interfaces;
using EPAM.FileSharing.Entities;

namespace EPAM.FileSharing.DAL.DAL
{
    public class FileJsonDAO : IFileShareDAO
    {
        public const string _JSON_FILES_PATH = @"C:\Users\Nuuskamuikkunen\source\repos\FileSharing\Files";
        public bool AddFile(ShFile fileshare)
        {
            string json = JsonConvert.SerializeObject(fileshare);

            File.WriteAllText(GetFilePathById(fileshare.ID), json);

            return File.Exists(GetFilePathById(fileshare.ID));
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

        public ShFile GetShFile(int id)
        {
            ///
            throw new InvalidOperationException("Cannot find file with ID = " + id);
        }

        public IEnumerable<ShFile> GetShFiles(bool orderedById)
        {
            ///
            throw new InvalidOperationException("Cannot find file" );
        }

        IEnumerable<ShFile> GetAllUserShFilesById(int ID_User)
        {
            ///
            throw new InvalidOperationException("Cannot find file");
        }

        IEnumerable<ShFile> IFileShareDAO.GetAllUserShFilesById(int ID_User)
        {
            throw new NotImplementedException();
        }

        public User GetProfileById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
