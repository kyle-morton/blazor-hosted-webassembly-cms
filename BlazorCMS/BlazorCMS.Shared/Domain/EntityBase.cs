using System;

namespace BlazorCMS.Shared.Domain
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
