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
    
    public partial class Remains
    {
        public int Id { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> MaterialId { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<System.DateTime> DateChanges { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
