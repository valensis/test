
using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SecureStudentManager.Models 

{
    public class StudentDepartmentIDs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)

]
        public int StudentId { get; set; }

    public int Department { get; set; }

    public string Details { get; set; }


}
}