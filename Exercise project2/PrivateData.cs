using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_project2
{
    public class DataInOut
    {
        DataStorage _data = new DataStorage();

        public string Record(string a)
        {
            return _data.StorageTransfer = a;

        }

        public string GetData(string a)
        {

            return a = _data.StorageTransfer;
        }
    }
    internal class DataStorage
    {
        private string _storageTransfer;

        public string StorageTransfer
        {
            get { return _storageTransfer; }
            set { _storageTransfer = value; }
        }

    }
}
