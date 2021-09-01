﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfWorkExperienceDal: EfEntityRepositoryBase<WorkExperience, RecapAPIContext>, IWorkExperience
    {
    }
}
