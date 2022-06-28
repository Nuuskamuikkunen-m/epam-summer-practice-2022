﻿using System;
using System.Collections.Generic;
using EPAM.FileSharing.Common.Entities;

namespace EPAM.FileSharing.DAL.Interfaces
{
    public interface IFileShareDAO
    {
        bool AddFile(ShFile fileshare);

        void RemoveFile(int id);

        void EditFile(int id, string newName);

        ShFile GetShFile(int id);
        IEnumerable<ShFile> GetShFiles(bool orderedById);

    }
}