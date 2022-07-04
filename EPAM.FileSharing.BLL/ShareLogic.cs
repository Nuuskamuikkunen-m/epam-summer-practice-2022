using EPAM.FileSharing.Common.Entities;
using System;
using EPAM.FileSharing.DAL.DAL;
using EPAM.FileSharing.DAL.Interfaces;
using EPAM.FileSharing.DAL.SQLDAL;
using EPAM.FileSharing.BLLInterfaces;
using System.Collections.Generic;
using EPAM.FileSharing.Entities;

namespace EPAM.FileSharing.BLL.BLL
{
    public class ShareLogic : IShareLogic
    {
        private IFileShareDAO _fileDAO;

        public ShareLogic(IFileShareDAO shareDAO)
        {
            _fileDAO = shareDAO;
        }
        public void AddFile(ShFile fileshare) => 
            _fileDAO.AddFile(fileshare);


        public void RemoveFile(int id) =>
            _fileDAO.RemoveFile(id);

        public void RemoveFile(ShFile fileshare) => RemoveFile(fileshare.ID);

        public void EditFile(int id, string newName) =>
            _fileDAO.EditFile(id, newName);

        public ShFile GetShFile(int id) => _fileDAO.GetShFile(id);

        public IEnumerable<ShFile> GetShFiles(bool orderedById) => _fileDAO.GetShFiles(orderedById);

        public IEnumerable<object> GetAllUserShFilesById(int id) => _fileDAO.GetAllUserShFilesById(id);

        public User GetProfileById(int id) => _fileDAO.GetProfileById(id);
    }
}
