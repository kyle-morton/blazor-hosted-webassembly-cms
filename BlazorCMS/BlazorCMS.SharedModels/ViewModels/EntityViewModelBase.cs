using System;

namespace BlazorCMS.SharedModels.ViewModels
{
    public class EntityViewModelBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
