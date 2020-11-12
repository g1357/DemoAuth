using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models2
{
    public struct DishType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plurals { get; set; }
        public string Descriprion { get; set; }
        public string IconName { get; set; }
    }
}
