using EPAM.FileSharing.Common.Entities;
using EPAM.FileSharing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileSharing.BLLInterfaces
{
    public interface IShareLogic
    {
        IEnumerable<ShFile> FindFileBySimbols(string str);
        bool AddFile(ShFile fileshare);

        void RemoveFile(int id);

        void RemoveFile(ShFile fileshare);

        void EditFile(int id, string newName);

        ShFile GetShFile(int id);
        IEnumerable<ShFile> GetShFiles(bool orderedById = true);
        IEnumerable<object> GetAllUserShFilesById(int id);
        User GetProfileById(int v);

        void EditNameProfileById(int id, string newName);
        void EditEmailProfileById(int id, string newEmail);
        void EditLoginProfileById(int id, string newLogin);
        void EditPasswordProfileById(int id, string newPass);
        void EditDateProfileById(int id, DateTime newDate);

        bool SingIn(string login, string pass);
        int SingInwithRole(string login, string pass);
        int GetIdByLogPass(string log, string pass);
         bool AddFileInUserProfile(int id);
         bool AddFileInUserProfile(ShFile fileshare, int id);


    }
}
