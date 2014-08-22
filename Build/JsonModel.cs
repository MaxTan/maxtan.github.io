using System.Collections.Generic;

namespace Build {

    public class JsonModel {

        public string site_name { get; set; }
        public string copyright { get; set; }
        public List<cate> cates { get; set; }
        public List<article> articles { get; set; }
    }

    public class cate {

        public string name { get; set; }
        public string text { get; set; }
    }

    public class article {

        public string title { get; set; }
        public string date { get; set; }
        public string file { get; set; }
        public string cate { get; set; }
    }
}
