using System;
using System.Collections.Generic;
using EPAM.FileSharing.Common.Entities;
using EPAM.FileSharing.Entities;

namespace EPAM.FileSharing.DAL.Interfaces
{
    public interface IFileShareDAO
    {
        bool AddFile(ShFile fileshare);

        void RemoveFile(int id);

        void EditFile(int id, string newName);

        ShFile GetShFile(int id);
        IEnumerable<ShFile> GetShFiles(bool orderedById);

        IEnumerable<ShFile> GetAllUserShFilesById(int ID_User);
        User GetProfileById(int id);

        void EditNameProfileById(int id, string newName);

        void EditEmailProfileById(int id, string newEmail);

        void EditLoginProfileById(int id, string newLogin);

        void EditPasswordProfileById(int id, string newPass);

        void EditDateProfileById(int id, DateTime newDate);
        IEnumerable<ShFile> FindFileBySimbols(string str);
        bool SingIn(string login, string pass);
        int SingInwithRole(string login, string pass);
        int GetIdByLogPass(string log, string pass);
       bool AddFileInUserProfile(int id);
        bool AddFileInUserProfile(ShFile fileshare, int id);
    }
}
