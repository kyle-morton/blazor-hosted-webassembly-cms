using System;

namespace BlazorCMS.SharedModels.ViewModels
{
    public class EntityViewModelBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateHumanized => CreateDate.ToString("MM/dd/yyyy hh:mm");
        public DateTime ModifyDate { get; set; }
        public string ModifyDateHumanized => ModifyDate.ToString("MM/dd/yyyy hh:mm");
    }
}
