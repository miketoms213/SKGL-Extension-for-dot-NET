﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SKGL
{
    public class Customer
    {
        public int Id { get; set; }

        //[MaxLength(100, ErrorMessage = "The name of the customer is limited to 100 characters.")]
        [StringValidator(MaxLength = 100)]
        public string Name { get; set; }

        //[MaxLength(100, ErrorMessage = "The name of the customer is limited to 100 characters.")]
        [StringValidator(MaxLength = 100)]
        public string Email { get; set; }

        //[MaxLength(100, ErrorMessage = "The name of the customer is limited to 100 characters.")]
        [StringValidator(MaxLength = 100)]
        public string CompanyName { get; set; }

        public DateTime Created { get; set; }
    }
}