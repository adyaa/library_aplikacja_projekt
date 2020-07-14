//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PurchaseTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseTable()
        {
            this.PurchaseDetailTables = new HashSet<PurchaseDetailTable>();
        }
    
        public int PurchaseID { get; set; }

        [Required(ErrorMessage = "Prosz� wybra� dat� zam�wienia")]
        [DataType(DataType.Date)]
        public System.DateTime PurchaseDate { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Prosz� wpisa� kwot� zam�wienia")]
        public double PurchaseAmount { get; set; }

        [Required(ErrorMessage = "Prosz� wybra� dostawc�")]
        public int SupplierID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetailTable> PurchaseDetailTables { get; set; }
        public virtual SupplierTable SupplierTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
