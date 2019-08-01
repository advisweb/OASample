using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OASample.Data.ViewModel
{
    public class BaseViewModel
    {
        [DisplayName("Created")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Modified")]
        public DateTime ModifiedDate { get; set; }
    }
}
