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

    public partial class IssueBookTable
    {
        public int IssueBookID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Prosz� wybra� ksi��k�")]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Prosz� wybra� pracownika")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Prosz� wpisa� liczb� kopii ksi��ki")]
        public int IssueCopies { get; set; }

        [Required(ErrorMessage = "Prosz� wybra� dat� wypo�yczenia")]
        [DataType(DataType.Date)]
        public System.DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Prosz� wybra� dat� zwrotu")]
        [DataType(DataType.Date)]
        public System.DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public bool ReserveNoOfCopies { get; set; }
    
        public virtual BookTable BookTable { get; set; }
        public virtual EmployeeTable EmployeeTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}