//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductionLopushock.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Priority
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<int> AgentId { get; set; }
    
        public virtual Agent Agent { get; set; }
    }
}
