using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmDiEfSample.Services
{
    public class RandomStringService : IRandomStringService
    {
        private List<string> list = new()
        {
            "Hello world!",
            "Im a really noob",
            "Are you winning, son?",
            "WTF???",
            "Ah shit! Here we go again."
        };

        public string GetRandomString()
        {
            var random = new Random();
            return list[random.Next(list.Count)];
        }
    }
}
