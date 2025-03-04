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
    
    public partial class Application
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> AgentId { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> ProductionTime { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Product Product { get; set; }
        public virtual Status Status { get; set; }
    }
}
