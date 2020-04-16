﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
   public class StudyPath
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}