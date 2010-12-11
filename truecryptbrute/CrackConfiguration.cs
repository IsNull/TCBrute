using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace truecryptbrute
{
    [Serializable]
    public class CrackConfiguration
    {
        public string WordListPath = "";
        public int WordListOffset = 0;
        public string ContainerPath = "";
        public bool MountAsSystemVolume = false;
        public bool AttackHiddenVolume = false;
        public bool UseKeyFiles = false;
        public List<string> KeyFiles = new List<string>();
        public int ThreadCount = 1;
    }
}
