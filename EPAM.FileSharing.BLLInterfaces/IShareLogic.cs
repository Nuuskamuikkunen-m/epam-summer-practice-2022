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

        void AddFile(ShFile fileshare);

        void RemoveFile(int id);

        void RemoveFile(ShFile fileshare);

        void EditFile(int id, string newName);

        ShFile GetShFile(int id);
        IEnumerable<ShFile> GetShFiles(bool orderedById = true);
        IEnumerable<object> GetAllUserShFilesById(int id);
        User GetProfileById(int v);
    }
}
