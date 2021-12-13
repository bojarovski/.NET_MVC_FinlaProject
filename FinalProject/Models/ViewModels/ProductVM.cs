using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class ProductVM
    {
        public Products Products { get; set; }
        public IEnumerable<SelectListItem> DropDown{ get; set; }
    }
}
