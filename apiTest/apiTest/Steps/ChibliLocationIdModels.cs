using System;
using System.Collections.Generic;
using System.Text;

namespace apiTest.Steps
{
    public class ChibliLocationIdModels
    {
        public string id { get; set; }
        public string name { get; set; }
        public string climate { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public List<string> residents { get; set; }
        public List<string> films { get; set; }
        public string url { get; set; }
    }
}
