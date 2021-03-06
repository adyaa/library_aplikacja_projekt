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

    public partial class BookFineTable
    {
        public int BookFineID { get; set; }
        [Required(ErrorMessage = "Prosz� wybra� pracownika")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Prosz� wybra� ksi��k�")]
        public int BookID { get; set; }
        public int UserID { get; set; }


        [Required(ErrorMessage = "Prosz� wybra� dat�")]
        [DataType(DataType.Date)]
        public System.DateTime FineDate { get; set; }

        [Required(ErrorMessage = "Prosz� wpisa� kwot�")]
        public double FineAmount { get; set; }

        [Required(ErrorMessage = "Prosz� wpisa� otrzyman� kwot�")]
        public Nullable<double> ReceiveAmount { get; set; }

        [Required(ErrorMessage = "Prosz� wpisa� liczb� dni")]
        public int NoOfDays { get; set; }
    
        public virtual BookTable BookTable { get; set; }
        public virtual EmployeeTable EmployeeTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
