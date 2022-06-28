using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.FileSharing.BLL.BLL;
using EPAM.FileSharing.BLLInterfaces;
using EPAM.FileSharing.DAL.DAL;
using EPAM.FileSharing.DAL.Interfaces;
using EPAM.FileSharing.DAL.SQLDAL;

namespace EPAM.FileSharing.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLTONE

        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();
                return _instance;
            }
        }

        #endregion

        public IFileShareDAO FileDAO => new FileSqlDAO();

        public IShareLogic ShareLogic => new ShareLogic(FileDAO);

    }

}


