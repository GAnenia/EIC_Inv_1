using System;

namespace CUSTOR.EICOnline.DAL.EntityLayer
{
  public interface IAuditableEntity
  {
        string CreatedUserId { get; set; }
        string UpdatedUserId { get; set; }
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}