﻿using Digital.Infrastructure.Model.DocumentModel;
using Digital.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital.Infrastructure.Model.ProcessModel;

namespace Digital.Infrastructure.Interface
{
    public interface IProcessService
    {
        Task<ResultModel> GetProcesses(ProcessSearchModel searchModel);
        Task<ResultModel> GetProcessById(Guid id);
        Task<ResultModel> GetProcessByDocumentType(Guid docTypeId);
        Task<ResultModel> GetProcessByCreatedDate(DateTime createdDate);
        Task<ResultModel> CreateProcess(ProcessCreateModel model);
        Task<int> DeleteProcess(Guid id);
        Task<ResultModel> UpdateProcess(ProcessUpdateModel model, Guid Id);
    }
}