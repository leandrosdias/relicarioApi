using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses
{
    public class ResponseBase
    {
        public DateTime DateTs => DateTime.Now;
        public bool Sucess { get; set; }
        public IEnumerable<string> ErrorList { get; set; }

        public ResponseBase()
        {
            Sucess = true;
        }

        public ResponseBase(bool sucess, IEnumerable<string> errorList)
        {
            Sucess = sucess;
            ErrorList = errorList;
        }

        public ResponseBase(bool sucess, string error)
        {
            Sucess = sucess;
            ErrorList = new List<string> { error };
        }
    }
}
