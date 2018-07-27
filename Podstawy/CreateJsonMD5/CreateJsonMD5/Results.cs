using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateJsonMD5
{
    class Results
    {
        int _ID;
        string _FileName;
        string _FileMD5;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }


        public string FileName
        {
            get
            {
                return _FileName;
            }

            set
            {
                _FileName = value;
            }
        }

        public string FileMD5
        {
            get
            {
                return _FileMD5;
            }

            set
            {
                _FileMD5 = value;
            }
        }
    }
}
