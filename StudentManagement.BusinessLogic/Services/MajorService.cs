using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;
using System.Collections.Generic;
using System;

public class MajorService : IMajorService
{
    private readonly IMajorRepository _majorRepository;

    public MajorService(IMajorRepository majorRepository)
    {
        _majorRepository = majorRepository;
    }

    public IEnumerable<Major> GetAllMajors()
    {
        return _majorRepository.GetAll();
    }

    public Major GetByMajorCode(string majorCode)
    {
        return _majorRepository.GetByMajorCode(majorCode);
    }

    public bool MajorExists(string majorCode)
    {
        return _majorRepository.GetByMajorCode(majorCode) != null;
    }

    public void AddMajor(Major major)
    {
        _majorRepository.Add(major);
    }

    public void UpdateMajor(Guid majorId, Major major)
    {
        _majorRepository.Update(majorId, major);
    }

    public void DeleteMajor(Guid majorId)
    {
        _majorRepository.Delete(majorId);
    }
}