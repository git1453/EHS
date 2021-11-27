using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHSENTITY.HR
{
    public interface IHR
    {
        public DataSet GetDataSet();
        public DataSet TestDataSet();
    }
}
