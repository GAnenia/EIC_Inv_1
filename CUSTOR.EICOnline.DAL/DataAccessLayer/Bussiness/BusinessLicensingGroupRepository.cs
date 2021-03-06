﻿using CUSTOR.EICOnline.DAL.EntityLayer;
using CUSTOR.EntityFrameworkCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.EICOnline.DAL.DataAccessLayer.Bussiness
{
   public class BusinessLicensingGroupRepository : EFRepository<ApplicationDbContext, BusinessLicensingGroup>
    {
        public BusinessLicensingGroupRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<BusinessLicensingGroup> SaveBussinessBussinessLicense(BusinessLicensingGroup business)
        {
           BusinessLicensingGroup businessLicense = null;
            try
            {
               
                Context.Add(business);
                await Context.SaveChangesAsync();
                return businessLicense;

            }
            catch (InvalidOperationException ex1)
            {
                SetError("Couldn't load tblbusiness - invalid tblbusiness id specified.");
                return null;
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
            return businessLicense;
        }
    }
}
