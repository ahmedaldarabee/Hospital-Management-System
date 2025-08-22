using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Program {
        static void Main(string[] args){
            CRUDOperations crudOperation = new CRUDOperations();
            crudOperation.getStudentAvg();
        }
    }
}
