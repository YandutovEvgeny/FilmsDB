using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDB
{
    class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BDay { get; set; }
        public List<MyFilm> Films { get; set; }
    }
}
