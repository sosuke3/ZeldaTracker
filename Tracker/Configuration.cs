using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Tracker
{
    public class Configuration : ICloneable
    {
        public List<string> DisplayOrder { get; set; } = new List<string>();
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public int WindowX { get; set; }
        public int WindowY { get; set; }
        public bool ShowMapWindowsOnStartup { get; set; }

        public object Clone()
        {
            // be lazy and use AutoMapper to clone
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Configuration, Configuration>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Configuration, Configuration>(this);
        }
    }
}
