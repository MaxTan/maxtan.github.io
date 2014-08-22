using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Build {

    static class Program {

        static void Main(string[] args) {
            try {
                var count = 0;
                var jsonmodel = JsonConvert.DeserializeObject<JsonModel>(File.ReadAllText("meta.js"));
                Directory.GetFiles("Temp").ToList().ForEach(x => {
                    var date = DateTime.Now.ToString("yyyy-MM-dd");
                    var title = Path.GetFileNameWithoutExtension(x);
                    var file = string.Format("{0}-{1}", date, title);
                    jsonmodel.articles.Add(new article {
                        date = date,
                        title = title,
                        file = file,
                        cate = "tech"
                    });
                    File.Move(x, string.Format(@"post\{0}{1}", file, ".txt"));
                    Console.WriteLine("正在处理{0}{1}文件", title, ".txt");
                    count++;
                });
                File.WriteAllText(@"meta.js", JsonConvert.SerializeObject(jsonmodel));
                Console.WriteLine("Build完毕，共处理{0}个文件", count);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
            Console.ReadKey();

        }
    }
}
